using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions; //Allows Regex to be used

namespace srdb
{
    class validate
    {
        public int launch(int var1, int var2, int var3, int var4, int var5, int var6, int var7) 
        { 
            if (var1 == 1 && var2 == 1 && var3 == 1 && var4 == 1 && var5 == 1 && var6 == 1 && var7 == 1)
            {
                return 1;
            } 
            else 
            {
                MessageBox.Show("Invalid details or missing fields on the form! Review before sending again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return 0;
            }
        }
        
        public int validate_name(string input)
        {
            Regex regex_name = new Regex("^[A-Z][a-zA-Z]*$"); //@"/^[a-zA-ZàáâäãåąćęèéêëìíîïłńòóôöõøùúûüÿýżźñçčšžÀÁÂÄÃÅĄĆĘÈÉÊËÌÍÎÏŁŃÒÓÔÖÕØÙÚÛÜŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$/u"); //[A-Z][a-z]+( [A-Z][a-z]+) old REGEX
            if (regex_name.IsMatch(input) && input != "") 
            {
                return 1;
            } 
            else
            {
                MessageBox.Show("Invalid input for name!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int validate_postcode(string input)
        {
            Regex regex_postcode = new Regex("(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY])))) [0-9][A-Z-[CIKMOV]]{2})");
            if (regex_postcode.IsMatch(input) && input != "")
            {
                return 1;
            } 
            else
            {
                MessageBox.Show("Invalid input for postcode!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        } 
         
        public int validate_id(string input)
        {
            Regex regex_ID = new Regex("^[0-9]{1,999999}$");
            if (regex_ID.IsMatch(input) && input != "")
            {
                return 1;
            } 
            else
            {
                MessageBox.Show("Invalid input for ID!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int validate_currency(string input)
        {
            Regex regex_currency = new Regex(@"^\-?\(?\£?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$");//("/^£?(([1-9]{1,3}(,\d{3})*(\.\d{2})?)|(0\.[1-9]\d)|(0\.0[1-9]))$/"); 
            if (regex_currency.IsMatch(input) && input != "")
            {
                return 1;
            } 
            else
            {
                MessageBox.Show("Invalid input for this value!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int validate_registration(string input)
        {
            Regex regex_registration = new Regex(@"^([A-Z]{3}\s?(\d{3}|\d{2}|d{1})\s?[A-Z])|([A-Z]\s?(\d{3}|\d{2}|\d{1})\s?[A-Z]{3})|(([A-HK-PRSVWY][A-HJ-PR-Y])\s?([0][2-9]|[1-9][0-9])\s?[A-HJ-PR-Z]{3})$"); 
            if (regex_registration.IsMatch(input) && input != "")
            {
                return 1;
            }
            else
            {
                MessageBox.Show("Invalid input for registration!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

    }
}
