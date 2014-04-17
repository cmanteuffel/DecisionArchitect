﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DecisionViewpoints {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DecisionViewpoints.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to Alternative for-relationships cannot point to discarded decisions..
        /// </summary>
        internal static string AlternativeForNotPointTo {
            get {
                return ResourceManager.GetString("AlternativeForNotPointTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Alternative for-relationships can only originate from tentative or discarded decisions..
        /// </summary>
        internal static string AlternativeForOnlyOriginateFrom {
            get {
                return ResourceManager.GetString("AlternativeForOnlyOriginateFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Caused by-relationships cannot point to discarded decisions..
        /// </summary>
        internal static string CausedByNotPointTo {
            get {
                return ResourceManager.GetString("CausedByNotPointTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do you still want to create this relationship?.
        /// </summary>
        internal static string ConfirmCreateRelation {
            get {
                return ResourceManager.GetString("ConfirmCreateRelation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Depends on-relationships can only point to tentative, decided, approved or challenged decisions..
        /// </summary>
        internal static string DependsOnOnlyPointTo {
            get {
                return ResourceManager.GetString("DependsOnOnlyPointTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Excluded by-relationships cannot point to idea, tentative, discarded or rejected decisions..
        /// </summary>
        internal static string ExcludedByNotPointTo {
            get {
                return ResourceManager.GetString("ExcludedByNotPointTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Excluded by-relationships can only originate from idea, tentative, discarded or rejected decisions..
        /// </summary>
        internal static string ExcludedOnlyOriginateFrom {
            get {
                return ResourceManager.GetString("ExcludedOnlyOriginateFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Decision Viewpoints.
        /// </summary>
        internal static string ModelValidationCategory {
            get {
                return ResourceManager.GetString("ModelValidationCategory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} ({1} {3} {2}).
        /// </summary>
        internal static string ModelValidationConnectorMessage {
            get {
                return ResourceManager.GetString("ModelValidationConnectorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} (‹‹{1}›› {2}).
        /// </summary>
        internal static string ModelValidationElementMessage {
            get {
                return ResourceManager.GetString("ModelValidationElementMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Every decision should have a unique name..
        /// </summary>
        internal static string NameUniqueness {
            get {
                return ResourceManager.GetString("NameUniqueness", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A decision is not allowed to have a relation with itself.
        /// </summary>
        internal static string NoLoops {
            get {
                return ResourceManager.GetString("NoLoops", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Relationships cannot originate from idea decisions..
        /// </summary>
        internal static string NotOriginateFromIdea {
            get {
                return ResourceManager.GetString("NotOriginateFromIdea", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Relationships cannot point to idea decisions..
        /// </summary>
        internal static string NotPointToIdea {
            get {
                return ResourceManager.GetString("NotPointToIdea", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Replaces-relationships can only point to rejected decisions..
        /// </summary>
        internal static string ReplacesOnlyPointTo {
            get {
                return ResourceManager.GetString("ReplacesOnlyPointTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Warning.
        /// </summary>
        internal static string WarningCreateRelation {
            get {
                return ResourceManager.GetString("WarningCreateRelation", resourceCulture);
            }
        }
    }
}
