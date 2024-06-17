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
    /// Логика взаимодействия для ViewCulturesPage.xaml
    /// </summary>
    public partial class ViewCulturesPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public ViewCulturesPage()
        {
            InitializeComponent();

            db.FillCulturesForAdmin(DataGridCulturesView);
        }

        private void AddCultureClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cultureTextBox.Text))
            {
                MessageBox.Show("Должно быть заполнено поле Наименование культуры", "Не заполнены поля", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (cultureTextBox.Text.Length > 100)
            {
                MessageBox.Show("Наименование культуры не должно превышать 100 символов", "Наименование культуры", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string name = cultureTextBox.Text;
                db.SaveNewCultures(name);
                cultureTextBox.Clear();
                db.FillCulturesForAdmin(DataGridCulturesView);
            }
        }

        private void DataGrid_CellClicked(object sender, MouseButtonEventArgs e)
        {
            string id = ((DataRowView)DataGridCulturesView.SelectedItem).Row["Id"].ToString();
            App.Current.Resources["id"] = id;
            NavigationPage.MainFrame.Navigate(new EditCulturePage());
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
        private void Go_ToViewOrgsPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ViewOrgsPage());
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
