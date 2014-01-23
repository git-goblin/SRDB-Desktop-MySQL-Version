using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
//add this to create Excel documents -->
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System.IO;
using System.Diagnostics;

namespace srdb
{
    public partial class adminSQLServiceReport : Form
    {
        private DBConnect dbConnect;
        private DataTable sr_table = new DataTable();
        public adminSQLServiceReport()
        {
            dbConnect = new DBConnect();
            InitializeComponent();
        }

        private void fill_table()
        {
            String report_query = txtQuery.Text;
            dbConnect.services_initialise();
            dbConnect.services_Open_Connection();
            using (MySqlDataAdapter da = new MySqlDataAdapter(report_query, dbConnect.services_connection)) //create a new DataAdaptor
            {
                da.Fill(sr_table); //File the table with the values from the DataAdaptor
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                String sql_query = txtQuery.Text;
                if (sql_query == "" || sql_query.Length < 10)
                {
                    MessageBox.Show("Invalid SQL query! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FolderBrowserDialog fbd = new FolderBrowserDialog(); //Asks the user to choose a file where the PDF will be saved
                fbd.ShowDialog();
                string u_path = fbd.SelectedPath;
                String day = Convert.ToString(DateTime.Now.Day);
                String month = Convert.ToString(DateTime.Now.Month);
                String year = Convert.ToString(DateTime.Now.Year);
                String date = day + "-" + month + "-" + year;
                string file_name = "Report Created - " + date;
                using (ExcelPackage excelpkg = new ExcelPackage())
                {
                    excelpkg.Workbook.Properties.Title = "End of Month Report"; //Adds a title
                    excelpkg.Workbook.Worksheets.Add("Report"); //creates a new worksheet
                    ExcelWorksheet ws = excelpkg.Workbook.Worksheets[1]; //postion of the worksheet
                    ws.Name = "EoM Report";

                    fill_table();

                    ws.Cells["A3"].LoadFromDataTable(sr_table, true); //by setting to TRUE, it used the table column names as the headers

                    Byte[] bin = excelpkg.GetAsByteArray();
                    File.WriteAllBytes(u_path + "/" + file_name + ".xlsx", bin); //writes to the file, needs to be XLSX format
                }
                MessageBox.Show("Report created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlMenu acm = new adminControlMenu();
            acm.Show();
        }

        private void linkLabelSQL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.w3schools.com/sql/");
            Process.Start(sInfo);
        }
    }
}
