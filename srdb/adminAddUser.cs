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
                if (rbStandardUser.Checked)
                {
                    user_level = "user";
                }
                else if (rbAdministrator.Checked)
                {
                    user_level = "Admin";
                }
                string username = txtUserName.Text;
                
                dbConnect.Initialize();
                dbConnect.OpenConnection();
                string query = "INSERT INTO auth (username, pass, email, firstName, surName, user_level) VALUES (@username, @password, @email, @firstName, @surname, @user_level)"; //(`username`, `pass`, `email`, `firstName`, `surName`, `user_level`)
                using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@username", username.ToLower());
                    cmd.Parameters.AddWithValue("@password", dbConnect.hash_value(txtPassword.Text));
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@surname", txtSurName.Text);
                    cmd.Parameters.AddWithValue("@user_level", user_level);
                    cmd.ExecuteNonQuery();
                }
                dbConnect.CloseConnection();
                MessageBox.Show("User added successfully!\nTheir username is: " + username, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error Adding User " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int check_username()
        {
            try
            {
                dbConnect.Initialize();
                dbConnect.OpenConnection();
                int var1 = val.validate_name(txtFirstName.Text);
                int var2 = val.validate_name(txtSurName.Text);
                if (var1 != 1 && var2 != 1)
                {
                    return 0;
                }
                if (txtPassword.Text == "" || txtPassword.TextLength < 7)
                {
                    MessageBox.Show("Password Cannot be blank and must be greater than 7 characters!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return 0;
                } 

                string check_query = "SELECT * FROM auth WHERE username=@username";
                MySqlCommand check = new MySqlCommand(check_query, dbConnect.connection);
                check.Parameters.AddWithValue("@username", txtUserName.Text);
                if (check.ExecuteScalar() == null)
                {
                    return 1;
                }
                else
                {
                    MessageBox.Show("Username already exists, please choose another one", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
                return 0;
            }
        }
        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtSurName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtUserName.Clear();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlMenu acm = new adminControlMenu();
            acm.Show();
        }

        private void adminAddUser_Load(object sender, EventArgs e)
        {
            rbStandardUser.Checked = true;
            btnAddUser.Enabled = false;
        }

        private void btnCheckUser_Click(object sender, EventArgs e)
        {
            if (txtUserName.TextLength < 5)
            {
                MessageBox.Show("Invalid username! Must be at least 5 characters long", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int check = check_username();
            if (check != 1)
            {
                return;
            }
            btnAddUser.Enabled = true;
        }
    }
}
