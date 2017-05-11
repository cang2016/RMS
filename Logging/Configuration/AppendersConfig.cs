using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace RMS.Logging
{
    public class AppendersConfig : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AppenderConfig();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((AppenderConfig)element).Name;
        }
    }
}
