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

namespace srdb
{
    public partial class inputService : Form
    {
        private DBConnect dbConnect;
        private validate val;
        private String firstName, surName, number_of_services;
        private String date, services_remaining, services_left;
        public inputService()
        {
            dbConnect = new DBConnect();
            val = new validate();
            InitializeComponent();
        }


        private void inputService_Load(object sender, EventArgs e)
        {
            //Form load
            loadPaymentMethodCB();
            cbPaymentmethod.SelectedIndex = 0;
        }

        private void btnSearchMenu_Click(object sender, EventArgs e)
        {
            searchRecordsMenu srm = new searchRecordsMenu();
            srm.Show();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtAmount.Clear();
            txtInvoiceNumber.Clear();
            txtServiceRecordID.Clear();
            cbPaymentmethod.SelectedIndex = 0;
            dataOfService.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        //Functions go here -->
        private void get_values_from_records()
        {
            try
            {
                dbConnect.Initialize();
                dbConnect.OpenConnection();
                string get_query = "SELECT * FROM records WHERE SRID=@SRID";
                using (MySqlCommand gvfr = new MySqlCommand(get_query, dbConnect.connection))
                {
                    gvfr.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                    using (MySqlDataReader read = gvfr.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            firstName = read.GetString(read.GetOrdinal("firstName"));
                            surName = read.GetString(read.GetOrdinal("surName"));
                            number_of_services = read.GetString(read.GetOrdinal("number_of_services"));
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error getting values from records! " +ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void check_services()
        {
            try
            {
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                string check_query = "SELECT MIN(services_remaining) FROM services WHERE SRID=@SRID AND services_left=@SL";
                using (MySqlCommand cs = new MySqlCommand(check_query, dbConnect.services_connection))
                {
                    cs.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                    cs.Parameters.AddWithValue("@SL", "TRUE"); 
                    using (MySqlDataReader read = cs.ExecuteReader())
                    {
                        while (read.Read())
                        {
                                //will use an IF statement, if NULL so something else, do something else
                                //Could use similar style to login form
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error checking services! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void create_new_service()
        {
            try
            {
                int n_o_s = Convert.ToInt32(number_of_services);
                int sr = n_o_s - 1;
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                string insert_new_service_query = "INSERT INTO services (SRID, date, firstName, surName, amount, services_remianing, services_left, invoice_number) VALUES (@SRID, @date, @firstName, @surName, @amount, @services_remianing, @services_left, @invoice_number)";
                using (MySqlCommand cns = new MySqlCommand(insert_new_service_query, dbConnect.services_connection))
                {
                    cns.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                    cns.Parameters.AddWithValue("@date", dataOfService.Text);
                    cns.Parameters.AddWithValue("@firstName", firstName);
                    cns.Parameters.AddWithValue("@surName", surName);
                    cns.Parameters.AddWithValue("@services_remianing", sr);
                    cns.Parameters.AddWithValue("@services_left", "TRUE");
                    cns.Parameters.AddWithValue("@invoice_number", txtInvoiceNumber.Text);

                    cns.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error creating new service record! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            int val1, val2;
            val1 = val.validate_srid(txtServiceRecordID.Text);
            val2 = val.validate_currency(txtAmount.Text);

            if (val1 != 1 && val2 != 1 && txtInvoiceNumber.TextLength < 3)
            {
                return;
            }

            MessageBox.Show("This may take a while...", "Be patient", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //get the values from the records table we need: firstname, surname and number of services
            get_values_from_records();





















        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }
        public void loadPaymentMethodCB()
        {
            try
            {
                dbConnect.combobox_initialise();
                dbConnect.combobox_Open_Connection();

                var query = "SELECT paymentMethod FROM paymentMethod";
                using (var command = new MySqlCommand(query, dbConnect.cb_connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            cbPaymentmethod.Items.Add(reader.GetString("paymentMethod"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading model ComboBox " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}