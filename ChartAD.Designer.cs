
namespace DataMonitoring
{
    partial class ChartAD
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartAD));
            this.chartDataArchive = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.меткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoveLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.масштабированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOnZoomable = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOpenStatistic = new System.Windows.Forms.Button();
            this.buttonOpenChartRT = new System.Windows.Forms.Button();
            this.btnSaveChart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbMaxAxisY = new System.Windows.Forms.MaskedTextBox();
            this.mtbMinAxisY = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonNextDay = new System.Windows.Forms.Button();
            this.buttonPreviosDay = new System.Windows.Forms.Button();
            this.buttonRemoveSeries = new System.Windows.Forms.Button();
            this.buttonAddNewSeries = new System.Windows.Forms.Button();
            this.cbParameter = new System.Windows.Forms.ComboBox();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chartDataArchive)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartDataArchive
            // 
            this.chartDataArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartDataArchive.BackColor = System.Drawing.Color.Empty;
            this.chartDataArchive.BorderlineColor = System.Drawing.Color.Empty;
            this.chartDataArchive.BorderSkin.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 11;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 8;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea1.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 11;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 8;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            chartArea1.CursorY.Interval = 0.1D;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 92F;
            chartArea1.Position.Width = 98F;
            chartArea1.Position.Y = 4F;
            this.chartDataArchive.ChartAreas.Add(chartArea1);
            this.chartDataArchive.ContextMenuStrip = this.contextMenuStrip1;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSpacing = 1;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Legend2";
            legend1.Position.Auto = false;
            legend1.Position.Height = 5F;
            legend1.Position.Width = 80F;
            legend1.Position.X = 10F;
            this.chartDataArchive.Legends.Add(legend1);
            this.chartDataArchive.Location = new System.Drawing.Point(0, 72);
            this.chartDataArchive.Name = "chartDataArchive";
            this.chartDataArchive.Size = new System.Drawing.Size(1057, 395);
            this.chartDataArchive.TabIndex = 0;
            this.chartDataArchive.Text = "chart1";
            this.chartDataArchive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartDataArchive_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.меткиToolStripMenuItem,
            this.масштабированиеToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 48);
            // 
            // меткиToolStripMenuItem
            // 
            this.меткиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowLabel,
            this.tsmiRemoveLabel});
            this.меткиToolStripMenuItem.Name = "меткиToolStripMenuItem";
            this.меткиToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.меткиToolStripMenuItem.Text = "Метки";
            // 
            // tsmiShowLabel
            // 
            this.tsmiShowLabel.CheckOnClick = true;
            this.tsmiShowLabel.Name = "tsmiShowLabel";
            this.tsmiShowLabel.Size = new System.Drawing.Size(141, 22);
            this.tsmiShowLabel.Text = "Отображать";
            this.tsmiShowLabel.Click += new System.EventHandler(this.tsmiShowLabel_Click);
            // 
            // tsmiRemoveLabel
            // 
            this.tsmiRemoveLabel.Name = "tsmiRemoveLabel";
            this.tsmiRemoveLabel.Size = new System.Drawing.Size(141, 22);
            this.tsmiRemoveLabel.Text = "Очистить";
            this.tsmiRemoveLabel.Click += new System.EventHandler(this.tsmiRemoveLabel_Click);
            // 
            // масштабированиеToolStripMenuItem
            // 
            this.масштабированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOnZoomable});
            this.масштабированиеToolStripMenuItem.Name = "масштабированиеToolStripMenuItem";
            this.масштабированиеToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.масштабированиеToolStripMenuItem.Text = "Масштабирование";
            // 
            // tsmiOnZoomable
            // 
            this.tsmiOnZoomable.CheckOnClick = true;
            this.tsmiOnZoomable.Name = "tsmiOnZoomable";
            this.tsmiOnZoomable.Size = new System.Drawing.Size(129, 22);
            this.tsmiOnZoomable.Text = "Включить";
            this.tsmiOnZoomable.Click += new System.EventHandler(this.tsmiOnZoomable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Помещение";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker.Location = new System.Drawing.Point(6, 24);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker.TabIndex = 7;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.buttonOpenStatistic);
            this.groupBox1.Controls.Add(this.buttonOpenChartRT);
            this.groupBox1.Controls.Add(this.btnSaveChart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mtbMaxAxisY);
            this.groupBox1.Controls.Add(this.mtbMinAxisY);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.buttonRemoveSeries);
            this.groupBox1.Controls.Add(this.buttonAddNewSeries);
            this.groupBox1.Controls.Add(this.cbParameter);
            this.groupBox1.Controls.Add(this.cbLocation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(2, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1054, 70);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Диапазон шкалы";
            // 
            // buttonOpenStatistic
            // 
            this.buttonOpenStatistic.Location = new System.Drawing.Point(957, 16);
            this.buttonOpenStatistic.Name = "buttonOpenStatistic";
            this.buttonOpenStatistic.Size = new System.Drawing.Size(79, 40);
            this.buttonOpenStatistic.TabIndex = 12;
            this.buttonOpenStatistic.Text = "Статистика";
            this.buttonOpenStatistic.UseVisualStyleBackColor = true;
            this.buttonOpenStatistic.Click += new System.EventHandler(this.buttonOpenStatistic_Click);
            // 
            // buttonOpenChartRT
            // 
            this.buttonOpenChartRT.Location = new System.Drawing.Point(831, 16);
            this.buttonOpenChartRT.Name = "buttonOpenChartRT";
            this.buttonOpenChartRT.Size = new System.Drawing.Size(110, 40);
            this.buttonOpenChartRT.TabIndex = 11;
            this.buttonOpenChartRT.Text = "График текущих значений";
            this.buttonOpenChartRT.UseVisualStyleBackColor = true;
            this.buttonOpenChartRT.Click += new System.EventHandler(this.buttonOpenChartRT_Click);
            // 
            // btnSaveChart
            // 
            this.btnSaveChart.Location = new System.Drawing.Point(740, 16);
            this.btnSaveChart.Name = "btnSaveChart";
            this.btnSaveChart.Size = new System.Drawing.Size(75, 40);
            this.btnSaveChart.TabIndex = 10;
            this.btnSaveChart.Text = "Сохранить график";
            this.btnSaveChart.UseVisualStyleBackColor = true;
            this.btnSaveChart.Click += new System.EventHandler(this.btnSaveChart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Макс";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Мин";
            // 
            // mtbMaxAxisY
            // 
            this.mtbMaxAxisY.Location = new System.Drawing.Point(81, 40);
            this.mtbMaxAxisY.Mask = "0000";
            this.mtbMaxAxisY.Name = "mtbMaxAxisY";
            this.mtbMaxAxisY.PromptChar = ' ';
            this.mtbMaxAxisY.Size = new System.Drawing.Size(50, 20);
            this.mtbMaxAxisY.TabIndex = 2;
            this.mtbMaxAxisY.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbMaxAxisY_MaskInputRejected);
            this.mtbMaxAxisY.Click += new System.EventHandler(this.mtbMaxAxisY_Click);
            this.mtbMaxAxisY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbMaxAxisY_KeyPress);
            // 
            // mtbMinAxisY
            // 
            this.mtbMinAxisY.Location = new System.Drawing.Point(13, 40);
            this.mtbMinAxisY.Mask = "#000";
            this.mtbMinAxisY.Name = "mtbMinAxisY";
            this.mtbMinAxisY.PromptChar = ' ';
            this.mtbMinAxisY.Size = new System.Drawing.Size(50, 20);
            this.mtbMinAxisY.TabIndex = 1;
            this.mtbMinAxisY.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtbMinAxisY_MaskInputRejected);
            this.mtbMinAxisY.Click += new System.EventHandler(this.mtbMinAxisY_Click);
            this.mtbMinAxisY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbMinAxisY_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonNextDay);
            this.groupBox2.Controls.Add(this.buttonPreviosDay);
            this.groupBox2.Controls.Add(this.dateTimePicker);
            this.groupBox2.Location = new System.Drawing.Point(490, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 70);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дата";
            // 
            // buttonNextDay
            // 
            this.buttonNextDay.Location = new System.Drawing.Point(156, 37);
            this.buttonNextDay.Name = "buttonNextDay";
            this.buttonNextDay.Size = new System.Drawing.Size(70, 23);
            this.buttonNextDay.TabIndex = 9;
            this.buttonNextDay.Text = ">>";
            this.buttonNextDay.UseVisualStyleBackColor = true;
            this.buttonNextDay.Click += new System.EventHandler(this.buttonNextDay_Click);
            // 
            // buttonPreviosDay
            // 
            this.buttonPreviosDay.Location = new System.Drawing.Point(156, 11);
            this.buttonPreviosDay.Name = "buttonPreviosDay";
            this.buttonPreviosDay.Size = new System.Drawing.Size(70, 23);
            this.buttonPreviosDay.TabIndex = 8;
            this.buttonPreviosDay.Text = "<<";
            this.buttonPreviosDay.UseVisualStyleBackColor = true;
            this.buttonPreviosDay.Click += new System.EventHandler(this.buttonPreviosDay_Click);
            // 
            // buttonRemoveSeries
            // 
            this.buttonRemoveSeries.Location = new System.Drawing.Point(409, 37);
            this.buttonRemoveSeries.Name = "buttonRemoveSeries";
            this.buttonRemoveSeries.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveSeries.TabIndex = 6;
            this.buttonRemoveSeries.Text = "Удалить";
            this.buttonRemoveSeries.UseVisualStyleBackColor = true;
            this.buttonRemoveSeries.Click += new System.EventHandler(this.buttonRemoveSeries_Click);
            // 
            // buttonAddNewSeries
            // 
            this.buttonAddNewSeries.Location = new System.Drawing.Point(409, 11);
            this.buttonAddNewSeries.Name = "buttonAddNewSeries";
            this.buttonAddNewSeries.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNewSeries.TabIndex = 5;
            this.buttonAddNewSeries.Text = "Добавить";
            this.buttonAddNewSeries.UseVisualStyleBackColor = true;
            this.buttonAddNewSeries.Click += new System.EventHandler(this.buttonAddNewSeries_Click);
            // 
            // cbParameter
            // 
            this.cbParameter.FormattingEnabled = true;
            this.cbParameter.Location = new System.Drawing.Point(282, 39);
            this.cbParameter.Name = "cbParameter";
            this.cbParameter.Size = new System.Drawing.Size(121, 21);
            this.cbParameter.TabIndex = 4;
            // 
            // cbLocation
            // 
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(155, 39);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(121, 21);
            this.cbLocation.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Параметр";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(149, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(351, 70);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Выбор параметров";
            // 
            // ChartAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1057, 467);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chartDataArchive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartAD";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Text = "График архива данных";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GraficAD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDataArchive)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDataArchive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem меткиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLabel;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveLabel;
        private System.Windows.Forms.ToolStripMenuItem масштабированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOnZoomable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbParameter;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Button buttonAddNewSeries;
        private System.Windows.Forms.Button buttonRemoveSeries;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbMaxAxisY;
        private System.Windows.Forms.MaskedTextBox mtbMinAxisY;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonNextDay;
        private System.Windows.Forms.Button buttonPreviosDay;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSaveChart;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonOpenChartRT;
        private System.Windows.Forms.Button buttonOpenStatistic;
    }
}

