﻿#pragma checksum "..\..\..\Admin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BBDBB71D734DC07D6EE95D7B1DD0E0BB2882D123"
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


namespace Ticket2Help {
    
    
    /// <summary>
    /// Admin
    /// </summary>
    public partial class Admin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReply;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDetails;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCheckUsers;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDashboard;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Admin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSair;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Ticket2Help;component/admin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Admin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.listView = ((System.Windows.Controls.ListView)(target));
            
            #line 12 "..\..\..\Admin.xaml"
            this.listView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnReply = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Admin.xaml"
            this.btnReply.Click += new System.Windows.RoutedEventHandler(this.btnReply_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDetails = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Admin.xaml"
            this.btnDetails.Click += new System.Windows.RoutedEventHandler(this.btnDetails_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCheckUsers = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Admin.xaml"
            this.btnCheckUsers.Click += new System.Windows.RoutedEventHandler(this.btnCheckUsers_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDashboard = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Admin.xaml"
            this.btnDashboard.Click += new System.Windows.RoutedEventHandler(this.btnDashboard_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnSair = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Admin.xaml"
            this.btnSair.Click += new System.Windows.RoutedEventHandler(this.btnSair_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

