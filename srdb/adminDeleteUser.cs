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
    public partial class adminDeleteUser : Form
    {
        private DBConnect dbConnect;
        private validate val;
        public adminDeleteUser()
        {
            dbConnect = new DBConnect();
            val = new validate();
            InitializeComponent();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                int var1 = val.validate_id(txtUserID.Text);
                if (var1 != 1)
                {
                    return;
                }
                dbConnect.Initialize();
                dbConnect.OpenConnection();
                string DELETE_ROW = "DELETE FROM auth WHERE ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(DELETE_ROW, dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@ID", txtUserID.Text);
                    cmd.ExecuteNonQuery(); 
                    dbConnect.CloseConnection();
                }
                MessageBox.Show("User successuflly deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting the user! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
