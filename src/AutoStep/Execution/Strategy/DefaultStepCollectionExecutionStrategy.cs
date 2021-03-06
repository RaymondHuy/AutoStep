﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoStep.Elements.Metadata;
using AutoStep.Execution.Contexts;
using AutoStep.Execution.Control;
using AutoStep.Execution.Dependency;
using AutoStep.Execution.Events;

namespace AutoStep.Execution.Strategy
{
    /// <summary>
    /// Implements the default step collection execution strategy.
    /// </summary>
    internal class DefaultStepCollectionExecutionStrategy : IStepCollectionExecutionStrategy
    {
        /// <summary>
        /// Execute the strategy.
        /// </summary>
        /// <param name="owningScope">The owning scope.</param>
        /// <param name="owningContext">The owning context.</param>
        /// <param name="stepCollection">The step collection metadata.</param>
        /// <param name="variables">The set of variables currently in-scope.</param>
        /// <returns>A task that should complete when the step collection has finished executing.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Need to capture any error arising from a nested step.")]
        public async ValueTask Execute(IServiceScope owningScope, StepCollectionContext owningContext, IStepCollectionInfo stepCollection, VariableSet variables)
        {
            var stepExecutionStrategy = owningScope.Resolve<IStepExecutionStrategy>();
            var executionManager = owningScope.Resolve<IExecutionStateManager>();
            var events = owningScope.Resolve<IEventPipeline>();

            var collectionTimer = new Stopwatch();
            collectionTimer.Start();

            try
            {
                for (var stepIdx = 0; stepIdx < stepCollection.Steps.Count; stepIdx++)
                {
                    var step = stepCollection.Steps[stepIdx];

                    var stepContext = new StepContext(stepIdx, owningContext, step, variables);

                    using var stepScope = owningScope.BeginNewScope(stepContext);

                    // Halt before the step begins.
                    var stepHaltInstruction = await executionManager.CheckforHalt(stepScope, stepContext, TestThreadState.StartingStep).ConfigureAwait(false);

                    var stepRan = false;
                    var timer = new Stopwatch();
                    timer.Start();

                    try
                    {
                        // Halt instruction for step collections can include:
                        //  - Moving to a specific step position
                        //  - Stepping Up (i.e. run to next scope).
                        //  - Something else?
                        await events.InvokeEvent(
                            stepScope,
                            stepContext,
                            (handler, sc, ctxt, next) => handler.OnStep(sc, ctxt, next),
                            async (scope, ctxt) =>
                            {
                                try
                                {
                                    stepRan = true;

                                    // Execute the step.
                                    await stepExecutionStrategy.ExecuteStep(
                                            scope,
                                            ctxt,
                                            variables).ConfigureAwait(false);
                                }
                                catch (EventHandlingException ex)
                                {
                                    stepContext.FailException = ex;
                                }
                                catch (StepFailureException ex)
                                {
                                    stepContext.FailException = ex;
                                }
                                catch (Exception ex)
                                {
                                    // Wrap the context.
                                    stepContext.FailException = new StepFailureException(stepContext.Step, ex);
                                }
                            }).ConfigureAwait(false);
                    }
                    catch (EventHandlingException ex)
                    {
                        // Error in an event handler; fail the step.
                        stepContext.FailException = ex;
                    }
                    finally
                    {
                        timer.Stop();
                        stepContext.Elapsed = timer.Elapsed;
                        stepContext.StepExecuted = stepRan;
                    }

                    if (stepContext.FailException is object)
                    {
                        // The step failed, alert the execution manager.
                        var breakInstructions = await executionManager.StepError(stepContext).ConfigureAwait(false);

                        // React to the 'break'. Retry step?
                        // Can we re-bind/recompile partway through a test?
                        // Re-linking won't be an issue, because all that will change is the step definition,
                        // but re-compilation will re-construct our tree structure. Perhaps there is a way for the
                        // break response to instruct the caller.
                        // Regardless, we need to mark the owner as failing.
                        owningContext.FailException = stepContext.FailException;
                        owningContext.FailingStep = stepContext.Step;

                        // Consider allowing the scenario to continue until the next non-assert step (i.e. Then/When, etc).
                        break;
                    }
                }
            }
            finally
            {
                owningContext.Elapsed = collectionTimer.Elapsed;
                collectionTimer.Stop();
            }
        }
    }
}
