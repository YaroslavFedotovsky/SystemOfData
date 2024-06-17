using ScottPlot;
using ScottPlot.WPF;
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
using Color = System.Drawing.Color;

namespace SystemForAutData.Pages.GeneralPages
{
    /// <summary>
    /// Логика взаимодействия для InfographicsGeneralPage.xaml
    /// </summary>
    public partial class InfographicsGeneralPage : Page
    {
        DatabaseConnect db = new DatabaseConnect();
        
        public InfographicsGeneralPage()
        {
            InitializeComponent();
            db.FillOrganizationComboBox(comboBoxOrganization);
            LoadCultures();

            ResourceDictionary resources = App.Current.Resources;
            orgTextBlock.Text = (string)resources["organizationName"];

        }

        private void LoadDataForTextBlocks(object sender, RoutedEventArgs e)
        {
            if(cultureComboBox.SelectedItem == null || comboBoxOrganization.SelectedItem == null)
            {
                MessageBox.Show("Должны быть заполнены все данные (Организация и Культура)", "Не все поля заполнены", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int cultId = db.GetCultureIdByName(cultureComboBox.SelectedItem.ToString());
                int orgId = db.GetOrgIdByName(comboBoxOrganization.SelectedItem.ToString());
                int stageId = db.GetNowStageId(orgId, cultId);
                int val = db.GetPlanOfNowStage(orgId, cultId);
                db.GetNowStageAndValue(orgId, cultId, stageId, out string stage, out string value);
                stageNow.Text = stage;
                valueOfStageNow.Text = val.ToString();
                PlotStatsAllStageFilling(orgId, cultId);
                PlotPercentPieFilling(orgId, cultId, value);
                PlotStatsInYearsFilling(orgId, cultId);
            }
            
        }

        private void PlotStatsAllStageFilling(int orgId, int cultId)
        {
            db.GetDataForFirstPlot(orgId, cultId, out double[] valueFirst);
            
            var bar = PlotStatsAllStage.Plot.AddBar(valueFirst);
            bar.ShowValuesAboveBars = true;

            PlotStatsAllStage.Plot.SetAxisLimits(yMin: 0);
            PlotStatsAllStage.Plot.Style(figureBackground: Color.AntiqueWhite);
            PlotStatsAllStage.Refresh();
        }

        private void PlotPercentPieFilling(int orgId, int cultId, string value)
        {
            double values = Convert.ToDouble(value);
            double plan = db.GetNowPlanValue(orgId, cultId);
            double[] val = {values, plan};

            string centerText = $"{values / plan * 100:00.0}%";
            Color color1 = Color.FromArgb(209, 152, 38, 255);
            Color color2 = Color.FromArgb(82, 58, 11, 255);

            var pie = PlotPercentPie.Plot.AddPie(val);
            pie.DonutSize = .6;
            pie.DonutLabel = centerText;
            pie.CenterFont.Color = color1;
            pie.OutlineSize = 2;
            pie.SliceFillColors = new Color[] { color1, color2 };
            PlotPercentPie.Plot.Style(figureBackground: Color.AntiqueWhite);
            PlotPercentPie.Refresh();
        }

        private void PlotStatsInYearsFilling(int orgId, int cultId)
        {
            db.GetFiveYearsPlanValue(orgId, cultId, out double[] value, out string[] years);

            double[] y = new double[] { 1, 2, 3, 4, 5 };
            PlotStatsInYears.Plot.AddScatter(y, value);
            PlotStatsInYears.Plot.XTicks(years);

            PlotStatsInYears.Plot.XLabel("Года");
            PlotStatsInYears.Plot.YLabel("Объем работ");
            PlotStatsInYears.Plot.Style(figureBackground: Color.AntiqueWhite);
            PlotStatsInYears.Refresh();
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
        private void Go_ToMainGeneralPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new MainGeneralPage());
        }

        private void Go_ToMyRequestGeneral(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new MyRequestGeneral());
        }

        private void Go_ToControlAndReportGeneralPage(object sender, EventArgs e)
        {
            NavigationPage.MainFrame.Navigate(new ControlAndReportGeneralPage());
        }
    }
}
