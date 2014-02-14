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
        private String title, firstName, surName, reg, number_of_services, services_left;
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
            btnSaveService.Enabled = false;
            txtInvoiceNumber.ReadOnly = true;
            txtAmount.ReadOnly = true;
            //these stay read only
            txtTitle.ReadOnly = true;
            txtFirstName.ReadOnly = true;
            txtSurName.ReadOnly = true;
            txtRegistration.ReadOnly = true;
        }

        private void btnSearchMenu_Click(object sender, EventArgs e)
        {
            searchMenu sm = new searchMenu();
            sm.Show();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtFirstName.Clear();
            txtSurName.Clear();
            txtRegistration.Clear();

            txtAmount.Clear();
            txtInvoiceNumber.Clear();
            txtServiceRecordID.Clear();
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
                            title = read.GetString(read.GetOrdinal("title"));
                            firstName = read.GetString(read.GetOrdinal("firstName"));
                            surName = read.GetString(read.GetOrdinal("surName"));
                            reg = read.GetString(read.GetOrdinal("registration"));
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

        private int check_false_services()
        {
            try
            {
                string get_false_query = "SELECT * FROM services WHERE SRID=@SRID AND services_left=@SL AND services_remaining=@SR";
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                MySqlCommand gfq = new MySqlCommand(get_false_query, dbConnect.services_connection);
                gfq.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                gfq.Parameters.AddWithValue("@SL", "FALSE");
                gfq.Parameters.AddWithValue("@SR", "0");
                var check_false_var = gfq.ExecuteScalar();
                if (check_false_var != null)// DBNull.Value)
                {
                    MessageBox.Show("This person has no bookings left!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Checking false values! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        } 

        private void check_services()
        {
            try
            {
               int check_var = check_false_services();
               if (check_var == 1)
               {
                   return;
               }

                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                string check_query = "SELECT MIN(services_remaining) FROM services WHERE SRID=@SRID AND services_left=@SL";
                string pull_query = "SELECT * FROM services WHERE SRID=@SRID AND services_left=@SL AND services_remaining=@SR";
                MySqlCommand cs = new MySqlCommand(check_query, dbConnect.services_connection);
                
                    cs.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                    cs.Parameters.AddWithValue("@SL", "TRUE");
                    var serv_rem = cs.ExecuteScalar();
                    if (serv_rem == DBNull.Value)
                    {
                        int n_o_s = Convert.ToInt32(number_of_services);
                        if (n_o_s == 0)
                        {
                            MessageBox.Show("This person has no services on their plan!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int sr;
                        sr = n_o_s - 1;
                        services_left = "TRUE";
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

                    upr.ExecuteNonQuery();
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
                MessageBox.Show("This is the last service available for this person!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                if (services_left == "")
                {
                    services_left = "TRUE";
                }
                dbConnect.services_initialise();
                dbConnect.services_Open_Connection();
                string insert_new_service_query = "INSERT INTO services (SRID, date, title, firstName, surName, registration, amount, services_remaining, services_left, invoice_number) VALUES (@SRID, @date, @title, @firstName, @surName, @registration, @amount, @services_remaining, @services_left, @invoice_number)";
                using (MySqlCommand cns = new MySqlCommand(insert_new_service_query, dbConnect.services_connection))
                {
                    cns.Parameters.AddWithValue("@SRID", txtServiceRecordID.Text);
                    cns.Parameters.AddWithValue("@date", dataOfService.Text);
                    cns.Parameters.AddWithValue("@title", title);
                    cns.Parameters.AddWithValue("@firstName", firstName);
                    cns.Parameters.AddWithValue("@surName", surName);
                    cns.Parameters.AddWithValue("@registration", reg);
                    cns.Parameters.AddWithValue("@amount", txtAmount.Text);
                    cns.Parameters.AddWithValue("@services_remaining", services_remaining);
                    cns.Parameters.AddWithValue("@services_left", services_left);
                    cns.Parameters.AddWithValue("@invoice_number", txtInvoiceNumber.Text);

                    cns.ExecuteNonQuery();
                }
                MessageBox.Show("Added and Completed!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error creating new service record! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            int val1, val2, val3, val4;
            val1 = val.validate_srid(txtServiceRecordID.Text);
            val2 = val.validate_currency(txtAmount.Text);
            val3 = val.validate_invoice_number(txtInvoiceNumber.Text);
            val4 = val.validate_registration(txtRegistration.Text);

            if (val1 != 1 || val2 != 1 || val3 != 1 || val4 != 1)
            {
                return;
            }

            MessageBox.Show("This may take a while...", "Be patient", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //get the values from the records table we need: firstname, surname and number of services
            //check the number of services remaining and add in a new service into the DB or if not record is available, create a new one
            check_services();
            //check what to do based on the number of services remaining
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }

        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            int val1 = val.validate_srid(txtServiceRecordID.Text);
            if (val1 != 1)
            {
                return;
            }
            get_values_from_records();
            //set to writable 
            txtInvoiceNumber.ReadOnly = false;
            txtAmount.ReadOnly = false;
            txtTitle.Text = title;
            txtFirstName.Text = firstName;
            txtSurName.Text = surName;
            txtRegistration.Text = reg;
            btnSaveService.Enabled = true;
        }
      
    }
}