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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="AutoStepParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IAutoStepParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFile([NotNull] AutoStepParser.FileContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFile([NotNull] AutoStepParser.FileContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.featureBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFeatureBlock([NotNull] AutoStepParser.FeatureBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.featureBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFeatureBlock([NotNull] AutoStepParser.FeatureBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.annotations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotations([NotNull] AutoStepParser.AnnotationsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.annotations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotations([NotNull] AutoStepParser.AnnotationsContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>tagAnnotation</c>
	/// labeled alternative in <see cref="AutoStepParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTagAnnotation([NotNull] AutoStepParser.TagAnnotationContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>tagAnnotation</c>
	/// labeled alternative in <see cref="AutoStepParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTagAnnotation([NotNull] AutoStepParser.TagAnnotationContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>optionAnnotation</c>
	/// labeled alternative in <see cref="AutoStepParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptionAnnotation([NotNull] AutoStepParser.OptionAnnotationContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>optionAnnotation</c>
	/// labeled alternative in <see cref="AutoStepParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptionAnnotation([NotNull] AutoStepParser.OptionAnnotationContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>blank</c>
	/// labeled alternative in <see cref="AutoStepParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlank([NotNull] AutoStepParser.BlankContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>blank</c>
	/// labeled alternative in <see cref="AutoStepParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlank([NotNull] AutoStepParser.BlankContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.featureDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFeatureDefinition([NotNull] AutoStepParser.FeatureDefinitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.featureDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFeatureDefinition([NotNull] AutoStepParser.FeatureDefinitionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.featureTitle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFeatureTitle([NotNull] AutoStepParser.FeatureTitleContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.featureTitle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFeatureTitle([NotNull] AutoStepParser.FeatureTitleContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.featureBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFeatureBody([NotNull] AutoStepParser.FeatureBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.featureBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFeatureBody([NotNull] AutoStepParser.FeatureBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.backgroundBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBackgroundBlock([NotNull] AutoStepParser.BackgroundBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.backgroundBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBackgroundBlock([NotNull] AutoStepParser.BackgroundBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.backgroundBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBackgroundBody([NotNull] AutoStepParser.BackgroundBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.backgroundBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBackgroundBody([NotNull] AutoStepParser.BackgroundBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.scenarioBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScenarioBlock([NotNull] AutoStepParser.ScenarioBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.scenarioBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScenarioBlock([NotNull] AutoStepParser.ScenarioBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.scenarioDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScenarioDefinition([NotNull] AutoStepParser.ScenarioDefinitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.scenarioDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScenarioDefinition([NotNull] AutoStepParser.ScenarioDefinitionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.scenarioTitle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScenarioTitle([NotNull] AutoStepParser.ScenarioTitleContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.scenarioTitle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScenarioTitle([NotNull] AutoStepParser.ScenarioTitleContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.scenarioBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterScenarioBody([NotNull] AutoStepParser.ScenarioBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.scenarioBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitScenarioBody([NotNull] AutoStepParser.ScenarioBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.stepCollectionBodyLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStepCollectionBodyLine([NotNull] AutoStepParser.StepCollectionBodyLineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.stepCollectionBodyLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStepCollectionBodyLine([NotNull] AutoStepParser.StepCollectionBodyLineContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>given</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGiven([NotNull] AutoStepParser.GivenContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>given</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGiven([NotNull] AutoStepParser.GivenContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>when</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhen([NotNull] AutoStepParser.WhenContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>when</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhen([NotNull] AutoStepParser.WhenContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>then</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterThen([NotNull] AutoStepParser.ThenContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>then</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitThen([NotNull] AutoStepParser.ThenContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>and</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnd([NotNull] AutoStepParser.AndContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>and</c>
	/// labeled alternative in <see cref="AutoStepParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnd([NotNull] AutoStepParser.AndContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.statementBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatementBody([NotNull] AutoStepParser.StatementBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.statementBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatementBody([NotNull] AutoStepParser.StatementBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>statementSectionPart</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatementSectionPart([NotNull] AutoStepParser.StatementSectionPartContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>statementSectionPart</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatementSectionPart([NotNull] AutoStepParser.StatementSectionPartContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>statementWs</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatementWs([NotNull] AutoStepParser.StatementWsContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>statementWs</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatementWs([NotNull] AutoStepParser.StatementWsContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>argEmpty</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgEmpty([NotNull] AutoStepParser.ArgEmptyContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>argEmpty</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgEmpty([NotNull] AutoStepParser.ArgEmptyContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>argFloat</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgFloat([NotNull] AutoStepParser.ArgFloatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>argFloat</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgFloat([NotNull] AutoStepParser.ArgFloatContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>argInt</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgInt([NotNull] AutoStepParser.ArgIntContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>argInt</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgInt([NotNull] AutoStepParser.ArgIntContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>argInterpolate</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgInterpolate([NotNull] AutoStepParser.ArgInterpolateContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>argInterpolate</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgInterpolate([NotNull] AutoStepParser.ArgInterpolateContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>argText</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgText([NotNull] AutoStepParser.ArgTextContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>argText</c>
	/// labeled alternative in <see cref="AutoStepParser.statementSection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgText([NotNull] AutoStepParser.ArgTextContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.statementTextContentBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatementTextContentBlock([NotNull] AutoStepParser.StatementTextContentBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.statementTextContentBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatementTextContentBlock([NotNull] AutoStepParser.StatementTextContentBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.text"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterText([NotNull] AutoStepParser.TextContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.text"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitText([NotNull] AutoStepParser.TextContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLine([NotNull] AutoStepParser.LineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLine([NotNull] AutoStepParser.LineContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AutoStepParser.description"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDescription([NotNull] AutoStepParser.DescriptionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AutoStepParser.description"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDescription([NotNull] AutoStepParser.DescriptionContext context);
}
} // namespace AutoStep.Compiler.Parser