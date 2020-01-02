﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AutoStep.Compiler.Parser;
using AutoStep.Core;
using AutoStep.Core.Elements;

namespace AutoStep.Compiler
{
    /// <summary>
    /// The CompilerTreeWalker is an implementation of an Antlr Visitor that traverses the Antlr parse tree after the parse process has completed,
    /// and builts a <see cref="BuiltFile"/> from that tree.
    /// </summary>
    internal class CompilerTreeWalker : AutoStepParserBaseVisitor<BuiltFile?>
    {
        private readonly string? sourceName;
        private readonly ITokenStream tokenStream;
        private readonly List<CompilerMessage> messages = new List<CompilerMessage>();
        private readonly TokenStreamRewriter currentRewriter;

        private readonly (int TokenType, string Replace)[] tableCellReplacements = new[]
        {
            (AutoStepParser.ESCAPED_TABLE_DELIMITER, "|"),
            (AutoStepParser.ARG_EXAMPLE_START_ESCAPE, "<"),
            (AutoStepParser.ARG_EXAMPLE_END_ESCAPE, ">"),
        };

        private readonly (int TokenType, string Replace)[] argReplacements = new[]
        {
            (AutoStepParser.ARG_ESCAPE_QUOTE, "'"),
            (AutoStepParser.ARG_EXAMPLE_START_ESCAPE, "<"),
            (AutoStepParser.ARG_EXAMPLE_END_ESCAPE, ">"),
        };

        private BuiltFile? file;
        private IAnnotatableElement? currentAnnotatable;
        private ScenarioElement? currentScenario;
        private List<StepReferenceElement>? currentStepSet = null;
        private StepDefinitionElement? currentStepDefinition;

        private StepReferenceElement? currentStep = null;
        private StepReferenceElement? currentStepSetLastConcrete = null;

        private TableElement? currentTable;
        private TableRowElement? currentRow;

        private bool canArgumentValueBeDetermined = true;
        private List<ArgumentSectionElement> currentArgumentSections = new List<ArgumentSectionElement>();

        private IToken? textSectionTokenStart;
        private IToken? textSectionTokenEnd;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerTreeWalker"/> class.
        /// </summary>
        /// <param name="sourceName">The source name; added to compiler messages.</param>
        /// <param name="tokens">The token stream used by the parse tree.</param>
        public CompilerTreeWalker(string? sourceName, ITokenStream tokens)
        {
            this.sourceName = sourceName;
            tokenStream = tokens;
            currentRewriter = new TokenStreamRewriter(tokens);
        }

        /// <summary>
        /// Gets the list of compiler messages generated during the compilation process.
        /// </summary>
        public IReadOnlyList<CompilerMessage> Messages => messages;

        /// <summary>
        /// Gets the result of the compilation, a completed AutoStep file.
        /// </summary>
        public BuiltFile? Result => file;

        /// <summary>
        /// Gets a value indicating whether the compile process succeeded (and <see cref="Result"/> is therefore a valid runnable autostep file).
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// Visits the top level file node. Creates the file object.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile? VisitFile(AutoStepParser.FileContext context)
        {
            Success = true;
            file = new BuiltFile();

            VisitChildren(context);

            return file;
        }

        /// <summary>
        /// Visits the Feature block (Feature:) and generates a <see cref="FeatureElement"/> that is added to the file.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile? VisitFeatureBlock([NotNull] AutoStepParser.FeatureBlockContext context)
        {
            Debug.Assert(file is object);

            if (file.Feature != null)
            {
                // We already have a feature, don't go any deeper, add an error.
                AddMessage(context.featureDefinition().featureTitle(), CompilerMessageLevel.Error, CompilerMessageCode.OnlyOneFeatureAllowed);
                return file;
            }

            file.Feature = new FeatureElement();

            currentAnnotatable = file.Feature;

            VisitChildren(context);

            if (file.Feature.Scenarios.Count == 0)
            {
                // Warning should be associated to the title.
                AddMessage(context.featureDefinition().featureTitle(), CompilerMessageLevel.Warning, CompilerMessageCode.NoScenarios, file.Feature.Name);
            }

            return file;
        }

        /// <summary>
        /// Visits a feature or scenario tag '@tag' and adds it to the current <see cref="IAnnotatableElement"/> feature or scenario object.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitTagAnnotation([NotNull] AutoStepParser.TagAnnotationContext context)
        {
            Debug.Assert(file is object);

            if (currentAnnotatable == null)
            {
                AddMessage(context, CompilerMessageLevel.Error, CompilerMessageCode.UnexpectedAnnotation);
                return file;
            }

            var tag = context.TAG();

            var tagBody = context.TAG().GetText().Substring(1).TrimEnd();

            currentAnnotatable.Annotations.Add(LineInfo(new TagElement { Tag = tagBody }, tag));

            return file;
        }

