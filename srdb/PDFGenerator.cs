using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
//using iTextSharp.text.pdf;
//using iTextSharp.text;  

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace srdb
{
    public partial class PDFGenerator : Form
    {
        private DBConnect dbConnect;
        private validate val;
        public PDFGenerator()
        {
            val = new validate();
            dbConnect = new DBConnect();
            InitializeComponent();
        }

        String Firstname, Surname, Address1, Address2, Postcode, Registration, carModel, dateSold, Invoicenumber, soldBy, salesBranch, carType, paymentMethod, Total, Invoicetotal, numberofServices, CommissionAmount;
        private void PDFGenerator_Load(object sender, EventArgs e)
        {
            //form on load
        }
        private void pull_from_db()
        {
            try
            {
                dbConnect.Initialize();
                dbConnect.OpenConnection();
                String ID = txtSRID.Text;
                if (val.validate_id(ID) != 1)
                {
                    return;
                }

                string selectID = "SELECT * FROM records WHERE ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(selectID, dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    using (MySqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        //Gets the value by column name
                        {
                            Firstname = read.GetString(read.GetOrdinal("firstName"));
                            Surname = read.GetString(read.GetOrdinal("surName"));
                            Address1 = read.GetString(read.GetOrdinal("address1"));
                            Address2 = read.GetString(read.GetOrdinal("address2"));
                            Postcode = read.GetString(read.GetOrdinal("postcode"));
                            Registration = read.GetString(read.GetOrdinal("registration"));
                            carModel = read.GetString(read.GetOrdinal("model"));
                            dateSold = read.GetString(read.GetOrdinal("date_sold"));
                            Invoicenumber = read.GetString(read.GetOrdinal("invoice_number"));
                            soldBy = read.GetString(read.GetOrdinal("sold_by"));
                            salesBranch = read.GetString(read.GetOrdinal("sales_branch"));
                            carType = read.GetString(read.GetOrdinal("type"));
                            paymentMethod = read.GetString(read.GetOrdinal("payment_method"));
                            Total = read.GetString(read.GetOrdinal("total"));
                            Invoicetotal = read.GetString(read.GetOrdinal("invoice_total"));
                            numberofServices = read.GetString(read.GetOrdinal("number_of_services"));
                            CommissionAmount = read.GetString(read.GetOrdinal("commission_amount"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with pulling values from the DB " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void create_PDF()
        {
            try
            {
                String ID = txtSRID.Text;
                string file_name = "Invoice - " + Invoicenumber + " From Service Record ID - " + ID;
                FolderBrowserDialog fbd = new FolderBrowserDialog(); //Asks the user to choose a file where the PDF will be saved
                fbd.ShowDialog();
                string u_path = fbd.SelectedPath;
                var document = new Document();
                PdfWriter.GetInstance(document, new FileStream(u_path + "/"+file_name+".pdf", FileMode.Create));
                document.Open();
                document.Add(new Paragraph("My First PDF"));
                document.Add(new Paragraph());
                document.Add(new Paragraph());
                document.Add(new Paragraph("Dear " + Firstname + " " + Surname));
                document.Add(new Paragraph());
                document.Add(new Paragraph());
                document.Add(new Paragraph("Main Body text goes here --> --> --> values can be added using concatination"));
                document.Add(new Paragraph());
                document.Add(new Paragraph());
                document.Add(new Paragraph("Ending to the letter goes here --> --> -->"));
                document.Add(new Paragraph());
                document.Add(new Paragraph());

                document.Close();
                MessageBox.Show("PDF Successfully created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PDF! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void invoice_PDF()
        {
            try
            {
                String ID = txtSRID.Text;
                string file_name = "Invoice - " + Invoicenumber + " From Service Record ID - " + ID;
                FolderBrowserDialog fbd = new FolderBrowserDialog(); //Asks the user to choose a file where the PDF will be saved
                fbd.ShowDialog();
                Font arial = FontFactory.GetFont("Arial", 12, BaseColor.GRAY);
                string u_path = fbd.SelectedPath;
                var document = new Document();
                PdfWriter.GetInstance(document, new FileStream(u_path + "/" + file_name + ".pdf", FileMode.Create)); //File path
                document.Open();
                PdfPTable inv_table = new PdfPTable(2);
                inv_table.HorizontalAlignment = 0;
                inv_table.SpacingBefore = 10;
                inv_table.SpacingAfter = 10;
                inv_table.DefaultCell.Border = 0;
                inv_table.SetWidths(new int[] { 1, 4 }); // Creates a 2x2 table, filled from top left to bottom right

                inv_table.AddCell(new Phrase("Invoice Number: ", arial));
                inv_table.AddCell(new Phrase(Invoicenumber, arial));
                inv_table.AddCell(new Phrase("Name: ", arial));
                inv_table.AddCell(new Phrase(Firstname + " " + Surname, arial));

                document.Add(inv_table);

                document.Close();
                MessageBox.Show("PDF Successfully created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PDF! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            pull_from_db();
            create_PDF();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }
    }
}
