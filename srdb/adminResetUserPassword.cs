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
    public partial class adminResetUserPassword : Form
    {
        private DBConnect dbConnect;
        public adminResetUserPassword()
        {
            dbConnect = new DBConnect();
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtRePassword.Text)
                {
                    MessageBox.Show("Passwords do not match!");
                    return;
                }
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Enter a Username!");
                    return;
                }
                if (txtPassword.Text == "" || txtPassword.TextLength < 7)
                {
                    MessageBox.Show("Password Cannot be blank and must be greater than 7 characters!");
                    return;
                }
                string pass = dbConnect.hash_value(txtRePassword.Text);

                dbConnect.Initialize();
                dbConnect.OpenConnection();

                string query = "UPDATE auth SET pass=@password WHERE username=@username";

                    dbConnect.Initialize();
                    dbConnect.OpenConnection();

                    using (MySqlCommand cmd = new MySqlCommand(query, dbConnect.connection))
                    {
                        cmd.Parameters.AddWithValue("@password", pass);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Password Successfully changed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing password " + ex);
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlMenu acm = new adminControlMenu();
            acm.Show();
        }
    }
}
