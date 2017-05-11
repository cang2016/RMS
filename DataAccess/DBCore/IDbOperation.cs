using System;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;

namespace RMS.DataAccess
{
    /// <summary>
    /// 数据库通用操作接口.
    /// </summary>
    /// <author>xucj</author>
    /// <date>2013-05-15</date>
    public interface IDbOperation
    {
        /// <summary>
        /// 执行查询,并返回查询所返回的结果集中第一行的第一列.
        /// </summary>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <returns>结果集中第一行的第一列.</returns>
        object ExecuteScalar(string commandText);

        /// <summary>
        /// 执行查询,并返回查询所返回的结果集中第一行的第一列.
        /// </summary>
        /// <param name="commandType">操作类型.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <returns>结果集中第一行的第一列.</returns>
        object ExecuteScalar(CommandType commandType, string commandText);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        DbDataReader ExecuteReader(string commandText);

        /// <summary>
        /// 返回DbDataReader对象.
        /// </summary>
        /// <param name="commandType">操作类型.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <returns>DbDataReader对象</returns>
        DbDataReader ExecuteReader(CommandType commandType, string commandText);

        /// <summary>
        /// 返回DbDataReader对象.
        /// </summary>
        /// <param name="commandType">操作类型.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <param name="commandParameters">命令参数.</param>
        /// <returns>DbDataReader对象</returns>
        DbDataReader ExecuteReader(CommandType commandType, string commandText, params DbParameter[] commandParameters);

        /// <summary>
        /// 对连接对象执行SQL语句.
        /// </summary>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <returns>受影响的行数.</returns>
        int ExecuteNonQuery(string commandText);

        /// <summary>
        /// 对连接对象执行SQL语句.
        /// </summary>
        /// <param name="commandType">操作类型.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <returns>受影响的行数.</returns>
        int ExecuteNonQuery(CommandType commandType, string commandText);

        /// <summary>
        /// 对连接对象执行SQL语句.
        /// </summary>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <param name="commandParameters">操作类型.</param>
        /// <returns>受影响的行数.</returns>
        int ExecuteNonQuery(string commandText, params DbParameter[] commandParameters);

        /// <summary>
        /// 对连接对象执行SQL语句.
        /// </summary>
        /// <param name="commandType">操作类型.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <param name="commandParameters">命令参数.</param>
        /// <returns>受影响的行数.</returns>
        int ExecuteNonQuery(CommandType commandType, string commandText, params DbParameter[] commandParameters);

        /// <summary>
        /// 对连接对象执行SQL语句.
        /// </summary>
        /// <param name="transaction">事务.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <returns>受影响的行数.</returns>
        int ExecuteNonQuery(DbTransaction transaction, string commandText);

        /// <summary>
        /// 对连接对象执行SQL语句.
        /// </summary>
        /// <param name="transaction">事务.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <param name="commandParameters">命令参数.</param>
        /// <returns>受影响的行数.</returns>
        int ExecuteNonQuery(DbTransaction transaction, string commandText, params DbParameter[] commandParameters);

        /// <summary>
        /// 返回DataSet数据集.
        /// </summary>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <returns>DataSet数据集</returns>
        DataSet FillDataset(string commandText);

        /// /// <summary>
        /// 返回DataSet数据集.
        /// </summary>
        /// /// <param name="transaction">事务.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <returns>DataSet数据集</returns>
        DataSet FillDataset(DbTransaction transaction, string commandText);

        /// <summary>
        /// 返回DataSet数据集.
        /// </summary>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <param name="commandParameters">命令参数.</param>
        /// <returns>DataSet数据集.</returns>
        DataSet FillDataset(string commandText, params DbParameter[] commandParameters);

        /// <summary>
        /// 返回DataSet数据集.
        /// </summary>
        /// <param name="transaction">事务.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <param name="commandParameters">命令参数.</param>
        /// <returns>DataSet数据集.</returns>
        DataSet FillDataset(DbTransaction transaction, string commandText, params DbParameter[] commandParameters);

        /// <summary>
        /// 返回DataSet数据集.
        /// </summary>
        /// <param name="commandType">操作类型.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <returns>DataSet数据集.</returns>
        DataSet FillDataset(CommandType commandType, string commandText);

        /// <summary>
        /// 返回DataSet数据集.
        /// </summary>
        /// <param name="commandType">操作类型.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <param name="parameters">命令参数.</param>
        /// <returns>DataSet数据集.</returns>
        DataTable FillDataTable(CommandType commandType, string commandText, params DbParameter[] parameters);

        /// <summary>
        /// 返回DataSet数据集.
        /// </summary>
        /// <param name="commText">命令文本(SQL语句).</param>
        /// <returns>DataSet数据集.</returns>
        DataTable FillDataTable(string commText);

        /// <summary>
        /// 返回DataSet数据集.
        /// </summary>
        /// <param name="commandType">操作类型.</param>
        /// <param name="commText">命令文本(SQL语句).</param>
        /// <returns>DataSet数据集.</returns>
        DataTable FillDataTable(CommandType commandType, string commText);

        /// <summary>
        /// 返回DataSet数据集.
        /// </summary>
        /// <param name="commandType">操作类型.</param>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <param name="commandParameters">命令参数.</param>
        /// <returns>DataSet数据集.</returns>
        DataSet FillDataset(CommandType commandType, string commandText, params DbParameter[] commandParameters);
    }
}
