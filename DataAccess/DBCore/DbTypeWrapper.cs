using System.Data;
using System.Data.OracleClient;
using System.Data.SQLite;

namespace RMS.DataAccess
{
    /// <summary>
    /// 封装转换.NET Framework 数据提供程序的字段、属性或 Parameter 对象的数据类型.
    /// </summary>
    public class DbTypeWrapper
    {
        private DbType m_dbType;

        public DbTypeWrapper(DbType dbType)
        {
            m_dbType = dbType;
        }

        public DbTypeWrapper(int dbType)
        {
            m_dbType = (DbType)dbType;
        }

        public DbTypeWrapper(OracleType dbType)
        {
            m_dbType = (DbType)dbType;
        }

        public DbTypeWrapper(SqlDbType dbType)
        {
            m_dbType = (DbType)dbType;
        }

        public DbTypeWrapper(TypeAffinity sqliteType)
        {
            m_dbType = (DbType)sqliteType;
        }

        public DbType DbType
        {
            get
            {
                return m_dbType;
            }
        }

        public static implicit operator DbType(DbTypeWrapper wrapper)
        {
            return wrapper.DbType;
        }

        public static implicit operator OracleType(DbTypeWrapper wrapper)
        {
            return (OracleType)wrapper.DbType;
        }

        public static implicit operator SqlDbType(DbTypeWrapper wrapper)
        {
            return (SqlDbType)wrapper.DbType;
        }

        public static implicit operator DbTypeWrapper(DbType dbType)
        {
            return new DbTypeWrapper(dbType);
        }

        public static implicit operator DbTypeWrapper(int dbType)
        {
            return new DbTypeWrapper((DbType)dbType);
        }

        public static implicit operator DbTypeWrapper(OracleType dbType)
        {
            return new DbTypeWrapper((DbType)dbType);
        }

        public static implicit operator DbTypeWrapper(SqlDbType dbType)
        {
            return new DbTypeWrapper((DbType)dbType);
        }

        public static implicit operator DbTypeWrapper(TypeAffinity sqliteType)
        {
            return new DbTypeWrapper((DbType)sqliteType);
        }
    }
}
