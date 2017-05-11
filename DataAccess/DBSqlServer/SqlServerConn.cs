
namespace RMS.DataAccess
{
    public class SqlServerConn : SqlServerFactory<SqlServerConn>, IDbConnectionString
    {

        public new string ConnectionString
        {
            get
            {
                return BaseConfigFactory.ConfigurationDic["SqlServer"].ConnString;
            }
        }
    }
}
