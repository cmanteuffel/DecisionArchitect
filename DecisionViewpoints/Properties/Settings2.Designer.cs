﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DecisionViewpoints.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Decision Viewpoints::Relationship")]
        public string RelationshipDiagramMetaType {
            get {
                return ((string)(this["RelationshipDiagramMetaType"]));
            }
            set {
                this["RelationshipDiagramMetaType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Decision Viewpoints::Chronological")]
        public string ChronologicalDiagramMetaType {
            get {
                return ((string)(this["ChronologicalDiagramMetaType"]));
            }
            set {
                this["ChronologicalDiagramMetaType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Decision Viewpoints::Stakeholder Involvement")]
        public string StakeholderInvolvementDiagramMetaType {
            get {
                return ((string)(this["StakeholderInvolvementDiagramMetaType"]));
            }
            set {
                this["StakeholderInvolvementDiagramMetaType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool BaselineOptionOnFileClose {
            get {
                return ((bool)(this["BaselineOptionOnFileClose"]));
            }
            set {
                this["BaselineOptionOnFileClose"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool BaselineOptionOnModification {
            get {
                return ((bool)(this["BaselineOptionOnModification"]));
            }
            set {
                this["BaselineOptionOnModification"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool BaselineOptionManually {
            get {
                return ((bool)(this["BaselineOptionManually"]));
            }
            set {
                this["BaselineOptionManually"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Decision History")]
        public string BaselineIdentifier {
            get {
                return ((string)(this["BaselineIdentifier"]));
            }
            set {
                this["BaselineIdentifier"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Forces")]
        public string ForcesElementMetatype {
            get {
                return ((string)(this["ForcesElementMetatype"]));
            }
            set {
                this["ForcesElementMetatype"] = value;
            }
        }
    }
}
