﻿#pragma checksum "..\..\..\Panels\LoginPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72FAA7A849F2C065E48FF694E693B155E7D61B7D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HomeBudget.Panels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HomeBudget.Panels {
    
    
    /// <summary>
    /// LoginPanel
    /// </summary>
    public partial class LoginPanel : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Panels\LoginPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label MainLabel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Panels\LoginPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Panels\LoginPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Panels\LoginPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoginButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Panels\LoginPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LoginFail;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Panels\LoginPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label EmailLabel;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Panels\LoginPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PasswordLabel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Panels\LoginPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegisterButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HomeBudget;component/panels/loginpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Panels\LoginPanel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.EmailBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.LoginButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Panels\LoginPanel.xaml"
            this.LoginButton.Click += new System.Windows.RoutedEventHandler(this.LoginButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LoginFail = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.EmailLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.PasswordLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.RegisterButton = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Panels\LoginPanel.xaml"
            this.RegisterButton.Click += new System.Windows.RoutedEventHandler(this.RegisterButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

