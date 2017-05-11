using System;
using System.Configuration;
using System.IO;
using RMS.DataAccess;

namespace RMS.DataAccess
{
    /// <summary>
    /// 数据库访问连接配置基类.
    /// </summary>
    public class BaseConfigInfo
    {
        private IBaseConfigInfo instance;

        public BaseConfigInfo(IBaseConfigInfo baseConfigInfo)
        {
            instance = baseConfigInfo;
        }

        /// <summary>
        /// 数据库连接串.
        /// </summary>
        public string ConnString
        {
            get
            {
                return instance.ConnString;
            }
        }

        /// <summary>
        /// 数据库引擎名称.
        /// </summary>
        public string ProviderName
        {
            get
            {
                return instance.ProviderName;
            }
        }
    }
}
