﻿#pragma checksum "..\..\..\..\Windows\Random_image.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E1D235364A585FE6F0F02936042A06F5C4B9C9EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using API_Animal_Pics.Windows;
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
using WpfAnimatedGif;


namespace API_Animal_Pics.Windows {
    
    
    /// <summary>
    /// Random_image
    /// </summary>
    public partial class Random_image : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\Windows\Random_image.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Status_Bar;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Windows\Random_image.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Animal_pic;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Windows\Random_image.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Loading_pic;
        
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
            System.Uri resourceLocater = new System.Uri("/API_Animal_Pics;V1.0.0.0;component/windows/random_image.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Random_image.xaml"
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
            
            #line 27 "..\..\..\..\Windows\Random_image.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_image_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 28 "..\..\..\..\Windows\Random_image.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_image_list_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 29 "..\..\..\..\Windows\Random_image.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Status_Bar = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 36 "..\..\..\..\Windows\Random_image.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_ClickAsync);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 37 "..\..\..\..\Windows\Random_image.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_ClickAsync);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 38 "..\..\..\..\Windows\Random_image.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_ClickAsync);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 39 "..\..\..\..\Windows\Random_image.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_ClickAsync);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Animal_pic = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.Loading_pic = ((System.Windows.Controls.Image)(target));
            return;
            case 11:
            
            #line 43 "..\..\..\..\Windows\Random_image.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_image_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

