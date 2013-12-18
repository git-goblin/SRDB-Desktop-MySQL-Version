namespace srdb
{
    partial class editForm
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
            this.soldBy = new System.Windows.Forms.ComboBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnClearform = new System.Windows.Forms.Button();
            this.numberofServices = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtInvoicetotal = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.paymentMethod = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.carType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.salesBranch = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInvoicenumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateSold = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.carModel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegistration = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectID = new System.Windows.Forms.Button();
            this.txtSelectID = new System.Windows.Forms.TextBox();
            this.txtCommissionAmount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // soldBy
            // 
            this.soldBy.FormattingEnabled = true;
            this.soldBy.Location = new System.Drawing.Point(79, 280);
            this.soldBy.Name = "soldBy";
            this.soldBy.Size = new System.Drawing.Size(143, 21);
            this.soldBy.TabIndex = 70;
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(311, 334);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(133, 34);
            this.btnMenu.TabIndex = 69;
            this.btnMenu.Text = "Main Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(311, 273);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(133, 34);
            this.btnSaveChanges.TabIndex = 68;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnClearform
            // 
            this.btnClearform.Location = new System.Drawing.Point(311, 211);
            this.btnClearform.Name = "btnClearform";
            this.btnClearform.Size = new System.Drawing.Size(133, 34);
            this.btnClearform.TabIndex = 67;
            this.btnClearform.Text = "Clear Form";
            this.btnClearform.UseVisualStyleBackColor = true;
            this.btnClearform.Click += new System.EventHandler(this.btnClearform_Click);
            // 
            // numberofServices
            // 
            this.numberofServices.FormattingEnabled = true;
            this.numberofServices.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10 ",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            ""});
            this.numberofServices.Location = new System.Drawing.Point(370, 127);
            this.numberofServices.Name = "numberofServices";
            this.numberofServices.Size = new System.Drawing.Size(74, 21);
            this.numberofServices.TabIndex = 66;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(261, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 13);
            this.label16.TabIndex = 65;
            this.label16.Text = "Number of Services:";
            // 
            // txtInvoicetotal
            // 
            this.txtInvoicetotal.Location = new System.Drawing.Point(335, 101);
            this.txtInvoicetotal.Name = "txtInvoicetotal";
            this.txtInvoicetotal.Size = new System.Drawing.Size(109, 20);
            this.txtInvoicetotal.TabIndex = 64;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(257, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 63;
            this.label15.Text = "Invoice Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(314, 75);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(130, 20);
            this.txtTotal.TabIndex = 62;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(281, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 61;
            this.label14.Text = "Total:";
            // 
            // paymentMethod
            // 
            this.paymentMethod.FormattingEnabled = true;
            this.paymentMethod.Items.AddRange(new object[] {
            "New",
            "Renewed"});
            this.paymentMethod.Location = new System.Drawing.Point(353, 46);
            this.paymentMethod.Name = "paymentMethod";
            this.paymentMethod.Size = new System.Drawing.Size(91, 21);
            this.paymentMethod.TabIndex = 60;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(257, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "Payment Method:";
            // 
            // carType
            // 
            this.carType.FormattingEnabled = true;
            this.carType.Items.AddRange(new object[] {
            "New",
            "Renewed"});
            this.carType.Location = new System.Drawing.Point(79, 334);
            this.carType.Name = "carType";
            this.carType.Size = new System.Drawing.Size(143, 21);
            this.carType.TabIndex = 58;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 337);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "Type:";
            // 
            // salesBranch
            // 
            this.salesBranch.FormattingEnabled = true;
            this.salesBranch.Location = new System.Drawing.Point(79, 307);
            this.salesBranch.Name = "salesBranch";
            this.salesBranch.Size = new System.Drawing.Size(143, 21);
            this.salesBranch.TabIndex = 56;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 312);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 55;
            this.label11.Text = "Sales Branch:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "Sold by:";
            // 
            // txtInvoicenumber
            // 
            this.txtInvoicenumber.Location = new System.Drawing.Point(104, 255);
            this.txtInvoicenumber.Name = "txtInvoicenumber";
            this.txtInvoicenumber.Size = new System.Drawing.Size(118, 20);
            this.txtInvoicenumber.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Invoice Number:";
            // 
            // dateSold
            // 
            this.dateSold.Location = new System.Drawing.Point(79, 229);
            this.dateSold.Name = "dateSold";
            this.dateSold.Size = new System.Drawing.Size(143, 20);
            this.dateSold.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Date Sold:";
            // 
            // carModel
            // 
            this.carModel.FormattingEnabled = true;
            this.carModel.Location = new System.Drawing.Point(79, 202);
            this.carModel.Name = "carModel";
            this.carModel.Size = new System.Drawing.Size(143, 21);
            this.carModel.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Model:";
            // 
            // txtRegistration
            // 
            this.txtRegistration.Location = new System.Drawing.Point(79, 176);
            this.txtRegistration.Name = "txtRegistration";
            this.txtRegistration.Size = new System.Drawing.Size(143, 20);
            this.txtRegistration.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Registration:";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(79, 150);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(143, 20);
            this.txtPostcode.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Postcode:";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(79, 124);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(143, 20);
            this.txtAddress2.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Address 2:";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(79, 98);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(143, 20);
            this.txtAddress1.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Address 1:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(79, 72);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(143, 20);
            this.txtSurname.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Surname:";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(79, 46);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(143, 20);
            this.txtFirstname.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Firstname:";
            // 
            // btnSelectID
            // 
            this.btnSelectID.Location = new System.Drawing.Point(147, 12);
            this.btnSelectID.Name = "btnSelectID";
            this.btnSelectID.Size = new System.Drawing.Size(75, 23);
            this.btnSelectID.TabIndex = 71;
            this.btnSelectID.Text = "Select ID";
            this.btnSelectID.UseVisualStyleBackColor = true;
            this.btnSelectID.Click += new System.EventHandler(this.btnSelectID_Click);
            // 
            // txtSelectID
            // 
            this.txtSelectID.Location = new System.Drawing.Point(229, 14);
            this.txtSelectID.Name = "txtSelectID";
            this.txtSelectID.Size = new System.Drawing.Size(86, 20);
            this.txtSelectID.TabIndex = 72;
            // 
            // txtCommissionAmount
            // 
            this.txtCommissionAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtCommissionAmount.Location = new System.Drawing.Point(385, 154);
            this.txtCommissionAmount.Name = "txtCommissionAmount";
            this.txtCommissionAmount.Size = new System.Drawing.Size(59, 20);
            this.txtCommissionAmount.TabIndex = 74;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(281, 157);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 13);
            this.label17.TabIndex = 73;
            this.label17.Text = "Commission Amount:";
            // 
            // editForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 382);
            this.Controls.Add(this.txtCommissionAmount);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtSelectID);
            this.Controls.Add(this.btnSelectID);
            this.Controls.Add(this.soldBy);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnClearform);
            this.Controls.Add(this.numberofServices);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtInvoicetotal);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.paymentMethod);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.carType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.salesBranch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtInvoicenumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateSold);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.carModel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRegistration);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPostcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.label1);
            this.Name = "editForm";
            this.Text = "Edit Record";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox soldBy;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnClearform;
        private System.Windows.Forms.ComboBox numberofServices;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtInvoicetotal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox paymentMethod;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox carType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox salesBranch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtInvoicenumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateSold;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox carModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRegistration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectID;
        private System.Windows.Forms.TextBox txtSelectID;
        private System.Windows.Forms.TextBox txtCommissionAmount;
        private System.Windows.Forms.Label label17;
    }
}