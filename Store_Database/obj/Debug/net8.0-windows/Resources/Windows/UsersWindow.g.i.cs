﻿#pragma checksum "..\..\..\..\..\Resources\Windows\UsersWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "922DD888CCE78F095D03A6C855AE614E6E6652FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Store_Database.Resources.Windows;
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


namespace Store_Database.Resources.Windows {
    
    
    /// <summary>
    /// UsersWindow
    /// </summary>
    public partial class UsersWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid UserGrid;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_Button;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LetGo_Button;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit_Button;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Report_Button;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Only_Employed_Button;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Only_Workers_Button;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Only_Managers_Button;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Filter_Name_Button;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Filter_Text;
        
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
            System.Uri resourceLocater = new System.Uri("/Store_Database;V1.0.0.0;component/resources/windows/userswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
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
            this.UserGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.Add_Button = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
            this.Add_Button.Click += new System.Windows.RoutedEventHandler(this.Add_Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LetGo_Button = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
            this.LetGo_Button.Click += new System.Windows.RoutedEventHandler(this.LetGo_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Edit_Button = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
            this.Edit_Button.Click += new System.Windows.RoutedEventHandler(this.Edit_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Report_Button = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
            this.Report_Button.Click += new System.Windows.RoutedEventHandler(this.Report_Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Only_Employed_Button = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
            this.Only_Employed_Button.Click += new System.Windows.RoutedEventHandler(this.Only_Employed_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Only_Workers_Button = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
            this.Only_Workers_Button.Click += new System.Windows.RoutedEventHandler(this.Only_Workers_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Only_Managers_Button = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
            this.Only_Managers_Button.Click += new System.Windows.RoutedEventHandler(this.Only_Managers_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Filter_Name_Button = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\..\Resources\Windows\UsersWindow.xaml"
            this.Filter_Name_Button.Click += new System.Windows.RoutedEventHandler(this.Filter_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Filter_Text = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

