﻿#pragma checksum "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DF766391B93497C7AB262E0CBF19BE374547EB8B2694CEF26E72324B792D948A"
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
using SystemForAutData.Pages.UserPages;


namespace SystemForAutData.Pages.UserPages {
    
    
    /// <summary>
    /// HarvestingUserPage
    /// </summary>
    public partial class HarvestingUserPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock orgTextBlock;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox valueBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCultures;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridPlanView;
        
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
            System.Uri resourceLocater = new System.Uri("/SystemForAutData;component/pages/userpages/harvestinguserpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
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
            
            #line 28 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToMainUserPage);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 29 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToMyRequestsUser);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 30 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToPlanUserPage);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 31 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToSittingUserPage);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 32 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToFeedingUserPage);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 33 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToChemicalRegimentUserPage);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 35 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_ToFilledDataUserPage);
            
            #line default
            #line hidden
            return;
            case 8:
            this.orgTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.valueBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.cmbCultures = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            
            #line 58 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveForms_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 62 "..\..\..\..\Pages\UserPages\HarvestingUserPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FillDataOfThisStage);
            
            #line default
            #line hidden
            return;
            case 13:
            this.DataGridPlanView = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

