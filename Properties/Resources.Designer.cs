﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VaultExceptionParser2024.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VaultExceptionParser2024.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to ############################
        ///### Vault 2024 Error Codes
        ///############################
        ///### Code | Name | Comments 
        ///############################
        ///0 UnspecifiedSystemException Used when the error code is invalid. 
        ///100 CreateKnowledgeVaultDatabase Error creating the knowledge vault. 
        ///102 DatabaseExists Database already exists. 
        ///103 DatabaseFull Database is full. 
        ///106 TransactionInvalidPrincipal The principal does not meet requirements to call this service.
        ///An example would be making a call without being [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string _2024ErrorCodes {
            get {
                return ResourceManager.GetString("2024ErrorCodes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #################################
        ///### Vault 2024 Restriction Codes
        ///#################################
        ///### Code | Name | Comments 
        ///#################################
        ///1000 FileDependantParents	Operation cannot be performed because the file has dependent parents.
        ///1001	FileCheckedOut	Operation cannot be performed because the file is checked out.
        ///1002	FileOldVersion	Operation cannot be performed because the file is an old version.
        ///1003	FileLinkedToItem	Operation cannot be performed because the file is link [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string _2024RestrictionCodes {
            get {
                return ResourceManager.GetString("2024RestrictionCodes", resourceCulture);
            }
        }
    }
}
