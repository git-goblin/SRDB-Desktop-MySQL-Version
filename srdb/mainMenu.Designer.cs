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
            this.SuspendLayout();
            // 
            // btnAddrecord
            // 
            this.btnAddrecord.Location = new System.Drawing.Point(12, 19);
            this.btnAddrecord.Name = "btnAddrecord";
            this.btnAddrecord.Size = new System.Drawing.Size(110, 41);
            this.btnAddrecord.TabIndex = 0;
            this.btnAddrecord.Text = "Add Record";
            this.btnAddrecord.UseVisualStyleBackColor = true;
            this.btnAddrecord.Click += new System.EventHandler(this.btnAddrecord_Click);
            // 
            // btnSearchrecords
            // 
            this.btnSearchrecords.Location = new System.Drawing.Point(172, 19);
            this.btnSearchrecords.Name = "btnSearchrecords";
            this.btnSearchrecords.Size = new System.Drawing.Size(110, 41);
            this.btnSearchrecords.TabIndex = 1;
            this.btnSearchrecords.Text = "Search Records";
            this.btnSearchrecords.UseVisualStyleBackColor = true;
            this.btnSearchrecords.Click += new System.EventHandler(this.btnSearchrecords_Click);
            // 
            // btnAdminpanel
            // 
            this.btnAdminpanel.Location = new System.Drawing.Point(93, 103);
            this.btnAdminpanel.Name = "btnAdminpanel";
            this.btnAdminpanel.Size = new System.Drawing.Size(110, 41);
            this.btnAdminpanel.TabIndex = 2;
            this.btnAdminpanel.Text = "Administrator Panel";
            this.btnAdminpanel.UseVisualStyleBackColor = true;
            this.btnAdminpanel.Click += new System.EventHandler(this.btnAdminpanel_Click);
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 156);
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
    }
}