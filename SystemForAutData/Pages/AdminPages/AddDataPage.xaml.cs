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
    /// Логика взаимодействия для AddDataPage.xaml
    /// </summary>
    public partial class AddDataPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public AddDataPage()
        {
            InitializeComponent();
            LoadCultures();
            FillComboBoxes();
        }

        private void SaveDataClick(object sender, RoutedEventArgs e)
        {
            if (comboBoxOrganization.SelectedItem == null || cultureComboBox.SelectedItem == null || stageComboBox.SelectedItem == null || valueTextBox.Text == null)
            {
                MessageBox.Show("Должны быть заполнены все данные (Организация, Культура, Стадия, Объем)", "Не заполнены данные", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    int orgId = db.GetOrgIdByName(comboBoxOrganization.SelectedItem.ToString());
                    int cultId = db.GetCultureIdByName(cultureComboBox.SelectedItem.ToString());
                    int stageId = db.GetStageIdByName(stageComboBox.SelectedItem.ToString());
                    int value = Convert.ToInt32(valueTextBox.Text);

                    db.SaveForms(orgId, stageId, cultId, value);
                    NavigationPage.MainFrame.Navigate(new ViewDataPage());
                }
                catch { MessageBox.Show("Данные должны быть введены без лишних символов", "Некорректные данные", MessageBoxButton.OK, MessageBoxImage.None); }
            }

        }

        private void FillComboBoxes()
        {
            db.FillOrganizationComboBox(comboBoxOrganization);
            db.FillStageComboBox(stageComboBox);
        }

        private void LoadCultures()
        {
            try
            {
                // Получаем данные о культурах из базы данных
                DataTable culturesTable = db.GetCultures();

                // Проходим по строкам DataTable и добавляем значения в ComboBox
                foreach (DataRow row in culturesTable.Rows)
                {
                    cultureComboBox.Items.Add(row["culture_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке культур: " + ex.Message);
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
        private void Go_ToViewCulturesPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ViewCulturesPage());
        }

        private void Go_ToReportPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ReportPage());
        }
    }
}
