﻿#pragma checksum "..\..\..\..\View\Operations\RESERVSTIONCHECKIN.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7BB363AC170B48560585CA01560E9ACFB5882DAF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HMS.View.Operations;
using HMS.ViewModel;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using RootLibrary.WPF.Localization;
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


namespace HMS.View.Operations {
    
    
    /// <summary>
    /// RESERVSTIONCHECKIN
    /// </summary>
    public partial class RESERVSTIONCHECKIN : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\..\View\Operations\RESERVSTIONCHECKIN.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid reserevationdetails;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\View\Operations\RESERVSTIONCHECKIN.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup pop1;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\View\Operations\RESERVSTIONCHECKIN.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Error1;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\View\Operations\RESERVSTIONCHECKIN.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup pop2;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\View\Operations\RESERVSTIONCHECKIN.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Error2;
        
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
            System.Uri resourceLocater = new System.Uri("/HMS;component/view/operations/reservstioncheckin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Operations\RESERVSTIONCHECKIN.xaml"
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
            this.reserevationdetails = ((System.Windows.Controls.DataGrid)(target));
            
            #line 56 "..\..\..\..\View\Operations\RESERVSTIONCHECKIN.xaml"
            this.reserevationdetails.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.reserevationdetails_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.pop1 = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 3:
            this.Error1 = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\..\View\Operations\RESERVSTIONCHECKIN.xaml"
            this.Error1.Click += new System.Windows.RoutedEventHandler(this.Error1_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pop2 = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 5:
            this.Error2 = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\..\View\Operations\RESERVSTIONCHECKIN.xaml"
            this.Error2.Click += new System.Windows.RoutedEventHandler(this.Error2_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

