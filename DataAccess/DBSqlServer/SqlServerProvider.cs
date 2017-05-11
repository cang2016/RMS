using System.Data.Common;
using System.Data.SqlClient;

namespace RMS.DataAccess
{
    public class SqlServerProvider : IDbProvider
    {
        public DbProviderFactory Instance()
        {
            return SqlClientFactory.Instance;
        }

        public DbParameter MakeParam(string paramName, DbTypeWrapper dbType, int size)
        {
            SqlParameter param = null;

            if (size > 0)
            {
                param = new SqlParameter(paramName, dbType, size);
            }
            else
            {
                param = new SqlParameter(paramName, dbType);
            }

            return param;
        }
    }
}
