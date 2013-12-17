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
    public partial class adminAddUser : Form
    {
        private DBConnect dbConnect;
        private validate val;
        private string user_level;
        public adminAddUser()
        {
            dbConnect = new DBConnect();
            val = new validate(); 
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                int var1 = val.validate_name(txtFirstName.Text);
                int var2 = val.validate_name(txtSurName.Text);
                if (var1 != 1 && var2 != 1)
                {
                    return;
                } 
                if (txtPassword.Text == "" || txtPassword.TextLength < 7)
                {
                    MessageBox.Show("Password Cannot be blank and must be greater than 7 characters!");
                    return;
                } 
                
                if (rbStandardUser.Checked)
                {
                    user_level = "user";
                }
                else if (rbAdministrator.Checked)
                {
                    user_level = "Admin";
                } 
                string fn = txtFirstName.Text;
                string sn = txtSurName.Text; 

                string username = fn + sn[0];
                
                dbConnect.Initialize();
                dbConnect.OpenConnection();
                string query = "INSERT INTO Auth (username, firstName, surName, email, user_level, password) VALUES (@username, @firstName, @surName, @email, @user_level, @password)";
                using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@surname", txtSurName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@user_level", user_level);
                    cmd.Parameters.AddWithValue("@password", dbConnect.hash_value(txtPassword.Text));
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error Adding User" + ex);
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtSurName.Clear();
            txtEmail.Clear();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Form adminControlMenu = new Form();
        }
    }
}
