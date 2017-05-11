using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace RMS.Logging
{
    public class AppenderConfig : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "Microsoft", IsRequired = true, IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("type", DefaultValue = "Microsoft", IsRequired = true, IsKey = true)]
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

        [ConfigurationProperty("description", DefaultValue = "Microsoft", IsRequired = true, IsKey = true)]
        public string Description
        {
            get
            {
                return (string)this["description"];
            }
            set
            {
                this["description"] = value;
            }
        }



        [ConfigurationProperty("path", DefaultValue = "Microsoft", IsRequired = false, IsKey = true)]
        public string Path
        {
            get
            {
                return (string)this["path"];
            }
            set
            {
                this["path"] = value;
            }
        }

        [ConfigurationProperty("fileName", DefaultValue = "Microsoft", IsRequired = false, IsKey = true)]
        public string FileName
        {
            get
            {
                return (string)this["fileName"];
            }
            set
            {
                this["fileName"] = value;
            }
        }

        [ConfigurationProperty("fileSize", DefaultValue = "Microsoft", IsRequired = false, IsKey = true)]
        public string FileSize
        {
            get
            {
                return (string)this["fileSize"];
            }
            set
            {
                this["fileSize"] = value;
            }
        }
    }
}
