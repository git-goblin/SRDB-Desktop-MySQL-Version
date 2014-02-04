namespace srdb
{
    partial class searchMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchMenu));
            this.btnSearchRecords = new System.Windows.Forms.Button();
            this.btnSearchServices = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearchRecords
            // 
            this.btnSearchRecords.Location = new System.Drawing.Point(12, 12);
            this.btnSearchRecords.Name = "btnSearchRecords";
            this.btnSearchRecords.Size = new System.Drawing.Size(90, 23);
            this.btnSearchRecords.TabIndex = 0;
            this.btnSearchRecords.Text = "Records";
            this.btnSearchRecords.UseVisualStyleBackColor = true;
            this.btnSearchRecords.Click += new System.EventHandler(this.btnSearchRecords_Click);
            // 
            // btnSearchServices
            // 
            this.btnSearchServices.Location = new System.Drawing.Point(112, 12);
            this.btnSearchServices.Name = "btnSearchServices";
            this.btnSearchServices.Size = new System.Drawing.Size(90, 23);
            this.btnSearchServices.TabIndex = 1;
            this.btnSearchServices.Text = "Services";
            this.btnSearchServices.UseVisualStyleBackColor = true;
            this.btnSearchServices.Click += new System.EventHandler(this.btnSearchServices_Click);
            // 
            // searchMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 43);
            this.Controls.Add(this.btnSearchServices);
            this.Controls.Add(this.btnSearchRecords);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "searchMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearchRecords;
        private System.Windows.Forms.Button btnSearchServices;
    }
}