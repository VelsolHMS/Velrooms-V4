﻿#pragma checksum "..\..\..\View\PreLoaderControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6E032931B6BA240C219FAE045331B8828B93D4E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PreLoader.CustomControls;
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


namespace PreLoader.CustomControls {
    
    
    /// <summary>
    /// PreLoaderControl
    /// </summary>
    public partial class PreLoaderControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\View\PreLoaderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridBlock1;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View\PreLoaderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PreLoader.CustomControls.Block block1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\PreLoaderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridBlock2;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\PreLoaderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PreLoader.CustomControls.Block block2;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\PreLoaderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridBlock3;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\View\PreLoaderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PreLoader.CustomControls.Block block3;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\View\PreLoaderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridBlock4;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\View\PreLoaderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PreLoader.CustomControls.Block block4;
        
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
            System.Uri resourceLocater = new System.Uri("/HMS;component/view/preloadercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\PreLoaderControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 4 "..\..\..\View\PreLoaderControl.xaml"
            ((PreLoader.CustomControls.PreLoaderControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 8 "..\..\..\View\PreLoaderControl.xaml"
            ((System.Windows.Media.Animation.DoubleAnimation)(target)).Completed += new System.EventHandler(this.ProgressAnimation1_Completed);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 12 "..\..\..\View\PreLoaderControl.xaml"
            ((System.Windows.Media.Animation.DoubleAnimation)(target)).Completed += new System.EventHandler(this.ProgressAnimation2_Completed);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 16 "..\..\..\View\PreLoaderControl.xaml"
            ((System.Windows.Media.Animation.DoubleAnimation)(target)).Completed += new System.EventHandler(this.ProgressAnimation3_Completed);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 20 "..\..\..\View\PreLoaderControl.xaml"
            ((System.Windows.Media.Animation.DoubleAnimation)(target)).Completed += new System.EventHandler(this.ProgressAnimation4_Completed);
            
            #line default
            #line hidden
            return;
            case 6:
            this.gridBlock1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.block1 = ((PreLoader.CustomControls.Block)(target));
            return;
            case 8:
            this.gridBlock2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.block2 = ((PreLoader.CustomControls.Block)(target));
            return;
            case 10:
            this.gridBlock3 = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.block3 = ((PreLoader.CustomControls.Block)(target));
            return;
            case 12:
            this.gridBlock4 = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.block4 = ((PreLoader.CustomControls.Block)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

