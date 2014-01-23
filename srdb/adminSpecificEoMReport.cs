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
    public partial class adminSpecificEoMReport : Form
    {
        private DataTable sr_table = new DataTable();
        private DBConnect dbConnect;
        public adminSpecificEoMReport()
        {
            dbConnect = new DBConnect();
            InitializeComponent();
        }

        private void adminSpecificEoMReport_Load(object sender, EventArgs e)
        {
            cbDate.SelectedIndex = 0;
            //Form loading, code goes here -->
            int current_year = Convert.ToInt32(DateTime.Today.Year);
            for (int i = 1950; current_year >= i ; current_year--)
            {
                cbYear.Items.Add(current_year);
            }
            cbYear.SelectedIndex = 0;
        }
        private void fill_table()
        {
            String month = cbDate.Text;
            String year = cbYear.Text;
            String like_value = month + " " + year;
            String report_query = "SELECT SRID, date, firstName, surName, amount, services_remaining, services_left, invoice_number FROM services WHERE date LIKE '%" + like_value + "%'";

            dbConnect.services_initialise();
            dbConnect.services_Open_Connection();
            using (MySqlDataAdapter da = new MySqlDataAdapter(report_query, dbConnect.services_connection)) //create a new DataAdaptor
            {
                da.Fill(sr_table); //File the table with the values from the DataAdaptor
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //--> Main Button here, all code goes here!
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog(); //Asks the user to choose a file where the PDF will be saved
                fbd.ShowDialog();
                string u_path = fbd.SelectedPath;
                String month = cbDate.Text;
                String year = cbYear.Text;
                String like_value = month + " " + year;
                string file_name = "EoM Report for - " + like_value;
                using (ExcelPackage excelpkg = new ExcelPackage())
                {
                    excelpkg.Workbook.Properties.Title = "End of Month Report"; //Adds a title
                    excelpkg.Workbook.Worksheets.Add("Report"); //creates a new worksheet
                    ExcelWorksheet ws = excelpkg.Workbook.Worksheets[1]; //postion of the worksheet
                    ws.Name = "EoM Report";

                    var cell_SRID = ws.Cells[1, 1]; //declare the cells
                    var cell_date = ws.Cells[1, 2];
                    var cell_firstName = ws.Cells[1, 3];
                    var cell_surName = ws.Cells[1, 4];
                    var cell_amount = ws.Cells[1, 5];
                    var cell_services_remaining = ws.Cells[1, 6];
                    var cell_services_left = ws.Cells[1, 7];
                    var cell_invoice_number = ws.Cells[1, 8];

                    cell_SRID.Value = "SRID"; //sets a value to the cells
                    cell_date.Value = "Date";
                    cell_firstName.Value = "Firstname";
                    cell_surName.Value = "Surname";
                    cell_amount.Value = "Amount";
                    cell_services_remaining.Value = "Services Remaining";
                    cell_services_left.Value = "Services Left";
                    cell_invoice_number.Value = "Invoice Number";

                    fill_table();

                    ws.Cells["A3"].LoadFromDataTable(sr_table, false);

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
    }
}