        /// <summary>
        /// Visits a feature or scenario option '$tag' and adds it to the current <see cref="IAnnotatableElement"/> feature or scenario object.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitOptionAnnotation([NotNull] AutoStepParser.OptionAnnotationContext context)
        {
            Debug.Assert(file is object);

            if (currentAnnotatable == null)
            {
                AddMessage(context, CompilerMessageLevel.Error, CompilerMessageCode.UnexpectedAnnotation);
                return file;
            }

            var option = context.OPTION();

            var optBody = option.GetText().Substring(1);

            // Trim the body to get rid of trailing whitespace.
            optBody = optBody.TrimEnd();

            // Now split on the first ':'.
            var positionOfColon = optBody.IndexOf(':', StringComparison.CurrentCulture);

            string? setting = null;
            string name = optBody;

            if (positionOfColon != -1)
            {
                var nextChar = positionOfColon + 1;
                name = name.Substring(0, positionOfColon);

                if (nextChar < optBody.Length)
                {
                    // Error, colon has been placed with no other content.
                    setting = optBody.Substring(nextChar).Trim();
                }

                if (string.IsNullOrEmpty(setting))
                {
                    AddMessage(option, CompilerMessageLevel.Error, CompilerMessageCode.OptionWithNoSetting, name);
                    return file;
                }
            }

            currentAnnotatable.Annotations.Add(LineInfo(
                new OptionElement
                {
                    Name = name,
                    Setting = setting,
                }, option));

            return file;
        }

        /// <summary>
        /// Visits the feature definition (which defines the name and description).
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile? VisitFeatureDefinition([NotNull] AutoStepParser.FeatureDefinitionContext context)
        {
            Debug.Assert(file is object);

            var titleTree = context.featureTitle();

            var featureToken = titleTree.FEATURE();
            var featureKeyWordText = featureToken.GetText();

            // We want the parser to allow case-insensitive keywords through, so we can assert on them
            // here and give more useful errors.
            if (featureKeyWordText != "Feature:")
            {
                AddMessage(featureToken, CompilerMessageLevel.Error, CompilerMessageCode.InvalidFeatureKeyword, featureKeyWordText);
            }

            var title = titleTree.text().GetText();
            var description = ExtractDescription(context.description());

            // Past this point, annotations aren't valid.
            currentAnnotatable = null;

            LineInfo(file.Feature, titleTree);

            file.Feature.Name = title;
            file.Feature.Description = string.IsNullOrWhiteSpace(description) ? null : description;

            return file;
        }

        /// <summary>
        /// Visits the Background block (which can contain steps).
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile? VisitBackgroundBlock([NotNull] AutoStepParser.BackgroundBlockContext context)
        {
            Debug.Assert(file is object);

            var background = new BackgroundElement();

            LineInfo(background, context.BACKGROUND());

            file.Feature.Background = background;

            currentStepSet = background.Steps;
            currentStepSetLastConcrete = null;

            return base.VisitBackgroundBlock(context);
        }

        public override BuiltFile VisitStepDefinitionBlock([NotNull] AutoStepParser.StepDefinitionBlockContext context)
        {
            Debug.Assert(file is object);

            var stepDefinition = new StepDefinitionElement();

            var definition = context.stepDefinition();

            var declaration = definition.stepDeclaration();

            LineInfo(stepDefinition, definition.STEP_DEFINE());

            currentAnnotatable = stepDefinition;

            var annotations = context.annotations();
            if (annotations is object)
            {
                Visit(annotations);
            }

            currentAnnotatable = null;

            var description = ExtractDescription(definition.description());
            stepDefinition.Description = string.IsNullOrWhiteSpace(description) ? null : description;

            currentStepDefinition = stepDefinition;

            // Visit the declaration to built the 'signature' of the method.
            Visit(declaration);

            if (stepDefinition.Arguments is object)
            {
                // At this point, we'll validate the provided 'arguments' to the step. All the arguments should just be variable names.
                foreach (var declaredArgument in stepDefinition.Arguments)
                {
                    // If the value cannot be immediately determined, it means there is some dynamic component (e.g. insertion variables or example inserts).
                    // Everything else is allowed.
                    if (declaredArgument.Value is null)
                    {
                        var argumentName = declaredArgument.RawArgument;

                        if (declaredArgument.Type == ArgumentType.Interpolated)
                        {
                            argumentName = ":" + argumentName;
                        }

                        AddMessage(declaredArgument, CompilerMessageLevel.Error, CompilerMessageCode.CannotSpecifyDynamicValueInStepDefinition, argumentName);
                    }
                }
            }

            currentStepSet = stepDefinition.Steps;

            Visit(context.stepDefinitionBody());

            file.AddStepDefinition(stepDefinition);

            currentStepSet = null;
            currentStepDefinition = null;

            return file;
        }

