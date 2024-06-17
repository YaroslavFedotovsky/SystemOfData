using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SystemForAutData.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для RequestsOfUsersPage.xaml
    /// </summary>
    public partial class RequestsOfUsersPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public RequestsOfUsersPage()
        {
            InitializeComponent();
            db.FillAllNewRequests(DataGridNewRequestView);
        }

        private void DataGrid_CellClicked(object sender, MouseButtonEventArgs e)
        {
            string id = ((DataRowView)DataGridNewRequestView.SelectedItem).Row["Id"].ToString();
            App.Current.Resources["id"] = id;
            NavigationPage.MainFrame.Navigate(new EditRequestPage());
        }


        private void Go_ToViewAllRequestPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ViewAllRequestPage());
        }

        //Методы навигации
        private void Go_ToMainAdminPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new MainAdminPage());
        }

        private void Go_ToViewUsersPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ViewUsersPage());
        }
        private void Go_ToViewOrgsPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ViewOrgsPage());
        }
        private void Go_ToViewCulturesPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ViewCulturesPage());
        }
        private void Go_ToViewDataPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ViewDataPage());
        }

        private void Go_ToReportPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ReportPage());
        }
    }
}
