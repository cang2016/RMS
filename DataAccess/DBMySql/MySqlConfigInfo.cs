using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.DataAccess;
using RMS.Logging;

namespace RMS.DataAccess
{
    public class MySqlConfigInfo : IBaseConfigInfo
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
        public MySqlConfigInfo()
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
