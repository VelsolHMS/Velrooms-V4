﻿#pragma checksum "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B21FFA75CAB8391E9F06395DE019B369C1A2AA95"
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
    /// GroupCheckinDeparture
    /// </summary>
    public partial class GroupCheckinDeparture : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 116 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel grpcheck;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtrooms;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtstaydep;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txttime;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ok;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
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
            System.Uri resourceLocater = new System.Uri("/HMS;component/view/operations/groupcheckindeparture.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
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
            this.grpcheck = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.txtrooms = ((System.Windows.Controls.TextBox)(target));
            
            #line 118 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
            this.txtrooms.LostFocus += new System.Windows.RoutedEventHandler(this.txtrooms_LostFocus);
            
            #line default
            #line hidden
            
            #line 118 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
            this.txtrooms.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtstaydep = ((System.Windows.Controls.TextBox)(target));
            
            #line 122 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
            this.txtstaydep.LostFocus += new System.Windows.RoutedEventHandler(this.txtstaydep_LostFocus);
            
            #line default
            #line hidden
            
            #line 122 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
            this.txtstaydep.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 4:
            this.txttime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ok = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
            this.ok.Click += new System.Windows.RoutedEventHandler(this.ok_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cancel = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
            this.cancel.Click += new System.Windows.RoutedEventHandler(this.cancel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.pop1 = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 8:
            
            #line 149 "..\..\..\..\..\View\Operations\GroupCheckinDeparture.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

