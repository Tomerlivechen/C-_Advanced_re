﻿#pragma checksum "..\..\..\..\Common_Elements\Input_box.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EDE9DAE4D7EB7E17ED164F872D3E1479E6FABB87"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Common_Classes.Common_Elements;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Common_Classes.Common_Elements {
    
    
    /// <summary>
    /// Input_box
    /// </summary>
    public partial class Input_box : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\Common_Elements\Input_box.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Title;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Common_Elements\Input_box.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Inputs;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Common_Elements\Input_box.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Field1_lable;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Common_Elements\Input_box.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Field1_TB;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Common_Elements\Input_box.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Field2_lable;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Common_Elements\Input_box.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Field2_TB;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Common_Elements\Input_box.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Field3_lable;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Common_Elements\Input_box.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Field3_TB;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Common_Elements\Input_box.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Submit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Common_Classes;component/common_elements/input_box.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Common_Elements\Input_box.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Inputs = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.Field1_lable = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Field1_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Field2_lable = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Field2_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Field3_lable = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Field3_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Submit = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Common_Elements\Input_box.xaml"
            this.Submit.Click += new System.Windows.RoutedEventHandler(this.Submit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

