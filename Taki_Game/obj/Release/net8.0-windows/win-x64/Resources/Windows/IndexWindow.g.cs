﻿#pragma checksum "..\..\..\..\..\..\Resources\Windows\IndexWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DE067351BDBBEBB24A062E6ABB3A177B420A3729"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
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
using Taki_Game;


namespace Taki_Game {
    
    
    /// <summary>
    /// IndexWindow
    /// </summary>
    public partial class IndexWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\..\Resources\Windows\IndexWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Taki_Game.IndexWindow Index_Window;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\..\Resources\Windows\IndexWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Player_amount;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\..\Resources\Windows\IndexWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Taki_Game;component/resources/windows/indexwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Resources\Windows\IndexWindow.xaml"
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
            this.Index_Window = ((Taki_Game.IndexWindow)(target));
            return;
            case 2:
            
            #line 28 "..\..\..\..\..\..\Resources\Windows\IndexWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_action);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 31 "..\..\..\..\..\..\Resources\Windows\IndexWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.About_action);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Player_amount = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Start_Game = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\..\..\Resources\Windows\IndexWindow.xaml"
            this.Start_Game.Click += new System.Windows.RoutedEventHandler(this.Start_Game_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
