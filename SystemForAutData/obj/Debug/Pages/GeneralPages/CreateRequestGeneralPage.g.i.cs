﻿#pragma checksum "..\..\..\..\Pages\GeneralPages\CreateRequestGeneralPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FABE4E0AB4174B347D12B906A552F8222F13A5E472C60347F519DC8218CCA813"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ScottPlot;
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
using SystemForAutData.Pages.GeneralPages;


namespace SystemForAutData.Pages.GeneralPages {
    
    
    /// <summary>
    /// CreateRequestGeneralPage
    /// </summary>
    public partial class CreateRequestGeneralPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\Pages\GeneralPages\CreateRequestGeneralPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock orgTextBlock;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Pages\GeneralPages\CreateRequestGeneralPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxTheme;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Pages\GeneralPages\CreateRequestGeneralPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBoxRequest;
        
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
            System.Uri resourceLocater = new System.Uri("/SystemForAutData;component/pages/generalpages/createrequestgeneralpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\GeneralPages\CreateRequestGeneralPage.xaml"
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
            
            #line 28 "..\..\..\..\Pages\GeneralPages\CreateRequestGeneralPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToMainGeneralPage);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 30 "..\..\..\..\Pages\GeneralPages\CreateRequestGeneralPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToInfographicsGeneralPage);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 31 "..\..\..\..\Pages\GeneralPages\CreateRequestGeneralPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToControlAndReportGeneralPage);
            
            #line default
            #line hidden
            return;
            case 4:
            this.orgTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtBoxTheme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtBoxRequest = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 54 "..\..\..\..\Pages\GeneralPages\CreateRequestGeneralPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SendRequest);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

