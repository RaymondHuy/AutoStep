﻿using System;
using System.Threading.Tasks;
using AutoStep.Elements;
using AutoStep.Execution;
using AutoStep.Execution.Contexts;
using AutoStep.Execution.Dependency;
using AutoStep.Execution.Strategy;

namespace AutoStep.Definitions.Test
{
    /// <summary>
    /// Represents a step definined inside an autostep file.
    /// </summary>
    internal class FileStepDefinition : StepDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileStepDefinition"/> class.
        /// </summary>
        /// <param name="source">The source from which this file was created.</param>
        /// <param name="element">The element that defines the step.</param>
        public FileStepDefinition(IStepDefinitionSource source, StepDefinitionElement element)
            : base(
                  source,
                  element?.Type ?? throw new ArgumentNullException(nameof(element)),
                  element.Declaration!) // The declaration is validated by FileStepDefinitionSource before instantiating.
        {
            Definition = element;
        }

        /// <summary>
        /// Compares two step definitions within the same source and decides if they are the same actual definition
        /// (i.e. one can be replaced with the other).
        /// </summary>
        /// <param name="def">The other definition.</param>
        /// <returns>True if the same, false otherwise.</returns>
        public override bool IsSameDefinition(StepDefinition def)
        {
            if (def is FileStepDefinition)
            {
                return Source.Uid == def.Source.Uid && Type == def.Type && Declaration == def.Declaration;
            }

            return false;
        }

        /// <summary>
        /// Executes the step.
        /// </summary>
        /// <param name="stepScope">The owning step scope.</param>
        /// <param name="context">The current step context.</param>
        /// <param name="variables">The set of all variables.</param>
        /// <returns>Task completion.</returns>
        public override async ValueTask ExecuteStepAsync(IServiceScope stepScope, StepContext context, VariableSet variables)
        {
            // Extract the arguments, and invoke the collection executor.
            var nestedVariables = new VariableSet();

            if (context.Step.Binding is null)
            {
                throw new LanguageEngineAssertException();
            }

            if (Definition is null || Definition.Arguments.Count != context.Step.Binding.Arguments.Length)
            {
                throw new LanguageEngineAssertException();
            }

            // TODO: Do this once per row of the table in the step reference, or just once if there's no table?
            for (var argIdx = 0; argIdx < Definition.Arguments.Count; argIdx++)
            {
                var argValue = context.Step.Binding.Arguments[argIdx];

                var argText = argValue.GetFullText(stepScope, context.Step.Text, variables);

                nestedVariables.Set(Definition.Arguments[argIdx].Name, argText);
            }

            var collectionStrategy = stepScope.Resolve<IStepCollectionExecutionStrategy>();

            var fileStepContext = new FileDefinedStepContext(Definition);

            await collectionStrategy.Execute(
                stepScope,
                fileStepContext,
                Definition,
                nestedVariables).ConfigureAwait(false);

            if (fileStepContext.FailException is object)
            {
                context.FailException = fileStepContext.FailException;
            }
        }
    }
}
