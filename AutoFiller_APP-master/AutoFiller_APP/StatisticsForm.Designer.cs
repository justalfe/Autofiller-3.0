namespace AutoFiller_APP
{
    partial class StatisticsForm
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
            this._listOfDates = new System.Windows.Forms.ComboBox();
            this._downloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _listOfDates
            // 
            this._listOfDates.FormattingEnabled = true;
            this._listOfDates.Location = new System.Drawing.Point(31, 35);
            this._listOfDates.Name = "_listOfDates";
            this._listOfDates.Size = new System.Drawing.Size(154, 21);
            this._listOfDates.TabIndex = 0;
            // 
            // _downloadButton
            // 
            this._downloadButton.Location = new System.Drawing.Point(67, 79);
            this._downloadButton.Name = "_downloadButton";
            this._downloadButton.Size = new System.Drawing.Size(75, 23);
            this._downloadButton.TabIndex = 1;
            this._downloadButton.Text = "Download";
            this._downloadButton.UseVisualStyleBackColor = true;
            this._downloadButton.Click += new System.EventHandler(this._downloadButton_Click);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 137);
            this.Controls.Add(this._downloadButton);
            this.Controls.Add(this._listOfDates);
            this.Name = "StatisticsForm";
            this.Text = "Statistics";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _listOfDates;
        private System.Windows.Forms.Button _downloadButton;
    }
}