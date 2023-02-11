using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DataMonitoring
{
    static class DataFromDB
    {
        //Определяем строку подключения, предоставляющая информацию о базе данных
        public static string conString = ConfigurationManager.ConnectionStrings["PathDB"].ConnectionString;
        private static Configuration config;
        //Создание подключения
        private static string sql;
        public static DataSet DsInstallationLocation { get; set; }
        public static DataSet DsParameter { get; set; }

        public static string minValue = "";

        public static string maxValue = "";

        public static string averageValue = "";

        public static DataSet GetDsInstallationLocation()
        {
            using (var conn = new SQLiteConnection(conString))
            {
                DsInstallationLocation = new DataSet();
                sql = "SELECT InstallationLocationId, InstallationLocationName FROM InstallationLocation";
                SQLiteDataAdapter daIL = new SQLiteDataAdapter(sql, conn);
                daIL.Fill(DsInstallationLocation, "InstallationLocation");
            }
            return DsInstallationLocation;
        }

        public static DataSet GetDsParameter()
        {
            using (var conn = new SQLiteConnection(conString))
            {
                DsParameter = new DataSet();
                sql = "SELECT ParameterId, ParameterName FROM Parameter";
                SQLiteDataAdapter daP = new SQLiteDataAdapter(sql, conn);
                daP.Fill(DsParameter, "Parameter");
            }
            return DsParameter;
        }

        public static string GetTagId(string cbLocationId, string cbParameterId)
        {
            string tagId = "";
            //Создание подключения. В конструктор объекту SQLiteConnection передается строка подключения, которая инициализирует объект
            using (var conn = new SQLiteConnection(conString)) //конструкция using автоматически закрывает подключение
            {
                conn.Open();

                using (var command = new SQLiteCommand(conn))
                {
                    command.Connection = conn;
                    command.CommandText = "SELECT TagId " +
                        "FROM Tag " +
                        "WHERE ParameterId = " + cbParameterId + " " +
                        "AND DeviceId = (SELECT DeviceId " +
                        "FROM Device " +
                        "WHERE InstallationLocationId = " + cbLocationId + ")";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            tagId = reader.GetInt32(0).ToString();
                    }
                }
            }
            return tagId;
        }

        public static string GetTagName(string cbLocationId, string cbParameterId)
        {
            string tagName = "";
            using (var conn = new SQLiteConnection(conString))
            {
                conn.Open();

                using (var command = new SQLiteCommand(conn))
                {
                    command.Connection = conn;
                    command.CommandText = "SELECT TagFullName " +
                        "FROM Tag " +
                        "WHERE ParameterId = " + cbParameterId + " " +
                        "AND DeviceId = (SELECT DeviceId " +
                        "FROM Device " +
                        "WHERE InstallationLocationId = " + cbLocationId + ")";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            tagName = reader.GetString(0);
                    }
                }
            }
            return tagName;
        }

        public static DataSet GetDsDatetimeAndValueAS(string TagId, string DatetimeFromDateTimePicker)
        {
            DataSet ds = new DataSet();
            using (var conn = new SQLiteConnection(conString))
            {
                sql = "SELECT Datetime, ValueAS FROM TagValue WHERE TagId=" + TagId + " AND Datetime LIKE '" + DatetimeFromDateTimePicker + "%'";
                //Создаем объект SqlDataAdapter, который принимает объект подключения и sql-выражение
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                //Загружаем данные в ds
                da.Fill(ds, "TagValue");
            }
            return ds;
        }

        public static List<string> GetMinMaxAvgFault(string cbLocationId, string cbParameterId, string dateFrom, string dateTo)
        {
            string tagId = GetTagId(cbLocationId, cbParameterId);

            List<string> listDateFault = new List<string>();
            try
            {
                using (var conn = new SQLiteConnection(conString))
                {
                    conn.Open();

                    using (var command = new SQLiteCommand(conn))
                    {
                        command.Connection = conn;


                        command.CommandText = "SELECT MIN(ValueAS), Datetime FROM TagValue " +
                                                "WHERE Quality=192 AND TagId=" + tagId + " " +
                                                "AND Datetime " +
                                                "BETWEEN '" + dateFrom + "' " +
                                                "AND '" + dateTo + "'";
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                minValue = $"{reader.GetDouble(0)}\n({reader.GetDateTime(1)})";
                        }

                        command.CommandText = "SELECT MAX(ValueAS), Datetime FROM TagValue " +
                                                "WHERE Quality=192 AND TagId=" + tagId + " " +
                                                "AND Datetime " +
                                                "BETWEEN '" + dateFrom + "' " +
                                                "AND '" + dateTo + "'";
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                maxValue = $"{reader.GetDouble(0)}\n({reader.GetDateTime(1)})";
                        }

                        command.CommandText = "SELECT AVG(ValueAS) FROM TagValue " +
                                                "WHERE Quality=192 AND TagId=" + tagId + " " +
                                                "AND Datetime " +
                                                "BETWEEN '" + dateFrom + "' " +
                                                "AND '" + dateTo + "'";
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                averageValue = reader.GetDouble(0).ToString("##.#");
                        }

                        command.CommandText = "SELECT Datetime FROM TagValue " +
                                                "WHERE NOT Quality=192 AND TagId=" + tagId + " " +
                                                "AND Datetime " +
                                                "BETWEEN '" + dateFrom + "' " +
                                                "AND '" + dateTo + "'";
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    listDateFault.Add(reader.GetDateTime(0).ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (System.InvalidCastException)
            {
                MessageBox.Show("Нет данных", "", MessageBoxButtons.OK);
            }
            return listDateFault;
        }

        public static void ChangeDBandConnString()
        {
            ConnectionString.Connect();
            conString = ConnectionString.Value;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["PathDB"].ConnectionString = ConnectionString.Value;
            config.Save(ConfigurationSaveMode.Modified);
        }
    }
}