namespace AutoFiller_APP
{
    partial class ExportForm
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
            this.ExportSCExcel = new System.Windows.Forms.Button();
            this.ExportPrpExcel = new System.Windows.Forms.Button();
            this.ExportPatientData = new System.Windows.Forms.Button();
            this.startDateBox = new System.Windows.Forms.DateTimePicker();
            this.endDateBox = new System.Windows.Forms.DateTimePicker();
            this.AllCheckBox = new System.Windows.Forms.CheckBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExportSCExcel
            // 
            this.ExportSCExcel.Location = new System.Drawing.Point(226, 253);
            this.ExportSCExcel.Name = "ExportSCExcel";
            this.ExportSCExcel.Size = new System.Drawing.Size(166, 23);
            this.ExportSCExcel.TabIndex = 0;
            this.ExportSCExcel.Text = "Export Civil Sergeons to Excel";
            this.ExportSCExcel.UseVisualStyleBackColor = true;
            this.ExportSCExcel.Click += new System.EventHandler(this.ExportSCExcel_Click);
            // 
            // ExportPrpExcel
            // 
            this.ExportPrpExcel.Location = new System.Drawing.Point(402, 253);
            this.ExportPrpExcel.Name = "ExportPrpExcel";
            this.ExportPrpExcel.Size = new System.Drawing.Size(151, 23);
            this.ExportPrpExcel.TabIndex = 1;
            this.ExportPrpExcel.Text = "Export Preparers to Excel";
            this.ExportPrpExcel.UseVisualStyleBackColor = true;
            this.ExportPrpExcel.Click += new System.EventHandler(this.ExportPrpExcel_Click);
            // 
            // ExportPatientData
            // 
            this.ExportPatientData.Location = new System.Drawing.Point(67, 253);
            this.ExportPatientData.Name = "ExportPatientData";
            this.ExportPatientData.Size = new System.Drawing.Size(149, 23);
            this.ExportPatientData.TabIndex = 2;
            this.ExportPatientData.Text = "Export Patients to Excel";
            this.ExportPatientData.UseVisualStyleBackColor = true;
            this.ExportPatientData.Click += new System.EventHandler(this.ExportPatientData_Click);
            // 
            // startDateBox
            // 
            this.startDateBox.Location = new System.Drawing.Point(69, 41);
            this.startDateBox.Name = "startDateBox";
            this.startDateBox.Size = new System.Drawing.Size(200, 20);
            this.startDateBox.TabIndex = 3;
            // 
            // endDateBox
            // 
            this.endDateBox.Location = new System.Drawing.Point(353, 41);
            this.endDateBox.Name = "endDateBox";
            this.endDateBox.Size = new System.Drawing.Size(200, 20);
            this.endDateBox.TabIndex = 4;
            // 
            // AllCheckBox
            // 
            this.AllCheckBox.AutoSize = true;
            this.AllCheckBox.Location = new System.Drawing.Point(69, 195);
            this.AllCheckBox.Name = "AllCheckBox";
            this.AllCheckBox.Size = new System.Drawing.Size(37, 17);
            this.AllCheckBox.TabIndex = 5;
            this.AllCheckBox.Text = "All";
            this.AllCheckBox.UseVisualStyleBackColor = true;
            this.AllCheckBox.CheckedChanged += new System.EventHandler(this.AllCheckBox_CheckedChanged);
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(67, 90);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(200, 21);
            this.cmbGender.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(353, 90);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(67, 132);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 20);
            this.txtPhone.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(353, 132);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 9;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(9, 47);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(56, 13);
            this.lblFromDate.TabIndex = 10;
            this.lblFromDate.Text = "From Date";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(301, 46);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(46, 13);
            this.lblToDate.TabIndex = 11;
            this.lblToDate.Text = "To Date";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(9, 90);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 12;
            this.lblGender.Text = "Gender";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(301, 93);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 13;
            this.lblAddress.Text = "Address";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(9, 135);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(38, 13);
            this.lblPhone.TabIndex = 14;
            this.lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(301, 139);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email";
            // 
            // ExportForm
            // 
            this.ClientSize = new System.Drawing.Size(606, 528);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.AllCheckBox);
            this.Controls.Add(this.endDateBox);
            this.Controls.Add(this.startDateBox);
            this.Controls.Add(this.ExportPatientData);
            this.Controls.Add(this.ExportPrpExcel);
            this.Controls.Add(this.ExportSCExcel);
            this.Name = "ExportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExportSCExcel;
        private System.Windows.Forms.Button ExportPrpExcel;
        private System.Windows.Forms.Button ExportPatientData;
        private System.Windows.Forms.DateTimePicker startDateBox;
        private System.Windows.Forms.DateTimePicker endDateBox;
        private System.Windows.Forms.CheckBox AllCheckBox;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
    }
}
