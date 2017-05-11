using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using RMS.DataAccess;

namespace RMS.DataAccess
{
    /// <summary>
    /// 数据库配置元素集合.
    /// </summary>
    public class DbConfigurations : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DbConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DbConfiguration)element).ProviderName;
        }
    }
}
