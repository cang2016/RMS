
namespace RMS.DataAccess
{
    /// <summary>
    /// OleDbConn Data操作执行类<含基本数据库相关操作>
    /// </summary>
    public class OleDbConn : OleDbFactory<OleDbConn>, IDbConnectionString
    {
        public new string ConnectionString
        {
            get
            {
                return BaseConfigFactory.ConfigurationDic["OleDb"].ConnString;
            }
        }   
    }
}
