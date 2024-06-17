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
    /// Логика взаимодействия для EditRequestPage.xaml
    /// </summary>
    public partial class EditRequestPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public EditRequestPage()
        {
            InitializeComponent();
            ResourceDictionary resources = App.Current.Resources;
            int id = Convert.ToInt32((string)resources["id"]);
            db.SelectDataOfRequestForId(id, out string userName, out string date, out string theme, out string text);
            userRequestTextBlock.Text = userName;
            dateRequestTextBlock.Text = date;
            themeRequestTextBlock.Text = theme;
            textRequestTextBlock.Text = text;
        }

        private void CompleteRequest(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(commentTextBox.Text))
            {
                MessageBox.Show("Оставьте комментарий о решении", "Нет комментария", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (commentTextBox.Text.Length > 300)
            {
                MessageBox.Show("Превышено количество символов. Комментарий должен быть не длиннее 300 символов", "Превышена норма длины", MessageBoxButton.OK, MessageBoxImage.None);
            }
            else
            {
                ResourceDictionary resources = App.Current.Resources;
                int id = Convert.ToInt32((string)resources["id"]);
                string comment = commentTextBox.Text;
                db.CompletingRequest(comment, id);
                MessageBox.Show("Заявка успешно выполнена", "Заявка выполнена", MessageBoxButton.OK, MessageBoxImage.None);
                NavigationPage.MainFrame.Navigate(new RequestsOfUsersPage());
            }
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
