using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFiller_APP.Model
{
    public class DbConnectionSetupModel
    {
        private string _connectionString;
        public static string ConnectionString
        {
            get
            {
                return BuildConnectionString();
            }
        }

        private static string BuildConnectionString()
        {

            var rootPath = System.Windows.Forms.Application.StartupPath.Replace("\\bin", "").Replace("\\Debug", "");
            var filetPath = rootPath + @"\DbManagment\DbConfig.json";
            var content = File.ReadAllText(filetPath);
            var model = JsonConvert.DeserializeObject<DbConfigModel>(content);


            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = model.server_name,
                InitialCatalog = model.database_name,
                MultipleActiveResultSets = true,
            };

            if (model.authentication_mode.Equals("SqlServer"))
            {
                sqlConnectionStringBuilder.UserID = model.user_id;
                sqlConnectionStringBuilder.Password = model.password;
                sqlConnectionStringBuilder.IntegratedSecurity = false;
            }
            else
            {
                sqlConnectionStringBuilder.IntegratedSecurity = true;
            }

            //Entityramework connection string builder
            EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata = @"res://*/Entites.DBUtilityModel.csdl|res://*/Entites.DBUtilityModel.ssdl|res://*/Entites.DBUtilityModel.msl",
                ProviderConnectionString = sqlConnectionStringBuilder.ToString()
            };


            return entityConnectionStringBuilder.ToString();
        }
    }
}