        /// <summary>
        /// Visits the Scenario block (which is annotable and can contain steps). Adds the scenario to the feature.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile? VisitScenarioBlock([NotNull] AutoStepParser.ScenarioBlockContext context)
        {
            Debug.Assert(file is object);

            ScenarioElement scenario;

            var definition = context.scenarioDefinition();
            var title = definition.scenarioTitle();

            string titleText;

            if (title is AutoStepParser.NormalScenarioTitleContext scenarioTitle)
            {
                var scenarioToken = scenarioTitle.SCENARIO();
                var scenarioKeyWordText = scenarioToken.GetText();

                // We want the parser to allow case-insensitive keywords through, so we can assert on them
                // here and give more useful errors.
                if (scenarioKeyWordText != "Scenario:")
                {
                    AddMessage(scenarioToken, CompilerMessageLevel.Error, CompilerMessageCode.InvalidScenarioKeyword, scenarioKeyWordText);
                    return file;
                }

                scenario = new ScenarioElement();
                titleText = scenarioTitle.text().GetText();
            }
            else if (title is AutoStepParser.ScenarioOutlineTitleContext scenariOutlineTitle)
            {
                var scenarioOutlineToken = scenariOutlineTitle.SCENARIO_OUTLINE();
                var scenarioOutlineKeyWordText = scenarioOutlineToken.GetText();

                // We want the parser to allow case-insensitive keywords through, so we can assert on them
                // here and give more useful errors.
                if (scenarioOutlineKeyWordText != "Scenario Outline:")
                {
                    AddMessage(scenarioOutlineToken, CompilerMessageLevel.Error, CompilerMessageCode.InvalidScenarioOutlineKeyword, scenarioOutlineKeyWordText);
                    return file;
                }

                scenario = new ScenarioOutlineElement();
                titleText = scenariOutlineTitle.text().GetText();
            }
            else
            {
                const string assertFailure = "Cannot reach here if the parser rules are valid; parser will not enter the " +
                                             "scenario block if neither SCENARIO or SCENARIO_OUTLINE tokens are present.";
                Debug.Assert(false, assertFailure);
                return file;
            }

            currentAnnotatable = scenario;

            var annotations = context.annotations();
            if (annotations is object)
            {
                Visit(annotations);
            }

            var description = ExtractDescription(definition.description());

            LineInfo(scenario, title);

            scenario.Name = titleText;
            scenario.Description = string.IsNullOrWhiteSpace(description) ? null : description;

            currentAnnotatable = null;
            currentScenario = scenario;

            // Visit the examples first, it will let us validate any insertion variables
            // when we process the steps.
            Visit(context.examples());

            currentStepSet = scenario.Steps;
            currentStepSetLastConcrete = null;

            Visit(context.scenarioBody());

            currentStepSet = null;
            currentScenario = null;

            file.Feature.Scenarios.Add(scenario);

            return file;
        }

        /// <summary>
        /// Visits a Given step (and adds it to the current step collection).
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile? VisitGiven([NotNull] AutoStepParser.GivenContext context)
        {
            AddStep(StepType.Given, context, context.statementBody());

            return file;
        }

        /// <summary>
        /// Visits a Then step (and adds it to the current step collection).
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile? VisitThen([NotNull] AutoStepParser.ThenContext context)
        {
            AddStep(StepType.Then, context, context.statementBody());

            return file;
        }

        /// <summary>
        /// Visits a When step (and adds it to the current step collection).
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile? VisitWhen([NotNull] AutoStepParser.WhenContext context)
        {
            AddStep(StepType.When, context, context.statementBody());

            return file;
        }

        /// <summary>
        /// Visits an And step (and adds it to the current step collection).
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile? VisitAnd([NotNull] AutoStepParser.AndContext context)
        {
            AddStep(StepType.And, context, context.statementBody());

            return file;
        }

        /// <summary>
        /// Visits an empty statement argument.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitArgEmpty([NotNull] AutoStepParser.ArgEmptyContext context)
        {
            Debug.Assert(currentStep is object);
            Debug.Assert(file is object);

            currentStep.AddArgument(PositionalLineInfo(
                new StepArgumentElement
                {
                    RawArgument = string.Empty,
                    Type = ArgumentType.Empty,
                    EscapedArgument = string.Empty,
                    Value = string.Empty,
                }, context));

            return file;
        }

        /// <summary>
        /// Visits an interpolated statement argument.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitArgInterpolate([NotNull] AutoStepParser.ArgInterpolateContext context)
        {
            Debug.Assert(currentStep is object);
            Debug.Assert(file is object);

            var contentBlock = context.statementArgument();

            Visit(contentBlock);

            PersistWorkingTextSection(argReplacements);

            var escaped = currentRewriter.GetText(contentBlock.SourceInterval);

            var arg = new StepArgumentElement
            {
                RawArgument = contentBlock.GetText(),
                Type = ArgumentType.Interpolated,

                // The rewriter will contain any modifications that replace the escaped characters.
                EscapedArgument = escaped,
            };

            arg.ReplaceSections(currentArgumentSections);

            currentArgumentSections.Clear();
            canArgumentValueBeDetermined = true;

            currentStep.AddArgument(PositionalLineInfo(arg, context));

            return file;
        }

