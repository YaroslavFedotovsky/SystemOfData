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
    /// Логика взаимодействия для EditCulturePage.xaml
    /// </summary>
    public partial class EditCulturePage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public EditCulturePage()
        {
            InitializeComponent();

            ResourceDictionary resources = App.Current.Resources;
            int id = Convert.ToInt32((string)resources["id"]);
            db.GetCultureById(id, out string name);
            cultureTextBox.Text = name;
        }

        //Редактирование культуры
        private void EditCultureClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cultureTextBox.Text))
            {
                MessageBox.Show("Должны быть заполнены все поля (Наименование культуры)", "Не заполнены поля", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ResourceDictionary resources = App.Current.Resources;
                int id = Convert.ToInt32((string)resources["id"]);
                string name = cultureTextBox.Text;
                db.EditCultures(id, name);
                NavigationPage.MainFrame.Navigate(new ViewCulturesPage());
            }
        }

        //Удаление культуры
        private void DeleteCultureClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить культуру?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ResourceDictionary resources = App.Current.Resources;
                int id = Convert.ToInt32((string)resources["id"]);
                db.DeleteCultures(id);
                NavigationPage.MainFrame.Navigate(new ViewCulturesPage());
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
