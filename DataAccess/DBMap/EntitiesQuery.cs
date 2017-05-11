using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace RMS.DataAccess
{
    /// <summary>
    /// 通过Sql查询获取相关实现类。
    /// </summary>
    /// <typeparam name="C"></typeparam>
    /// <typeparam name="P"></typeparam>
    public class EntitiesQuery<C, P> : DbOperationExx<C, P>, IQuery
        where C : IDbConnectionString,new()
        where P : IDbProviderName, new()
    {
        /// <summary>
        ///  查询多个实体集合
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public List<T> QueryAsObjectInstanceList<T>(CommandType commandType, string sql, params DbParameter[] parameters) where T : new()
        {
            DbDataReader dataReader = base.ExecuteReader(commandType, sql,parameters);
            return EntityReader.GetEntities<T>(dataReader);
        }

        /// <summary>
        ///  查询多个实体集合
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public List<T> QueryAsObjectInstanceList<T>(string sql) where T : new()
        {
            DbDataReader dataReader = base.ExecuteReader(CommandType.Text, sql);
            return EntityReader.GetEntities<T>(dataReader);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>
        /// <returns></returns>
        public T QueryAsObjectInstance<T>(string sql, params DbParameter[] parameters) where T : new()
        {
            return QueryAsObjectInstance<T>(CommandType.Text, sql, parameters);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>   
        /// <returns></returns>
        public T QueryAsObjectInstance<T>(string sql) where T : new()
        {
            return QueryAsObjectInstance<T>(CommandType.Text, sql, null);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">返回的实体集合类型</typeparam>
        /// <param name="sql">要执行的查询语句</param>   
        /// <param name="parameters">执行SQL查询语句所需要的参数</param>   
        /// <param name="commandType">执行的SQL语句的类型</param>
        /// <returns></returns>
        public T QueryAsObjectInstance<T>(CommandType commandType, string sql, params DbParameter[] parameters) where T : new()
        {
            return QueryAsObjectInstanceList<T>(commandType, sql, parameters)[0];
        }
    }
}
