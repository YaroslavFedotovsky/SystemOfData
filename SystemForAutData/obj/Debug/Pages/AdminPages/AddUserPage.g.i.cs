﻿#pragma checksum "..\..\..\..\Pages\AdminPages\AddUserPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AB1513B64F2B5CA0F27DDDD702E16FF75F1E901370E4B846D73851B97A574320"
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
    /// AddUserPage
    /// </summary>
    public partial class AddUserPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox familieTextBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patronymicTextBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox emailTextBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginTextBox;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passTextBox;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbOrgs;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbRoles;
        
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
            System.Uri resourceLocater = new System.Uri("/SystemForAutData;component/pages/adminpages/adduserpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
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
            
            #line 28 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToMainAdminPage);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 29 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToRequestsOfUsersPage);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 31 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToViewOrgsPage);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 32 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToViewCulturesPage);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 35 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToViewDataPage);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 36 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToReportPage);
            
            #line default
            #line hidden
            return;
            case 7:
            this.familieTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.patronymicTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.emailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.phoneTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.loginTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.passTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.cmbOrgs = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.cmbRoles = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 16:
            
            #line 88 "..\..\..\..\Pages\AdminPages\AddUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveUserClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

