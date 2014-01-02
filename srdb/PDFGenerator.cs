using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using iTextSharp.text.pdf;
//using iTextSharp.text;  

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace srdb
{
    public partial class PDFGenerator : Form
    {
        public PDFGenerator()
        {
            InitializeComponent();
        }

        private void PDFGenerator_Load(object sender, EventArgs e)
        {
            //form on load
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
          
           // SaveFileDialog sfd = new SaveFileDialog();
         //   sfd.ShowDialog();
            var document = new Document();
            string path = @"C:\PDF";
            PdfWriter.GetInstance(document, new FileStream(path + "/Tables.pdf", FileMode.Create));

            document.Open();
            document.Add(new Paragraph("My First PDF"));
            PdfPTable table = new PdfPTable(3);
            PdfPCell cell = new PdfPCell(new Phrase("Curriemotors Invoice"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            table.AddCell("Value 1");
            table.AddCell("Value 2");
            table.AddCell("Value 3");
            document.Add(table);
            document.Close();
        }
    }
}
