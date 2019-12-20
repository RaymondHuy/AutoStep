//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\AutoStepParser.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AutoStep.Compiler.Parser {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="AutoStepParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IAutoStepParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFile([NotNull] AutoStepParser.FileContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.featureBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFeatureBlock([NotNull] AutoStepParser.FeatureBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.annotations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotations([NotNull] AutoStepParser.AnnotationsContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>tagAnnotation</c>
	/// labeled alternative in <see cref="AutoStepParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTagAnnotation([NotNull] AutoStepParser.TagAnnotationContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>optionAnnotation</c>
	/// labeled alternative in <see cref="AutoStepParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOptionAnnotation([NotNull] AutoStepParser.OptionAnnotationContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>blank</c>
	/// labeled alternative in <see cref="AutoStepParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlank([NotNull] AutoStepParser.BlankContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.featureDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFeatureDefinition([NotNull] AutoStepParser.FeatureDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.featureTitle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFeatureTitle([NotNull] AutoStepParser.FeatureTitleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.featureBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFeatureBody([NotNull] AutoStepParser.FeatureBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.backgroundBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBackgroundBlock([NotNull] AutoStepParser.BackgroundBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.backgroundBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBackgroundBody([NotNull] AutoStepParser.BackgroundBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.scenarioBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScenarioBlock([NotNull] AutoStepParser.ScenarioBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.scenarioDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScenarioDefinition([NotNull] AutoStepParser.ScenarioDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.scenarioTitle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScenarioTitle([NotNull] AutoStepParser.ScenarioTitleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.scenarioBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScenarioBody([NotNull] AutoStepParser.ScenarioBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.stepCollectionBodyLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStepCollectionBodyLine([NotNull] AutoStepParser.StepCollectionBodyLineContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>given</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGiven([NotNull] AutoStepParser.GivenContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>when</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhen([NotNull] AutoStepParser.WhenContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>then</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitThen([NotNull] AutoStepParser.ThenContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>and</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnd([NotNull] AutoStepParser.AndContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.statementBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementBody([NotNull] AutoStepParser.StatementBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>statementSectionPart</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementSectionPart([NotNull] AutoStepParser.StatementSectionPartContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>statementWs</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementWs([NotNull] AutoStepParser.StatementWsContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>argEmpty</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgEmpty([NotNull] AutoStepParser.ArgEmptyContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>argFloat</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgFloat([NotNull] AutoStepParser.ArgFloatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>argInt</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgInt([NotNull] AutoStepParser.ArgIntContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>argInterpolate</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgInterpolate([NotNull] AutoStepParser.ArgInterpolateContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>argText</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgText([NotNull] AutoStepParser.ArgTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.statementTextContentBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementTextContentBlock([NotNull] AutoStepParser.StatementTextContentBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.text"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitText([NotNull] AutoStepParser.TextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLine([NotNull] AutoStepParser.LineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepParser.description"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDescription([NotNull] AutoStepParser.DescriptionContext context);
}
} // namespace AutoStep.Compiler.Parser
