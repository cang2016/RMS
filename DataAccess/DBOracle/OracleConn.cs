
namespace RMS.DataAccess
{
    public class OracleConn : OracleFactory<OracleConn>, IDbConnectionString
    {
        new public string ConnectionString
        {
            get
            {
                return BaseConfigFactory.ConfigurationDic["Oracle"].ConnString;
            }
        }
    }
}
