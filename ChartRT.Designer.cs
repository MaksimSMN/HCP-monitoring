
namespace DataMonitoring
{
    partial class ChartRT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            //System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            //System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            //System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartRT));
            this.chartRunTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerUpdateChart = new System.Windows.Forms.Timer(this.components);
            this.btnOffUpdate = new System.Windows.Forms.Button();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOffLine = new System.Windows.Forms.Button();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.cbParameter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartRunTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartRunTime
            // 
            this.chartRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.MajorGrid.Interval = 0D;
            chartArea1.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.ScaleView.SmallScrollSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IsMarksNextToAxis = false;
            chartArea1.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY.LineWidth = 30;
            //chartArea1.AxisY2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            //chartArea1.AxisY2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 93F;
            chartArea1.Position.Width = 98F;
            chartArea1.Position.Y = 5F;
            this.chartRunTime.ChartAreas.Add(chartArea1);
            legend1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend2";
            legend1.Position.Auto = false;
            legend1.Position.Height = 5F;
            legend1.Position.Width = 80F;
            legend1.Position.X = 10F;
            this.chartRunTime.Legends.Add(legend1);
            this.chartRunTime.Location = new System.Drawing.Point(0, 74);
            this.chartRunTime.Name = "chartRunTime";
            this.chartRunTime.Size = new System.Drawing.Size(883, 376);
            this.chartRunTime.TabIndex = 0;
            this.chartRunTime.Text = "chart1";
            //title1.Name = "Title1";
            //title2.Name = "Title2";
            //title3.Name = "Title3";
            //this.chartRunTime.Titles.Add(title1);
            //this.chartRunTime.Titles.Add(title2);
            //this.chartRunTime.Titles.Add(title3);
            // 
            // timerUpdateChart
            // 
            this.timerUpdateChart.Enabled = true;
            this.timerUpdateChart.Tick += new System.EventHandler(this.timerUpdateChart_Tick);
            // 
            // btnOffUpdate
            // 
            this.btnOffUpdate.Location = new System.Drawing.Point(40, 24);
            this.btnOffUpdate.Name = "btnOffUpdate";
            this.btnOffUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnOffUpdate.TabIndex = 5;
            this.btnOffUpdate.Text = "Выключить";
            this.btnOffUpdate.UseVisualStyleBackColor = true;
            this.btnOffUpdate.Click += new System.EventHandler(this.btnOffUpdate_Click);
            // 
            // cbLocation
            // 
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(20, 43);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(145, 21);
            this.cbLocation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Помещение";
            // 
            // btnOffLine
            // 
            this.btnOffLine.Location = new System.Drawing.Point(345, 42);
            this.btnOffLine.Name = "btnOffLine";
            this.btnOffLine.Size = new System.Drawing.Size(75, 23);
            this.btnOffLine.TabIndex = 4;
            this.btnOffLine.Text = "Удалить";
            this.btnOffLine.UseVisualStyleBackColor = true;
            this.btnOffLine.Click += new System.EventHandler(this.btnOffLine_Click);
            // 
            // btnAddLine
            // 
            this.btnAddLine.Location = new System.Drawing.Point(345, 12);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(75, 23);
            this.btnAddLine.TabIndex = 3;
            this.btnAddLine.Text = "Добавить";
            this.btnAddLine.UseVisualStyleBackColor = true;
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // cbParameter
            // 
            this.cbParameter.FormattingEnabled = true;
            this.cbParameter.Location = new System.Drawing.Point(180, 43);
            this.cbParameter.Name = "cbParameter";
            this.cbParameter.Size = new System.Drawing.Size(145, 21);
            this.cbParameter.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Параметр";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbParameter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnOffLine);
            this.groupBox1.Controls.Add(this.btnAddLine);
            this.groupBox1.Controls.Add(this.cbLocation);
            this.groupBox1.Location = new System.Drawing.Point(181, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 74);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор параметров";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelTime);
            this.groupBox2.Controls.Add(this.btnOffUpdate);
            this.groupBox2.Location = new System.Drawing.Point(439, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 74);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Обновление графика";
            // 
            // labelTime
            // 
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTime.Location = new System.Drawing.Point(3, 58);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(145, 13);
            this.labelTime.TabIndex = 10;
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChartRT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(883, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chartRunTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChartRT";
            this.Text = "График текущих значений";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartRT_FormClosing);
            this.Load += new System.EventHandler(this.ChartRT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartRunTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartRunTime;
        private System.Windows.Forms.Timer timerUpdateChart;
        private System.Windows.Forms.Button btnOffUpdate;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOffLine;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.ComboBox cbParameter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelTime;
    }
}