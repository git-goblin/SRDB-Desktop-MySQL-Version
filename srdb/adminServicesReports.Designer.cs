namespace srdb
{
    partial class adminServicesReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminServicesReports));
            this.btnEoMReport = new System.Windows.Forms.Button();
            this.btnSQLReport = new System.Windows.Forms.Button();
            this.btnMonthYearReport = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEoMReport
            // 
            this.btnEoMReport.Location = new System.Drawing.Point(12, 16);
            this.btnEoMReport.Name = "btnEoMReport";
            this.btnEoMReport.Size = new System.Drawing.Size(115, 23);
            this.btnEoMReport.TabIndex = 0;
            this.btnEoMReport.Text = "End of Month Report";
            this.btnEoMReport.UseVisualStyleBackColor = true;
            this.btnEoMReport.Click += new System.EventHandler(this.btnEoMReport_Click);
            // 
            // btnSQLReport
            // 
            this.btnSQLReport.Location = new System.Drawing.Point(12, 56);
            this.btnSQLReport.Name = "btnSQLReport";
            this.btnSQLReport.Size = new System.Drawing.Size(115, 23);
            this.btnSQLReport.TabIndex = 1;
            this.btnSQLReport.Text = "SQL Report";
            this.btnSQLReport.UseVisualStyleBackColor = true;
            this.btnSQLReport.Click += new System.EventHandler(this.btnSQLReport_Click);
            // 
            // btnMonthYearReport
            // 
            this.btnMonthYearReport.Location = new System.Drawing.Point(160, 16);
            this.btnMonthYearReport.Name = "btnMonthYearReport";
            this.btnMonthYearReport.Size = new System.Drawing.Size(115, 23);
            this.btnMonthYearReport.TabIndex = 2;
            this.btnMonthYearReport.Text = "Specific Month/Year ";
            this.btnMonthYearReport.UseVisualStyleBackColor = true;
            this.btnMonthYearReport.Click += new System.EventHandler(this.btnMonthYearReport_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(160, 56);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(115, 23);
            this.btnMainMenu.TabIndex = 3;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // adminServicesReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 95);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnMonthYearReport);
            this.Controls.Add(this.btnSQLReport);
            this.Controls.Add(this.btnEoMReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "adminServicesReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Services Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEoMReport;
        private System.Windows.Forms.Button btnSQLReport;
        private System.Windows.Forms.Button btnMonthYearReport;
        private System.Windows.Forms.Button btnMainMenu;
    }
}