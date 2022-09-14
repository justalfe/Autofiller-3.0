using AutoFiller_APP.Entites;
using AutoFiller_APP.Model;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AutoFiller_APP
{
    public partial class DbConfigForm : Form
    {
        public DbConfigForm()
        {
            InitializeComponent();
            List<Item> items = new List<Item>();
            items.Add(new Item() { Text = "Windows Authentication", Value = "Windows" });
            items.Add(new Item() { Text = "Sql Server Authentication", Value = "SqlServer" });

            AuthenticaTypeBox.DataSource = items;
            AuthenticaTypeBox.DisplayMember = "Text";
            AuthenticaTypeBox.ValueMember = "Value";

            IsAuthencationMode("Windows");
            ReadConfigFromFile();
        }

        private class Item
        {
            public Item() { }

            public string Value { set; get; }
            public string Text { set; get; }
        }

        void IsAuthencationMode(string mode)
        {
            if (mode == "Windows")
            {
                lbl_user_name.Visible = false;
                lbl_password.Visible = false;
                txt_user_name.Visible = false;
                txt_password.Visible = false;
            }
            else
            {
                lbl_user_name.Visible = true;
                lbl_password.Visible = true;
                txt_user_name.Visible = true;
                txt_password.Visible = true;
            }
        }

        void ReadConfigFromFile()
        {
            try
            {
                var rootPath = System.Windows.Forms.Application.StartupPath.Replace("\\bin", "").Replace("\\Debug", "");
                var filetPath = rootPath + @"\DbManagment\DbConfig.json";
                var content = File.ReadAllText(filetPath);
                var model = JsonConvert.DeserializeObject<DbConfigModel>(content);
                if (model != null)
                {
                    txtServerName.Text = model.server_name;
                    txt_database_name.Text = model.database_name;
                    txt_user_name.Text = model.user_id;
                    txt_password.Text = model.password;
                    AuthenticaTypeBox.SelectedIndex = model.authentication_mode.Equals("SqlServer") ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem occured to read server configurations");
            }
        }

        private void AuthenticaTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsAuthencationMode(AuthenticaTypeBox.SelectedValue.ToString());
        }

        private void btn_test_connection_Click(object sender, EventArgs e)
        {
            try
            {
                //validate form
                var isFormValid = true;
                if (string.IsNullOrEmpty(txtServerName.Text))
                {
                    isFormValid = false;
                    MessageBox.Show("Enter Server Name.");
                }

                if (string.IsNullOrEmpty(txt_database_name.Text))
                {
                    isFormValid = false;
                    MessageBox.Show("Enter Database Name.");
                }

                if (string.IsNullOrEmpty(AuthenticaTypeBox.SelectedValue.ToString()))
                {
                    isFormValid = false;
                    MessageBox.Show("Select Authentication Mode.");
                }

                if (AuthenticaTypeBox.SelectedValue.ToString() == "SqlServer")
                {

                    if (string.IsNullOrEmpty(txt_user_name.Text))
                    {
                        isFormValid = false;
                        MessageBox.Show("Enter Sql Server UserName.");
                    }

                    if (string.IsNullOrEmpty(txt_password.Text))
                    {
                        isFormValid = false;
                        MessageBox.Show("Enter Sql Server Password.");
                    }

                }

                if (isFormValid)
                {
                    if (SaveConfigurations())
                    {
                        TestConnection();
                    }
                    else
                    {
                        MessageBox.Show("Unable to save configurations.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured to save & test connection settings.");
            }
        }

        private bool SaveConfigurations()
        {
            var model = new DbConfigModel()
            {
                authentication_mode = AuthenticaTypeBox.SelectedValue.ToString(),
                database_name = txt_database_name.Text,
                server_name = txtServerName.Text
            };

            if (model.authentication_mode.Equals("SqlServer"))
            {
                model.user_id = txt_user_name.Text;
                model.password = txt_password.Text;
            }

            var content = JsonConvert.SerializeObject(model);

            var rootPath = System.Windows.Forms.Application.StartupPath.Replace("\\bin", "").Replace("\\Debug", "");
            var filetPath = rootPath + @"\DbManagment\DbConfig.json";
            File.WriteAllText(filetPath, content);
            return true;
        }
        private void TestConnection()
        {
            using (var db = new AutoDBContext())
            {
                try
                {
                    db.Database.Connection.Open();
                    if (db.Database.Connection.State == ConnectionState.Open)
                    {
                        MessageBox.Show("You have been successfully connected to the database!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Connection failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed due to exception occured.");
                }

            }
        }
    }
}
