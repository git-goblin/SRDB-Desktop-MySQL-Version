namespace srdb
{
    partial class adminSQLQueryMenu
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
            this.btnSearchQuery = new System.Windows.Forms.Button();
            this.btnOtherQueries = new System.Windows.Forms.Button();
            this.linkLabelSQL = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnSearchQuery
            // 
            this.btnSearchQuery.Location = new System.Drawing.Point(14, 20);
            this.btnSearchQuery.Name = "btnSearchQuery";
            this.btnSearchQuery.Size = new System.Drawing.Size(136, 38);
            this.btnSearchQuery.TabIndex = 0;
            this.btnSearchQuery.Text = "Search Query";
            this.btnSearchQuery.UseVisualStyleBackColor = true;
            this.btnSearchQuery.Click += new System.EventHandler(this.btnSearchQuery_Click);
            // 
            // btnOtherQueries
            // 
            this.btnOtherQueries.Location = new System.Drawing.Point(227, 20);
            this.btnOtherQueries.Name = "btnOtherQueries";
            this.btnOtherQueries.Size = new System.Drawing.Size(136, 38);
            this.btnOtherQueries.TabIndex = 1;
            this.btnOtherQueries.Text = "All Other Queries";
            this.btnOtherQueries.UseVisualStyleBackColor = true;
            this.btnOtherQueries.Click += new System.EventHandler(this.btnOtherQueries_Click);
            // 
            // linkLabelSQL
            // 
            this.linkLabelSQL.AutoSize = true;
            this.linkLabelSQL.Location = new System.Drawing.Point(39, 75);
            this.linkLabelSQL.Name = "linkLabelSQL";
            this.linkLabelSQL.Size = new System.Drawing.Size(298, 26);
            this.linkLabelSQL.TabIndex = 2;
            this.linkLabelSQL.TabStop = true;
            this.linkLabelSQL.Text = "If you are unsure what SQL syntax to use, make sure you \r\nfollow this link or con" +
    "tact the DBA before running SQL queries";
            this.linkLabelSQL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabelSQL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSQL_LinkClicked);
            // 
            // adminSQLQueryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 119);
            this.Controls.Add(this.linkLabelSQL);
            this.Controls.Add(this.btnOtherQueries);
            this.Controls.Add(this.btnSearchQuery);
            this.Name = "adminSQLQueryMenu";
            this.Text = "Admin SQL Query Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchQuery;
        private System.Windows.Forms.Button btnOtherQueries;
        private System.Windows.Forms.LinkLabel linkLabelSQL;
    }
}