using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RMS.DataAccess
{
    public class MySqlProvider : IDbProvider
    {
        public System.Data.Common.DbProviderFactory Instance()
        {
            return MySqlClientFactory.Instance;
        }

        public System.Data.Common.DbParameter MakeParam(string paramName, MySqlDbType dbType, int size)
        {
            MySqlParameter param = null;

            param = size > 0 ? new MySqlParameter(paramName, dbType, size) : new MySqlParameter(paramName, dbType);

            return param;
        }


        public System.Data.Common.DbParameter MakeParam(string paramName, DbTypeWrapper dbType, int size)
        {
            throw new NotImplementedException();
        }
    }
}
