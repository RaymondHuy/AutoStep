﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoStep.Compiler {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CompilerMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CompilerMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AutoStep.Compiler.CompilerMessages", typeof(CompilerMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An &apos;And&apos; statement must be preceded by a &apos;Given&apos;, &apos;When&apos; or &apos;Then&apos;..
        /// </summary>
        internal static string AndMustFollowNormalStep {
            get {
                return ResourceManager.GetString("AndMustFollowNormalStep", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Quoted argument has not been closed..
        /// </summary>
        internal static string ArgumentHasNotBeenClosed {
            get {
                return ResourceManager.GetString("ArgumentHasNotBeenClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bad option format. Option must the format &apos;$optionName&apos;, optionally with a value separated by &apos;:&apos;, e.g. &apos;$optionName:value&apos;..
        /// </summary>
        internal static string BadOptionFormat {
            get {
                return ResourceManager.GetString("BadOptionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bad tag format. Tag must have the format &apos;@tagName&apos;..
        /// </summary>
        internal static string BadTagFormat {
            get {
                return ResourceManager.GetString("BadTagFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Examples blocks must contain a table..
        /// </summary>
        internal static string ExamplesBlockRequiresTable {
            get {
                return ResourceManager.GetString("ExamplesBlockRequiresTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have specified an Example variable to insert, &apos;{0}&apos;, but the step is in a Scenario; did you mean to use a Scenario Outline instead?.
        /// </summary>
        internal static string ExampleVariableInScenario {
            get {
                return ResourceManager.GetString("ExampleVariableInScenario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have specified an Example variable to insert, &apos;{0}&apos;, but you have not declared the variable in any of your Examples. This value will always be blank when the test runs..
        /// </summary>
        internal static string ExampleVariableNotDeclared {
            get {
                return ResourceManager.GetString("ExampleVariableNotDeclared", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;Examples&apos; keyword is case-sensitive, so &apos;{0}&apos; should be &apos;Examples:&apos;.
        /// </summary>
        internal static string InvalidExamplesKeyword {
            get {
                return ResourceManager.GetString("InvalidExamplesKeyword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;Feature&apos; keyword is case-sensitive, so &apos;{0}&apos; should be &apos;Feature:&apos;.
        /// </summary>
        internal static string InvalidFeatureKeyword {
            get {
                return ResourceManager.GetString("InvalidFeatureKeyword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;Scenario&apos; keyword is case-sensitive, so &apos;{0}&apos; should be &apos;Scenario:&apos;.
        /// </summary>
        internal static string InvalidScenarioKeyword {
            get {
                return ResourceManager.GetString("InvalidScenarioKeyword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;Scenario Outline&apos; phrase is case-sensitive, so &apos;{0}&apos; should be &apos;Scenario Outline:&apos;.
        /// </summary>
        internal static string InvalidScenarioOutlineKeyword {
            get {
                return ResourceManager.GetString("InvalidScenarioOutlineKeyword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Features must have a title..
        /// </summary>
        internal static string NoFeatureTitleProvided {
            get {
                return ResourceManager.GetString("NoFeatureTitleProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scenario Outlines must have a title..
        /// </summary>
        internal static string NoScenarioOutlineTitleProvided {
            get {
                return ResourceManager.GetString("NoScenarioOutlineTitleProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your Feature &apos;{0}&apos; has no Scenarios, so will not run any tests..
        /// </summary>
        internal static string NoScenarios {
            get {
                return ResourceManager.GetString("NoScenarios", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scenarios must have a title..
        /// </summary>
        internal static string NoScenarioTitleProvided {
            get {
                return ResourceManager.GetString("NoScenarioTitleProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not expecting an Examples block here; did you mean to define &apos;{0}&apos; as a Scenario Outline rather than a Scenario?.
        /// </summary>
        internal static string NotExpectingExample {
            get {
                return ResourceManager.GetString("NotExpectingExample", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You can only have one Feature per file. Create a new file for this Feature..
        /// </summary>
        internal static string OnlyOneFeatureAllowed {
            get {
                return ResourceManager.GetString("OnlyOneFeatureAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provided Option &apos;{0}&apos; has a setting value marker &apos;:&apos;, but no value has been provided..
        /// </summary>
        internal static string OptionWithNoSetting {
            get {
                return ResourceManager.GetString("OptionWithNoSetting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Step is not expected here..
        /// </summary>
        internal static string StepNotExpected {
            get {
                return ResourceManager.GetString("StepNotExpected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Syntax Error: {0}.
        /// </summary>
        internal static string SyntaxError {
            get {
                return ResourceManager.GetString("SyntaxError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The row contains {0} cell(s), but we are expecting {1}, because of the number of headers..
        /// </summary>
        internal static string TableColumnsMismatch {
            get {
                return ResourceManager.GetString("TableColumnsMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Table cell has not been terminated. Expecting a table delimiter character &apos;|&apos;..
        /// </summary>
        internal static string TableRowHasNotBeenTerminated {
            get {
                return ResourceManager.GetString("TableRowHasNotBeenTerminated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not expecting an annotation at this position..
        /// </summary>
        internal static string UnexpectedAnnotation {
            get {
                return ResourceManager.GetString("UnexpectedAnnotation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected end of file..
        /// </summary>
        internal static string UnexpectedEndOfFile {
            get {
                return ResourceManager.GetString("UnexpectedEndOfFile", resourceCulture);
            }
        }
    }
}