        /// <summary>
        /// Visits a text statement argument.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitArgText([NotNull] AutoStepParser.ArgTextContext context)
        {
            Debug.Assert(currentStep is object);
            Debug.Assert(file is object);

            var contentBlock = context.statementArgument();

            Visit(contentBlock);

            PersistWorkingTextSection(argReplacements);

            var escaped = currentRewriter.GetText(contentBlock.SourceInterval);

            var arg = new StepArgumentElement
            {
                RawArgument = contentBlock.GetText(),
                Type = ArgumentType.Text,

                // The rewriter will contain any modifications that replace the escaped characters.
                EscapedArgument = escaped,
            };

            arg.ReplaceSections(currentArgumentSections);

            if (canArgumentValueBeDetermined)
            {
                arg.Value = escaped;
            }

            currentArgumentSections.Clear();
            canArgumentValueBeDetermined = true;

            currentStep.AddArgument(PositionalLineInfo(arg, context));

            return file;
        }

        /// <summary>
        /// Visit the example block for example reference variables inside an argument.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitExampleArgBlock([NotNull] AutoStepParser.ExampleArgBlockContext context)
        {
            Debug.Assert(file != null);

            PersistWorkingTextSection(argReplacements);

            var content = context.GetText();

            var escaped = EscapeText(
                context,
                argReplacements);

            var allBodyInterval = context.argumentExampleNameBody().SourceInterval;

            var insertionName = currentRewriter.GetText(allBodyInterval);

            var arg = new ArgumentSectionElement
            {
                RawText = content,
                EscapedText = escaped,

                // The insertion name is the escaped name inside the angle brackets
                ExampleInsertionName = insertionName,
            };

            // If we've got an insertion, then the value of an argument cannot be determined at compile time.
            canArgumentValueBeDetermined = false;

            currentArgumentSections.Add(PositionalLineInfo(arg, context));

            ValidateVariableInsertionName(context, insertionName);

            return file;
        }

        /// <summary>
        /// Visit the argument block for text.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitTextArgBlock([NotNull] AutoStepParser.TextArgBlockContext context)
        {
            Debug.Assert(file != null);

            if (textSectionTokenStart is null)
            {
                textSectionTokenStart = context.Start;
            }

            // Move the end
            textSectionTokenEnd = context.Stop;

            return file;
        }

        /// <summary>
        /// Visits a float statement argument.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitArgFloat([NotNull] AutoStepParser.ArgFloatContext context)
        {
            Debug.Assert(currentStep is object);
            Debug.Assert(file is object);

            var valueText = context.ARG_FLOAT().GetText();
            var symbolText = context.ARG_CURR_SYMBOL()?.GetText();
            var content = symbolText + valueText;

            currentStep.AddArgument(PositionalLineInfo(
                new StepArgumentElement
                {
                    RawArgument = content,
                    Type = ArgumentType.NumericDecimal,
                    EscapedArgument = content,
                    Value = decimal.Parse(valueText, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.CurrentCulture),
                    Symbol = symbolText,
                }, context));

            return file;
        }

        /// <summary>
        /// Visits an integer statement argument.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitArgInt([NotNull] AutoStepParser.ArgIntContext context)
        {
            Debug.Assert(currentStep is object);
            Debug.Assert(file is object);

            var valueText = context.ARG_INT().GetText();
            var symbolText = context.ARG_CURR_SYMBOL()?.GetText();
            var content = symbolText + valueText;

            currentStep.AddArgument(PositionalLineInfo(
                new StepArgumentElement
                {
                    RawArgument = content,
                    Type = ArgumentType.NumericInteger,
                    EscapedArgument = content,
                    Value = int.Parse(valueText, NumberStyles.AllowThousands, CultureInfo.CurrentCulture),
                    Symbol = symbolText,
                }, context));

            return file;
        }

        /// <summary>
        /// Vists a statement that contains a table.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitStatementWithTable([NotNull] AutoStepParser.StatementWithTableContext context)
        {
            Debug.Assert(file is object);

            base.VisitStatementWithTable(context);

            Debug.Assert(currentStep is object);

            currentStep.Table = currentTable;

            currentTable = null;

            return file;
        }

