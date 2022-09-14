namespace AutoFiller_APP
{
    partial class Main
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
            this._serverIP = new System.Windows.Forms.TextBox();
            this._saveServer = new System.Windows.Forms.Button();
            this._existingForms = new System.Windows.Forms.DataGridView();
            this._refresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._selectedCivilSurgeonPreview = new System.Windows.Forms.Label();
            this._selectedPreparerPreview = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.ExportData = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._existingForms)).BeginInit();
            this.SuspendLayout();
            // 
            // _serverIP
            // 
            this._serverIP.Location = new System.Drawing.Point(12, 12);
            this._serverIP.Name = "_serverIP";
            this._serverIP.Size = new System.Drawing.Size(94, 20);
            this._serverIP.TabIndex = 0;
            this._serverIP.Text = "localhost";
            // 
            // _saveServer
            // 
            this._saveServer.Location = new System.Drawing.Point(112, 12);
            this._saveServer.Name = "_saveServer";
            this._saveServer.Size = new System.Drawing.Size(75, 23);
            this._saveServer.TabIndex = 1;
            this._saveServer.Text = "Save Server";
            this._saveServer.UseVisualStyleBackColor = true;
            this._saveServer.Click += new System.EventHandler(this._saveServer_Click);
            // 
            // _existingForms
            // 
            this._existingForms.AllowUserToAddRows = false;
            this._existingForms.AllowUserToDeleteRows = false;
            this._existingForms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._existingForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._existingForms.Location = new System.Drawing.Point(12, 106);
            this._existingForms.MultiSelect = false;
            this._existingForms.Name = "_existingForms";
            this._existingForms.ReadOnly = true;
            this._existingForms.RowHeadersVisible = false;
            this._existingForms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._existingForms.Size = new System.Drawing.Size(949, 381);
            this._existingForms.TabIndex = 2;
            this._existingForms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._existingForms_CellDoubleClick);
            this._existingForms.KeyUp += new System.Windows.Forms.KeyEventHandler(this._existingForms_KeyUp);
            // 
            // _refresh
            // 
            this._refresh.Location = new System.Drawing.Point(886, 73);
            this._refresh.Name = "_refresh";
            this._refresh.Size = new System.Drawing.Size(75, 23);
            this._refresh.TabIndex = 3;
            this._refresh.Text = "Refresh";
            this._refresh.UseVisualStyleBackColor = true;
            this._refresh.Click += new System.EventHandler(this._refresh_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Test Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Civil Surgeon";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(131, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Preparer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "Management";
            // 
            // _selectedCivilSurgeonPreview
            // 
            this._selectedCivilSurgeonPreview.AutoSize = true;
            this._selectedCivilSurgeonPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectedCivilSurgeonPreview.Location = new System.Drawing.Point(250, 47);
            this._selectedCivilSurgeonPreview.Name = "_selectedCivilSurgeonPreview";
            this._selectedCivilSurgeonPreview.Size = new System.Drawing.Size(113, 20);
            this._selectedCivilSurgeonPreview.TabIndex = 47;
            this._selectedCivilSurgeonPreview.Text = "Management";
            // 
            // _selectedPreparerPreview
            // 
            this._selectedPreparerPreview.AutoSize = true;
            this._selectedPreparerPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectedPreparerPreview.Location = new System.Drawing.Point(250, 76);
            this._selectedPreparerPreview.Name = "_selectedPreparerPreview";
            this._selectedPreparerPreview.Size = new System.Drawing.Size(113, 20);
            this._selectedPreparerPreview.TabIndex = 48;
            this._selectedPreparerPreview.Text = "Management";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 73);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 23);
            this.button4.TabIndex = 49;
            this.button4.Text = "Statistics";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // ExportData
            // 
            this.ExportData.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.ExportData.Location = new System.Drawing.Point(816, 12);
            this.ExportData.Name = "ExportData";
            this.ExportData.Size = new System.Drawing.Size(145, 23);
            this.ExportData.TabIndex = 50;
            this.ExportData.Text = "Export";
            this.ExportData.UseVisualStyleBackColor = true;
            this.ExportData.Click += new System.EventHandler(this.ExportData_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(273, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 23);
            this.button5.TabIndex = 51;
            this.button5.Text = "Test Sql Connection";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 499);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.ExportData);
            this.Controls.Add(this.button4);
            this.Controls.Add(this._selectedPreparerPreview);
            this.Controls.Add(this._selectedCivilSurgeonPreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._refresh);
            this.Controls.Add(this._existingForms);
            this.Controls.Add(this._saveServer);
            this.Controls.Add(this._serverIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this._existingForms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox _serverIP;
        private System.Windows.Forms.Button _saveServer;
        private System.Windows.Forms.DataGridView _existingForms;
        private System.Windows.Forms.Button _refresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _selectedCivilSurgeonPreview;
        private System.Windows.Forms.Label _selectedPreparerPreview;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button ExportData;
        private System.Windows.Forms.Button button5;
    }
}

