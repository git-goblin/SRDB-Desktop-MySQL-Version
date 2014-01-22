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
    public partial class adminEoMReport : Form
    {
        private DBConnect dbConnect;
        public adminEoMReport()
        {
            dbConnect = new DBConnect();
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                String month = cbDate.Text;
                String year = Convert.ToString(DateTime.Now.Year);
                String like_value = month + " " + year;
                String report_query = "SELECT * FROM services WHERE date LIKE @like";
                MySqlCommand eom = new MySqlCommand(report_query, dbConnect.services_connection);
                eom.Parameters.AddWithValue("@LIKE", "%" + like_value + "%");
                
                //Add TEXT/ID validation here -->

                using (MySqlDataReader read = eom.ExecuteReader())
                {
                    while (read.Read())
                    {
                        String SRID = read.GetString(read.GetOrdinal("SRID"));
                        String date = read.GetString(read.GetOrdinal("date"));
                        String firstName = read.GetString(read.GetOrdinal("firstName"));
                        String surName = read.GetString(read.GetOrdinal("surName"));
                        String amount = read.GetString(read.GetOrdinal("amount"));
                        String services_remaining = read.GetString(read.GetOrdinal("services_remaining"));
                        String services_left = read.GetString(read.GetOrdinal("services_left"));
                        String invoice_number = read.GetString(read.GetOrdinal("invoice_number"));
                    }
                }

                using (ExcelPackage excelpkg = new ExcelPackage())
                {
                    excelpkg.Workbook.Properties.Title = "End of Month Report"; //Adds a title
                    excelpkg.Workbook.Worksheets.Add(month); //creates a new worksheet
                    ExcelWorksheet ws = excelpkg.Workbook.Worksheets[1]; //postion of the worksheet
                    ws.Name = "EoM Report";

                    var cell_SRID = ws.Cells[1, 1]; //declare the cells
                    var cell_firstName = ws.Cells[1, 2];
                    var cell_surName = ws.Cells[1, 3];
                    var cell_amount = ws.Cells[1, 4];
                    var cell_services_remaining = ws.Cells[1, 5];
                    var cell_services_left = ws.Cells[1, 6];
                    var cell_invoice_number = ws.Cells[1, 7];

                    cell_SRID.Value = "SRID"; //sets a value to the cells
                    cell_firstName.Value = "Firstname";
                    cell_surName.Value = "Surname";
                    cell_amount.Value = "Amount";
                    cell_services_remaining.Value = "Services Remaining";
                    cell_services_left.Value = "Services Left";
                    cell_invoice_number.Value = "Invoice Number";

                    Byte[] bin = excelpkg.GetAsByteArray();
                    File.WriteAllBytes(@"C:\EXCEL\test_with_x.xlsx", bin); //writes to the file, needs to be XLSX format
                }
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
    }
}
