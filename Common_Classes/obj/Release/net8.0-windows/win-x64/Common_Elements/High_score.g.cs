﻿#pragma checksum "..\..\..\..\..\Common_Elements\High_score.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18945321EED91F2DE90CD4170AE9F30FE8E4418F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
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
    /// High_score
    /// </summary>
    public partial class High_score : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\Common_Elements\High_score.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Cards;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Common_Elements\High_score.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Card_s;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Common_Elements\High_score.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PlayerDataGrid;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Common_Elements\High_score.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn Score_hedder;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Common_Elements\High_score.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Start_Game;
        
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
            System.Uri resourceLocater = new System.Uri("/Common_Classes;component/common_elements/high_score.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Common_Elements\High_score.xaml"
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
            this.Cards = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Card_s = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.PlayerDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.Score_hedder = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.Start_Game = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\..\Common_Elements\High_score.xaml"
            this.Start_Game.Click += new System.Windows.RoutedEventHandler(this.Close_BT_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
