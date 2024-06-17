using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для EditOrgPage.xaml
    /// </summary>
    public partial class EditOrgPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public EditOrgPage()
        {
            InitializeComponent();

            ResourceDictionary resources = App.Current.Resources;
            int id = Convert.ToInt32((string)resources["id"]);
            db.GetOrgById(id, out string orgName);
            orgNameTextBox.Text = orgName;
        }

        //Редактирование организации
        private void EditOrgClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(orgNameTextBox.Text))
            {
                MessageBox.Show("Должны быть заполнены все поля (Название организации)", "Не заполнены поля", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ResourceDictionary resources = App.Current.Resources;
                int id = Convert.ToInt32((string)resources["id"]);
                string orgName = orgNameTextBox.Text;
                db.EditOrgs(id, orgName);
                NavigationPage.MainFrame.Navigate(new ViewOrgsPage());
            }
        }

        //Удаление организации
        private void DeleteOrgClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить организацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ResourceDictionary resources = App.Current.Resources;
                int id = Convert.ToInt32((string)resources["id"]);
                db.DeleteOrgs(id);
                NavigationPage.MainFrame.Navigate(new ViewOrgsPage());
            }
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
