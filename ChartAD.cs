using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataMonitoring
{
    public partial class ChartAD : Form
    {
        //Предназначены для сохранения выбранного в ComboBox параметра пользователем
        string cbParameterId = "";
        string cbLocationId = "";

        //Хранит номер тега. Тип string для запроса
        string tagId = "";

        //Хранит "связь" тега с данными соответствующей серии на графике
        Dictionary<string, string> TagIdSeries = new Dictionary<string, string>();

        //Хранит ссылку на метод закрытия формы 
        public delegate void InvokeDelegate();

        public ChartAD()
        {
            InitializeComponent();
        }

        private void GraficAD_Load(object sender, EventArgs e)
        {
            //Заполняем данными ComboBox и добавляем на график одну серию
            FillingComboBoxAndAddNewSeries();
            //Ограничиваем максимальную дату dateTimePicker сегодняшним днем
            dateTimePicker.MaxDate = DateTime.Today;

            //Формат меток оси Х
            chartDataArchive.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy\nHH:mm:ss";
            chartDataArchive.ChartAreas[0].AxisY.Minimum = 0;

            //Отключаем масштабирование
            foreach (Axis axis in chartDataArchive.ChartAreas[0].Axes)
            {
                axis.ScaleView.Zoomable = false;
            }
        }

        //Метод заполняет данными ComboBox и добавляет на график одну серию
        private void FillingComboBoxAndAddNewSeries()
        {
            try
            {
                //Выводим значение таблицы места установки в выпадающий список ComboBox
                cbLocation.DataSource = DataFromDB.GetDsInstallationLocation().Tables["InstallationLocation"];
                cbLocation.DisplayMember = "InstallationLocationName";
                cbLocation.ValueMember = "InstallationLocationId";

                //Выводим значение таблицы параметр в выпадающий список ComboBox
                cbParameter.DataSource = DataFromDB.GetDsParameter().Tables["Parameter"];
                cbParameter.DisplayMember = "ParameterName";
                cbParameter.ValueMember = "ParameterId";
                
                //AddNewSeries();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message + "\nНарушена структура базы данных\nОткрыть базу данных?", "Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //Выбираем базу данных и изменяем строку подключения
                    DataFromDB.ChangeDBandConnString();
                    FillingComboBoxAndAddNewSeries();
                }
                if (result == DialogResult.No)
                    //Закрываем приложение
                    this.BeginInvoke(new InvokeDelegate(CloseTheForm));
            }
            //Выводим на график данные параметра
            AddNewSeries();
        }

        //Метод предназначен для закрытия экземпляра формы в блоке catch метода FillingComboBoxAndAddNewSeries()
        private void CloseTheForm()
        {
            this.Close();
        }

        //Метод создает серию, заполняет ее соответствующими данными и добавляет на график
        private void AddNewSeries()
        {
            cbLocationId = cbLocation.SelectedValue.ToString();
            cbParameterId = cbParameter.SelectedValue.ToString();

            tagId = DataFromDB.GetTagId(cbLocationId, cbParameterId);
            //Создаем серию данных с именем Место-Параметр
            cbLocationId = cbLocation.Text;
            cbParameterId = cbParameter.Text;
            bool newSeries = true;
            foreach (Series s in chartDataArchive.Series)
            {
                if (s.Name == cbLocationId + "-" + cbParameterId)
                {
                    newSeries = false;
                    //if (s.Enabled == false)
                    //    s.Enabled = true;
                }
            }
            if (newSeries)
            {
                TagIdSeries.Add(cbLocationId + "-" + cbParameterId, tagId);
                Series series = new Series(cbLocationId + "-" + cbParameterId);
                series.BorderWidth = 2;
                series.ChartType = SeriesChartType.Area;
                series.Legend = "Legend2";
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 2;
                series.IsValueShownAsLabel = false;
                series.XValueType = ChartValueType.DateTime;
                //series.YValueType = ChartValueType.Double;
                chartDataArchive.Series.Add(series);
                SetSeriesTransparency(chartDataArchive, 40);
                //Устанавливаем источник данных 
                chartDataArchive.DataSource = DataFromDB.GetDsDatetimeAndValueAS(tagId, dateTimePicker.Value.ToString("yyyy-MM-dd"));
                //Заполняем серию данными
                chartDataArchive.Series[cbLocationId + "-" + cbParameterId].XValueMember = "DateTime";
                chartDataArchive.Series[cbLocationId + "-" + cbParameterId].YValueMembers = "ValueAS";
                chartDataArchive.DataBind();
                chartDataArchive.Series[cbLocationId + "-" + cbParameterId].XValueMember = "";
                chartDataArchive.Series[cbLocationId + "-" + cbParameterId].YValueMembers = "";
                //Если в источнике нет данных добавляем к тексту легенды текст "[Нет данных]"
                if (chartDataArchive.Series[cbLocationId + "-" + cbParameterId].Points.Count == 0)
                    chartDataArchive.Series[cbLocationId + "-" + cbParameterId].LegendText =
                        chartDataArchive.Series[cbLocationId + "-" + cbParameterId].Name + " [Нет данных]";
                else
                    chartDataArchive.Series[cbLocationId + "-" + cbParameterId].LegendText =
                        chartDataArchive.Series[cbLocationId + "-" + cbParameterId].Name;

                //Значение параметра -50 в сервере задано как аварийное и позволяет "оборвать" серию на графике
                foreach (var point in chartDataArchive.Series[cbLocationId + "-" + cbParameterId].Points)
                {
                    if (point.YValues[0] == -50)
                        point.IsEmpty = true;
                }
            }
            chartDataArchive.Update();
        }

        //Свойство series.ChartType = SeriesChartType.Area по умолчанию имеет сплошной цвет. Данный метод делает прозрачной область под линией графика
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
                }

                foreach (ChartArea chartarea in chart.ChartAreas)
                {
                    chartarea.AxisX.MajorGrid.LineColor = Color.FromArgb(alpha, sc);
                    chartarea.AxisX.ScrollBar.BackColor = Color.FromArgb(alpha, sc);
                    chartarea.AxisX.ScrollBar.LineColor = Color.White;
                    chartarea.AxisX.ScrollBar.ButtonColor = sc;

                    chartarea.AxisY.MajorGrid.LineColor = Color.FromArgb(alpha, sc);
                    chartarea.AxisY.ScrollBar.BackColor = Color.FromArgb(alpha, sc);
                    chartarea.AxisY.ScrollBar.LineColor = Color.White;
                    chartarea.AxisY.ScrollBar.ButtonColor = sc;
                }
            }
        }
       
        private void chartDataArchive_MouseClick(object sender, MouseEventArgs e)
        {
            //Если выбрано меню Метки-Отображать, то при нажатии кнопки мыши в точке пересеченич вертикальной линии курсора с графиком над ближайшей точкой отобразится метка
            if (showLabel)
            {
                if (Math.Round(this.chartDataArchive.ChartAreas[0].CursorX.Position) > 0)
                {
                    foreach (var series in chartDataArchive.Series)
                    {
                        foreach (var item in series.Points)
                        {
                            if (item.XValue > chartDataArchive.ChartAreas[0].CursorX.Position)
                            {
                                int index = series.Points.IndexOf(item);
                                if (index == 0)
                                {
                                    series.Points[index].Label = "[#VALX{HH:mm:ss}]\n#VALY";
                                    series.Points[index].MarkerSize = 6;
                                }
                                else
                                {
                                    series.Points[index - 1].Label = "[#VALX{HH:mm:ss}]\n#VALY";
                                    series.Points[index - 1].MarkerSize = 6;
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void tsmiRemoveLabel_Click(object sender, EventArgs e)
        {
            foreach (var series in chartDataArchive.Series)
            {
                for (int i = 0; i < series.Points.Count; i++)
                {
                    series.Points[i].Label = "";
                    series.Points[i].MarkerSize = 1;
                }
            }
        }

        bool showLabel = false;

        private void tsmiShowLabel_Click(object sender, EventArgs e)
        {
            if (!showLabel) showLabel = true;
            else showLabel = false;
        }

        //Отключение масштабирования
        bool disableZoom = false;

        private void tsmiOnZoomable_Click(object sender, EventArgs e)
        {
            if (!disableZoom)
            {
                foreach (Axis axis in chartDataArchive.ChartAreas[0].Axes)
                {
                    axis.ScaleView.Zoomable = true;
                }
                disableZoom = true;
            }
            else
            {
                foreach (Axis axis in chartDataArchive.ChartAreas[0].Axes)
                {
                    axis.ScaleView.Zoomable = false;
                }
                disableZoom = false;
            }
        }
        
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //Обновление данных серий при изменении даты
            for (int i = 0; i < chartDataArchive.Series.Count; i++)
            {
                chartDataArchive.Series[i].Points.Clear();
                
                chartDataArchive.DataSource = DataFromDB.GetDsDatetimeAndValueAS(TagIdSeries[chartDataArchive.Series[i].Name], dateTimePicker.Value.ToString("yyyy-MM-dd")); ;
                chartDataArchive.Series[chartDataArchive.Series[i].Name].XValueMember = "DateTime";
                chartDataArchive.Series[chartDataArchive.Series[i].Name].YValueMembers = "ValueAS";
                chartDataArchive.DataBind();
                chartDataArchive.Series[chartDataArchive.Series[i].Name].XValueMember = "";
                chartDataArchive.Series[chartDataArchive.Series[i].Name].YValueMembers = "";

                if (chartDataArchive.Series[i].Points.Count == 0)
                    chartDataArchive.Series[i].LegendText = chartDataArchive.Series[i].Name + " [Нет данных]";
                else
                    chartDataArchive.Series[i].LegendText = chartDataArchive.Series[i].Name;
                foreach (var point in chartDataArchive.Series[i].Points)
                {
                    if (point.YValues[0] == -50)
                        point.IsEmpty = true;
                }
            }
            chartDataArchive.Update();
        }

        #region Сохранение формы в файл
        private void btnSaveChart_Click(object sender, EventArgs e)
        {
            SaveCaptureScreen();
        }

        private void SaveCaptureScreen()
        {
            using (Bitmap bitmap = new Bitmap(this.Width-20, this.Height-20))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Size s = this.Size;
                    g.CopyFromScreen(this.Location.X+10, this.Location.Y+10, 0,0, s);
                }
                saveFileDialog1.Filter = "Bitmap Image|*.bmp|JPeg Image|*.jpg|Gif Image|*.gif";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveFileDialog1.OpenFile();
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            bitmap.Save(fs, ImageFormat.Bmp);
                            break;

                        case 2:
                            bitmap.Save(fs, ImageFormat.Jpeg);
                            break;

                        case 3:
                            bitmap.Save(fs, ImageFormat.Gif);
                            break;
                    }
                    fs.Close();
                }
            }
        }
        #endregion

        private void buttonAddNewSeries_Click(object sender, EventArgs e)
        {
            AddNewSeries();
            //chartDataArchive.ChartAreas[0].RecalculateAxesScale();
        }

        private void buttonRemoveSeries_Click(object sender, EventArgs e)
        {
            cbLocationId = cbLocation.Text;
            cbParameterId = cbParameter.Text;
            try
            {
                chartDataArchive.Series.Remove(chartDataArchive.Series[cbLocationId + "-" + cbParameterId]);
                TagIdSeries.Remove(cbLocationId + "-" + cbParameterId);
                SetSeriesTransparency(chartDataArchive, 40);
            }
            catch (System.ArgumentException)
            {
                ;
            }
        }

        private void buttonPreviosDay_Click(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker.Value.AddDays(-1);
            dateTimePicker.Value = new DateTime(dateTime.Ticks);
        }

        private void buttonNextDay_Click(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker.Value.AddDays(1);
            if (dateTime <= dateTimePicker.MaxDate)
            dateTimePicker.Value = new DateTime(dateTime.Ticks);
        }

        #region Диапазон шкалы

        //Формирование подсказки о недопустимом вводе
        private void mtbMinAxisY_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (e.Position == mtbMinAxisY.Mask.Length)
            {
                toolTip1.ToolTipTitle = "Превышено количество символов";
                toolTip1.Show("Значение не должно быть более " + Convert.ToString(mtbMinAxisY.Mask.Length) + " символов.", mtbMinAxisY, 0, 20, 5000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Ввод отклонен";
                toolTip1.Show("В это поле можно добавлять только цифры (0–9)", mtbMinAxisY, 0, 20, 5000);
            }
        }

        private void mtbMaxAxisY_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (e.Position == mtbMaxAxisY.Mask.Length)
            {
                toolTip1.ToolTipTitle = "Превышено количество символов";
                toolTip1.Show("Значение не должно быть более " + Convert.ToString(mtbMaxAxisY.Mask.Length) + " символов.", mtbMaxAxisY, 0, 20, 5000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Ввод отклонен";
                toolTip1.Show("В это поле можно добавлять только цифры (0–9)", mtbMaxAxisY, 0, 20, 5000);
            }
        }

        //Применение введенного значения к шкале. Отключение звука после нажатия клавиши enter
        private void mtbMinAxisY_KeyPress(object sender, KeyPressEventArgs e)
        {
            toolTip1.Hide(mtbMinAxisY); //выключает toolTip1.ToolTipTitle в maskedTextBox2_MaskInputRejected (до 5 сек)

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (sender is MaskedTextBox)
                {
                    MaskedTextBox txb = (MaskedTextBox)sender;

                    try
                    {
                        if (Convert.ToDouble(txb.Text) < this.chartDataArchive.ChartAreas[0].AxisY.Maximum)
                            this.chartDataArchive.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txb.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                //e.SuppressKeyPress = true; отключает звук нажатия enter при применении в maskedTextBox1_KeyDown при повторном вводе заменяет первую цифру null
                e.Handled = true;//отключает звук нажатия enter
            }
        }

        private void mtbMaxAxisY_KeyPress(object sender, KeyPressEventArgs e)
        {
            toolTip1.Hide(mtbMaxAxisY); //выключает toolTip1.ToolTipTitle в maskedTextBox2_MaskInputRejected (до 5 сек)

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (sender is MaskedTextBox)
                {
                    MaskedTextBox txb = (MaskedTextBox)sender;
                    try
                    {
                        if (Convert.ToDouble(txb.Text) > this.chartDataArchive.ChartAreas[0].AxisY.Minimum)
                            this.chartDataArchive.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txb.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                //e.SuppressKeyPress = true; отключает звук нажатия enter при применении в maskedTextBox1_KeyDown при повторном вводе заменяет первую цифру null
                e.Handled = true;//отключает звук нажатия enter
            }
        }

        //Очищение MaskedTextBox перед вводом значения
        private void mtbMinAxisY_Click(object sender, EventArgs e)
        {
            mtbMinAxisY.Clear();
        }
        
        private void mtbMaxAxisY_Click(object sender, EventArgs e)
        {
            mtbMaxAxisY.Clear();
        }
        #endregion

        private void buttonOpenChartRT_Click(object sender, EventArgs e)
        {
            ChartRT chartRT = new ChartRT();
            chartRT.Show();
        }

        private void buttonOpenStatistic_Click(object sender, EventArgs e)
        {
            Statistic statistic = new Statistic();
            statistic.Show();
        }
    }
}
