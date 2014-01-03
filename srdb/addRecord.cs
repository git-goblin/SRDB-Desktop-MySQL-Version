using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using MySql.Data.MySqlClient;

namespace srdb
{
    public partial class addRecord : Form
    {
       private DBConnect dbConnect;
       private validate val;
        public addRecord()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
            val = new validate();
        }

        /* public void loadComboBoxes()
       {
           try
           {
               dbConnect.combobox_initialise();
               dbConnect.combobox_Open_Connection();

               var query = "SELECT model FROM model; SELECT soldBy FROM soldBy; SELECT salesBranch FROM salesBranch; SELECT type FROM type; SELECT paymentMethod FROM paymentMethod;";//"SELECT model FROM model UNION SELECT soldBy FROM soldBy UNION SELECT salesBranch FROM salesBranch UNION SELECT type FROM type UNION SELECT paymentMethod FROM paymentMethod" ;    //"SELECT model, soldBy, salesBranch, type, paymentMethod FROM comboboxlist";
               using (var command = new MySqlCommand(query, dbConnect.cb_connection))
               {
                   using (var reader = command.ExecuteReader())
                   {
                       //Iterate through the rows and add it to the combobox's items
                       while (reader.Read())
                       {
                           //CustomerIdComboBox.Items.Add(reader.GetString("Id"));
                           carModel.Items.Add(reader.GetString("model"));
                           soldBy.Items.Add(reader.GetString("soldBy"));
                           salesBranch.Items.Add(reader.GetString("salesBranch"));
                           carType.Items.Add(reader.GetString("type"));
                           paymentMethod.Items.Add(reader.GetString("paymentMethod"));
                       }
                   }
               }
           } 
           catch (Exception ex)
           {
               MessageBox.Show("Error loading ComboBoxes" + ex);
           }
       }*/

       public void loadCarModelCB()
       {
           try
           {
               dbConnect.combobox_initialise();
               dbConnect.combobox_Open_Connection();

               var query = "SELECT model FROM model";
               using (var command = new MySqlCommand(query, dbConnect.cb_connection))
               {
                   using (var reader = command.ExecuteReader())
                   {
                       //Iterate through the rows and add it to the combobox's items
                       while (reader.Read())
                       {
                           carModel.Items.Add(reader.GetString("model"));
                       }
                   }
               }
           } 
           catch (Exception ex)
           {
               MessageBox.Show("Error loading model ComboBox " + ex);
           }
       }
 
       public void loadSoldByCB()
       {
           try
           {
               dbConnect.combobox_initialise();
               dbConnect.combobox_Open_Connection();

               var query = "SELECT soldBy FROM soldBy";
               using (var command = new MySqlCommand(query, dbConnect.cb_connection))
               {
                   using (var reader = command.ExecuteReader())
                   {
                       //Iterate through the rows and add it to the combobox's items
                       while (reader.Read())
                       {
                           soldBy.Items.Add(reader.GetString("soldBy"));
                       }
                   }
               }
           } 
           catch (Exception ex)
           {
               MessageBox.Show("Error loading soldBy ComboBox " + ex);
           }
       }

