namespace srdb
{
    partial class adminControlMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminControlMenu));
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnAddRemoveUser = new System.Windows.Forms.Button();
            this.btnAmmendCombox = new System.Windows.Forms.Button();
            this.btnSQLQuery = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnResetUserPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Location = new System.Drawing.Point(12, 10);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(121, 23);
            this.btnDeleteRecord.TabIndex = 0;
            this.btnDeleteRecord.Text = "Delete Record";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // btnAddRemoveUser
            // 
            this.btnAddRemoveUser.Location = new System.Drawing.Point(12, 44);
            this.btnAddRemoveUser.Name = "btnAddRemoveUser";
            this.btnAddRemoveUser.Size = new System.Drawing.Size(121, 23);
            this.btnAddRemoveUser.TabIndex = 1;
            this.btnAddRemoveUser.Text = "Add/Delete User";
            this.btnAddRemoveUser.UseVisualStyleBackColor = true;
            this.btnAddRemoveUser.Click += new System.EventHandler(this.btnAddRemoveUser_Click);
            // 
            // btnAmmendCombox
            // 
            this.btnAmmendCombox.Location = new System.Drawing.Point(170, 10);
            this.btnAmmendCombox.Name = "btnAmmendCombox";
            this.btnAmmendCombox.Size = new System.Drawing.Size(121, 23);
            this.btnAmmendCombox.TabIndex = 2;
            this.btnAmmendCombox.Text = "Ammend ComboBoxes";
            this.btnAmmendCombox.UseVisualStyleBackColor = true;
            this.btnAmmendCombox.Click += new System.EventHandler(this.btnAmmendCombox_Click);
            // 
            // btnSQLQuery
            // 
            this.btnSQLQuery.Location = new System.Drawing.Point(170, 44);
            this.btnSQLQuery.Name = "btnSQLQuery";
            this.btnSQLQuery.Size = new System.Drawing.Size(121, 23);
            this.btnSQLQuery.TabIndex = 3;
            this.btnSQLQuery.Text = "Run SQL Query";
            this.btnSQLQuery.UseVisualStyleBackColor = true;
            this.btnSQLQuery.Click += new System.EventHandler(this.btnSQLQuery_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(170, 78);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(121, 23);
            this.btnMainMenu.TabIndex = 4;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnResetUserPassword
            // 
            this.btnResetUserPassword.Location = new System.Drawing.Point(12, 78);
            this.btnResetUserPassword.Name = "btnResetUserPassword";
            this.btnResetUserPassword.Size = new System.Drawing.Size(121, 23);
            this.btnResetUserPassword.TabIndex = 5;
            this.btnResetUserPassword.Text = "Reset User Password";
            this.btnResetUserPassword.UseVisualStyleBackColor = true;
            this.btnResetUserPassword.Click += new System.EventHandler(this.btnResetUserPassword_Click);
            // 
            // adminControlMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 114);
            this.Controls.Add(this.btnResetUserPassword);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnSQLQuery);
            this.Controls.Add(this.btnAmmendCombox);
            this.Controls.Add(this.btnAddRemoveUser);
            this.Controls.Add(this.btnDeleteRecord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "adminControlMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Control Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnAddRemoveUser;
        private System.Windows.Forms.Button btnAmmendCombox;
        private System.Windows.Forms.Button btnSQLQuery;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnResetUserPassword;
    }
}