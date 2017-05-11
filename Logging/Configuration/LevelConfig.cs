namespace RMS.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    /// <summary>
    /// Level配置类
    /// </summary>
    public class LevelConfig : ConfigurationSection
    {
        public LevelConfig()
        {

        }

        [ConfigurationProperty("levelElement", IsRequired = true)]
        public LevelValuelElement Level
        {
            get
            {
                return (
                  (LevelValuelElement)this["levelElement"]);
            }
            set
            {
                this["levelElement"] = value;
            }
        }
    }

    /// <summary>
    /// Level元素值
    /// </summary>
    public class LevelValuelElement : ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = "Debug", IsRequired = true, IsKey = true)]
        public string Value
        {
            get
            {
                return (string)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
    }
}
