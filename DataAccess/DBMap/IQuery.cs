using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace RMS.DataAccess
{
    /// <summary>
    /// 通过Sql语句来获取对象或列表.
    /// </summary>
    public interface IQuery
    {
        /// <summary>
        /// 通过Sql语句来获取对象列表.
        /// </summary>
        /// <typeparam name="T">实体对象类型.</typeparam>
        /// <param name="commandType">命令类型.</param>
        /// <param name="sql">Sql语句.</param>
        /// <param name="parameters">命令参数数组.</param>
        /// <returns>对象实例列表.</returns>
        List<T> QueryAsObjectInstanceList<T>(CommandType commandType, string sql, params DbParameter[] parameters) where T : new();

        /// <summary>
        /// 通过Sql语句来获取对象列表.
        /// </summary>
        /// <typeparam name="T">实体对象类型.</typeparam>
        /// <param name="sql">Sql语句.</param>
        /// <returns>对象实例列表.</returns>
        List<T> QueryAsObjectInstanceList<T>(string sql) where T : new();

        /// <summary>
        /// 通过Sql语句来获取对象.
        /// </summary>
        /// <typeparam name="T">实体对象类型.</typeparam>
        /// <param name="commandType">实体对象类型.</param>
        /// <param name="sql">Sql语句.</param>
        /// <param name="parameters">命令参数数组.</param>
        /// <returns>对象实例.</returns>
        T QueryAsObjectInstance<T>(CommandType commandType, string sql, params DbParameter[] parameters) where T : new();

        /// <summary>
        /// 通过Sql语句来获取对象列表.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns>对象实例.</returns>
        T QueryAsObjectInstance<T>(string sql) where T : new();

        /// <summary>
        /// 通过Sql语句来获取对象列表.
        /// </summary>
        /// <typeparam name="T">实体对象类型.</typeparam>
        /// <param name="sql">Sql语句.</param>
        /// <param name="parameters">命令参数数组.</param>
        /// <returns>对象实例.</returns>
        T QueryAsObjectInstance<T>(string sql, params DbParameter[] parameters) where T : new();
    }
}
