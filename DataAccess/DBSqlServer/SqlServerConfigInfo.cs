using System.Configuration;
using RMS.DataAccess;
using RMS.Logging;

namespace RMS.DataAccess
{
    public class SqlServerConfigInfo : IBaseConfigInfo
    {
        private readonly string m_providerName;
        private readonly string m_connString;

        /// <summary>
        /// SqlServer provider name.
        /// </summary>
        public string ProviderName
        {
            get
            {
                return m_providerName;
            }
        }

        /// <summary>
        ///  SqlServer connection string.
        /// </summary>
        public string ConnString
        {

            get
            {
                return m_connString;
            }
        }


        public SqlServerConfigInfo()
        {
            try
            {
            //System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetEntryAssembly().Location);
            //    m_providerName = config.AppSettings.Settings["DataProvider"].Value;
            //    m_connString = config.AppSettings.Settings["ConnectionString"].Value;

                DbCommon.GetDbConfig(ref m_providerName,ref m_connString,this);
            }
            catch (CustomDataException ex)
            {
                LoggerManager.GetILog("Constructor:SqlServerConfigInfo-" + ex.StackTrace);
            }
        }
    }
}
