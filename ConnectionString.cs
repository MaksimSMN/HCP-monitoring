using System.Windows.Forms;

namespace DataMonitoring
{
    static class ConnectionString
    {
        public static string Value;
        public static string Connect()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string filename = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
            Value = "Data Source=" + filename + "";

            return Value;
        }
    }
}
