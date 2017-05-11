using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.DataAccess.DBMySql;

namespace RMS.DataAccess
{
    public class MySqlConn : MySqlFactory<MySqlConn>, IDbConnectionString
    {
        public new string ConnectionString
        {
            get
            {
                return BaseConfigFactory.ConfigurationDic["MySql"].ConnString;
            }
        }
    }
}