        /// <summary>
        /// Visit an examples block.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitExampleBlock([NotNull] AutoStepParser.ExampleBlockContext context)
        {
            Debug.Assert(file is object);
            Debug.Assert(currentScenario is object);

            var outline = currentScenario as ScenarioOutlineElement;
            var exampleTokenText = context.EXAMPLES().GetText();

            if (exampleTokenText != "Examples:")
            {
                AddMessage(context.EXAMPLES(), CompilerMessageLevel.Error, CompilerMessageCode.InvalidExamplesKeyword, exampleTokenText);
                return file;
            }

            if (outline == null)
            {
                AddMessage(context.EXAMPLES(), CompilerMessageLevel.Error, CompilerMessageCode.NotExpectingExample, currentScenario.Name);
                return file;
            }

            var example = new ExampleElement();

            currentAnnotatable = example;

            LineInfo(example, context.EXAMPLES());

            Visit(context.annotations());

            currentAnnotatable = null;

            Visit(context.tableBlock());

            example.Table = currentTable;

            currentTable = null;

            outline.AddExample(example);

            return file;
        }

        /// <summary>
        /// Vists a table block (prepares the table).
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitTableBlock([NotNull] AutoStepParser.TableBlockContext context)
        {
            Debug.Assert(file is object);
            currentTable = new TableElement();

            LineInfo(currentTable, context.tableHeader());

            base.VisitTableBlock(context);

            return file;
        }

        /// <summary>
        /// Vists a table header.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitTableHeader([NotNull] AutoStepParser.TableHeaderContext context)
        {
            Debug.Assert(file is object);
            Debug.Assert(currentTable is object);

            LineInfo(currentTable.Header, context);

            base.VisitTableHeader(context);

            return file;
        }

        /// <summary>
        /// Vists a table header cell.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitTableHeaderCell([NotNull] AutoStepParser.TableHeaderCellContext context)
        {
            Debug.Assert(file is object);
            Debug.Assert(currentTable is object);

            var headerTextBlock = context.headerCell();

            var header = new TableHeaderCellElement
            {
                HeaderName = headerTextBlock?.GetText(),
            };

            if (headerTextBlock is null)
            {
                var cellWs = context.CELL_WS(0);

                if (cellWs is object)
                {
                    PositionalLineInfo(header, cellWs);
                }
                else
                {
                    PositionalLineInfo(header, context);
                }
            }
            else
            {
                PositionalLineInfo(header, headerTextBlock);
            }

            currentTable.Header.AddHeader(header);

            return file;
        }

        /// <summary>
        /// Vists a table data row.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitTableRow([NotNull] AutoStepParser.TableRowContext context)
        {
            Debug.Assert(file is object);
            Debug.Assert(currentTable is object);

            currentRow = LineInfo(new TableRowElement(), context);

            base.VisitTableRow(context);

            // Check if the number of cells in the row doesn't match the headings.
            if (currentRow.Cells.Count != currentTable.ColumnCount)
            {
                AddMessageStoppingAtPrecedingToken(context, CompilerMessageLevel.Error, CompilerMessageCode.TableColumnsMismatch, currentRow.Cells.Count, currentTable.ColumnCount);
            }

            currentTable.AddRow(currentRow);

            return file;
        }

        /// <summary>
        /// Vists the cell of a table data row.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitTableRowCell([NotNull] AutoStepParser.TableRowCellContext context)
        {
            Debug.Assert(file is object);
            Debug.Assert(currentRow is object);

            var cellContent = context.tableRowCellContent();

            if (cellContent == null)
            {
                // Empty cell, add a cell with an empty argument.
                var cell = new TableCellElement();

                var cellWs = context.CELL_WS(0);

                var arg = new StepArgumentElement
                {
                    RawArgument = null,
                    Type = ArgumentType.Empty,
                    EscapedArgument = null,
                    Value = null,
                };

                if (cellWs == null)
                {
                    // If there's no whitespace, we'll just have to use the start of the table delimiter.
                    PositionalLineInfo(cell, context);
                    PositionalLineInfo(arg, context);
                }
                else
                {
                    PositionalLineInfo(cell, cellWs);
                    PositionalLineInfo(arg, cellWs);
                }

                cell.Value = arg;

                currentRow.AddCell(cell);
            }
            else
            {
                Visit(cellContent);
            }

            return file;
        }

        /// <summary>
        /// Vists a float value in a table data cell.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitCellFloat([NotNull] AutoStepParser.CellFloatContext context)
        {
            Debug.Assert(file is object);
            Debug.Assert(currentRow is object);

            var cell = new TableCellElement();

            PositionalLineInfo(cell, context);

            var valueText = context.CELL_FLOAT().GetText();
            var symbolText = context.CELL_CURR_SYMBOL()?.GetText();
            var content = symbolText + valueText;

            var arg = PositionalLineInfo(
                new StepArgumentElement
                {
                    RawArgument = content,
                    Type = ArgumentType.NumericDecimal,
                    EscapedArgument = content,
                    Value = decimal.Parse(valueText, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.CurrentCulture),
                    Symbol = symbolText,
                }, context);

            cell.Value = arg;

            currentRow.AddCell(cell);

            return file;
        }

