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
        private String number_of_services, firstName, surName, services_left, services_Remaining, previous_date;
        private DateTime prev_date;
        private DateTime date_today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
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

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("This may take a moment...", "Please be patient", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Save the record
                int val1 = val.validate_currency(txtAmount.Text);
                int val2 = val.validate_invoice_number(txtInvoiceNumber.Text);
                int val3 = val.validate_id(txtServiceRecordID.Text);

                if (val1 != 1 && val2 != 1 && val3 != 1)
                {
                    MessageBox.Show("There were errors with the details you have entered! Review before sending again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                //select the values from records
                dbConnect.Initialize();
                dbConnect.OpenConnection();
                MySqlCommand read_from_records = new MySqlCommand("SELECT * FROM records WHERE SRID = @SRID", dbConnect.connection);
                read_from_records.Parameters.Add("@SRID", txtServiceRecordID.Text);
                using (MySqlDataReader read = read_from_records.ExecuteReader())
                {
                    firstName = read.GetString(read.GetOrdinal("firstName"));
                    surName = read.GetString(read.GetOrdinal("surName"));
                    number_of_services = read.GetString(read.GetOrdinal("number_of_services"));
                }
                dbConnect.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error gettings values from records! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //checks to see if a record exists, if not, create one
            try
            {
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                MySqlCommand check_record = new MySqlCommand("SELECT * FROM services WHERE SRID=@SRID", dbConnect.services_connection);
                if (check_record.ExecuteScalar() == null)
                {
                    try
                    {
                        string insert_query = "INSERT INTO (SRID, firstName, surName, services_remaining) VALUES (@SRID, @firstName, @surName, @services_remaining)";
                        using (MySqlCommand insert_service = new MySqlCommand(insert_query, dbConnect.services_connection))
                        {
                            insert_service.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                            insert_service.Parameters.AddWithValue("@firstName", firstName);
                            insert_service.Parameters.AddWithValue("@surName", surName);
                            insert_service.Parameters.AddWithValue("@services_remaining", services_Remaining);

                            insert_service.ExecuteNonQuery();
                            dbConnect.services_CloseConnection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting new services details! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking record! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //compare services and check
            try
            {
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                MySqlCommand read_from_services = new MySqlCommand("SELECT * FROM services WHERE SRID = @SRID AND `services_left` = `TRUE`", dbConnect.services_connection);
                read_from_services.Parameters.Add("@SRID", txtServiceRecordID.Text);
                using (MySqlDataReader read = read_from_services.ExecuteReader())
                {
                    services_left = read.GetString(read.GetOrdinal("services_left"));
                    services_Remaining = read.GetString(read.GetOrdinal("services_remaining"));
                    previous_date = read.GetString(read.GetOrdinal("date"));
                }
                dbConnect.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error gettings values from records! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (services_Remaining == "0")
            {
                MessageBox.Show("This person currently has no services left!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            //update previous record
            string update_previous_service = "UPDATE services SET services_remaining=@services_remaining, services_left=@services_left WHERE IN (SRID=@SRID, date=@prev_date)";
            int n_o_s = Convert.ToInt32(number_of_services);
            int s_r = Convert.ToInt32(services_Remaining);
            s_r = n_o_s - 1;
            services_Remaining = s_r.ToString();
            services_left = "FALSE";
            try
            {
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                using (MySqlCommand update_prev_service = new MySqlCommand(update_previous_service, dbConnect.services_connection))
                {
                    update_prev_service.Parameters.AddWithValue("@services_remaining", services_Remaining);
                    update_prev_service.Parameters.AddWithValue("@services_left", services_left);
                    update_prev_service.Parameters.AddWithValue("@prev_date", previous_date);
                    update_prev_service.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);

                    update_prev_service.ExecuteNonQuery();
                    dbConnect.services_CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the previous record! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //insert the new record into services
            string inset_query = "INSERT INTO services VALUES (@SRID, @date, @firstName, @surName, @amount, @services_remaining, @services_left, @invoice_number) WHERE SRID=@SRID";
            try
            {
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                using (MySqlCommand insert_service = new MySqlCommand(inset_query, dbConnect.services_connection))
                {
                    insert_service.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                    insert_service.Parameters.AddWithValue("@date", date_today);
                    insert_service.Parameters.AddWithValue("@firstName", firstName);
                    insert_service.Parameters.AddWithValue("@surName", surName);
                    insert_service.Parameters.AddWithValue("@amount", txtAmount.Text);
                    insert_service.Parameters.AddWithValue("@services_remaining", services_Remaining);
                    insert_service.Parameters.AddWithValue("@services_left", services_left); //Another check can be added, set this to true however is services remaing == 0 then this needs to be set to false
                    insert_service.Parameters.AddWithValue("@invoice_number", txtInvoiceNumber.Text);

                    insert_service.ExecuteNonQuery();
                    dbConnect.services_CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting the record! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //close the connection and done!



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