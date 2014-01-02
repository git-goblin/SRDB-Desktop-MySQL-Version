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
    public partial class deleteRow : Form
    {
        private DBConnect dbConnect;
        private validate val;
        public deleteRow()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
            val = new validate();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                int var1 = val.validate_id(txtDeleteRow.Text);
                if (var1 != 1)
                {
                    return;
                }
                dbConnect.Initialize();
                dbConnect.OpenConnection();
                string DELETE_ROW = "INSERT INTO deleted_records SELECT * FROM records WHERE ID=@ID";
                using (MySqlCommand cmd = new MySqlCommand(DELETE_ROW, dbConnect.connection))
                {
                    cmd.Parameters.AddWithValue("@ID", txtDeleteRow.Text);
                    cmd.ExecuteNonQuery();
                    dbConnect.CloseConnection();
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting the row!" + ex);
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
