﻿#pragma checksum "..\..\Stammdaten.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ACA3F5F1D1C8994A71DA1E076E7B8A59"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
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


namespace AufträgeOrgadata {
    
    
    /// <summary>
    /// Stammdaten
    /// </summary>
    public partial class Stammdaten : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Stammdaten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvStammDaten;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Stammdaten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menu;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Stammdaten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mAdd;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Stammdaten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mChange;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Stammdaten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mDelete;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Stammdaten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mSearch;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Stammdaten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mClose;
        
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
            System.Uri resourceLocater = new System.Uri("/AufträgeOrgadata;component/stammdaten.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Stammdaten.xaml"
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
            this.lvStammDaten = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.menu = ((System.Windows.Controls.Menu)(target));
            
            #line 25 "..\..\Stammdaten.xaml"
            this.menu.Loaded += new System.Windows.RoutedEventHandler(this.PWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mAdd = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 4:
            this.mChange = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 5:
            this.mDelete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 37 "..\..\Stammdaten.xaml"
            this.mDelete.Click += new System.Windows.RoutedEventHandler(this.mDelete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.mSearch = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 7:
            this.mClose = ((System.Windows.Controls.MenuItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

