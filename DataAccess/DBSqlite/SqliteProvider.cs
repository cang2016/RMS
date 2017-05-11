using System.Data.Common;
using System.Data.SQLite;

namespace RMS.DataAccess
{
    class SqliteProvider : IDbProvider
    {
        public DbProviderFactory Instance()
        {
            return System.Data.SQLite.SQLiteFactory.Instance;
        }

        public DbParameter MakeParam(string paramName, DbTypeWrapper dbType, int size)
        {
            SQLiteParameter param = null;

            if (size > 0)
            {
                param = new SQLiteParameter(paramName, dbType, size);
            }
            else
            {
                param = new SQLiteParameter(paramName, dbType);
            }

            return param;
        }
    }
}
