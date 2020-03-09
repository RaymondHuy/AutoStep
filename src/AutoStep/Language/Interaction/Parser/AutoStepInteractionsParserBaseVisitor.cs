//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\AutoStepInteractionsParser.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AutoStep.Language.Interaction.Parser {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IAutoStepInteractionsParserVisitor{Result}"/>,
/// which can be extended to create a visitor which only needs to handle a subset
/// of the available methods.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
internal partial class AutoStepInteractionsParserBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, IAutoStepInteractionsParserVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.file"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFile([NotNull] AutoStepInteractionsParser.FileContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.entityDefinition"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEntityDefinition([NotNull] AutoStepInteractionsParser.EntityDefinitionContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.appDefinition"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAppDefinition([NotNull] AutoStepInteractionsParser.AppDefinitionContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>appName</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.appItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAppName([NotNull] AutoStepInteractionsParser.AppNameContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>appTraits</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.appItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAppTraits([NotNull] AutoStepInteractionsParser.AppTraitsContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>appMethod</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.appItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAppMethod([NotNull] AutoStepInteractionsParser.AppMethodContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>appStep</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.appItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAppStep([NotNull] AutoStepInteractionsParser.AppStepContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.traitDefinition"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitTraitDefinition([NotNull] AutoStepInteractionsParser.TraitDefinitionContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.traitRefList"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitTraitRefList([NotNull] AutoStepInteractionsParser.TraitRefListContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>traitName</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.traitItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitTraitName([NotNull] AutoStepInteractionsParser.TraitNameContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>traitMethod</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.traitItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitTraitMethod([NotNull] AutoStepInteractionsParser.TraitMethodContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>traitStep</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.traitItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitTraitStep([NotNull] AutoStepInteractionsParser.TraitStepContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.methodDefinition"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodDefinition([NotNull] AutoStepInteractionsParser.MethodDefinitionContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.methodDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodDeclaration([NotNull] AutoStepInteractionsParser.MethodDeclarationContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.methodDefArgs"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodDefArgs([NotNull] AutoStepInteractionsParser.MethodDefArgsContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.methodCallChain"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodCallChain([NotNull] AutoStepInteractionsParser.MethodCallChainContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.methodCall"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodCall([NotNull] AutoStepInteractionsParser.MethodCallContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.methodCallArgs"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodCallArgs([NotNull] AutoStepInteractionsParser.MethodCallArgsContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>stringArg</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.methodCallArg"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitStringArg([NotNull] AutoStepInteractionsParser.StringArgContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>variableRef</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.methodCallArg"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVariableRef([NotNull] AutoStepInteractionsParser.VariableRefContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>variableArrRef</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.methodCallArg"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVariableArrRef([NotNull] AutoStepInteractionsParser.VariableArrRefContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>variableArrStrRef</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.methodCallArg"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitVariableArrStrRef([NotNull] AutoStepInteractionsParser.VariableArrStrRefContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>constantRef</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.methodCallArg"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitConstantRef([NotNull] AutoStepInteractionsParser.ConstantRefContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>intArg</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.methodCallArg"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIntArg([NotNull] AutoStepInteractionsParser.IntArgContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>floatArg</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.methodCallArg"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFloatArg([NotNull] AutoStepInteractionsParser.FloatArgContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.methodStr"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodStr([NotNull] AutoStepInteractionsParser.MethodStrContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>methodStrContent</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.methodStrPart"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodStrContent([NotNull] AutoStepInteractionsParser.MethodStrContentContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>methodStrEscape</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.methodStrPart"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodStrEscape([NotNull] AutoStepInteractionsParser.MethodStrEscapeContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>methodStrVariable</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.methodStrPart"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMethodStrVariable([NotNull] AutoStepInteractionsParser.MethodStrVariableContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.componentDefinition"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitComponentDefinition([NotNull] AutoStepInteractionsParser.ComponentDefinitionContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>componentName</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.componentItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitComponentName([NotNull] AutoStepInteractionsParser.ComponentNameContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>componentInherits</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.componentItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitComponentInherits([NotNull] AutoStepInteractionsParser.ComponentInheritsContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>componentTraits</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.componentItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitComponentTraits([NotNull] AutoStepInteractionsParser.ComponentTraitsContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>componentMethod</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.componentItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitComponentMethod([NotNull] AutoStepInteractionsParser.ComponentMethodContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>componentStep</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.componentItem"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitComponentStep([NotNull] AutoStepInteractionsParser.ComponentStepContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.stepDefinitionBody"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitStepDefinitionBody([NotNull] AutoStepInteractionsParser.StepDefinitionBodyContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.stepDefinition"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitStepDefinition([NotNull] AutoStepInteractionsParser.StepDefinitionContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>declareGiven</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.stepDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclareGiven([NotNull] AutoStepInteractionsParser.DeclareGivenContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>declareWhen</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.stepDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclareWhen([NotNull] AutoStepInteractionsParser.DeclareWhenContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>declareThen</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.stepDeclaration"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclareThen([NotNull] AutoStepInteractionsParser.DeclareThenContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.stepDeclarationBody"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitStepDeclarationBody([NotNull] AutoStepInteractionsParser.StepDeclarationBodyContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>declarationArgument</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.stepDeclarationSection"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclarationArgument([NotNull] AutoStepInteractionsParser.DeclarationArgumentContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>declarationSection</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.stepDeclarationSection"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclarationSection([NotNull] AutoStepInteractionsParser.DeclarationSectionContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.stepDeclarationArgument"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitStepDeclarationArgument([NotNull] AutoStepInteractionsParser.StepDeclarationArgumentContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.stepDeclarationArgumentName"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitStepDeclarationArgumentName([NotNull] AutoStepInteractionsParser.StepDeclarationArgumentNameContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="AutoStepInteractionsParser.stepDeclarationTypeHint"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitStepDeclarationTypeHint([NotNull] AutoStepInteractionsParser.StepDeclarationTypeHintContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>declarationWord</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.stepDeclarationSectionContent"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclarationWord([NotNull] AutoStepInteractionsParser.DeclarationWordContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>declarationComponentInsert</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.stepDeclarationSectionContent"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclarationComponentInsert([NotNull] AutoStepInteractionsParser.DeclarationComponentInsertContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>declarationEscaped</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.stepDeclarationSectionContent"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclarationEscaped([NotNull] AutoStepInteractionsParser.DeclarationEscapedContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>declarationWs</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.stepDeclarationSectionContent"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclarationWs([NotNull] AutoStepInteractionsParser.DeclarationWsContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>declarationColon</c>
	/// labeled alternative in <see cref="AutoStepInteractionsParser.stepDeclarationSectionContent"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDeclarationColon([NotNull] AutoStepInteractionsParser.DeclarationColonContext context) { return VisitChildren(context); }
}
} // namespace AutoStep.Language.Interaction.Parser

