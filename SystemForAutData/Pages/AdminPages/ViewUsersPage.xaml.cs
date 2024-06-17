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
    /// Логика взаимодействия для ViewUsersPage.xaml
    /// </summary>
    public partial class ViewUsersPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public ViewUsersPage()
        {
            InitializeComponent();
            FillOrganizationComboBox();
        }

        private void FillOrganizationComboBox()
        {
            // Вызываем метод из класса базы данных
            db.FillOrganizationComboBox(comboBoxOrganization);
        }

        private void ViewUsersInOrg(object sender, EventArgs e)
        {
            // Проверяем, что выбрана организация
            if (comboBoxOrganization.SelectedItem != null)
            {
                // Получаем выбранное имя организации из ComboBox
                string selectedOrganization = comboBoxOrganization.SelectedItem.ToString();

                // Вызываем метод для отображения форм для выбранной организации и обновления DataGrid
                db.FillUsers(selectedOrganization, DataGridUsersView);
            }
            else
            {
                MessageBox.Show("Выберите организацию, у которой хотите посмотреть данные", "Не выбрана организация", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DataGrid_CellClicked(object sender, MouseButtonEventArgs e)
        {
            string id = ((DataRowView)DataGridUsersView.SelectedItem).Row["Id"].ToString();
            App.Current.Resources["id"] = id;
            NavigationPage.MainFrame.Navigate(new EditUserPage());
        }

        private void Go_ToAddUserPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new AddUserPage());
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
