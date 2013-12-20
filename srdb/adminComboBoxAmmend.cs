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
    public partial class adminComboBoxAmmend : Form
    {
        private DataTable table;
        private MySqlCommand cmd;
        private DBConnect dbConnect;
        private MySqlDataAdapter da;
        public adminComboBoxAmmend()
        {
            dbConnect = new DBConnect();
            table = new DataTable();
            cmd = new MySqlCommand();
            da = new MySqlDataAdapter("SELECT model, soldBy, salesBranch, type, paymentMethod FROM comboboxlist", dbConnect.connection);
            InitializeComponent();
        }
        void fillTable()
        {
            dbConnect.Initialize();
            dbConnect.OpenConnection(); 
            using (da)
            {    
                da.Fill(table);
                dataGridView1.DataSource = table; 
                dataGridView1.MultiSelect = false;
            }

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(table);
                MessageBox.Show("Table updated");
            }
                
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the table! " + ex);
            }
            }

        private void adminComboBoxAmmend_Load(object sender, EventArgs e)
        {
            fillTable();
        }
    }
}
