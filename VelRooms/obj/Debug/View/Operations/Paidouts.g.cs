﻿#pragma checksum "..\..\..\..\View\Operations\Paidouts.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1CA0E918B1C9E927DB3357881B4E867ABF15D751"
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
using System.Windows.Interactivity;
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
    /// Paidouts
    /// </summary>
    public partial class Paidouts : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 107 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CB;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtn1;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtn2;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock pagename;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtvochernumber;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtauthorization;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtamount;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtparticualr;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel paytype_sp;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbpaytype;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearall;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup pop1;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popup_insert;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\..\View\Operations\Paidouts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button insertpop;
        
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
            System.Uri resourceLocater = new System.Uri("/HMS;component/view/operations/paidouts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Operations\Paidouts.xaml"
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
            this.CB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.rbtn1 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 110 "..\..\..\..\View\Operations\Paidouts.xaml"
            this.rbtn1.Checked += new System.Windows.RoutedEventHandler(this.rbtn1_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rbtn2 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 111 "..\..\..\..\View\Operations\Paidouts.xaml"
            this.rbtn2.Checked += new System.Windows.RoutedEventHandler(this.rbtn2_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pagename = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtvochernumber = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txtauthorization = ((System.Windows.Controls.TextBox)(target));
            
            #line 127 "..\..\..\..\View\Operations\Paidouts.xaml"
            this.txtauthorization.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtamount = ((System.Windows.Controls.TextBox)(target));
            
            #line 131 "..\..\..\..\View\Operations\Paidouts.xaml"
            this.txtamount.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtparticualr = ((System.Windows.Controls.TextBox)(target));
            
            #line 135 "..\..\..\..\View\Operations\Paidouts.xaml"
            this.txtparticualr.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.Validation_Error));
            
            #line default
            #line hidden
            return;
            case 9:
            this.paytype_sp = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.cbpaytype = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.clearall = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\..\..\View\Operations\Paidouts.xaml"
            this.clearall.Click += new System.Windows.RoutedEventHandler(this.clear_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Save = ((System.Windows.Controls.Button)(target));
            
            #line 151 "..\..\..\..\View\Operations\Paidouts.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.pop1 = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 14:
            
            #line 169 "..\..\..\..\View\Operations\Paidouts.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.popup_insert = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 16:
            this.insertpop = ((System.Windows.Controls.Button)(target));
            
            #line 199 "..\..\..\..\View\Operations\Paidouts.xaml"
            this.insertpop.Click += new System.Windows.RoutedEventHandler(this.insertpop_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