        /// <summary>
        /// Vists an int value in a table data cell.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitCellInt([NotNull] AutoStepParser.CellIntContext context)
        {
            Debug.Assert(file is object);
            Debug.Assert(currentRow is object);

            var cell = new TableCellElement();

            PositionalLineInfo(cell, context);

            var valueText = context.CELL_INT().GetText();
            var symbolText = context.CELL_CURR_SYMBOL()?.GetText();
            var content = symbolText + valueText;

            var arg = PositionalLineInfo(
                new StepArgumentElement
                {
                    RawArgument = content,
                    Type = ArgumentType.NumericInteger,
                    EscapedArgument = content,
                    Value = int.Parse(valueText, NumberStyles.AllowThousands, CultureInfo.CurrentCulture),
                    Symbol = symbolText,
                }, context);

            cell.Value = arg;

            currentRow.AddCell(cell);

            return file;
        }

        /// <summary>
        /// Vists an interpolated value in a table data cell.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitCellInterpolate([NotNull] AutoStepParser.CellInterpolateContext context)
        {
            Debug.Assert(currentRow is object);
            Debug.Assert(file is object);

            var cell = new TableCellElement();

            PositionalLineInfo(cell, context);

            var contentBlock = context.cellArgument();

            Visit(contentBlock);

            PersistWorkingTextSection(tableCellReplacements);

            var escaped = currentRewriter.GetText(contentBlock.SourceInterval);

            var arg = new StepArgumentElement
            {
                RawArgument = contentBlock.GetText(),
                Type = ArgumentType.Interpolated,

                // The rewriter will contain any modifications that replace the escaped characters.
                EscapedArgument = escaped,
            };

            arg.ReplaceSections(currentArgumentSections);

            PositionalLineInfo(arg, context);

            currentArgumentSections.Clear();
            canArgumentValueBeDetermined = true;

            cell.Value = arg;

            currentRow.AddCell(cell);

            return file;
        }

        /// <summary>
        /// Vists a text value in a table data cell.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitCellText([NotNull] AutoStepParser.CellTextContext context)
        {
            Debug.Assert(currentRow is object);
            Debug.Assert(file is object);

            var cell = new TableCellElement();

            PositionalLineInfo(cell, context);

            var contentBlock = context.cellArgument();

            Visit(contentBlock);

            PersistWorkingTextSection(tableCellReplacements);

            var escaped = currentRewriter.GetText(contentBlock.SourceInterval);

            var arg = new StepArgumentElement
            {
                RawArgument = contentBlock.GetText(),
                Type = ArgumentType.Text,

                // The rewriter will contain any modifications that replace the escaped characters.
                EscapedArgument = escaped,
            };

            arg.ReplaceSections(currentArgumentSections);

            PositionalLineInfo(arg, context);

            if (canArgumentValueBeDetermined)
            {
                arg.Value = escaped;
            }

            currentArgumentSections.Clear();
            canArgumentValueBeDetermined = true;

            cell.Value = arg;

            currentRow.AddCell(cell);

            return file;
        }

        /// <summary>
        /// Visit the example cell block (which is the part of the cell that contains an example reference).
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitExampleCellBlock([NotNull] AutoStepParser.ExampleCellBlockContext context)
        {
            Debug.Assert(file != null);

            PersistWorkingTextSection(tableCellReplacements);

            var content = context.GetText();

            var escaped = EscapeText(
                context,
                tableCellReplacements);

            var allBodyInterval = context.cellExampleNameBody().SourceInterval;

            var insertionName = currentRewriter.GetText(allBodyInterval);

            var arg = new ArgumentSectionElement
            {
                RawText = content,
                EscapedText = escaped,

                // The insertion name is the escaped name inside the angle brackets
                ExampleInsertionName = currentRewriter.GetText(allBodyInterval),
            };

            // If we've got an insertion, then the value of an argument cannot be determined at compile time.
            canArgumentValueBeDetermined = false;

            ValidateVariableInsertionName(context, insertionName);

            currentArgumentSections.Add(PositionalLineInfo(arg, context));

            return file;
        }

        /// <summary>
        /// Visit a block within the cell that contains text.
        /// </summary>
        /// <param name="context">The parse context.</param>
        /// <returns>The file.</returns>
        public override BuiltFile VisitTextCellBlock([NotNull] AutoStepParser.TextCellBlockContext context)
        {
            Debug.Assert(file != null);

            if (textSectionTokenStart is null)
            {
                textSectionTokenStart = context.Start;
            }

            // Move the end of the text section to the stop token.
            textSectionTokenEnd = context.Stop;

            return file;
        }

        private void ValidateVariableInsertionName(ParserRuleContext context, string insertionName)
        {
            if (currentStepDefinition is object && currentStepSet is object)
            {
                // We are inside a step definition body, so insertions will be references to step parameters defined on the step definition.
                if (!currentStepDefinition.ContainsArgument(insertionName))
                {
                    AddMessage(context, CompilerMessageLevel.Warning, CompilerMessageCode.StepVariableNotDeclared, insertionName);
                }
            }
            else if (currentScenario is ScenarioOutlineElement outline)
            {
                if (!outline.ContainsVariable(insertionName))
                {
                    // Referencing an undeclared examples variable
                    AddMessage(context, CompilerMessageLevel.Warning, CompilerMessageCode.ExampleVariableNotDeclared, insertionName);
                }
            }
            else if (currentScenario is object)
            {
                // Example variable in a regular scenario
                AddMessage(context, CompilerMessageLevel.Warning, CompilerMessageCode.ExampleVariableInScenario, insertionName);
            }
        }

