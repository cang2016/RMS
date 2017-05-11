using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace RMS.DataAccess
{
    /// <summary>
    /// 提供数据库引擎实例接口.
    /// </summary>
    public interface IDbProvider
    {
        /// <summary>
        /// 返回数据库引擎实例.
        /// </summary>
        /// <returns>引擎实例.</returns>
        DbProviderFactory Instance();

        /// <summary>
        /// 生成参数接口.
        /// </summary>
        /// <param name="ParamName">参数名称.</param>
        /// <param name="DbType">参数类型.</param>
        /// <param name="Size">参数大小..</param>
        /// <returns>生成后的参数.</returns>
        DbParameter MakeParam(string paramName, DbTypeWrapper dbType, Int32 size);
    }
}
