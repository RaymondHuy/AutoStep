﻿using System;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace AutoStep.Language
{
    /// <summary>
    /// Represents a base syntax error handling context, that allows for managed
    /// error matching based on the state of the parser and the position in the token stream.
    /// </summary>
    /// <typeparam name="TParser">The ANTLR parser implementation.</typeparam>
    internal abstract class BaseErrorHandlingContext<TParser>
        where TParser : Parser
    {
        private Func<bool>[]? handlers;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseErrorHandlingContext{TParser}"/> class.
        /// </summary>
        /// <param name="tokenStream">The token stream for the file being parsed.</param>
        /// <param name="recognizer">The Antlr recogniser.</param>
        /// <param name="offendingSymbol">The offending symbol from the syntax error.</param>
        /// <param name="ex">The syntax parse exception (if there is one).</param>
        public BaseErrorHandlingContext(ITokenStream tokenStream, IRecognizer recognizer, IToken offendingSymbol, RecognitionException? ex)
        {
            TokenStream = tokenStream;
            Parser = (TParser)recognizer;
            OffendingSymbol = offendingSymbol;
            Exception = ex;
            StartingSymbol = OffendingSymbol;
            EndingSymbol = OffendingSymbol;
            Code = CompilerMessageCode.SyntaxError;
        }

        /// <summary>
        /// Gets the compiler message code that this error implies.
        /// </summary>
        public CompilerMessageCode Code { get; private set; }

        /// <summary>
        /// Gets any message arguments assigned to the compilation message code.
        /// </summary>
        public object[]? MessageArguments { get; private set; }

        /// <summary>
        /// Gets the Starting Symbol of the error (defaults to the Offending Symbol).
        /// Update this to change the beginning of the error in the token stream.
        /// </summary>
        public IToken StartingSymbol { get; private set; }

        /// <summary>
        /// Gets the Ending Symbol of the error (defaults to the Offending Symbol).
        /// Update this to change the end of the error in the token stream.
        /// </summary>
        public IToken EndingSymbol { get; private set; }

        /// <summary>
        /// Gets the relevant token stream for the error.
        /// </summary>
        protected ITokenStream TokenStream { get; }

        /// <summary>
        /// Gets the parser instance.
        /// </summary>
        protected TParser Parser { get; }

        /// <summary>
        /// Gets the offending token from the Antlr syntax error.
        /// </summary>
        protected IToken OffendingSymbol { get; }

        /// <summary>
        /// Gets the syntax recognition exception for the Antlr error.
        /// </summary>
        protected RecognitionException? Exception { get; }

        /// <summary>
        /// Gets the current rule context in the parser.
        /// </summary>
        protected RuleContext? Context => Parser?.Context;

        /// <summary>
        /// Gets the set of expected tokens for the current parser state.
        /// </summary>
        /// <returns>The Antlr expected token set.</returns>
        protected IntervalSet? GetExpectedTokens() => Exception?.GetExpectedTokens();

        /// <summary>
        /// Runs error matching on the current context, updating context properties if a handler matches.
        /// </summary>
        public void DoErrorMatching()
        {
            if (handlers is object)
            {
                // Go through the handlers, stop on a match.
                foreach (var handler in handlers)
                {
                    if (handler())
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Indicates that the first occuring instance of one of the specified token
        /// types prior to the offending symbol should be used as the start symbol for the error.
        /// </summary>
        /// <param name="searchTypes">The token types to search for.</param>
        protected void UseOpeningTokenAsStart(params int[] searchTypes)
        {
            // Search back for the preceding symbol that opened the item in question.
            StartingSymbol = TokenStream.GetPrecedingToken(OffendingSymbol, searchTypes);
        }

        /// <summary>
        /// Indicates that the immediately preceding token to the offending symbol should be used for the ending symbol.
        /// </summary>
        protected void UsePrecedingTokenAsEnd()
        {
            // Get the preceding token for the offending new line
            EndingSymbol = TokenStream.GetPrecedingToken(OffendingSymbol);
        }

        /// <summary>
        /// Indicates that the preceding token of the specified type to the offending symbol should be used for the ending symbol.
        /// </summary>
        /// <param name="tokenType">The token type to use as the end token.</param>
        protected void UsePrecedingTokenAsEnd(int tokenType)
        {
            // Get the preceding token for the offending new line
            EndingSymbol = TokenStream.GetPrecedingToken(OffendingSymbol, tokenType);
        }

        /// <summary>
        /// Indicates that the preceding token of the specified type to the offending symbol should be used for the ending symbol.
        /// </summary>
        /// <param name="token">The token to search from.</param>
        /// <param name="precedingTokenType">The token type to use as the end token.</param>
        protected void UsePrecedingTokenAsEnd(IToken token, int precedingTokenType)
        {
            // Get the preceding token for the offending new line
            EndingSymbol = TokenStream.GetPrecedingToken(token, precedingTokenType);
        }

        /// <summary>
        /// Indicates that the specified symbol should be considered the end of the error.
        /// </summary>
        /// <param name="token">The token to use as the end of the error.</param>
        protected void UseTokenAsEnd(IToken token)
        {
            EndingSymbol = token;
        }

        /// <summary>
        /// Indicates that the error starts and ends on the same symbol.
        /// </summary>
        protected void UseStartSymbolAsEndSymbol()
        {
            EndingSymbol = StartingSymbol;
        }

        /// <summary>
        /// Indicates whether the set of expected tokens contains any of the specified token types.
        /// </summary>
        /// <param name="tokens">The token types to look for.</param>
        /// <returns>True if one of the specified token types is expected by the parser.</returns>
        protected bool ExpectingTokens(params int[] tokens)
        {
           return !Parser.GetExpectedTokens().And(new IntervalSet(tokens)).IsNil;
        }

        /// <summary>
        /// Indicates whether the current parse context started with one of the specified token types.
        /// </summary>
        /// <param name="tokens">The token types to look for.</param>
        /// <returns>True of one of the specified token types was the start token for the current context.</returns>
        protected bool ContextStartedWithOneOf(params int[] tokens)
        {
            var startToken = (Context as ParserRuleContext)?.Start;

            if (startToken is null)
            {
                return false;
            }

            return Array.IndexOf(tokens, startToken.Type) > -1;
        }

        /// <summary>
        /// Checks if the offending symbol is of the specified type.
        /// </summary>
        /// <param name="symbol">The symbol type.</param>
        /// <returns>True if the symbol is of the specified type.</returns>
        protected bool OffendingSymbolIs(int symbol)
        {
            return OffendingSymbol.Type == symbol;
        }

        /// <summary>
        /// Checks if the offending symbol is one of the specified token types.
        /// </summary>
        /// <param name="symbols">The symbol types.</param>
        /// <returns>True if the offending symbol is any of the specified types.</returns>
        protected bool OffendingSymbolIsOneOf(params int[] symbols)
        {
            return symbols.Contains(OffendingSymbol.Type);
        }

        /// <summary>
        /// Shortcut for !OffendingSymbolIs; make syntax of error matching more readable.
        /// </summary>
        /// <param name="symbol">The symbol type.</param>
        /// <returns>True if the symbol is not of the specified type.</returns>
        protected bool OffendingSymbolIsNot(int symbol)
        {
            return !OffendingSymbolIs(symbol);
        }

        /// <summary>
        /// Checks the text of the offending symbol.
        /// </summary>
        /// <param name="expectedText">The text to check.</param>
        /// <returns>True if the text of the offending symbol matches.</returns>
        protected bool OffendingSymbolTextIs(string expectedText)
        {
            return OffendingSymbol.Text == expectedText;
        }

        /// <summary>
        /// Define the list of error handlers.
        /// </summary>
        /// <param name="handlers">A set of handlers, each of which can return true to report the error 'handled'.</param>
        protected void SetErrorHandlers(params Func<bool>[] handlers)
        {
            this.handlers = handlers;
        }

        /// <summary>
        /// Changes the message code for this error.
        /// </summary>
        /// <param name="code">The new code.</param>
        /// <param name="formatArgs">Format arguments for the message.</param>
        protected void ChangeError(CompilerMessageCode code, params object[] formatArgs)
        {
            Code = code;
            MessageArguments = formatArgs;
        }
    }
}
