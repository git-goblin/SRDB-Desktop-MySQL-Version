namespace srdb
{
    partial class searchRecordsMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchRecordsMenu));
            this.btnSearchDate = new System.Windows.Forms.Button();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.btnSearchInvoiceNumber = new System.Windows.Forms.Button();
            this.btnSearchSoldyBy = new System.Windows.Forms.Button();
            this.btnSearchSRDBID = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearchDate
            // 
            this.btnSearchDate.Location = new System.Drawing.Point(12, 12);
            this.btnSearchDate.Name = "btnSearchDate";
            this.btnSearchDate.Size = new System.Drawing.Size(107, 34);
            this.btnSearchDate.TabIndex = 0;
            this.btnSearchDate.Text = "Search by Date";
            this.btnSearchDate.UseVisualStyleBackColor = true;
            this.btnSearchDate.Click += new System.EventHandler(this.btnSearchDate_Click);
            // 
            // btnSearchName
            // 
            this.btnSearchName.Location = new System.Drawing.Point(136, 12);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(107, 34);
            this.btnSearchName.TabIndex = 1;
            this.btnSearchName.Text = "Search by Name";
            this.btnSearchName.UseVisualStyleBackColor = true;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // btnSearchInvoiceNumber
            // 
            this.btnSearchInvoiceNumber.Location = new System.Drawing.Point(136, 62);
            this.btnSearchInvoiceNumber.Name = "btnSearchInvoiceNumber";
            this.btnSearchInvoiceNumber.Size = new System.Drawing.Size(107, 34);
            this.btnSearchInvoiceNumber.TabIndex = 3;
            this.btnSearchInvoiceNumber.Text = "Search Invoice Number";
            this.btnSearchInvoiceNumber.UseVisualStyleBackColor = true;
            this.btnSearchInvoiceNumber.Click += new System.EventHandler(this.btnSearchInvoiceNumber_Click);
            // 
            // btnSearchSoldyBy
            // 
            this.btnSearchSoldyBy.Location = new System.Drawing.Point(12, 62);
            this.btnSearchSoldyBy.Name = "btnSearchSoldyBy";
            this.btnSearchSoldyBy.Size = new System.Drawing.Size(107, 34);
            this.btnSearchSoldyBy.TabIndex = 2;
            this.btnSearchSoldyBy.Text = "Search Sold By";
            this.btnSearchSoldyBy.UseVisualStyleBackColor = true;
            this.btnSearchSoldyBy.Click += new System.EventHandler(this.btnSearchSoldyBy_Click);
            // 
            // btnSearchSRDBID
            // 
            this.btnSearchSRDBID.Location = new System.Drawing.Point(12, 118);
            this.btnSearchSRDBID.Name = "btnSearchSRDBID";
            this.btnSearchSRDBID.Size = new System.Drawing.Size(107, 34);
            this.btnSearchSRDBID.TabIndex = 4;
            this.btnSearchSRDBID.Text = "Search By Service Record ID";
            this.btnSearchSRDBID.UseVisualStyleBackColor = true;
            this.btnSearchSRDBID.Click += new System.EventHandler(this.btnSearchSRDBID_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(136, 118);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(107, 34);
            this.btnMainMenu.TabIndex = 5;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // searchRecordsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 168);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnSearchSRDBID);
            this.Controls.Add(this.btnSearchInvoiceNumber);
            this.Controls.Add(this.btnSearchSoldyBy);
            this.Controls.Add(this.btnSearchName);
            this.Controls.Add(this.btnSearchDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "searchRecordsMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Options";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearchDate;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.Button btnSearchInvoiceNumber;
        private System.Windows.Forms.Button btnSearchSoldyBy;
        private System.Windows.Forms.Button btnSearchSRDBID;
        private System.Windows.Forms.Button btnMainMenu;
    }
}