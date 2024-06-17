﻿using System;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace SystemForAutData.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();

        public ReportPage()
        {
            InitializeComponent();
        }

        private void ExportDataClick(object sender, EventArgs e)
        {
            db.GetAllFilledData(DataGridDataView);
        }

        private void ExportUsersClick(object sender, EventArgs e)
        {
            db.GetAllUsers(DataGridDataView);
        }

        private void ExportOrgsClick(object sender, EventArgs e)
        {
            db.GetAllOrgs(DataGridDataView);
        }

        private void ExportCulturesClick(object sender, EventArgs e)
        {
            db.GetAllCultures(DataGridDataView);
        }

        private void ExportRequestsClick(object sender, EventArgs e)
        {
            db.GetAllRequests(DataGridDataView);
        }

        //Метод для экспорта данных
        private void Export(object sender, RoutedEventArgs e)
        {
            if (DataGridDataView.Items.Count == 0)
            {
                MessageBox.Show("Выберите данные, которые хотите выгрузить", "Не выбраны данные", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook workbook = exApp.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet ws = (Excel.Worksheet)exApp.ActiveSheet;

                for (int j = 0; j < DataGridDataView.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)ws.Cells[1, j + 1];
                    ws.Cells[1, j + 1].Font.Bold = true;
                    ws.Columns[j + 1].ColumnWidth = 20;
                    myRange.Value2 = DataGridDataView.Columns[j].Header;
                }
                for (int i = 0; i < DataGridDataView.Columns.Count; i++)
                {
                    for (int j = 0; j < DataGridDataView.Items.Count; j++)
                    {
                        TextBlock b = DataGridDataView.Columns[i].GetCellContent(DataGridDataView.Items[j]) as TextBlock;

                        if (b == null)
                            continue;

                        Excel.Range myRange = (Excel.Range)ws.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;
                    }
                }
                exApp.Visible = true;
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

        private void Go_ToViewDataPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ViewDataPage());
        }
    }
}
