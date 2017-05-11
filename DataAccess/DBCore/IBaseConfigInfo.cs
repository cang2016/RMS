using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.DataAccess
{
    /// <summary>
    /// 提供配置信息接口 .
    /// </summary>
    public interface IBaseConfigInfo
    {
        /// <summary>
        /// 数据库连接串.
        /// </summary>
        string ConnString
        {
            get;
        }

        /// <summary>
        /// 数据库引擎名称.
        /// </summary>
        string ProviderName
        {
            get;
        }
    }
}
