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
    public partial class PDFGenerator : Form
    {
        private DBConnect dbConnect;
        private validate val;
        public PDFGenerator()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
            val = new validate();
        }

        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            int valid_ID = val.validate_id(txtPDFID.Text); 
            if (valid_ID != 1)
            {
                return;
            }
    
            dbConnect.login_initialise();
            dbConnect.login_Open_Connection();
            string login_query = "SELECT * FROM records WHERE ID=@ID";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@ID", txtPDFID.Text);
          
            MySqlDataReader reader = new MySqlDataReader();




        }
    }
}
