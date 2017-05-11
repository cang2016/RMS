using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.DataAccess
{
    /// <summary>
    /// 提供数据库引擎名称接口.
    /// </summary>
    public interface IDbProviderName
    {
        /// <summary>
        /// 数据库引擎名称.
        /// </summary>
        string DbProviderName
        {
            get;
        }
    }
}
