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
    public partial class adminComboBoxAmmed : Form
    {
        private DBConnect dbConnect;
        private validate val;
        public adminComboBoxAmmed()
        {
            dbConnect = new DBConnect();
            val = new validate();
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlMenu acm = new adminControlMenu();
            acm.Show();
        }

        private void adminComboBoxAmmed_Load(object sender, EventArgs e)
        {
            //fill the comboboxes here!!!
            load_and_refresh_combobox_values();
           
        }
        //model CB starts here
        private void btnAddValueModel_Click(object sender, EventArgs e)
        { 
          try
              { 
                    if (txtModel.Text == "")
                    {
                        MessageBox.Show("Input Required!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dbConnect.combobox_initialise();
                    dbConnect.combobox_Open_Connection();
                    string query = "INSERT INTO model (model) VALUES (@input_value)";
                    using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.cb_connection))
                    {
                        cmd.Parameters.AddWithValue("@input_value", txtModel.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Value added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding value" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnDeleteModel_Click(object sender, EventArgs e)
        {
            try
            {
                int var1 = val.validate_id(txtModalID.Text);
                if (var1 != 1)
                {
                    return;
                }
                dbConnect.combobox_initialise();
                dbConnect.combobox_Open_Connection();
                string DELETE_ROW = "DELETE FROM model WHERE ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(DELETE_ROW, dbConnect.cb_connection))
                {
                    cmd.Parameters.AddWithValue("@ID", txtModalID.Text);
                    cmd.ExecuteNonQuery();
                    dbConnect.cb_CloseConnection();
                }
                MessageBox.Show("Value Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting the row!" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //soldBy CB starts here
        private void btnAddValueSoldBy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoldBy.Text == "")
                {
                    MessageBox.Show("Input Required!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dbConnect.combobox_initialise();
                dbConnect.combobox_Open_Connection();
                string query = "INSERT INTO soldBy (soldBy) VALUES (@input_value)";
                using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.cb_connection))
                {
                    cmd.Parameters.AddWithValue("@input_value", txtSoldBy.Text);
                    cmd.ExecuteNonQuery();
                    dbConnect.cb_CloseConnection();
                }
                MessageBox.Show("Value Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding value" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSoldBy_Click(object sender, EventArgs e)
        {
            try
            {
                int var1 = val.validate_id(txtSoldByID.Text);
                if (var1 != 1)
                {
                    return;
                }
                dbConnect.combobox_initialise();
                dbConnect.combobox_Open_Connection();
                string DELETE_ROW = "DELETE FROM soldBy WHERE ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(DELETE_ROW, dbConnect.cb_connection))
                {
                    cmd.Parameters.AddWithValue("@ID", txtSoldByID.Text);
                    cmd.ExecuteNonQuery();
                    dbConnect.cb_CloseConnection();
                }
                MessageBox.Show("Value Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting the row!" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //salesBranch CB starts here
        private void btnAddValueSalesBranch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesBranch.Text == "")
                {
                    MessageBox.Show("Input Required!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dbConnect.combobox_initialise();
                dbConnect.combobox_Open_Connection();
                string query = "INSERT INTO salesBranch (salesBranch) VALUES (@input_value)";
                using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.cb_connection))
                {
                    cmd.Parameters.AddWithValue("@input_value", txtSalesBranch.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Value added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding value" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSalesBranchID_Click(object sender, EventArgs e)
        {
            try
            {
                int var1 = val.validate_id(txtSalesBranchID.Text);
                if (var1 != 1)
                {
                    return;
                }
                dbConnect.combobox_initialise();
                dbConnect.combobox_Open_Connection();
                string DELETE_ROW = "DELETE FROM salesBranch WHERE ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(DELETE_ROW, dbConnect.cb_connection))
                {
                    cmd.Parameters.AddWithValue("@ID", txtSalesBranchID.Text);
                    cmd.ExecuteNonQuery();
                    dbConnect.cb_CloseConnection();
                }
                MessageBox.Show("Value Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting the row!" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //type CB starts here
        private void btnAddValueType_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtType.Text == "")
                {
                    MessageBox.Show("Input Required!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dbConnect.combobox_initialise();
                dbConnect.combobox_Open_Connection();
                string query = "INSERT INTO type (type) VALUES (@input_value)";
                using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.cb_connection))
                {
                    cmd.Parameters.AddWithValue("@input_value", txtType.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Value added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding value" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTypeID_Click(object sender, EventArgs e)
        {
            try
            {
                int var1 = val.validate_id(txtTypeID.Text);
                if (var1 != 1)
                {
                    return;
                }
                dbConnect.combobox_initialise();
                dbConnect.combobox_Open_Connection();
                string DELETE_ROW = "DELETE FROM type WHERE ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(DELETE_ROW, dbConnect.cb_connection))
                {
                    cmd.Parameters.AddWithValue("@ID", txtTypeID.Text);
                    cmd.ExecuteNonQuery();
                    dbConnect.cb_CloseConnection();
                }
                MessageBox.Show("Value Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting the row!" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //paymentMethod CB starts here
        private void btnAddValuePaymentMethod_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPaymentMethod.Text == "")
                {
                    MessageBox.Show("Input Required!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dbConnect.combobox_initialise();
                dbConnect.combobox_Open_Connection();
                string query = "INSERT INTO paymentMethod (paymentMethod) VALUES (@input_value)";
                using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.cb_connection))
                {
                    cmd.Parameters.AddWithValue("@input_value", txtPaymentMethod.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Value added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding value" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletePaymentMethodID_Click(object sender, EventArgs e)
        {
            try
            {
                int var1 = val.validate_id(txtPaymentMethodID.Text);
                if (var1 != 1)
                {
                    return;
                }
                dbConnect.combobox_initialise();
                dbConnect.combobox_Open_Connection();
                string DELETE_ROW = "DELETE FROM paymentMethod WHERE ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(DELETE_ROW, dbConnect.cb_connection))
                {
                    cmd.Parameters.AddWithValue("@ID", txtPaymentMethodID.Text);
                    cmd.ExecuteNonQuery();
                    dbConnect.cb_CloseConnection();
                }
                MessageBox.Show("Value Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting the row!" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void load_and_refresh_combobox_values()
        {
            dbConnect.fill_data_model();
            dataGridViewModel.DataSource = dbConnect.m_table;
            dataGridViewModel.MultiSelect = false;

            dbConnect.fill_data_soldBy();
            dataGridViewSoldBy.DataSource = dbConnect.sb_table;
            dataGridViewSoldBy.MultiSelect = false;

            dbConnect.fill_data_salesBranch();
            dataGridViewSalesBranch.DataSource = dbConnect.sbr_table;
            dataGridViewSalesBranch.MultiSelect = false;

            dbConnect.fill_data_type();
            dataGridViewType.DataSource = dbConnect.t_table;
            dataGridViewType.MultiSelect = false;

            dbConnect.fill_data_paymentMethod();
            dataGridViewPaymentMethod.DataSource = dbConnect.pm_table;
            dataGridViewPaymentMethod.MultiSelect = false;
        }

        private void btnRefreshConnection_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminComboBoxAmmed acbm = new adminComboBoxAmmed();
            acbm.Show();
        }
    }
}
