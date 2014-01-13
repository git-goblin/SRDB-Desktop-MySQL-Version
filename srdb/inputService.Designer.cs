namespace srdb
{
    partial class inputService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inputService));
            this.btnSaveService = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServiceRecordID = new System.Windows.Forms.TextBox();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataOfService = new System.Windows.Forms.DateTimePicker();
            this.Date = new System.Windows.Forms.Label();
            this.cbPaymentmethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnSearchMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveService
            // 
            this.btnSaveService.Location = new System.Drawing.Point(254, 66);
            this.btnSaveService.Name = "btnSaveService";
            this.btnSaveService.Size = new System.Drawing.Size(84, 23);
            this.btnSaveService.TabIndex = 0;
            this.btnSaveService.Text = "Save Service";
            this.btnSaveService.UseVisualStyleBackColor = true;
            this.btnSaveService.Click += new System.EventHandler(this.btnSaveService_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(254, 94);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(84, 23);
            this.btnMainMenu.TabIndex = 1;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Service Record ID:";
            // 
            // txtServiceRecordID
            // 
            this.txtServiceRecordID.Location = new System.Drawing.Point(103, 12);
            this.txtServiceRecordID.Name = "txtServiceRecordID";
            this.txtServiceRecordID.Size = new System.Drawing.Size(100, 20);
            this.txtServiceRecordID.TabIndex = 3;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(103, 34);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(100, 20);
            this.txtInvoiceNumber.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Invoice Number:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(103, 86);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Amount: £";
            // 
            // dataOfService
            // 
            this.dataOfService.Location = new System.Drawing.Point(103, 60);
            this.dataOfService.Name = "dataOfService";
            this.dataOfService.Size = new System.Drawing.Size(135, 20);
            this.dataOfService.TabIndex = 8;
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(64, 66);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(33, 13);
            this.Date.TabIndex = 9;
            this.Date.Text = "Date:";
            // 
            // cbPaymentmethod
            // 
            this.cbPaymentmethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentmethod.FormattingEnabled = true;
            this.cbPaymentmethod.Location = new System.Drawing.Point(103, 112);
            this.cbPaymentmethod.Name = "cbPaymentmethod";
            this.cbPaymentmethod.Size = new System.Drawing.Size(121, 21);
            this.cbPaymentmethod.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Payment Method:";
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(254, 38);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(84, 23);
            this.btnClearForm.TabIndex = 12;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnSearchMenu
            // 
            this.btnSearchMenu.Location = new System.Drawing.Point(254, 10);
            this.btnSearchMenu.Name = "btnSearchMenu";
            this.btnSearchMenu.Size = new System.Drawing.Size(84, 23);
            this.btnSearchMenu.TabIndex = 13;
            this.btnSearchMenu.Text = "Search Menu";
            this.btnSearchMenu.UseVisualStyleBackColor = true;
            this.btnSearchMenu.Click += new System.EventHandler(this.btnSearchMenu_Click);
            // 
            // inputService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 151);
            this.Controls.Add(this.btnSearchMenu);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbPaymentmethod);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.dataOfService);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServiceRecordID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnSaveService);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "inputService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Service";
            this.Load += new System.EventHandler(this.inputService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveService;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServiceRecordID;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dataOfService;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.ComboBox cbPaymentmethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnSearchMenu;
    }
}