       public void loadSalesBranchCB()
       {
           try
           {
               dbConnect.combobox_initialise();
               dbConnect.combobox_Open_Connection();

               var query = "SELECT salesBranch FROM salesBranch";
               using (var command = new MySqlCommand(query, dbConnect.cb_connection))
               {
                   using (var reader = command.ExecuteReader())
                   {
                       //Iterate through the rows and add it to the combobox's items
                       while (reader.Read())
                       {
                           salesBranch.Items.Add(reader.GetString("salesBranch"));
                       }
                   }
               }
           } 
           catch (Exception ex)
           {
               MessageBox.Show("Error loading salesBranch ComboBox " + ex);
           }
       }
    public void loadTypeCB()
       {
           try
           {
               dbConnect.combobox_initialise();
               dbConnect.combobox_Open_Connection();

               var query = "SELECT type FROM type";
               using (var command = new MySqlCommand(query, dbConnect.cb_connection))
               {
                   using (var reader = command.ExecuteReader())
                   {
                       //Iterate through the rows and add it to the combobox's items
                       while (reader.Read())
                       {
                           carType.Items.Add(reader.GetString("type"));
                       }
                   }
               }
           } 
           catch (Exception ex)
           {
               MessageBox.Show("Error loading type ComboBox " + ex);
           }
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
                           paymentMethod.Items.Add(reader.GetString("paymentMethod"));
                       }
                   }
               }
           } 
           catch (Exception ex)
           {
               MessageBox.Show("Error loading paymentMethod ComboBox " + ex);
           }
       }
      

        private void btnAddrecord_Click(object sender, EventArgs e)
        {
            int var1 = val.validate_name(txtFirstname.Text);
            int var2 = val.validate_name(txtSurname.Text);
            int var3 = val.validate_postcode(txtPostcode.Text);
            int var4 = val.validate_registration(txtRegistration.Text);
            int var5 = val.validate_currency(txtTotal.Text);
            int var6 = val.validate_currency(txtInvoicetotal.Text);
            int var7 = val.validate_currency(txtCommissionAmount.Text);

            int go_no_go = val.launch(var1, var2, var3, var4, var5, var6, var7); 

            if (go_no_go != 1) 
            {
                return;
            }

            try
            {
                dbConnect.Initialize();
                dbConnect.OpenConnection();

                String firstName = txtFirstname.Text;
                String surName = txtSurname.Text;
                String address1 = txtAddress1.Text;
                String address2 = txtAddress2.Text;
                String postcode = txtPostcode.Text;
                String registration = txtRegistration.Text;
                String model = carModel.Text;
                String date_sold = dateSold.Text;
                String invoiceNumber = txtInvoicenumber.Text;
                String sold_by = soldBy.Text;
                String sales_branch = salesBranch.Text;
                String type = carType.Text;
                String payment_method = paymentMethod.Text;
                String total = txtTotal.Text;
                String invoice_total = txtInvoicetotal.Text;
                String number_of_services = numberofServices.Text;
                String commission_amount = txtCommissionAmount.Text;

                string query = "INSERT INTO records (firstName, surName ,address1, address2, postcode, registration,  model, sold_by,  date_sold,  invoice_number, sales_branch, type, payment_method, total, invoice_total, number_of_services, commission_amount) VALUES (@firstName, @surName, @address1, @address2, @postcode, @registration, @model, @sold_by, @date_sold, @invoice_number, @sales_branch, @type, @payment_method, @total, @invoice_total, @number_of_services, @commission_amount)";

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@surName", surName);
                    cmd.Parameters.AddWithValue("@address1", address1);
                    cmd.Parameters.AddWithValue("@address2", address2);
                    cmd.Parameters.AddWithValue("@postcode", postcode);
                    cmd.Parameters.AddWithValue("@registration", registration);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@sold_by", sold_by);
                    cmd.Parameters.AddWithValue("@date_sold", date_sold);
                    cmd.Parameters.AddWithValue("@invoice_number", invoiceNumber);
                    cmd.Parameters.AddWithValue("@sales_branch", sales_branch);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@payment_method", payment_method);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@invoice_total", invoice_total);
                    cmd.Parameters.AddWithValue("@number_of_services", number_of_services);
                    cmd.Parameters.AddWithValue("@commission_amount", commission_amount);
                   
                    cmd.ExecuteNonQuery();
                    dbConnect.CloseConnection();
                }
                MessageBox.Show("Record Added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding this record!" + ex);
            }
        }

        private void btnClearform_Click(object sender, EventArgs e)
        {
            txtFirstname.Clear();
            txtSurname.Clear();
            txtAddress1.Clear();
            txtAddress2.Clear();
            txtAddress2.Clear();
            txtRegistration.Clear();
            txtInvoicenumber.Clear();
            txtTotal.Clear();
            txtPostcode.Clear();
            txtInvoicetotal.Clear();
            txtCommissionAmount.Clear();
            carModel.SelectedIndex = -1;
            soldBy.SelectedIndex = -1;
            salesBranch.SelectedIndex = -1;
            carType.SelectedIndex = -1;
            paymentMethod.SelectedIndex = -1;
            numberofServices.SelectedIndex = -1;
            dateSold.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }

        private void addRecord_Load(object sender, EventArgs e)
        {
            loadCarModelCB();
            loadSoldByCB();
            loadSalesBranchCB();
            loadTypeCB();
            loadPaymentMethodCB();
            carModel.SelectedIndex = 0;
            soldBy.SelectedIndex = 0;
            salesBranch.SelectedIndex = 0;
            carType.SelectedIndex = 0;
            paymentMethod.SelectedIndex = 0;
            numberofServices.SelectedIndex = 0;
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double total = double.Parse(txtTotal.Text);
                total = total + (total * 0.20);
                txtInvoicetotal.Text = total.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error auto-calculating VAT");
            }
        }
    }
}
