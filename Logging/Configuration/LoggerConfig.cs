using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace RMS.Logging
{
    public class LoggerConfig : ConfigurationSection
    {
        private static LoggerConfig m_logger;

        public static LoggerConfig Logger
        {
            get
            {
                if (m_logger == null)
                {
                    m_logger = (LoggerConfig)ConfigurationManager.GetSection("logger");
                }

                return m_logger;
            }
        }

        [ConfigurationProperty("appenders")]
        [ConfigurationCollection(typeof(AppendersConfig),
          AddItemName = "appender",
          ClearItemsName = "clearappenders",
          RemoveItemName = "Removeappenders")]
        public AppendersConfig Appenders
        {
            get { return (AppendersConfig)this["appenders"]; }
            set { this["appenders"] = value; }
        }
    }
}
