using System;
using System.Data.Common;
using Oracle.DataAccess.Client;

namespace RMS.DataAccess
{
    public class OracleProvider : IDbProvider
    {
        public DbProviderFactory Instance()
        {
            return OracleClientFactory.Instance;
        }

        public DbParameter MakeParam(string paramName,  OracleDbType  dbType, int size)
        {
            OracleParameter param = null;

            if (size > 0)
            {
                param = new OracleParameter(paramName, dbType, size);
            }
            else
            {
                param = new OracleParameter(paramName, dbType);
            }

            return param;
        }

        public DbParameter MakeParam(string paramName, DbTypeWrapper dbType, int size)
        {
            throw new NotImplementedException();
        }
    }
}
