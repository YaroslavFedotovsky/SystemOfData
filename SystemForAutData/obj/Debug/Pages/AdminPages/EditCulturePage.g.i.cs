﻿#pragma checksum "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "110C58178F14EAA1DFB0742624CEC026BD6E2E3BCE968E7200F83E7B86EE2C98"
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
using SystemForAutData.Pages.AdminPages;


namespace SystemForAutData.Pages.AdminPages {
    
    
    /// <summary>
    /// EditCulturePage
    /// </summary>
    public partial class EditCulturePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cultureTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/SystemForAutData;component/pages/adminpages/editculturepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml"
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
            
            #line 28 "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToMainAdminPage);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 29 "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToRequestsOfUsersPage);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 30 "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToViewUsersPage);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 31 "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToViewOrgsPage);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 35 "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToViewDataPage);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 36 "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToReportPage);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cultureTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 51 "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteCultureClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 54 "..\..\..\..\Pages\AdminPages\EditCulturePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditCultureClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

