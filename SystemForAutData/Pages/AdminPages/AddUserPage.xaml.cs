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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public AddUserPage()
        {
            InitializeComponent();
            FillComboBoxes();
        }

        //Заполнение ComboBox
        private void FillComboBoxes()
        {
            db.FillOrganizationComboBox(cmbOrgs);
            db.FillRoleComboBox(cmbRoles);
        }

        //Сохранение нового пользователя в базу данных
        private void SaveUserClick(object sender, RoutedEventArgs e)
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
                string name;
                if (string.IsNullOrEmpty(patronymicTextBox.Text))
                {
                    name = familieTextBox.Text + " " + nameTextBox.Text;
                }
                else
                {
                    name = familieTextBox.Text + " " + nameTextBox.Text + " " + patronymicTextBox.Text;
                }
                string email = emailTextBox.Text;
                string phone = phoneTextBox.Text;
                string login = loginTextBox.Text;
                string pass = HashingData.HashData(passTextBox.Text);
                int orgId = db.GetOrgIdByName(cmbOrgs.SelectedItem.ToString());
                int roleId = db.GetRoleIdByName(cmbRoles.SelectedItem.ToString());
                db.SaveNewUser(login, pass, name, phone, email, orgId, roleId);
                MessageBox.Show("Пользователь успешно добавлен");
                NavigationPage.MainFrame.Navigate(new ViewUsersPage());
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
