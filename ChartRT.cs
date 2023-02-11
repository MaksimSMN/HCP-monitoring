using OPCAutomation;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataMonitoring
{
    public partial class ChartRT : Form
    {
        //Объявляем объекты OPC сервера, групп и элементов со ссылками на теги
        private OPCServer server;
        private OPCGroups opcGroups;
        private OPCGroup opcGroup;
        private OPCItem[] opcItem;

        //Объекты для хранения значений с опрошенных тегов
        Object input = null;
        Object quality = null;
        Object timeStamp = null;

        //Переменные для хранения Id параметра и места установки, имя тега
        string cbParameterId = "";
        string cbLocationId = "";
        string tagName = "";

        public ChartRT()
        {
            InitializeComponent();
        }
       
        private void ChartRT_Load(object sender, EventArgs e)
        {
            cbLocation.DataSource = DataFromDB.DsInstallationLocation.Tables["InstallationLocation"];
            cbLocation.DisplayMember = "InstallationLocationName";
            cbLocation.ValueMember = "InstallationLocationId";

            cbParameter.DataSource = DataFromDB.DsParameter.Tables["Parameter"];
            cbParameter.DisplayMember = "ParameterName";
            cbParameter.ValueMember = "ParameterId";

            server = new OPCServer(); // ServerState: OPCRunning = 1, OPCFailed = 2, OPCNoconfig = 3, OPCSuspended = 4, OPCTest = 5, OPCDisconnected = 6,
            if (server.ServerState == 6)
            {
                //Подключаемся к серверу
                server.Connect("InSAT.ModbusOPCServer.DA", "");
                opcGroups = server.OPCGroups;
                opcGroup = opcGroups.Add("Gr");
                //Период обновления значения элеменов группы в мс
                opcGroup.UpdateRate = 500;
                opcItem = new OPCItem[32];
            }
            
            //Задаем отображение осей на графике
            chartRunTime.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy\nHH:mm:ss";
            chartRunTime.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chartRunTime.ChartAreas[0].AxisX.ScaleView.MinSizeType = DateTimeIntervalType.Seconds;
            chartRunTime.ChartAreas[0].AxisX.ScaleView.MinSize = 25;
            chartRunTime.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            chartRunTime.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Seconds;
            chartRunTime.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            chartRunTime.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartRunTime.ChartAreas[0].AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Seconds;
            chartRunTime.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            chartRunTime.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;

            timerUpdateChart.Interval = 1000;

            AddNewLine();
        }

        private void ChartRT_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerUpdateChart.Stop();
            opcGroups.RemoveAll();
            server.Disconnect();
        }

        private void timerUpdateChart_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime date = DateTime.Now;

                labelTime.Text = date.ToString();
                chartRunTime.ChartAreas[0].AxisX.Maximum = date.AddSeconds(1).ToOADate();
                chartRunTime.ChartAreas[0].AxisX.Minimum = date.AddSeconds(-30).ToOADate();

                for (int i = 0; i < chartRunTime.Series.Count; i++)
                {
                    opcItem[i].Read(1, out input, out quality, out timeStamp);

                    if (Convert.ToInt32(quality) == 192)
                    {
                        chartRunTime.Series[i].Points.AddXY(date, Convert.ToDouble(input) / 10);
                    }
                    else
                    {
                        if (chartRunTime.Series[i].Points.Count>0)
                        chartRunTime.Series[i].Points[chartRunTime.Series[i].Points.Count-1].IsEmpty = true;
                    }

                    if (chartRunTime.Series[i].Points.Count > 50)
                        chartRunTime.Series[i].Points.RemoveAt(0);
                }
                this.chartRunTime.Update();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                timerUpdateChart.Stop();
                DialogResult res = MessageBox.Show("Нет связи с сервером. Окно графика текущих значений будет закрыто", "", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
       
        private void SetSeriesTransparency(Chart chart, byte alpha)
        {
            foreach (Series series in chart.Series)
            {
                series.Color = Color.Empty;
            }

            chart.ApplyPaletteColors();

            foreach (Series series in chart.Series)
            {
                    Color sc = series.Color;

                    if (series.ChartType == SeriesChartType.Area)
                    {
                        series.Color = Color.FromArgb(alpha, sc);
                        series.BorderColor = sc;
                        chartRunTime.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(alpha, sc);
                        chartRunTime.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(alpha, sc);
                    }
            }
        }

        private void btnOffUpdate_Click(object sender, EventArgs e)
        {
            if (timerUpdateChart.Enabled)
            {
                timerUpdateChart.Stop();
                btnOffUpdate.Text = "Включить";
            }
            else
            {
                if (chartRunTime.Series.Count>0)
                {
                    timerUpdateChart.Start();
                    btnOffUpdate.Text = "Выключить";
                }
            }
        }

        private void AddNewLine()
        {
            cbLocationId = cbLocation.SelectedValue.ToString();
            cbParameterId = cbParameter.SelectedValue.ToString();

            tagName = DataFromDB.GetTagName(cbLocationId, cbParameterId);

            cbLocationId = cbLocation.Text;
            cbParameterId = cbParameter.Text;
            bool newSeries = true;
            foreach (Series s in chartRunTime.Series)
            {
                if (s.Name == cbLocationId + "-" + cbParameterId)
                {
                    newSeries = false;
                    if (s.Enabled == false)
                        s.Enabled = true;
                }
            }
            if (newSeries)
            {
                Series series = new Series(cbLocationId + "-" + cbParameterId);
                series.BorderWidth = 3;
                series.ChartArea = "ChartArea1";
                series.ChartType = SeriesChartType.Area;
                series.Legend = "Legend2";
                series.MarkerStyle = MarkerStyle.Circle;
                series.IsValueShownAsLabel = true;
                chartRunTime.Series.Add(series);
                SetSeriesTransparency(chartRunTime, 40);
                opcItem[chartRunTime.Series.IndexOf(cbLocationId + "-" + cbParameterId)] = opcGroup.OPCItems.AddItem(tagName, opcGroup.ClientHandle);
            }
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            AddNewLine();
        }
        
        private void btnOffLine_Click(object sender, EventArgs e)
        {
            cbLocationId = cbLocation.Text;
            cbParameterId = cbParameter.Text;
            bool delSeries = false;
            foreach (Series s in chartRunTime.Series)
            {
                if (s.Name == cbLocationId + "-" + cbParameterId)
                    delSeries = true;
            }
            if (delSeries)
            {
                chartRunTime.Series[cbLocationId + "-" + cbParameterId].Enabled = false;
            }
        }
    }
}
