﻿#pragma checksum "..\..\Kunde.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6B99482E0B4A137D1E8179F6D87E1B79"
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
    /// Kunde
    /// </summary>
    public partial class Kunde : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\Kunde.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu menuKunde;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Kunde.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem data;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Kunde.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem add;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Kunde.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem edit;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Kunde.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem delete;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\Kunde.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem search;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\Kunde.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem close;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\Kunde.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvKunde;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Kunde.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem eintragen;
        
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
            System.Uri resourceLocater = new System.Uri("/AufträgeOrgadata;component/kunde.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Kunde.xaml"
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
            
            #line 10 "..\..\Kunde.xaml"
            ((AufträgeOrgadata.Kunde)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.menuKunde = ((System.Windows.Controls.Menu)(target));
            return;
            case 3:
            this.data = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 4:
            this.add = ((System.Windows.Controls.MenuItem)(target));
            
            #line 52 "..\..\Kunde.xaml"
            this.add.Click += new System.Windows.RoutedEventHandler(this.add_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.edit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 63 "..\..\Kunde.xaml"
            this.edit.Click += new System.Windows.RoutedEventHandler(this.edit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.delete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 74 "..\..\Kunde.xaml"
            this.delete.Click += new System.Windows.RoutedEventHandler(this.delete_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.search = ((System.Windows.Controls.MenuItem)(target));
            
            #line 86 "..\..\Kunde.xaml"
            this.search.Click += new System.Windows.RoutedEventHandler(this.search_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.close = ((System.Windows.Controls.MenuItem)(target));
            
            #line 99 "..\..\Kunde.xaml"
            this.close.Click += new System.Windows.RoutedEventHandler(this.close_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.lvKunde = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.eintragen = ((System.Windows.Controls.MenuItem)(target));
            
            #line 122 "..\..\Kunde.xaml"
            this.eintragen.Click += new System.Windows.RoutedEventHandler(this.cmeintragen_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

