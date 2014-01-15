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
        private String number_of_services, firstName, surName, services_left, services_Remaining, previous_date, input_sl, sl;
        private DateTime date_today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.);
        public inputService()
        {
            dbConnect = new DBConnect();
            val = new validate();
            InitializeComponent();
        }
        private void update_previous_record()
        {
            string update_previous_service = "UPDATE services SET services_remaining=@services_remaining, services_left=@services_left WHERE IN (SRID=@SRID, date=@prev_date)";

            //Get's the values pulled from the DB and converts them to INT so calculations can be performed 
            int n_o_s = Convert.ToInt32(number_of_services);
            int s_r = Convert.ToInt32(services_Remaining);
            if (s_r == 0)
            {
                services_left = "FALSE";
                s_r = 0;
            }
            else
            {
                input_sl = "TRUE";
                s_r = n_o_s - 1;
            }
            services_Remaining = s_r.ToString();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the previous record! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("This may take a moment...", "Please be patient", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Save the record
                int val1 = val.validate_currency(txtAmount.Text);
                int val2 = val.validate_invoice_number(txtInvoiceNumber.Text);
                int val3 = val.validate_srid(txtServiceRecordID.Text);

                if (val1 != 1 && val2 != 1 && val3 != 1)
                {
                    MessageBox.Show("There were errors with the details you have entered! Review before sending again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //select the values from records
                dbConnect.Initialize();
                dbConnect.OpenConnection();
                String get_rec_query = "SELECT * FROM records WHERE SRID=@SRID";
                using (MySqlCommand get_from_records = new MySqlCommand(get_rec_query, dbConnect.connection))
                {
                    get_from_records.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                 //   get_from_records.ExecuteNonQuery();
                    using (MySqlDataReader read = get_from_records.ExecuteReader())
                    {
                        while(read.Read())
                        firstName = read.GetString(read.GetOrdinal("firstName"));
                        surName = read.GetString(read.GetOrdinal("surName"));
                        number_of_services = read.GetString(read.GetOrdinal("number_of_services"));
                    }
                    //    dbConnect.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error gettings values from records! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //checks to see if a record exists, if not, create one
            try
            {
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                using (MySqlCommand check_record = new MySqlCommand("SELECT * FROM services WHERE SRID=@SRID", dbConnect.services_connection))
                {
                    check_record.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);

                    if (check_record.ExecuteScalar() == null)
                    {
                        try
                        {
                            string insert_query = "INSERT INTO services (SRID, firstName, surName, date, services_remaining, services_left) VALUES (@SRID, @firstName, @surName, @date, @services_remaining, @services_left)";
                            using (MySqlCommand insert_service = new MySqlCommand(insert_query, dbConnect.services_connection))
                            {
                                insert_service.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                                insert_service.Parameters.AddWithValue("@firstName", firstName);
                                insert_service.Parameters.AddWithValue("@surName", surName);
                                insert_service.Parameters.AddWithValue("@date", date_today);
                                insert_service.Parameters.AddWithValue("@services_left", txtServiceRecordID.Text); //Crude work around, it would keep flagging this as a previous service since service_left = TRUE so now it is set as the SRID it won't flag
                                insert_service.Parameters.AddWithValue("@services_remaining", number_of_services);

                                insert_service.ExecuteNonQuery();
                                // dbConnect.services_CloseConnection();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error inserting new service users details! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking record! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //compare services and check
            try
            {
                sl = "TRUE";
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                using (MySqlCommand read_from_services = new MySqlCommand("SELECT * FROM services WHERE SRID=@SRID AND services_left=@SL", dbConnect.services_connection))
                {
                   read_from_services.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                   read_from_services.Parameters.AddWithValue("@SL", sl);
                    using (MySqlDataReader read = read_from_services.ExecuteReader())
                    {
                        while(read.Read())
                        services_left = read.GetString(read.GetOrdinal("services_left"));
                        services_Remaining = read.GetString(read.GetOrdinal("services_remaining"));
                        previous_date = read.GetString(read.GetOrdinal("date"));
                    }
                    //dbConnect.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error gettings values from records for checking! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (services_Remaining == "0")
            {
                MessageBox.Show("This person currently has no services left!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //update previous record if an existing one exists
            string dt = date_today.ToString();
            if (previous_date != dt)
            {
                update_previous_record();
            }

            //insert the new record into services
            string inset_query = "INSERT INTO services VALUES (@SRID, @date, @firstName, @surName, @amount, @services_remaining, @services_left, @invoice_number)";
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
                    insert_service.Parameters.AddWithValue("@services_left", input_sl); //Another check can be added, set this to true however is services remaing == 0 then this needs to be set to false
                    insert_service.Parameters.AddWithValue("@invoice_number", txtInvoiceNumber.Text);

                    insert_service.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting the record! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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