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
        public partial class editForm : Form
        {
            private DBConnect dbConnect;
            private validate val;

            public editForm()
            {
                InitializeComponent();
                dbConnect = new DBConnect();
                val = new validate();
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

            private void btnSelectID_Click(object sender, EventArgs e)
            {
                int var1 = val.validate_id(txtSelectID.Text); 
                if (var1 != 1)
                {
                    return;
                }

                string ID = txtSelectID.Text;
                string selectID = "SELECT * FROM records WHERE ID=@ID";
               try
               { 
                dbConnect.Initialize();
                dbConnect.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(selectID, dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    using (MySqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                            //Gets the value by column name
                        txtFirstname.Text = read.GetString(read.GetOrdinal("firstName"));
                        txtSurname.Text = read.GetString(read.GetOrdinal("surName"));
                        txtAddress1.Text = read.GetString(read.GetOrdinal("address1"));
                        txtAddress2.Text = read.GetString(read.GetOrdinal("address2"));
                        txtPostcode.Text = read.GetString(read.GetOrdinal("postcode"));
                        txtRegistration.Text = read.GetString(read.GetOrdinal("registration"));
                        carModel.Text = read.GetString(read.GetOrdinal("model"));
                        dateSold.Text = read.GetString(read.GetOrdinal("date_sold"));
                        txtInvoicenumber.Text = read.GetString(read.GetOrdinal("invoice_number"));
                        soldBy.Text = read.GetString(read.GetOrdinal("sold_by"));
                        salesBranch.Text = read.GetString(read.GetOrdinal("sales_branch"));
                        carType.Text = read.GetString(read.GetOrdinal("type"));
                        paymentMethod.Text = read.GetString(read.GetOrdinal("payment_method"));
                        txtTotal.Text = read.GetString(read.GetOrdinal("total"));
                        txtInvoicetotal.Text = read.GetString(read.GetOrdinal("invoice_total"));
                        numberofServices.Text = read.GetString(read.GetOrdinal("number_of_services"));
                        txtCommissionAmount.Text = read.GetString(read.GetOrdinal("commission_amount"));
                   //     cmd.ExecuteNonQuery();
                     //   dbConnect.CloseConnection();
                    }
                } 
                   
                }
               catch (Exception ex)
               {
                   MessageBox.Show("Error with editing this record!" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }

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
                    MessageBox.Show("Error loading model ComboBox " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error loading soldBy ComboBox " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error loading salesBranch ComboBox " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error loading type ComboBox " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error loading paymentMethod ComboBox " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnSaveChanges_Click(object sender, EventArgs e)
            {
                try
                {
                    int var1 = val.validate_name(txtFirstname.Text);
                    int var2 = val.validate_name(txtSurname.Text);
                    int var3 = val.validate_postcode(txtPostcode.Text);
                    int var4 = val.validate_registration(txtRegistration.Text);
                    int var5 = val.validate_currency(txtTotal.Text);
                    int var6 = val.validate_currency(txtInvoicetotal.Text);
                    int var7 = val.validate_currency(txtCommissionAmount.Text);
   
                  int varID = val.validate_id(txtSelectID.Text); 
                     if (var1 != 1)
                  {
                    return;
                  }

                    int go_no_go = val.launch(var1, var2, var3, var4, var5, var6, var7);

                    if (go_no_go != 1)
                    {
                        return;
                    }

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
                    string ID = txtSelectID.Text;

                    string query = "UPDATE records SET firstName=@firstName, surName=@surName, address1=@address1, address2=@address2, postcode=@postcode, registration=@registration, model=@model, sold_by=@sold_by, date_sold=@date_sold, invoice_number=@invoice_number, sales_branch=@sales_branch, type=@type, payment_method=@payment_method, total=@total, invoice_total=@invoice_total, number_of_services=@number_of_services, commission_amount=@commission_amount WHERE ID=@ID";

                    dbConnect.Initialize();
                    dbConnect.OpenConnection();

                    using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.connection))

                    {
                        cmd.Parameters.AddWithValue("@ID", ID); 
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
                    MessageBox.Show("Values Updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating values " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnMenu_Click(object sender, EventArgs e)
            {
                this.Hide();
                mainMenu mm = new mainMenu();
                mm.Show();
            }

            private void editForm_Load(object sender, EventArgs e)
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
                    if (checkBoxVAT.Checked == false)
                    {
                        return;
                    }
                    double total = double.Parse(txtTotal.Text);
                    total = total + (total * 0.20);
                    txtInvoicetotal.Text = Math.Round(total, 2).ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error auto-calculating VAT", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }