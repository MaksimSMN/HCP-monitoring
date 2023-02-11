using System;
using System.Windows.Forms;

namespace DataMonitoring
{
    public partial class Statistic : Form
    {
        string cbParameterId = "";
        string cbLocationId = "";

        public Statistic()
        {
            InitializeComponent();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            dateTimePickerTo.MaxDate = DateTime.Today;
            dateTimePickerFrom.MaxDate = dateTimePickerTo.Value;

            buttonApply.Select();

            cbLocation.DataSource = DataFromDB.DsInstallationLocation.Tables["InstallationLocation"];
            cbLocation.DisplayMember = "InstallationLocationName";
            cbLocation.ValueMember = "InstallationLocationId";

            cbParameter.DataSource = DataFromDB.DsParameter.Tables["Parameter"];
            cbParameter.DisplayMember = "ParameterName";
            cbParameter.ValueMember = "ParameterId";
        }
        
        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerFrom.MaxDate = dateTimePickerTo.Value;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            listBoxDateFault.Items.Clear();

            cbLocationId = cbLocation.SelectedValue.ToString();
            cbParameterId = cbParameter.SelectedValue.ToString();

            listBoxDateFault.Items.AddRange( 
                DataFromDB.GetMinMaxAvgFault(cbLocationId, cbParameterId, 
                dateTimePickerFrom.Value.ToString("yyyy-MM-dd"), dateTimePickerTo.Value.AddDays(1).ToString("yyyy-MM-dd")).ToArray());

            labelMinValue.Text = DataFromDB.minValue;

            labelMaxValue.Text = DataFromDB.maxValue;

            labelAverageValue.Text = DataFromDB.averageValue;
        }
    }
}
