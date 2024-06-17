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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public EditUserPage()
        {
            InitializeComponent();
            FillComboBoxes();

            ResourceDictionary resources = App.Current.Resources;
            int id = Convert.ToInt32((string)resources["id"]);
            db.GetInfoForUsers(id, out string familie, out string name, out string patronymic, out string email, out string phone, out string login, out string pass, out string org, out string role);
            familieTextBox.Text = familie;
            nameTextBox.Text = name;
            patronymicTextBox.Text = patronymic;
            emailTextBox.Text = email;
            phoneTextBox.Text = phone;
            loginTextBox.Text = login;
            cmbOrgs.SelectedItem = org;
            cmbRoles.SelectedItem = role;
        }

        private void EditUserClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(familieTextBox.Text) || string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(emailTextBox.Text) || string.IsNullOrEmpty(phoneTextBox.Text) || string.IsNullOrEmpty(loginTextBox.Text) || string.IsNullOrEmpty(passTextBox.Text))
            {
                MessageBox.Show("Не все поля заполнены. Должны быть заполнены обязательно поля Фамилия, Имя, Email, Телефон, Логин, Пароль", "Не все поля заполнены", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (cmbOrgs.SelectedItem == null || cmbRoles.SelectedItem == null)
            {
                MessageBox.Show("Не все поля заполнены. Должны быть выбраны Роль и Организация", "Не все поля заполнены", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ResourceDictionary resources = App.Current.Resources;
                int id = Convert.ToInt32((string)resources["id"]);
                string login = loginTextBox.Text;
                string pass = HashingData.HashData(passTextBox.Text);
                string name = familieTextBox.Text + " " + nameTextBox.Text;
                if (patronymicTextBox != null)
                {
                    name += " " + patronymicTextBox.Text;
                }
                string phone = phoneTextBox.Text;
                string email = emailTextBox.Text;
                int org = db.GetOrgIdByName(cmbOrgs.SelectedItem.ToString());
                int role = db.GetRoleIdByName(cmbRoles.SelectedItem.ToString());
                db.EditUser(id, login, pass, name, phone, email, org, role);
                NavigationPage.MainFrame.Navigate(new ViewUsersPage());
            }

        }

        private void DeleteUserClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ResourceDictionary resources = App.Current.Resources;
                int id = Convert.ToInt32((string)resources["id"]);
                db.DeleteUser(id);
                NavigationPage.MainFrame.Navigate(new ViewUsersPage());
            }

        }

        //Заполнение ComboBox
        private void FillComboBoxes()
        {
            db.FillOrganizationComboBox(cmbOrgs);
            db.FillRoleComboBox(cmbRoles);
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
