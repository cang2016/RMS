using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using RMS.DataAccess;

namespace RMS.DataAccess
{
    /// <summary>
    /// 配置节点集合.
    /// </summary>
    public class DbConfigurationColl : ConfigurationSection
    {
        private static DbConfigurationColl m_dbConfiguration;

        /// <summary>
        /// 构造函数.
        /// </summary>
        public static DbConfigurationColl Configuration
        {
            get
            {
                if (m_dbConfiguration == null)
                {
                    m_dbConfiguration = (DbConfigurationColl)ConfigurationManager.GetSection("DBConfig");
                }

                return m_dbConfiguration;
            }
        }

        [ConfigurationProperty("DbConnections")]
        [ConfigurationCollection(typeof(DbConfigurations),
          AddItemName = "dbConnections",
          ClearItemsName = "ClearDbConnections",
          RemoveItemName = "RemoveDbConnections")]
        public DbConfigurations DbConnections
        {
            get
            {
                return (DbConfigurations)this["DbConnections"];
            }
            set
            {
                this["DbConnections"] = value;
            }
        }
    }
}
