using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace RMS.DataAccess
{
    /// <summary>
    /// 数据库配置类,用于设置ProviderName与ConnectionString.
    /// </summary>
    public class DbConfiguration : ConfigurationElement
    {
        /// <summary>
        /// 数据库引擎名称.
        /// </summary>
        [ConfigurationProperty("ProviderName", DefaultValue = "CC", IsRequired = true, IsKey = true)]
        public string ProviderName
        {
            get
            {
                return (string)this["ProviderName"];
            }
            set
            {
                this["ProviderName"] = value;
            }
        }

        /// <summary>
        /// 数据库连接字符.
        /// </summary>
        [ConfigurationProperty("ConnectionString", DefaultValue = "CC", IsRequired = true, IsKey = true)]
        public string ConnectionString
        {
            get
            {
                return (string)this["ConnectionString"];
            }
            set
            {
                this["ConnectionString"] = value;
            }
        }

        /// <summary>
        /// 数据库类型,如SqlServer,Sqlite,Oracle,OleDb.
        /// </summary>
        [ConfigurationProperty("type", DefaultValue = "CC", IsRequired = true, IsKey = true)]
        public string Type
        {
            get
            {
                return (string)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }
    }
}
