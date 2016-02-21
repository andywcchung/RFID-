using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace CS203_CALLBACK_API_DEMO
{
    class SQLMethod
    {
        private static string connectionString = string.Empty;
        private static SqlConnection sqlConn;

        public SQLMethod()
        {
            connectionString = string.Format("Data Source={0}\\{1};Initial Catalog={2};User ID={3};Password={4}",
                                            LocalSettings.ServerIP,
                                            LocalSettings.ServerName,
                                            LocalSettings.DBName,
                                            LocalSettings.UserID,
                                            LocalSettings.Password);
        }

        /// <summary>
        /// This method attempts to create the TagInfo SQL table.
        /// </summary>
        public bool Prepare()
        {
            //
            // Make sure connection is ok.
            //
            using (sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConn.Open();
                }
                catch (System.Data.SqlClient.SqlException ee)
                {
                    MessageBox.Show(ee.Message.ToString() + "\nPlease check SQL settings");
                    return false;
                }

                using (SqlCommand command = new SqlCommand("CREATE TABLE TagInfo (TagId TEXT, TagTime DATETIME)", sqlConn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        //MessageBox.Show("Could not create table.");
                    }
                }

                try
                {
                    sqlConn.Close();
                }
                catch (System.Data.SqlClient.SqlException ee)
                {
                    MessageBox.Show(ee.Message.ToString());
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Insert tag ID data into the SQL database table.
        /// </summary>
        /// <param name=epc>The tag ID.</param>
        public void AddData(string epc)
        {
            //
            // Create a DataTable with two columns.
            //
            DataTable table = new DataTable();
            table.Columns.Add("TagId", typeof(string));
            table.Columns.Add("TagTime", typeof(DateTime));

            //
            // Add data to the DataTable.
            //
            table.Rows.Add(epc, DateTime.Now);

            //
            // Create new SqlConnection, SqlDataAdapter, and builder.
            // 
            using (sqlConn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TagInfo", sqlConn))
            using (new SqlCommandBuilder(adapter))
            {
                try
                {
                    //
                    // Fill the DataAdapter with the values in the DataTable.
                    //
                    adapter.Fill(table);
                    //
                    // Open the connection to the SQL database.
                    //
                    sqlConn.Open();
                    //
                    // Update the SQL database table with the values.
                    //
                    adapter.Update(table);

                    //
                    // Close the connection to the SQL database.
                    //
                    sqlConn.Close();
                }
                catch (System.Data.SqlClient.SqlException ee)
                {
                    MessageBox.Show(ee.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Get tag ID data from the SQL database table.
        /// </summary>
        public void GetData(ListView listview)
        {
            using (sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                using (SqlDataReader reader = new SqlCommand("SELECT * FROM TagInfo", sqlConn).ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            string[] rowitem = new string[2];
                            rowitem[0] = reader.GetString(reader.GetOrdinal("TagId"));
                            rowitem[1] = reader.GetDateTime(reader.GetOrdinal("TagTime")).ToString();
                            ListViewItem listitem = new ListViewItem(rowitem);
                            //table.Rows.Add(epc, time);
                            listview.Items.Add(listitem);
                        }
                        reader.Close();
                    }
                    catch (System.Data.SqlClient.SqlException ee)
                    {
                        MessageBox.Show(ee.Message.ToString());
                    }
                }
                sqlConn.Close();
            }
        }

    }
}
