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
    /// Логика взаимодействия для ViewOrgsPage.xaml
    /// </summary>
    public partial class ViewOrgsPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public ViewOrgsPage()
        {
            InitializeComponent();
            db.FillOrgsForAdmin(DataGridOrgsView);

        }

        private void AddOrgClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(orgNameTextBox.Text))
            {
                MessageBox.Show("Должно быть заполнено поле Название организации", "Не заполнены поля", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (orgNameTextBox.Text.Length > 100)
            {
                MessageBox.Show("Название организации не должно превышать 100 символов", "Название организации", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string orgName = orgNameTextBox.Text;
                db.SaveNewOrg(orgName);
                orgNameTextBox.Clear();
                db.FillOrgsForAdmin(DataGridOrgsView);
            }
        }

        private void DataGrid_CellClicked(object sender, MouseButtonEventArgs e)
        {
            string id = ((DataRowView)DataGridOrgsView.SelectedItem).Row["Id"].ToString();
            App.Current.Resources["id"] = id;
            NavigationPage.MainFrame.Navigate(new EditOrgPage());
        }

        //Методы навигации
        private void Go_ToMainAdminPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new MainAdminPage());
        }

        private void Go_ToRequestsOfUsersPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new RequestsOfUsersPage());
        }
        private void Go_ToViewUsersPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ViewUsersPage());
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
