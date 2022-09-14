namespace AutoFiller_APP
{
    partial class DbConfigForm
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
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lbl_serverName = new System.Windows.Forms.Label();
            this.lbl_database_name = new System.Windows.Forms.Label();
            this.txt_database_name = new System.Windows.Forms.TextBox();
            this.lbl_authentication = new System.Windows.Forms.Label();
            this.AuthenticaTypeBox = new System.Windows.Forms.ComboBox();
            this.lbl_user_name = new System.Windows.Forms.Label();
            this.txt_user_name = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_test_connection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(40, 38);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(197, 20);
            this.txtServerName.TabIndex = 0;
            // 
            // lbl_serverName
            // 
            this.lbl_serverName.AutoSize = true;
            this.lbl_serverName.Location = new System.Drawing.Point(40, 19);
            this.lbl_serverName.Name = "lbl_serverName";
            this.lbl_serverName.Size = new System.Drawing.Size(69, 13);
            this.lbl_serverName.TabIndex = 1;
            this.lbl_serverName.Text = "Server Name";
            // 
            // lbl_database_name
            // 
            this.lbl_database_name.AutoSize = true;
            this.lbl_database_name.Location = new System.Drawing.Point(40, 70);
            this.lbl_database_name.Name = "lbl_database_name";
            this.lbl_database_name.Size = new System.Drawing.Size(84, 13);
            this.lbl_database_name.TabIndex = 3;
            this.lbl_database_name.Text = "Database Name";
            // 
            // txt_database_name
            // 
            this.txt_database_name.Location = new System.Drawing.Point(40, 89);
            this.txt_database_name.Name = "txt_database_name";
            this.txt_database_name.Size = new System.Drawing.Size(197, 20);
            this.txt_database_name.TabIndex = 2;
            // 
            // lbl_authentication
            // 
            this.lbl_authentication.AutoSize = true;
            this.lbl_authentication.Location = new System.Drawing.Point(40, 127);
            this.lbl_authentication.Name = "lbl_authentication";
            this.lbl_authentication.Size = new System.Drawing.Size(75, 13);
            this.lbl_authentication.TabIndex = 5;
            this.lbl_authentication.Text = "Authentication";
            // 
            // AuthenticaTypeBox
            // 
            this.AuthenticaTypeBox.FormattingEnabled = true;
            this.AuthenticaTypeBox.Location = new System.Drawing.Point(40, 144);
            this.AuthenticaTypeBox.Name = "AuthenticaTypeBox";
            this.AuthenticaTypeBox.Size = new System.Drawing.Size(197, 21);
            this.AuthenticaTypeBox.TabIndex = 6;
            this.AuthenticaTypeBox.SelectedIndexChanged += new System.EventHandler(this.AuthenticaTypeBox_SelectedIndexChanged);
            // 
            // lbl_user_name
            // 
            this.lbl_user_name.AutoSize = true;
            this.lbl_user_name.Location = new System.Drawing.Point(40, 177);
            this.lbl_user_name.Name = "lbl_user_name";
            this.lbl_user_name.Size = new System.Drawing.Size(60, 13);
            this.lbl_user_name.TabIndex = 8;
            this.lbl_user_name.Text = "User Name";
            // 
            // txt_user_name
            // 
            this.txt_user_name.Location = new System.Drawing.Point(40, 196);
            this.txt_user_name.Name = "txt_user_name";
            this.txt_user_name.Size = new System.Drawing.Size(197, 20);
            this.txt_user_name.TabIndex = 7;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(40, 230);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(53, 13);
            this.lbl_password.TabIndex = 10;
            this.lbl_password.Text = "Password";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(40, 249);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(197, 20);
            this.txt_password.TabIndex = 9;
            // 
            // btn_test_connection
            // 
            this.btn_test_connection.Location = new System.Drawing.Point(12, 285);
            this.btn_test_connection.Name = "btn_test_connection";
            this.btn_test_connection.Size = new System.Drawing.Size(260, 35);
            this.btn_test_connection.TabIndex = 11;
            this.btn_test_connection.Text = "Save and Test Connection";
            this.btn_test_connection.UseVisualStyleBackColor = true;
            this.btn_test_connection.Click += new System.EventHandler(this.btn_test_connection_Click);
            // 
            // DbConfigForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 343);
            this.Controls.Add(this.btn_test_connection);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.lbl_user_name);
            this.Controls.Add(this.txt_user_name);
            this.Controls.Add(this.AuthenticaTypeBox);
            this.Controls.Add(this.lbl_authentication);
            this.Controls.Add(this.lbl_database_name);
            this.Controls.Add(this.txt_database_name);
            this.Controls.Add(this.lbl_serverName);
            this.Controls.Add(this.txtServerName);
            this.Name = "DbConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lbl_serverName;
        private System.Windows.Forms.Label lbl_database_name;
        private System.Windows.Forms.TextBox txt_database_name;
        private System.Windows.Forms.Label lbl_authentication;
        private System.Windows.Forms.ComboBox AuthenticaTypeBox;
        private System.Windows.Forms.Label lbl_user_name;
        private System.Windows.Forms.TextBox txt_user_name;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_test_connection;
    }
}
