using System.Configuration;
using RMS.DataAccess;
using RMS.Logging;

namespace RMS.DataAccess
{
    public class SqliteConfigInfo : IBaseConfigInfo
    {
        private readonly string m_providerName;
        private readonly string m_connString;

        /// <summary>
        /// Sqlite provider name.
        /// </summary>
        public string ProviderName
        {
            get
            {
                return m_providerName;
            }
        }

        /// <summary>
        /// Sqlite connection string.
        /// </summary>
        public string ConnString
        {

            get
            {
                return m_connString;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SqliteConfigInfo()
        {
            try
            {
               DbCommon.GetDbConfig(ref m_providerName,ref m_connString,this);
            }
            catch(CustomDataException ex)
            {
                LoggerManager.GetILog("Constructor:SqlServerConfigInfo-" + ex.StackTrace);
            }
        }


    }
}
