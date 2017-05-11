using System;
using System.Data.Common;
using System.Data.OleDb;

namespace RMS.DataAccess
{
    public class OleDbProvider : IDbProvider
    {
        public DbProviderFactory Instance()
        {
            return System.Data.OleDb.OleDbFactory.Instance;
        }

        public DbParameter MakeParam(string paramName, OleDbType dbType, int size)
        {
            OleDbParameter param = null;

            if (size > 0)
            {
                param = new OleDbParameter(paramName, dbType, size);
            }
            else
            {
                param = new OleDbParameter(paramName, dbType);
            }

            return param;
        }

        public DbParameter MakeParam(string paramName, DbTypeWrapper dbType, int size)
        {
            throw new NotImplementedException();
        }
    }
}