        private void PersistWorkingTextSection(params (int Token, string Replacement)[] replacements)
        {
            if (textSectionTokenStart is object)
            {
                var content = tokenStream.GetText(textSectionTokenStart, textSectionTokenEnd!);

                var escaped = EscapeText(
                    textSectionTokenStart,
                    textSectionTokenEnd!,
                    replacements);

                var arg = new ArgumentSectionElement
                {
                    RawText = content,
                    EscapedText = escaped,
                };

                currentArgumentSections.Add(PositionalLineInfo(arg, textSectionTokenStart, textSectionTokenEnd!));
            }

            textSectionTokenStart = null;
            textSectionTokenEnd = null;
        }

        private void AddStep(StepType type, ParserRuleContext context, AutoStepParser.StatementBodyContext bodyContext)
        {
            if (currentStepSet is null && currentStepDefinition is null)
            {
                AddMessage(context, CompilerMessageLevel.Error, CompilerMessageCode.StepNotExpected);
                return;
            }

            // All step references are currently added as 'unknown', until they are linked.
            StepType? bindingType = null;
            var step = new StepReferenceElement
            {
                Type = type,
                RawText = bodyContext.GetText(),
            };

            if (type == StepType.And)
            {
                if (currentStepDefinition is object)
                {
                    // We are in the step declaration, which does not permit 'And'.
                    AddMessage(context, CompilerMessageLevel.Error, CompilerMessageCode.CannotDefineAStepWithAnd);
                }
                else if (currentStepSetLastConcrete is null)
                {
                    AddMessage(context, CompilerMessageLevel.Error, CompilerMessageCode.AndMustFollowNormalStep);
                }
                else
                {
                    bindingType = currentStepSetLastConcrete.BindingType;
                }
            }
            else
            {
                bindingType = type;

                if (currentStepDefinition is null)
                {
                    currentStepSetLastConcrete = step;
                }
            }

            step.BindingType = bindingType;

            LineInfo(step, context);

            currentStep = step;

            VisitChildren(bodyContext);

            if (currentStepSet is object)
            {
                currentStepSet.Add(step);
            }
            else if (currentStepDefinition is object)
            {
                // We're inside the step declaration.
                // Use the built step to populate the currentStepDefinition.
                if (step.Arguments != null)
                {
                    currentStepDefinition.AddArguments(step.Arguments);
                }

                currentStepDefinition.Type = step.Type;
                currentStepDefinition.Declaration = step.RawText;
            }
        }

        private string EscapeText(IToken start, IToken stop, params (int Token, string Replacement)[] replacements)
        {
            for (var idx = start.TokenIndex; idx <= stop.TokenIndex; idx++)
            {
                foreach (var rep in replacements)
                {
                    var token = tokenStream.Get(idx);

                    if (token.Type == rep.Token)
                    {
                        // Replace
                        currentRewriter.Replace(token, rep.Replacement);
                    }
                }
            }

            return currentRewriter.GetText(new Interval(start.TokenIndex, stop.TokenIndex));
        }

        private string EscapeText(ParserRuleContext context, params (int Token, string Replacement)[] replacements)
        {
            return EscapeText(context.Start, context.Stop, replacements);
        }

        private void AddMessage(ParserRuleContext context, CompilerMessageLevel level, CompilerMessageCode code, params object[] args)
        {
            AddMessage(level, code, context.Start, context.Stop, args);
        }

        private void AddMessage(PositionalElement element, CompilerMessageLevel level, CompilerMessageCode code, params object[] args)
        {
            AddMessage(level, code, element.SourceLine, element.SourceColumn, element.SourceLine, element.EndColumn, args);
        }

        private void AddMessageStoppingAtPrecedingToken(ParserRuleContext context, CompilerMessageLevel level, CompilerMessageCode code, params object[] args)
        {
            AddMessage(level, code, context.Start, tokenStream.GetPrecedingToken(context.Stop), args);
        }

        private void AddMessage(ITerminalNode context, CompilerMessageLevel level, CompilerMessageCode code, params object[] args)
        {
            AddMessage(level, code, context.Symbol, context.Symbol, args);
        }

        private void AddMessage(CompilerMessageLevel level, CompilerMessageCode code, IToken start, IToken stop, params object[] args)
        {
            AddMessage(level, code, start.Line, start.Column + 1, stop.Line, stop.Column + 1 + (stop.StopIndex - stop.StartIndex), args);          
        }

