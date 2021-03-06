﻿using AutoStep.Execution.Contexts;

namespace AutoStep.Execution.Dependency
{
    /// <summary>
    /// Provides extension methods on the service resolver (primarily to provide shortcuts for getting at useful services).
    /// </summary>
    public static class ServiceResolverExtensions
    {
        /// <summary>
        /// Get the current thread context.
        /// </summary>
        /// <param name="scope">The current scope.</param>
        /// <returns>The thread context.</returns>
        public static ThreadContext ThreadContext(this IServiceScope scope)
        {
            scope = scope.ThrowIfNull(nameof(scope));

            return scope.Resolve<ThreadContext>();
        }
    }
}
