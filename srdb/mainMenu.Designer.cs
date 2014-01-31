namespace srdb
{
    partial class mainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainMenu));
            this.btnAddrecord = new System.Windows.Forms.Button();
            this.btnSearchrecords = new System.Windows.Forms.Button();
            this.btnAdminpanel = new System.Windows.Forms.Button();
            this.btnGeneratePDF = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnSearchServices = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddrecord
            // 
            this.btnAddrecord.Location = new System.Drawing.Point(12, 12);
            this.btnAddrecord.Name = "btnAddrecord";
            this.btnAddrecord.Size = new System.Drawing.Size(110, 26);
            this.btnAddrecord.TabIndex = 0;
            this.btnAddrecord.Text = "Add Record";
            this.btnAddrecord.UseVisualStyleBackColor = true;
            this.btnAddrecord.Click += new System.EventHandler(this.btnAddrecord_Click);
            // 
            // btnSearchrecords
            // 
            this.btnSearchrecords.Location = new System.Drawing.Point(143, 12);
            this.btnSearchrecords.Name = "btnSearchrecords";
            this.btnSearchrecords.Size = new System.Drawing.Size(110, 26);
            this.btnSearchrecords.TabIndex = 1;
            this.btnSearchrecords.Text = "Search Records";
            this.btnSearchrecords.UseVisualStyleBackColor = true;
            this.btnSearchrecords.Click += new System.EventHandler(this.btnSearchrecords_Click);
            // 
            // btnAdminpanel
            // 
            this.btnAdminpanel.Location = new System.Drawing.Point(12, 44);
            this.btnAdminpanel.Name = "btnAdminpanel";
            this.btnAdminpanel.Size = new System.Drawing.Size(110, 27);
            this.btnAdminpanel.TabIndex = 2;
            this.btnAdminpanel.Text = "Administrator Panel";
            this.btnAdminpanel.UseVisualStyleBackColor = true;
            this.btnAdminpanel.Click += new System.EventHandler(this.btnAdminpanel_Click);
            // 
            // btnGeneratePDF
            // 
            this.btnGeneratePDF.Location = new System.Drawing.Point(143, 77);
            this.btnGeneratePDF.Name = "btnGeneratePDF";
            this.btnGeneratePDF.Size = new System.Drawing.Size(110, 27);
            this.btnGeneratePDF.TabIndex = 3;
            this.btnGeneratePDF.Text = "Generate PDF";
            this.btnGeneratePDF.UseVisualStyleBackColor = true;
            this.btnGeneratePDF.Click += new System.EventHandler(this.btnGeneratePDF_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(178, 114);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnServices
            // 
            this.btnServices.Location = new System.Drawing.Point(12, 77);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(110, 27);
            this.btnServices.TabIndex = 5;
            this.btnServices.Text = "Services";
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // btnSearchServices
            // 
            this.btnSearchServices.Location = new System.Drawing.Point(143, 45);
            this.btnSearchServices.Name = "btnSearchServices";
            this.btnSearchServices.Size = new System.Drawing.Size(110, 26);
            this.btnSearchServices.TabIndex = 6;
            this.btnSearchServices.Text = "Search Services";
            this.btnSearchServices.UseVisualStyleBackColor = true;
            this.btnSearchServices.Click += new System.EventHandler(this.btnSearchServices_Click);
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 146);
            this.Controls.Add(this.btnSearchServices);
            this.Controls.Add(this.btnServices);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnGeneratePDF);
            this.Controls.Add(this.btnAdminpanel);
            this.Controls.Add(this.btnSearchrecords);
            this.Controls.Add(this.btnAddrecord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddrecord;
        private System.Windows.Forms.Button btnSearchrecords;
        private System.Windows.Forms.Button btnAdminpanel;
        private System.Windows.Forms.Button btnGeneratePDF;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnSearchServices;
    }
}