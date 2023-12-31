﻿#pragma checksum "..\..\..\Views\ListCertificatesView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CE0B6EB461ECFE34580A7C88A1C123841D2CA36141E5EB0C70131032EB85BE79"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Caliburn.Micro;
using GroupManager.Views;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
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


namespace GroupManager.Views {
    
    
    /// <summary>
    /// ListCertificatesView
    /// </summary>
    public partial class ListCertificatesView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\Views\ListCertificatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridLayout;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Views\ListCertificatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Views\ListCertificatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock placeholderTextBlock;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Views\ListCertificatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Views\ListCertificatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewCertificates;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\Views\ListCertificatesView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView StudentsList;
        
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
            System.Uri resourceLocater = new System.Uri("/GroupManager;component/views/listcertificatesview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ListCertificatesView.xaml"
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
            this.GridLayout = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Back = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.placeholderTextBlock = ((System.Windows.Controls.TextBlock)(target));
            
            #line 88 "..\..\..\Views\ListCertificatesView.xaml"
            this.placeholderTextBlock.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.placeholderTextBlock_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 95 "..\..\..\Views\ListCertificatesView.xaml"
            this.searchTextBox.PreviewGotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.TextBox_PreviewGotKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 96 "..\..\..\Views\ListCertificatesView.xaml"
            this.searchTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddNewCertificates = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.StudentsList = ((System.Windows.Controls.ListView)(target));
            
            #line 141 "..\..\..\Views\ListCertificatesView.xaml"
            this.StudentsList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.StudentsList_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

