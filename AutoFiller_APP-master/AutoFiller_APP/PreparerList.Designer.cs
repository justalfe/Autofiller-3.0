namespace AutoFiller_APP
{
    partial class PreparerList
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
            this._preparerData = new System.Windows.Forms.DataGridView();
            this._addCivilSurgeonButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._selectButton = new System.Windows.Forms.Button();
            this._unselectButton = new System.Windows.Forms.Button();
            this._selectedCivilSurgeonPreview = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._preparerData)).BeginInit();
            this.SuspendLayout();
            // 
            // _preparerData
            // 
            this._preparerData.AllowUserToAddRows = false;
            this._preparerData.AllowUserToDeleteRows = false;
            this._preparerData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._preparerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._preparerData.Location = new System.Drawing.Point(12, 12);
            this._preparerData.Name = "_preparerData";
            this._preparerData.ReadOnly = true;
            this._preparerData.RowHeadersVisible = false;
            this._preparerData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._preparerData.Size = new System.Drawing.Size(1164, 205);
            this._preparerData.TabIndex = 0;
            this._preparerData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._surgeonData_MouseDoubleClick);
            // 
            // _addCivilSurgeonButton
            // 
            this._addCivilSurgeonButton.Location = new System.Drawing.Point(1021, 223);
            this._addCivilSurgeonButton.Name = "_addCivilSurgeonButton";
            this._addCivilSurgeonButton.Size = new System.Drawing.Size(75, 23);
            this._addCivilSurgeonButton.TabIndex = 1;
            this._addCivilSurgeonButton.Text = "Add";
            this._addCivilSurgeonButton.UseVisualStyleBackColor = true;
            this._addCivilSurgeonButton.Click += new System.EventHandler(this._addCivilSurgeonButton_Click);
            // 
            // _deleteButton
            // 
            this._deleteButton.Location = new System.Drawing.Point(1102, 223);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(75, 23);
            this._deleteButton.TabIndex = 2;
            this._deleteButton.Text = "Delete";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
            // 
            // _selectButton
            // 
            this._selectButton.Location = new System.Drawing.Point(801, 223);
            this._selectButton.Name = "_selectButton";
            this._selectButton.Size = new System.Drawing.Size(75, 23);
            this._selectButton.TabIndex = 3;
            this._selectButton.Text = "Select";
            this._selectButton.UseVisualStyleBackColor = true;
            this._selectButton.Click += new System.EventHandler(this._selectButton_Click);
            // 
            // _unselectButton
            // 
            this._unselectButton.Location = new System.Drawing.Point(882, 223);
            this._unselectButton.Name = "_unselectButton";
            this._unselectButton.Size = new System.Drawing.Size(75, 23);
            this._unselectButton.TabIndex = 4;
            this._unselectButton.Text = "Unselect";
            this._unselectButton.UseVisualStyleBackColor = true;
            this._unselectButton.Click += new System.EventHandler(this._unselectButton_Click);
            // 
            // _selectedCivilSurgeonPreview
            // 
            this._selectedCivilSurgeonPreview.AutoSize = true;
            this._selectedCivilSurgeonPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectedCivilSurgeonPreview.Location = new System.Drawing.Point(12, 226);
            this._selectedCivilSurgeonPreview.Name = "_selectedCivilSurgeonPreview";
            this._selectedCivilSurgeonPreview.Size = new System.Drawing.Size(113, 20);
            this._selectedCivilSurgeonPreview.TabIndex = 48;
            this._selectedCivilSurgeonPreview.Text = "Management";
            // 
            // PreparerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 254);
            this.Controls.Add(this._selectedCivilSurgeonPreview);
            this.Controls.Add(this._unselectButton);
            this.Controls.Add(this._selectButton);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._addCivilSurgeonButton);
            this.Controls.Add(this._preparerData);
            this.Name = "PreparerList";
            this.Text = "PreparerSurgeonList";
            ((System.ComponentModel.ISupportInitialize)(this._preparerData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _preparerData;
        private System.Windows.Forms.Button _addCivilSurgeonButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Button _selectButton;
        private System.Windows.Forms.Button _unselectButton;
        private System.Windows.Forms.Label _selectedCivilSurgeonPreview;
    }
}