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
    public partial class inputService : Form
    {
        private DBConnect dbConnect;
        private validate val; 
        public inputService()
        {
            dbConnect = new DBConnect();
            val = new validate();
            InitializeComponent();
        }

        private void inputService_Load(object sender, EventArgs e)
        {
            //Form load
            loadPaymentMethodCB();
        }

        private void btnSearchMenu_Click(object sender, EventArgs e)
        {
            searchRecordsMenu srm = new searchRecordsMenu();
            srm.Show();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtAmount.Clear();
            txtInvoiceNumber.Clear();
            txtServiceRecordID.Clear();
            cbPaymentmethod.SelectedIndex = 0;
            dataOfService.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This may take a moment...", "Please be patient", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //Save the record
            int val1 = val.validate_currency(txtAmount.Text);
            int val3 = val.validate_id(txtServiceRecordID.Text);
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
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
                           cbPaymentmethod.Items.Add(reader.GetString("paymentMethod"));
                       }
                   }
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error loading model ComboBox " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       } 
    }
}
