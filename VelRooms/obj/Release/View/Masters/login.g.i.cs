﻿#pragma checksum "..\..\..\..\View\Masters\login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CAAB7CB30438746D824AE26B6D71EC825F9D07AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HMS.View.Masters;
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


namespace HMS.View.Masters {
    
    
    /// <summary>
    /// login
    /// </summary>
    public partial class login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 111 "..\..\..\..\View\Masters\login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TXTUSERNAME;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\View\Masters\login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TXTPASSWORD;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\..\View\Masters\login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink tclink;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\View\Masters\login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popup;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\View\Masters\login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ok;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\View\Masters\login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup pop1;
        
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
            System.Uri resourceLocater = new System.Uri("/HMS;component/view/masters/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Masters\login.xaml"
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
            this.TXTUSERNAME = ((System.Windows.Controls.TextBox)(target));
            
            #line 111 "..\..\..\..\View\Masters\login.xaml"
            this.TXTUSERNAME.LostFocus += new System.Windows.RoutedEventHandler(this.TXTUSERNAME_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TXTPASSWORD = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 120 "..\..\..\..\View\Masters\login.xaml"
            this.TXTPASSWORD.LostFocus += new System.Windows.RoutedEventHandler(this.TXTPASSWORD_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 125 "..\..\..\..\View\Masters\login.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 126 "..\..\..\..\View\Masters\login.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tclink = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 131 "..\..\..\..\View\Masters\login.xaml"
            this.tclink.RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.tclink_RequestNavigate_1);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 134 "..\..\..\..\View\Masters\login.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 7:
            this.popup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 8:
            this.ok = ((System.Windows.Controls.Button)(target));
            
            #line 148 "..\..\..\..\View\Masters\login.xaml"
            this.ok.Click += new System.Windows.RoutedEventHandler(this.ok_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.pop1 = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 10:
            
            #line 159 "..\..\..\..\View\Masters\login.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

