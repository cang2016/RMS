using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RMS.DataAccess
{
    /// <summary>
    /// 配置工厂类.
    /// </summary>
    public class BaseConfigFactory
    {
        private static Dictionary<string, BaseConfigInfo> configurationDic;
        private static readonly object lockObject = new object();

        static BaseConfigFactory()
        {
            lock(lockObject)
            {
                foreach(Type type in Assembly.GetCallingAssembly().GetTypes().Where(t => t.FullName.Contains("ConfigInfo")))
                {
                    if(typeof(IBaseConfigInfo).IsAssignableFrom(type))
                    {
                        if(type == typeof(IBaseConfigInfo))
                        {
                            continue;
                        }

                        IBaseConfigInfo baseConfig = (IBaseConfigInfo)Activator.CreateInstance(type);
                        if(configurationDic == null)
                        {
                            configurationDic = new Dictionary<string, BaseConfigInfo>();
                        }
                        if(baseConfig == null)
                        {
                            continue;
                        }

                        configurationDic.Add(baseConfig.ProviderName, new BaseConfigInfo(baseConfig));
                    }
                }
            }
        }

        /// <summary>
        /// 配置字典集合.
        /// </summary>
        public static Dictionary<string,BaseConfigInfo> ConfigurationDic
        {
            get
            {
                return configurationDic;
            }
            set
            {
                configurationDic = value;
            }
        }
    }
}
