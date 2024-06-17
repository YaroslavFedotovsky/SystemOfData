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
    /// Логика взаимодействия для ViewDataPage.xaml
    /// </summary>
    public partial class ViewDataPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public ViewDataPage()
        {
            InitializeComponent();
            FillOrganizationComboBox();
        }

        private void FillOrganizationComboBox()
        {
            // Вызываем метод из класса базы данных
            db.FillOrganizationComboBox(comboBoxOrganization);
        }

        private void ViewDataInOrg(object sender, EventArgs e)
        {
            // Проверяем, что выбрана организация
            if (comboBoxOrganization.SelectedItem != null)
            {
                // Получаем выбранное имя организации из ComboBox
                string selectedOrganization = comboBoxOrganization.SelectedItem.ToString();

                // Вызываем метод для отображения форм для выбранной организации и обновления DataGrid
                db.DisplayData(selectedOrganization, DataGridDataView);

                this.DataGridDataView.Columns[1].Header = "Вид работы";
                this.DataGridDataView.Columns[2].Header = "Выращиваемая культура";
                this.DataGridDataView.Columns[3].Header = "Объем работ, га";
                this.DataGridDataView.Columns[4].Header = "Дата";

                this.DataGridDataView.Columns[0].Width = 40;
                this.DataGridDataView.Columns[1].Width = 100;
                this.DataGridDataView.Columns[2].Width = 100;
                this.DataGridDataView.Columns[3].Width = 100;
                this.DataGridDataView.Columns[4].Width = 100;
            }
            else
            {
                MessageBox.Show("Выберите организацию, у которой хотите посмотреть данные", "Не выбрана организация", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DataGrid_CellClicked(object sender, MouseButtonEventArgs e)
        {
            string id = ((DataRowView)DataGridDataView.SelectedItem).Row["Id"].ToString();
            App.Current.Resources["id"] = id;
            NavigationPage.MainFrame.Navigate(new EditDataPage());
        }

        private void Go_ToAddDataPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new AddDataPage());
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
