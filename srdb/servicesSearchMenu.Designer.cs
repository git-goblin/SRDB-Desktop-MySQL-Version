namespace srdb
{
    partial class servicesSearchMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(servicesSearchMenu));
            this.btnSByDate = new System.Windows.Forms.Button();
            this.btnSByINum = new System.Windows.Forms.Button();
            this.btnSByName = new System.Windows.Forms.Button();
            this.btnSBySRID = new System.Windows.Forms.Button();
            this.btnSByRegistration = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSByDate
            // 
            this.btnSByDate.Location = new System.Drawing.Point(12, 12);
            this.btnSByDate.Name = "btnSByDate";
            this.btnSByDate.Size = new System.Drawing.Size(105, 23);
            this.btnSByDate.TabIndex = 0;
            this.btnSByDate.Text = "By Date";
            this.btnSByDate.UseVisualStyleBackColor = true;
            this.btnSByDate.Click += new System.EventHandler(this.btnSByDate_Click);
            // 
            // btnSByINum
            // 
            this.btnSByINum.Location = new System.Drawing.Point(132, 12);
            this.btnSByINum.Name = "btnSByINum";
            this.btnSByINum.Size = new System.Drawing.Size(105, 23);
            this.btnSByINum.TabIndex = 2;
            this.btnSByINum.Text = "By Invoice Number";
            this.btnSByINum.UseVisualStyleBackColor = true;
            this.btnSByINum.Click += new System.EventHandler(this.btnSByINum_Click);
            // 
            // btnSByName
            // 
            this.btnSByName.Location = new System.Drawing.Point(12, 41);
            this.btnSByName.Name = "btnSByName";
            this.btnSByName.Size = new System.Drawing.Size(105, 23);
            this.btnSByName.TabIndex = 3;
            this.btnSByName.Text = "By Name";
            this.btnSByName.UseVisualStyleBackColor = true;
            this.btnSByName.Click += new System.EventHandler(this.btnSByName_Click);
            // 
            // btnSBySRID
            // 
            this.btnSBySRID.Location = new System.Drawing.Point(12, 70);
            this.btnSBySRID.Name = "btnSBySRID";
            this.btnSBySRID.Size = new System.Drawing.Size(105, 23);
            this.btnSBySRID.TabIndex = 4;
            this.btnSBySRID.Text = "By SRID";
            this.btnSBySRID.UseVisualStyleBackColor = true;
            this.btnSBySRID.Click += new System.EventHandler(this.btnSBySRID_Click);
            // 
            // btnSByRegistration
            // 
            this.btnSByRegistration.Location = new System.Drawing.Point(132, 41);
            this.btnSByRegistration.Name = "btnSByRegistration";
            this.btnSByRegistration.Size = new System.Drawing.Size(105, 23);
            this.btnSByRegistration.TabIndex = 5;
            this.btnSByRegistration.Text = "By Registration";
            this.btnSByRegistration.UseVisualStyleBackColor = true;
            this.btnSByRegistration.Click += new System.EventHandler(this.btnSByRegistration_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(132, 70);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(105, 23);
            this.btnMainMenu.TabIndex = 6;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // servicesSearchMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 104);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnSByRegistration);
            this.Controls.Add(this.btnSBySRID);
            this.Controls.Add(this.btnSByName);
            this.Controls.Add(this.btnSByINum);
            this.Controls.Add(this.btnSByDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "servicesSearchMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Services Search Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSByDate;
        private System.Windows.Forms.Button btnSByINum;
        private System.Windows.Forms.Button btnSByName;
        private System.Windows.Forms.Button btnSBySRID;
        private System.Windows.Forms.Button btnSByRegistration;
        private System.Windows.Forms.Button btnMainMenu;
    }
}