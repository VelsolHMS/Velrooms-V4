﻿#pragma checksum "..\..\..\mainwindowpages\dashboard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E9B5A918AD9BE773E659D0BE9A0E46450C14DFB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
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
using VELROOMS.mainwindowpages;


namespace VELROOMS.mainwindowpages {
    
    
    /// <summary>
    /// dashboard
    /// </summary>
    public partial class dashboard : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\..\mainwindowpages\dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid reservationlist;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\mainwindowpages\dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid guestlist;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\mainwindowpages\dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtforentoffice;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\mainwindowpages\dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PENDINGONBOARD;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\mainwindowpages\dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TAX;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\mainwindowpages\dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid taxcode;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\mainwindowpages\dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid companypendingdash;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\mainwindowpages\dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock POSTCHRGES;
        
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
            System.Uri resourceLocater = new System.Uri("/HMS;component/mainwindowpages/dashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\mainwindowpages\dashboard.xaml"
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
            this.reservationlist = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.guestlist = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.txtforentoffice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.PENDINGONBOARD = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TAX = ((System.Windows.Controls.ComboBox)(target));
            
            #line 135 "..\..\..\mainwindowpages\dashboard.xaml"
            this.TAX.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 6:
            this.taxcode = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.companypendingdash = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.POSTCHRGES = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

