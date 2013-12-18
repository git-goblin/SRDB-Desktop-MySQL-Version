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
    public partial class adminAmmendComboBoxes : Form
    {
        private DBConnect dbConnect;
        public adminAmmendComboBoxes()
        {
            dbConnect = new DBConnect();
            InitializeComponent();
        }
        DataTable table = new DataTable(); //create a new DataTable, declared here as a global variable so it can be searched and used to created the DataGridView
        void fillData()
        {
            dbConnect.Initialize();
            dbConnect.OpenConnection();
            using (MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("SELECT model, soldBy, salesBranch, type, paymentMethod FROM ComboBoxList", dbConnect.connection)) //create a new DataAdaptor
            {
                dataAdaptor.Fill(table); //File the table with the values from the DataAdaptor
                dataGridView1.DataSource = table; //Set the source, so where the DataGridView gets its value from at the table we have passed the values from the DataAdaptor into
                dataGridView1.MultiSelect = false; //stop users from selecting more than one row
            }
        }
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlMenu acm = new adminControlMenu();
            acm.Show();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (rbAdd.Checked)
            {
                try
                {

                    dbConnect.Initialize();
                    dbConnect.OpenConnection();
                    string query = "INSERT INTO ComboBoxList (@value) VALUES (@input_value)";
                    using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.connection))
                    {
                        cmd.Parameters.AddWithValue("@value", cbColumns.SelectedValue);
                        cmd.Parameters.AddWithValue("@input_value", txtValueName.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding value" + ex);
                }

            }
            else if (rbDelete.Checked)
            {
                try
                {

                    dbConnect.Initialize();
                    dbConnect.OpenConnection();
                    string query = "DELETE FROM ComboBoxList WHERE @value = @input_value";
                    using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.connection))
                    {
                        cmd.Parameters.AddWithValue("@value", cbColumns.SelectedValue);
                        cmd.Parameters.AddWithValue("@input_value", txtValueName.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting value" + ex);
                }
            } 
        }
    }
}
