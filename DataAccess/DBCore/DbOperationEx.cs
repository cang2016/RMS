using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using RMS.Logging;

namespace RMS.DataAccess
{
    /// <summary>
    /// 数据库操作扩展方法.
    /// </summary>
    /// <typeparam name="C">实现IDbConnectionString接口的连接串类.</typeparam>
    /// <typeparam name="P">实现IDbProviderName接口的数据库引擎名称.</typeparam>
    public class DbOperationEx<C, P> : DbOperation<C, P>
        where C : IDbConnectionString, new()
        where P : IDbProviderName, new()
    {
        #region 执行ExecuteScalar,将结果以字符串类型输出

        public string ExecuteScalarToStr(CommandType commandType, string commandText)
        {
            object ec = base.ExecuteScalar(commandType, commandText);
            if (ec == null)
            {
                return string.Empty;
            }

            return ec.ToString();
        }

        /// <summary>
        /// 返回字符串形式的标题值.
        /// </summary>
        /// <param name="commandText">命令文本(SQL语句).</param>
        /// <returns>字符串值.</returns>
        public string ExecuteScalarToStr(string commandText)
        {
            return ExecuteScalarToStr(CommandType.Text, commandText);
        }

        public string ExecuteScalarToStr(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            object ec = ExecuteScalar(commandType, commandText, commandParameters);
            if (ec == null)
            {
                return string.Empty;
            }

            return ec.ToString();
        }

        public string ExecuteScalarToStr(string commandText, params DbParameter[] commandParameters)
        {
            return ExecuteScalarToStr(CommandType.Text, commandText, commandParameters);
        }

        #endregion
        /// <summary>
        /// 保存数据(数据较少情况下)
        /// </summary>
        /// <param name="dataSet"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool SaveDataToTable(DataSet dataSet, string tableName)
        {
            string strSql = "select * from " + "[" + tableName + "]";

            try
            {
                if (!dataSet.HasChanges())
                {
                    return true;
                }
                DataSet changesDataSet = dataSet.GetChanges(DataRowState.Modified);

                int result = UpdateDataSet(dataSet, tableName, strSql);
                dataSet.AcceptChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LoggerManager.GetILog("MethodName:SaveDataToTable" + ex.StackTrace);
                return false;
            }
        }

        public int UpdateDataSet(DataSet dataSet, string tableName, string selectSql)
        {
            DbDataAdapter dbadpter = DbFactory<C, P>.Factory.CreateDataAdapter();
            //new SqlCommandBuilder(globAdapter);
            dataSet.Tables[0].TableName = tableName;
            dbadpter.SelectCommand = DbFactory<C, P>.Factory.CreateCommand();
            dbadpter.SelectCommand.CommandText = selectSql;
            dbadpter.SelectCommand.Connection = CreateConnection();
            //if (dbadpter.SelectCommand.Connection.State == ConnectionState.Closed)
            //{
            //    dbadpter.SelectCommand.Connection.Open();
            //}

            //DbCommandBuilder DbComBuilder = new SQLiteCommandBuilder((SQLiteDataAdapter)dbadpter); 或

            // DbCommandBuilder DbComBuilder = new SqlCommandBuilder((SqlDataAdapter)dbadpter);
            DbCommandBuilder DbComBuilder = null;
            // Todo  must modify  20130511

            string factoryName = DbFactory<C, P>.Factory.ToString();

            if (factoryName.Contains("SqlClientFactory"))
            {
                DbComBuilder = new SqlCommandBuilder();
            }
            else if (factoryName.Contains("SQLiteFactory"))
            {
                DbComBuilder = new SQLiteCommandBuilder();
            }
            else if (factoryName.Contains("OracleClientFactory"))
            {
                DbComBuilder = new Oracle.DataAccess.Client.OracleCommandBuilder();
            }

            DbComBuilder.DataAdapter = dbadpter;
            int result = dbadpter.Update(dataSet, tableName);

            return result;
        }
    }
}
