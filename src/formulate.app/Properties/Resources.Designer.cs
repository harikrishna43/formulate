﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace formulate.app.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("formulate.app.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to &lt;tab caption=&quot;Formulate&quot;&gt;
        ///    &lt;control&gt;/App_Plugins/formulate/dashboards/install.html&lt;/control&gt;
        ///&lt;/tab&gt;.
        /// </summary>
        internal static string FormulateTab {
            get {
                return ResourceManager.GetString("FormulateTab", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Action runat=&quot;install&quot; undo=&quot;false&quot; alias=&quot;Formulate.GrantPermissionToSection&quot; username=&quot;$AllUsers&quot; sectionName=&quot;formulate&quot; /&gt;.
        /// </summary>
        internal static string GrantAllUsersPermissionToSection {
            get {
                return ResourceManager.GetString("GrantAllUsersPermissionToSection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Action runat=&quot;install&quot; undo=&quot;false&quot; alias=&quot;Formulate.GrantPermissionToSection&quot; username=&quot;$CurrentUser&quot; sectionName=&quot;formulate&quot; /&gt;.
        /// </summary>
        internal static string GrantPermissionToSection {
            get {
                return ResourceManager.GetString("GrantPermissionToSection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Action runat=&quot;install&quot; undo=&quot;false&quot; alias=&quot;Formulate.TransformXmlFile&quot;
        ///  installTransform=&quot;~/App_Plugins/formulate/Transforms/applications.config.install.xdt.txt&quot;
        ///  uninstallTransform=&quot;~/App_Plugins/formulate/Transforms/applications.config.uninstall.xdt.txt&quot;
        ///  file=&quot;~/Config/applications.config&quot; /&gt;.
        /// </summary>
        internal static string TransformApplications {
            get {
                return ResourceManager.GetString("TransformApplications", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Action runat=&quot;install&quot; undo=&quot;false&quot; alias=&quot;Formulate.TransformXmlFile&quot;
        ///  installTransform=&quot;~/App_Plugins/formulate/Transforms/dashboard.config.install.xdt.txt&quot;
        ///  uninstallTransform=&quot;~/App_Plugins/formulate/Transforms/dashboard.config.uninstall.xdt.txt&quot;
        ///  file=&quot;~/Config/Dashboard.config&quot; /&gt;.
        /// </summary>
        internal static string TransformDashboard {
            get {
                return ResourceManager.GetString("TransformDashboard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Action runat=&quot;install&quot; undo=&quot;false&quot; alias=&quot;Formulate.TransformXmlFile&quot;
        ///  installTransform=&quot;~/App_Plugins/formulate/Transforms/web.config.install.xdt.txt&quot;
        ///  uninstallTransform=&quot;~/App_Plugins/formulate/Transforms/web.config.uninstall.xdt.txt&quot;
        ///  file=&quot;~/Web.config&quot; /&gt;.
        /// </summary>
        internal static string TransformWebConfig {
            get {
                return ResourceManager.GetString("TransformWebConfig", resourceCulture);
            }
        }
    }
}
