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
            this.ExportPDFData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExportSCExcel
            // 
            this.ExportSCExcel.Location = new System.Drawing.Point(45, 35);
            this.ExportSCExcel.Name = "ExportSCExcel";
            this.ExportSCExcel.Size = new System.Drawing.Size(198, 23);
            this.ExportSCExcel.TabIndex = 0;
            this.ExportSCExcel.Text = "Export Civil Sergeons to Excel";
            this.ExportSCExcel.UseVisualStyleBackColor = true;
            this.ExportSCExcel.Click += new System.EventHandler(this.ExportSCExcel_Click);
            // 
            // ExportPrpExcel
            // 
            this.ExportPrpExcel.Location = new System.Drawing.Point(43, 119);
            this.ExportPrpExcel.Name = "ExportPrpExcel";
            this.ExportPrpExcel.Size = new System.Drawing.Size(198, 23);
            this.ExportPrpExcel.TabIndex = 1;
            this.ExportPrpExcel.Text = "Export Preparers to Excel";
            this.ExportPrpExcel.UseVisualStyleBackColor = true;
            this.ExportPrpExcel.Click += new System.EventHandler(this.ExportPrpExcel_Click);
            // 
            // ExportPDFData
            // 
            this.ExportPDFData.Location = new System.Drawing.Point(43, 200);
            this.ExportPDFData.Name = "ExportPDFData";
            this.ExportPDFData.Size = new System.Drawing.Size(198, 23);
            this.ExportPDFData.TabIndex = 2;
            this.ExportPDFData.Text = "Export PDF Data to Excel";
            this.ExportPDFData.UseVisualStyleBackColor = true;
            this.ExportPDFData.Click += new System.EventHandler(this.ExportPDFData_Click);
            // 
            // ExportForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ExportPDFData);
            this.Controls.Add(this.ExportPrpExcel);
            this.Controls.Add(this.ExportSCExcel);
            this.Name = "ExportForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExportSCExcel;
        private System.Windows.Forms.Button ExportPrpExcel;
        private System.Windows.Forms.Button ExportPDFData;
    }
}
