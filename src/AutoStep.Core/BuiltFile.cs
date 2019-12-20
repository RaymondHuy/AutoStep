﻿using System.Collections.Generic;

namespace AutoStep.Core
{
    /// <summary>
    /// Defines a built file (which is a defined set of autostep content, with a known source).
    /// </summary>
    public class BuiltFile : BuiltContent
    {
        /// <summary>
        /// Gets or sets the name of the source (usually a file name).
        /// </summary>
        public string SourceName { get; set; }
    }
}