        private void AddMessage(CompilerMessageLevel level, CompilerMessageCode code, int lineStart, int colStart, int lineEnd, int colEnd, params object[] args)
        {
            if (level == CompilerMessageLevel.Error)
            {
                Success = false;
            }

            var message = new CompilerMessage(
                sourceName,
                level,
                code,
                string.Format(CultureInfo.CurrentCulture, CompilerMessages.ResourceManager.GetString(code.ToString(), CultureInfo.CurrentCulture), args),
                lineStart,
                colStart,
                lineEnd,
                colEnd);

            messages.Add(message);
        }

        private TElement PositionalLineInfo<TElement>(TElement element, ParserRuleContext ctxt)
            where TElement : PositionalElement
        {
            return PositionalLineInfo(element, ctxt.Start, ctxt.Stop);
        }

        private TElement PositionalLineInfo<TElement>(TElement element, ITerminalNode ctxt)
            where TElement : PositionalElement
        {
            return PositionalLineInfo(element, ctxt.Symbol, ctxt.Symbol);
        }

        private TElement PositionalLineInfo<TElement>(TElement element, IToken start, IToken stop)
            where TElement : PositionalElement
        {
            element.SourceLine = start.Line;
            element.SourceColumn = start.Column + 1;
            element.EndColumn = stop.Column + (stop.StopIndex - stop.StartIndex) + 1;

            return element;
        }

        private TElement LineInfo<TElement>(TElement element, ParserRuleContext ctxt)
            where TElement : BuiltElement
        {
            element.SourceLine = ctxt.Start.Line;
            element.SourceColumn = ctxt.Start.Column + 1;

            return element;
        }

        private TElement LineInfo<TElement>(TElement element, ITerminalNode ctxt)
            where TElement : BuiltElement
        {
            element.SourceLine = ctxt.Symbol.Line;
            element.SourceColumn = ctxt.Symbol.Column + 1;

            return element;
        }

        /// <summary>
        /// Generates the description text from a parsed description context.
        /// Handles indentation of the overall description, and indentation inside it.
        /// </summary>
        /// <param name="descriptionContext">The context.</param>
        /// <returns>The complete description string.</returns>
        private string? ExtractDescription(AutoStepParser.DescriptionContext descriptionContext)
        {
            if (descriptionContext is null)
            {
                return null;
            }

            var lines = descriptionContext.line();

            if (lines.Length == 0)
            {
                return null;
            }

            var descriptionBuilder = new StringBuilder();

            int? whitespaceRemovalCount = null;
            int? firstTextIndex = null;
            int lastTextIndex = 0;

            // First pass to get our whitespace size and last text position.
            for (var lineIdx = 0; lineIdx < lines.Length; lineIdx++)
            {
                var line = lines[lineIdx];
                var text = line.text();

                if (text is object)
                {
                    if (firstTextIndex == null)
                    {
                        firstTextIndex = lineIdx;
                    }

                    lastTextIndex = lineIdx;
                    var whiteSpaceSymbol = line.WS()?.Symbol;
                    var whiteSpaceSize = 0;

                    if (whiteSpaceSymbol is object)
                    {
                        // This is the size of the whitespace.
                        whiteSpaceSize = 1 + whiteSpaceSymbol.StopIndex - whiteSpaceSymbol.StartIndex;
                    }

                    if (whitespaceRemovalCount is null)
                    {
                        // This is the first item of non-whitespace text we have reached.
                        // Base our initial minimum whitespace on this.
                        whitespaceRemovalCount = whiteSpaceSize;
                    }
                    else if (whiteSpaceSize < whitespaceRemovalCount)
                    {
                        // Bring the whitespace in if the amount of whitespace has changed.
                        // We'll ignore whitespace lengths for lines with no text.
                        whitespaceRemovalCount = whiteSpaceSize;
                    }
                }
            }

            // No point rendering anything if there were no text lines.
            if (firstTextIndex is object)
            {
                // Second pass to render our description, only go up to the last text position.
                for (var lineIdx = firstTextIndex.Value; lineIdx <= lastTextIndex; lineIdx++)
                {
                    var line = lines[lineIdx];
                    var text = line.text();

                    if (text is null)
                    {
                        descriptionBuilder.AppendLine();
                    }
                    else
                    {
                        var wsText = line.WS()?.GetText();
                        if (whitespaceRemovalCount is object && wsText is object)
                        {
                            wsText = wsText.Substring(whitespaceRemovalCount.Value);
                        }

                        // Append all whitespace after the removal amount, plus the text.
                        descriptionBuilder.Append(wsText);
                        descriptionBuilder.Append(text.GetText());

                        if (lineIdx < lastTextIndex)
                        {
                            // Only add the line if we're not at the end.
                            descriptionBuilder.AppendLine();
                        }
                    }
                }
            }
            else
            {
                return null;
            }

            return descriptionBuilder.ToString();
        }
    }
}
