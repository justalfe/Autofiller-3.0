using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFiller_APP.Model
{
    public class DbConfigModel
    {
        public string server_name { get; set; }
        public string database_name { get; set; }
        public string authentication_mode { get; set; }
        public string user_id { get; set; }
        public string password { get; set; }
    }
}
