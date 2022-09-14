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

            comboBox1.DataSource = items;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            IsAuthencationMode("Windows");
            ReadConfigFromFile();
        }

        private class Item
        {
            public Item() { }

            public string Value { set; get; }
            public string Text { set; get; }
        }


        private class DbConfigModel
        {
            public string server_name { get; set; }
            public string database_name { get; set; }
            public string authentication_mode { get; set; }
            public string user_id { get; set; }
            public string password { get; set; }
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
                    comboBox1.SelectedIndex = model.authentication_mode.Equals("SqlServer") ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem occured to read server configurations");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsAuthencationMode(comboBox1.SelectedValue.ToString());
        }

        private void btn_test_connection_Click(object sender, EventArgs e)
        {
            try
            {
                var model = new DbConfigModel()
                {
                    authentication_mode = comboBox1.SelectedValue.ToString(),
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



                using (SqlConnection connection = new SqlConnection("Data Source=2124OLDFIELD\\SQLEXPRESS;Initial Catalog=AutoFiller_APP_DB;Integrated Security=True"))
                {
                    try
                    {
                        connection.Open();
                        if (connection.State == ConnectionState.Open)
                        {
                            MessageBox.Show("You have been successfully connected to the database!");
                        }
                        else
                        {
                            MessageBox.Show("Connection failed.");
                        }
                    }
                    catch (SqlException) { }

                }


                  //  MessageBox.Show("Successfully Tested Connection.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured to save & test connection settings.");
            }



        }
    }
}
