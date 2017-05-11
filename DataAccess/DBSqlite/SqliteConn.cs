

namespace RMS.DataAccess
{
    /// <summary>
    /// SQLite Data操作执行类<含基本数据库相关操作>
    /// </summary>
    public class SqliteConn : SqliteFactory<SqliteConn>, IDbConnectionString
    {
        public new string ConnectionString
        {
            get
            {
                return BaseConfigFactory.ConfigurationDic["Sqlite"].ConnString;
            }
        }
    }
}
