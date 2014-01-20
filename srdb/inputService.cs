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
        private String firstName, surName, number_of_services, services_left;
        private String services_remaining, rowID;
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
                string pull_query = "SELECT * FROM services WHERE SRID=@SRID AND services_left=@SL AND services_remaining=@SR";
                MySqlCommand cs = new MySqlCommand(check_query, dbConnect.services_connection);
                
                    cs.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                    cs.Parameters.AddWithValue("@SL", "TRUE");
                    var serv_rem = cs.ExecuteScalar();
                    MessageBox.Show("Value of scaler: " + serv_rem);
                    if (serv_rem == DBNull.Value)
                    {
                        int n_o_s = Convert.ToInt32(number_of_services);
                        int sr;
                        sr = n_o_s - 1;
                        services_remaining = sr.ToString();
                        create_new_service();
                    }
                    else
                    {
                        MySqlCommand cs2 = new MySqlCommand(pull_query, dbConnect.services_connection);
                        cs2.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                        cs2.Parameters.AddWithValue("@SL", "TRUE");
                        cs2.Parameters.AddWithValue("@SR", serv_rem);
                        //If there is a record currently in the DB do this
                        using (MySqlDataReader read = cs2.ExecuteReader())
                        {
                            while (read.Read())
                            {
                                services_remaining = read.GetString(read.GetOrdinal("services_remaining"));
                                rowID = read.GetString(read.GetOrdinal("ID"));
                            }
                        }
                        update_previous_record();
                        check_service_remaining();
                    } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking services! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_previous_record()
        {
            try
            {
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                string update_query = "UPDATE services SET services_left=@SL WHERE ID=@ID";
                using (MySqlCommand upr = new MySqlCommand(update_query, dbConnect.services_connection))
                {
                    upr.Parameters.AddWithValue("@ID", rowID);
                    upr.Parameters.AddWithValue("@SL", "FALSE");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error updating previous record! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
         
        private void check_service_remaining()
        {
            int sr = Convert.ToInt32(services_remaining);
            if (sr < 1)
            {
                MessageBox.Show("The person has no services left!", "Be patient", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return; 
            }
            else if (sr > 0)
            {
                sr = sr - 1;
                if (sr == 0)
                {
                    services_left = "FALSE";
                }
                services_remaining = sr.ToString();
                create_new_service();
            }
        }
        private void create_new_service()
        {
            try
            {
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                string insert_new_service_query = "INSERT INTO services (SRID, date, firstName, surName, amount, services_remaining, services_left, invoice_number) VALUES (@SRID, @date, @firstName, @surName, @amount, @services_remaining, @services_left, @invoice_number)";
                using (MySqlCommand cns = new MySqlCommand(insert_new_service_query, dbConnect.services_connection))
                {
                    cns.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                    cns.Parameters.AddWithValue("@date", dataOfService.Text);
                    cns.Parameters.AddWithValue("@firstName", firstName);
                    cns.Parameters.AddWithValue("@surName", surName);
                    cns.Parameters.AddWithValue("@amount", txtAmount.Text);
                    cns.Parameters.AddWithValue("@services_remaining", services_remaining);
                    cns.Parameters.AddWithValue("@services_left", services_left);
                    cns.Parameters.AddWithValue("@invoice_number", txtInvoiceNumber.Text);

                    cns.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error creating new service record! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            int val1, val2, val3;
            val1 = val.validate_srid(txtServiceRecordID.Text);
            val2 = val.validate_currency(txtAmount.Text);
            val3 = val.validate_invoice_number(txtInvoiceNumber.Text);

            if (val1 != 1 || val2 != 1 || val3 != 1)
            {
                return;
            }

            MessageBox.Show("This may take a while...", "Be patient", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //get the values from the records table we need: firstname, surname and number of services
            get_values_from_records();
            //check the number of services remaining and add in a new service into the DB or if not record is available, create a new one
            check_services();
            //check what to do based on the number of services remaining
            MessageBox.Show("Added and Completed!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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