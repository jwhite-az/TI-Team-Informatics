﻿#pragma checksum "..\..\..\UserControl1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7E256B16464925273A9B62FFFFD096CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace OperationSpan {
    
    
    /// <summary>
    /// UserControl1
    /// </summary>
    public partial class UserControl1 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel cp_side_navigation;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_template1;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel cp_mainwindow_navigation;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_get_intro_page;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_get_survey_page;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_get_game_page;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_get_visualization;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid cp_mainwindow;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\UserControl1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel cp_mainwindow_footer;
        
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
            System.Uri resourceLocater = new System.Uri("/OperationSpan;component/usercontrol1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControl1.xaml"
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
            this.cp_side_navigation = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.button_template1 = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\UserControl1.xaml"
            this.button_template1.Click += new System.Windows.RoutedEventHandler(this.set_button_navigation);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cp_mainwindow_navigation = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.button_get_intro_page = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\UserControl1.xaml"
            this.button_get_intro_page.Click += new System.Windows.RoutedEventHandler(this.get_intro_page);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button_get_survey_page = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\UserControl1.xaml"
            this.button_get_survey_page.Click += new System.Windows.RoutedEventHandler(this.get_survey_page);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button_get_game_page = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\UserControl1.xaml"
            this.button_get_game_page.Click += new System.Windows.RoutedEventHandler(this.get_game_page);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button_get_visualization = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\UserControl1.xaml"
            this.button_get_visualization.Click += new System.Windows.RoutedEventHandler(this.get_visualization);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cp_mainwindow = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.cp_mainwindow_footer = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

