﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeoAlert.App.Resources.Translations {
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
    internal class MainText {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MainText() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GeoAlert.App.Resources.Translations.MainText", typeof(MainText).Assembly);
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
        ///   Looks up a localized string similar to Aceptar.
        /// </summary>
        internal static string AlertAccept {
            get {
                return ResourceManager.GetString("AlertAccept", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cancelar.
        /// </summary>
        internal static string AlertCancel {
            get {
                return ResourceManager.GetString("AlertCancel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ha ocurrido un error. Por favor, inténtelo de nuevo..
        /// </summary>
        internal static string AlertMessageError {
            get {
                return ResourceManager.GetString("AlertMessageError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to De acuerdo.
        /// </summary>
        internal static string AlertOk {
            get {
                return ResourceManager.GetString("AlertOk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ¡Error!.
        /// </summary>
        internal static string AlertTitleError {
            get {
                return ResourceManager.GetString("AlertTitleError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ¡Alerta!.
        /// </summary>
        internal static string AlertTitleWarning {
            get {
                return ResourceManager.GetString("AlertTitleWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Te mantienes dentro de una de las ubicaciones configuradas..
        /// </summary>
        internal static string BroadcastDwellMessage {
            get {
                return ResourceManager.GetString("BroadcastDwellMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ¡Te quedas!.
        /// </summary>
        internal static string BroadcastDwellTitle {
            get {
                return ResourceManager.GetString("BroadcastDwellTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Has entrado en una de las ubicaciones configuradas..
        /// </summary>
        internal static string BroadcastInMessage {
            get {
                return ResourceManager.GetString("BroadcastInMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ¡Entraste!.
        /// </summary>
        internal static string BroadcastInTitle {
            get {
                return ResourceManager.GetString("BroadcastInTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Has salido de una de las ubicaciones configuradas..
        /// </summary>
        internal static string BroadcastOutMessage {
            get {
                return ResourceManager.GetString("BroadcastOutMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ¡Saliste!.
        /// </summary>
        internal static string BroadcastOutTitle {
            get {
                return ResourceManager.GetString("BroadcastOutTitle", resourceCulture);
            }
        }
    }
}