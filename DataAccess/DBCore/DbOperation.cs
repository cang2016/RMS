using System;
using System.Data;
using System.Data.Common;
using System.Text;
using RMS.DataAccess;
using RMS.Utility;
using RMS.Logging;

namespace RMS.DataAccess
{
    /// <summary>
    /// 数据库基本操作类.
    /// </summary>
    /// <typeparam name="C">实现IDbConnectionString接口的连接串类.</typeparam>
    /// <typeparam name="P">实现IDbProviderName接口的数据库引擎名称.</typeparam>
    public class DbOperation<C, P> : IDbOperation
        where C : IDbConnectionString, new()
        where P : IDbProviderName, new()
    {
        /// <summary>
        /// 数据库连接字符串.
        /// </summary>
        protected static string m_connString;

        /// <summary>
        /// 数据库连接字符串.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if(m_connString == null)
                {
                    m_connString = new C().ConnectionString;
                }

                return m_connString;
            }
            set
            {
                m_connString = value;
            }
        }

        /// <summary>
        /// 创建数据库连接类.
        /// </summary>
        /// <returns>数据库连接类</returns>
        public static DbConnection CreateConnection()
        {
            DbConnection connection = DbFactory<C, P>.Factory.CreateConnection();
            connection.ConnectionString = ConnectionString;

            return connection;
        }

        #region 私有方法

        /// <summary>
        /// 将DbParameter参数数组(参数值)分配给DbCommand命令.
        /// 参数为空时则赋值DBNull.Value.
        /// </summary>
        /// <param name="command">命令名</param>
        /// <param name="commandParameters">DbParameters数组</param>
        private static void AttachParameters(DbCommand command, DbParameter[] commandParameters)
        {
            command.NotNull("command is null");

            if(commandParameters != null)
            {
                foreach(DbParameter dbParam in commandParameters)
                {
                    if(dbParam != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if((dbParam.Direction == ParameterDirection.InputOutput || dbParam.Direction == ParameterDirection.Input) &&
                            (dbParam.Value == null))
                        {
                            dbParam.Value = DBNull.Value;
                        }

                        command.Parameters.Add(dbParam);
                    }
                }
            }
        }

        /// <summary>
        /// 将DataRow类型的列值分配到DbParameter参数数组.
        /// </summary>
        /// <param name="commandParameters">要分配值的DbParameter参数数组</param>
        /// <param name="dataRow">将要分配给存储过程参数的DataRow</param>
        private static void AssignParameterValues(DbParameter[] commandParameters, DataRow dataRow)
        {
            if((commandParameters == null) || (dataRow == null))
            {
                return;
            }

            int i = 0;
            // 设置参数值
            foreach(DbParameter commandParameter in commandParameters)
            {
                // 创建参数名称,如果不存在,只抛出一个异常.
                if(commandParameter.ParameterName == null || commandParameter.ParameterName.Length <= 1)
                {
                    throw new Exception(string.Format("请提供参数{0}一个有效的名称{1}.", i, commandParameter.ParameterName));
                }
                // 从dataRow的表中获取为参数数组中数组名称的列的索引.
                // 如果存在和参数名称相同的列,则将列值赋给当前名称的参数.
                if(dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
                {
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                }
                i++;
            }
        }

        /// <summary>
        /// 将一个对象数组分配给DbParameter参数数组.
        /// </summary>
        /// <param name="commandParameters">要分配值的DbParameter参数数组</param>
        /// <param name="parameterValues">将要分配给存储过程参数的对象数组</param>
        private static void AssignParameterValues(DbParameter[] commandParameters, object[] parameterValues)
        {
            if((commandParameters == null) || (parameterValues == null))
            {
                return;
            }

            // 确保对象数组个数与参数个数匹配,如果不匹配,抛出一个异常.
            if(commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("参数值个数与参数不匹配.");
            }

            // 给参数赋值
            for(int i = 0, j = commandParameters.Length; i < j; i++)
            {
                // If the current array value derives from IDbDataParameter, then assign its Value property
                if(parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                    if(paramInstance.Value == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = paramInstance.Value;
                    }
                }
                else if(parameterValues[i] == null)
                {
                    commandParameters[i].Value = DBNull.Value;
                }
                else
                {
                    commandParameters[i].Value = parameterValues[i];
                }
            }
        }

        /// <summary>
        /// 预处理用户提供的命令,数据库连接/事务/命令类型/参数.
        /// </summary>
        /// <param name="command">要处理的DbCommand.</param>
        /// <param name="connection">数据库连接.</param>
        /// <param name="transaction">一个有效的事务或者是null值.</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本, 其它).</param>
        /// <param name="commandText">存储过程名或都SQL命令文本.</param>
        /// <param name="commandParameters">和命令相关联的DbParameter参数数组,如果没有参数为'null'.</param>
        /// <param name="mustCloseConnection"><c>true</c> 如果连接是打开的,则为true,其它情况下为false.</param>
        private static void PrepareCommand(DbCommand command, DbConnection connection, DbTransaction transaction, CommandType commandType, string commandText, DbParameter[] commandParameters, out bool mustCloseConnection)
        {
            command.NotNull("command");

            commandText.NotNullOrEmptyOrSpaceWhite("commandText");

            // 打开数据库连接.
            if(connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // 给命令分配一个数据库连接.
            command.Connection = connection;

            // 设置命令文本(SQL语句或存储过程名称).
            command.CommandText = commandText;

            // WriteSqlStatement(command);
            // 分配事务
            if(transaction != null)
            {
                if(transaction.Connection == null)
                {
                    throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                }
                command.Transaction = transaction;
            }

            // 设置命令类型.
            command.CommandType = commandType;

            // 分配命令参数
            if(commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }

            return;
        }

        /// <summary>
        /// DbParameter参数数组的深层拷贝.
        /// </summary>
        /// <param name="originalParameters">原始参数数组.</param>
        /// <returns>返回一个同样的参数数组.</returns>
        private static DbParameter[] CloneParameters(DbParameter[] originalParameters)
        {
            DbParameter[] clonedParameters = new DbParameter[originalParameters.Length];

            for(int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (DbParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        #endregion 私有方法结束

        #region ExecuteNonQuery方法

        /// <summary>
        /// 执行指定操作类型,命令文本的数据操作.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int result = ExecuteNonQuery(CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="commandType">命令类型 (存储过程,命令文本,其它).</param>
        /// <param name="commandText">存储过程名称或SQL语句.</param>
        /// <returns>返回命令影响的行数.</returns>
        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行数据库命令操作.
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>返回命令影响的行数</returns>
        public int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行 DbCommand.如果没有提供参数,不返回结果.
        /// </summary>
        /// <param name="commandType">命令类型 (存储过程,命令文本, 其它.)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="commandParameters">DbParameter参数数组</param>
        /// <returns>返回命令影响的行数</returns>
        public int ExecuteNonQuery(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            commandText.NotNullOrEmptyOrSpaceWhite("commandText");

            using(DbConnection conn = DbFactory<C, P>.Factory.CreateConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();

                try
                {
                    return ExecuteNonQuery(conn, commandType, commandText, commandParameters);
                }
                catch(System.Exception ex)
                {
                    LoggerManager.GetILog("MethodName:[db]-ExecuteNonQuery-" + ex.StackTrace);
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行 DbCommand.如果没有提供参数,不返回结果.
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">DbParameter参数数组</param>
        /// <returns>返回命令影响的行数</returns>
        public int ExecuteNonQuery(string commandText, params DbParameter[] commandParameters)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令 
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="commandType">命令类型(存储过程,命令文本或其它.)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <returns>返回影响的行数</returns>
        private int ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(connection, commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行指定的命令 
        /// </summary>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <returns>返回影响的行数</returns>
        private int ExecuteNonQuery(DbConnection connection, string commandText)
        {
            return ExecuteNonQuery(connection, CommandType.Text, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型(存储过程,命令文本或其它.)</param>
        /// <param name="commandText">T存储过程名称或SQL语句</param>
        /// <param name="commandParameters">SqlParamter参数数组</param>
        /// <returns>返回影响的行数</returns>
        public int ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            connection.NotNull("connection");

            // 创建DbCommand命令,并进行预处理
            DbCommand cmd = DbFactory<C, P>.Factory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (DbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            string logsql = DbCommon.LogParameters(commandText, commandParameters, cmd);

            try
            {
                // Finally, execute the command
                int retval = cmd.ExecuteNonQuery();

                LoggerManager.GetILog("MethodName:[db]-ExecuteNonQuery").Info(logsql);   // 不能写到数据库，要不会循环执行.

                // 清除参数,以便再次使用.
                cmd.Parameters.Clear();
                return retval;
            }
            catch(System.Exception ex)
            {
                LoggerManager.GetILog("MethodName:[db]-ExecuteNonQuery").Fatal(StackFrameTransformer.TransformStack(ex.StackTrace, string.Empty));
                return 0;
            }
            finally
            {
                if(mustCloseConnection)
                {
                    connection.Close();
                }
            }
        }


        /// <summary>
        /// 执行指定数据库连接对象的命令.
        /// </summary>
        /// <param name="commandText">T存储过程名称或SQL语句.</param>
        /// <param name="commandParameters">SqlParamter参数数组.</param>
        /// <returns>返回影响的行数.</returns>
        public int ExecuteNonQuery(DbConnection connection, string commandText, params DbParameter[] commandParameters)
        {
            return ExecuteNonQuery(connection, CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// 执行带事务的DbCommand.
        /// </summary>
        /// <remarks>
        /// 示例.:  
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="transaction">一个有效的数据库连接对象.</param>
        /// <param name="commandType">命令类型(存储过程,命令文本或其它).</param>
        /// <param name="commandText">存储过程名称或SQL语句.</param>
        /// <returns>返回影响的行数.</returns>
        private int ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(transaction, commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行带事务的DbCommand.
        /// </summary>
        /// <param name="transaction">一个有效的数据库连接对象.</param>
        /// <param name="commandText">SQL语句.</param>
        /// <returns>返回影响的行数.</returns>
        public int ExecuteNonQuery(DbTransaction transaction, string commandText)
        {
            return ExecuteNonQuery(transaction, CommandType.Text, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行带事务的DbCommand(指定参数).
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">一个有效的数据库连接对象.</param>
        /// <param name="commandType">命令类型(存储过程,命令文本或其它).</param>
        /// <param name="commandText">存储过程名称或SQL语句.</param>
        /// <param name="commandParameters">SqlParamter参数数组.</param>
        /// <returns>返回影响的行数.</returns>
        private int ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            transaction.NotNull("transaction");
            if(transaction != null && transaction.Connection == null)
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }

            // 预处理.
            DbCommand cmd = DbFactory<C, P>.Factory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            string logsql = DbCommon.LogParameters(commandText, commandParameters, cmd);
            // 执行.
            int retval = cmd.ExecuteNonQuery();

            LoggerManager.GetILog("MethodName:[db]-ExecuteNonQuery").Info(logsql);   // 不能写到数据库，要不会循环执行.

            // 清除参数集,以便再次使用.
            cmd.Parameters.Clear();
            return retval;
        }

        /// <summary>
        /// 执行带事务的DbCommand(指定参数).
        /// </summary>
        /// <param name="transaction">一个有效的数据库连接对象.</param>
        /// <param name="commandText">SQL语句.</param>
        /// <param name="commandParameters">SqlParamter参数数组.</param>
        /// <returns>返回影响的行数.</returns>
        public int ExecuteNonQuery(DbTransaction transaction, string commandText, params DbParameter[] commandParameters)
        {
            return ExecuteNonQuery(transaction, CommandType.Text, commandText, commandParameters);
        }

        #endregion ExecuteNonQuery方法结束

        #region GetDataTable方法
        /// <summary>
        /// 通过sql语句返回DataTable.
        /// </summary>
        /// <param name="commText">sql语句.</param>
        /// <returns>DataTable.</returns>
        public DataTable FillDataTable(string commText)
        {
            return FillDataset(commText).Tables[0];
        }

        /// <summary>
        /// 通过commandType、sql语句返回DataTable.
        /// </summary>
        /// <param name="commandType">操作类型.</param>
        /// <param name="commText">sql语句.</param>
        /// <returns>DataTable</returns>
        public DataTable FillDataTable(CommandType commandType, string commText)
        {
            return FillDataTable(commandType, commText, null);
        }


        /// <summary>
        /// 根据commandType、sql、参数取得DataTable
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable FillDataTable(CommandType commandType, string sql, params DbParameter[] parameters)
        {
            return FillDataset(commandType, sql, parameters).Tables[0];
        }

        #endregion GetDataTable方法结束

        #region GetDataset方法

        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = GetDataSet(connString, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public DataSet FillDataset(CommandType commandType, string commandText)
        {
            return FillDataset(commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = GetDataSet("SELECT * FROM [table1]");
        /// </remarks>
        /// <param name="commandText">SQL语句</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public DataSet FillDataset(string commandText)
        {
            return FillDataset(CommandType.Text, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回DataSet.
        /// </summary>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="commandParameters">SqlParamters参数数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public DataSet FillDataset(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            ConnectionString.NotNullOrEmptyOrSpaceWhite("ConnectionString");

            // 创建并打开数据库连接对象,操作完成释放对象.

            //using (DbConnection connection = (DbConnection)new System.Data.SqlClient.SqlConnection(ConnectionString))
            using(DbConnection connection = DbFactory<C, P>.Factory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                // 调用指定数据库连接字符串重载方法.
                try
                {
                    return GetDataset(connection, commandType, commandText, commandParameters);
                }
                catch(CustomDataException ex)
                {
                    new CustomDataException(ex, commandText);

                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回DataSet.
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">SqlParamters参数数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public DataSet FillDataset(string commandText, params DbParameter[] commandParameters)
        {
            return FillDataset(CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = GetDataSet(conn, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或SQL语句</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        private DataSet GetDataset(DbConnection connection, CommandType commandType, string commandText)
        {
            return GetDataset(connection, commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回DataSet.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandText">SQL语句</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        private DataSet GetDataset(DbConnection connection, string commandText)
        {
            return GetDataset(connection, CommandType.Text, commandText);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,指定存储过程参数,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = GetDataSet(conn, CommandType.StoredProcedure, "GetOrders", new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或SQL语句</param>
        /// <param name="commandParameters">SqlParamter参数数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        private DataSet GetDataset(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            connection.NotNull("connection");

            // 预处理
            DbCommand cmd = DbFactory<C, P>.Factory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (DbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            try
            {
                // 创建DbDataAdapter和DataSet.
                using(DbDataAdapter da = DbFactory<C, P>.Factory.CreateDataAdapter())
                {
                    string logsql = DbCommon.LogParameters(commandText, commandParameters, cmd);
                    LoggerManager.GetILog("MethodName:[db]-GetDataset").Info(logsql);   // 不能写到数据库，要不会循环执行.

                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    // 填充DataSet.
                    da.Fill(ds);
                    cmd.Parameters.Clear();
                    return ds;
                }
            }

            catch(CustomDataException ex)
            {
                throw new CustomDataException(ex, commandText);
            }
            finally
            {
                if(mustCloseConnection)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回DataSet.
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">SqlParamter参数数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public DataSet GetDataset(DbConnection connection, string commandText, params DbParameter[] commandParameters)
        {
            return GetDataset(connection, CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// 执行指定事务的命令,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = GetDataSet(trans, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="transaction">事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或SQL语句</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        private DataSet GetDataset(DbTransaction transaction, CommandType commandType, string commandText)
        {
            return GetDataset(transaction, commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行指定事务的命令,返回DataSet.
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <param name="commandText">SQL语句</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public DataSet FillDataset(DbTransaction transaction, string commandText)
        {
            return GetDataset(transaction, CommandType.Text, commandText);
        }

        /// <summary>
        /// 执行指定事务的命令,指定参数,返回DataSet.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DataSet ds = GetDataSet(trans, CommandType.StoredProcedure, "GetOrders", new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或SQL语句</param>
        /// <param name="commandParameters">SqlParamter参数数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public DataSet GetDataset(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            transaction.NotNull("transaction");

            if(transaction != null && transaction.Connection == null)
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }

            // 预处理
            DbCommand cmd = DbFactory<C, P>.Factory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // 创建 DataAdapter & DataSet
            using(DbDataAdapter da = DbFactory<C, P>.Factory.CreateDataAdapter())
            {
                string logsql = DbCommon.LogParameters(commandText, commandParameters, cmd);
                LoggerManager.GetILog("MethodName:[db]-GetDataset").Info(logsql);   // 不能写到数据库，要不会循环执行.

                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();

                return ds;
            }
        }

        /// <summary>
        /// 执行指定事务的命令,指定参数,返回DataSet.
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">SqlParamter参数数组</param>
        /// <returns>返回一个包含结果集的DataSet</returns>
        public DataSet FillDataset(DbTransaction transaction, string commandText, params DbParameter[] commandParameters)
        {
            return GetDataset(transaction, CommandType.Text, commandText, commandParameters);
        }

        #endregion GetDataset数据集命令结束

        #region ExecuteReader 数据阅读器

        /// <summary>
        /// 枚举,标识数据库连接是由BaseDbHelper提供还是由调用者提供
        /// </summary>
        private enum DbConnectionOwnership
        {
            /// <summary>由BaseDbHelper提供连接</summary>
            Internal,
            /// <summary>由调用者提供连接</summary>
            External
        }

        /// <summary>
        /// 执行指定数据库连接对象的数据阅读器.
        /// </summary>
        /// <remarks>
        /// 如果是BaseDbHelper打开连接,当连接关闭DataReader也将关闭.
        /// 如果是调用都打开连接,DataReader由调用都管理.
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="transaction">一个有效的事务,或者为 'null'</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或SQL语句</param>
        /// <param name="commandParameters">DbParameters参数数组,如果没有参数则为'null'</param>
        /// <param name="connectionOwnership">标识数据库连接对象是由调用者提供还是由BaseDbHelper提供</param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        private static DbDataReader ExecuteReader(DbConnection connection, DbTransaction transaction, CommandType commandType, string commandText, DbParameter[] commandParameters, DbConnectionOwnership connectionOwnership)
        {
            connection.NotNull("connection");

            bool mustCloseConnection = false;
            // 创建命令
            DbCommand cmd = DbFactory<C, P>.Factory.CreateCommand();
            try
            {
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

                // 创建数据阅读器
                DbDataReader dataReader;

                if(connectionOwnership == DbConnectionOwnership.External)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }

                // 清除参数,以便再次使用..
                // HACK: There is a problem here, the output parameter values are fletched 
                // when the reader is closed, so if the parameters are detached from the command
                // then the SqlReader can set its values. 
                // When this happen, the parameters can be used again in other command.
                bool canClear = true;
                foreach(DbParameter commandParameter in cmd.Parameters)
                {
                    if(commandParameter.Direction != ParameterDirection.Input)
                    {
                        canClear = false;
                    }
                }

                if(canClear)
                {
                    //cmd.Dispose();
                    cmd.Parameters.Clear();
                }


                return dataReader;
            }
            catch
            {
                if(mustCloseConnection)
                {
                    connection.Close();
                }
                throw;
            }
        }

        /// <summary>
        /// 执行指定的Sql或存储过程的数据阅读器.
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        public DbDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(CommandType.Text, commandText);
        }

        /// <summary>
        /// 执行指定CommandType类型的Sql或存储过程的数据阅读器.
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        public DbDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return ExecuteReader(commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接字符串的数据阅读器,指定参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DbDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或SQL语句</param>
        /// <param name="commandParameters">SqlParamter参数数组(new DbParameter("@prodid", 24))</param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        public DbDataReader ExecuteReader(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            ConnectionString.NotNullOrEmptyOrSpaceWhite("ConnectionString");

            DbConnection connection = null;
            try
            {
                connection = DbFactory<C, P>.Factory.CreateConnection();
                connection.ConnectionString = ConnectionString;
                connection.Open();

                return ExecuteReader(connection, null, commandType, commandText, commandParameters, DbConnectionOwnership.Internal);
            }
            catch
            {
                // If we fail to return the SqlDatReader, we need to close the connection ourselves
                if(connection != null)
                    connection.Close();
                throw;
            }

        }

        /// <summary>
        /// 执行指定数据库连接对象的数据阅读器.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DbDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名或SQL语句</param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        private static DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteReader(connection, commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// [调用者方式]执行指定数据库连接对象的数据阅读器,指定参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DbDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandParameters">SqlParamter参数数组</param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        private static DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            return ExecuteReader(connection, (DbTransaction)null, commandType, commandText, commandParameters, DbConnectionOwnership.External);
        }

        /// <summary>
        /// [调用者方式]执行指定数据库事务的数据阅读器,指定参数值.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  DbDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        private static DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteReader(transaction, commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// [调用者方式]执行指定数据库事务的数据阅读器,指定参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///   DbDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param>
        /// <returns>返回包含结果集的DbDataReader</returns>
        private static DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            transaction.NotNull("transaction");

            if(transaction != null && transaction.Connection == null)
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }

            return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, DbConnectionOwnership.External);
        }

        #endregion ExecuteReader数据阅读器

        #region ExecuteScalar 返回结果集中的第一行第一列

        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            // 执行参数为空的方法
            return ExecuteScalar(commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,返回结果集中的第一行第一列.
        /// </summary>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public object ExecuteScalar(string commandText)
        {
            // 执行参数为空的方法
            return ExecuteScalar(CommandType.Text, commandText);
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,指定参数,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public object ExecuteScalar(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            ConnectionString.NotNullOrEmptyOrSpaceWhite("ConnectionString");

            // 创建并打开数据库连接对象,操作完成释放对象.
            using(DbConnection connection = DbFactory<C, P>.Factory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                try
                {
                    // 调用指定数据库连接字符串重载方法.
                    return ExecuteScalar(connection, commandType, commandText, commandParameters);
                }
                catch(System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        /// <summary>
        /// 执行指定数据库连接字符串的命令,指定参数,返回结果集中的第一行第一列.
        /// </summary>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public object ExecuteScalar(string commandText, params DbParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        private static object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText)
        {
            // 执行参数为空的方法
            return ExecuteScalar(connection, commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandText">SQL语句</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        private static object ExecuteScalar(DbConnection connection, string commandText)
        {
            // 执行参数为空的方法
            return ExecuteScalar(connection, CommandType.Text, commandText);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,指定参数,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        private static object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            connection.NotNull("connection");

            // 创建DbCommand命令,并进行预处理
            DbCommand cmd = DbFactory<C, P>.Factory.CreateCommand();

            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (DbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            try
            {
                // 执行DbCommand命令,并返回结果.
                object retval = cmd.ExecuteScalar();

                // 清除参数,以便再次使用.
                cmd.Parameters.Clear();
                return retval;
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(mustCloseConnection)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,指定参数,返回结果集中的第一行第一列.
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        private static object ExecuteScalar(DbConnection connection, string commandText, params DbParameter[] commandParameters)
        {
            return ExecuteScalar(connection, CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// 执行指定数据库事务的命令,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        private object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText)
        {
            // 执行参数为空的方法
            return ExecuteScalar(transaction, commandType, commandText, (DbParameter[])null);
        }

        /// <summary>
        /// 执行指定数据库事务的命令,指定参数,返回结果集中的第一行第一列.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param>
        /// <returns>返回结果集中的第一行第一列</returns>
        public object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            transaction.NotNull("transaction");
            if(transaction != null && transaction.Connection == null)
            {
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            }

            // 创建DbCommand命令,并进行预处理
            DbCommand cmd = DbFactory<C, P>.Factory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // 执行DbCommand命令,并返回结果.
            object retval = cmd.ExecuteScalar();

            // 清除参数,以便再次使用.
            cmd.Parameters.Clear();
            return retval;
        }

        #endregion ExecuteScalar

        #region FillDataset 填充数据集
        /// <summary>
        /// 执行指定数据库连接字符串的命令,映射数据表并填充数据集.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)</param>
        private static void FillDataset(CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
        {
            ConnectionString.NotNullOrEmptyOrSpaceWhite("ConnectionString");

            dataSet.NotNull("dataSet");

            // 创建并打开数据库连接对象,操作完成释放对象.
            using(DbConnection connection = DbFactory<C, P>.Factory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                try
                {
                    // 调用指定数据库连接字符串重载方法.
                    FillDataset(connection, commandType, commandText, dataSet, tableNames);
                }
                catch(System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行指定数据库连接字符串的命令,映射数据表并填充数据集.指定命令参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        private static void FillDataset(CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters)
        {
            if(ConnectionString == null || ConnectionString.Length == 0)
            {
                throw new ArgumentNullException("ConnectionString");
            }
            if(dataSet == null)
                throw new ArgumentNullException("dataSet");
            // 创建并打开数据库连接对象,操作完成释放对象.
            using(DbConnection connection = DbFactory<C, P>.Factory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                try
                {
                    // 调用指定数据库连接字符串重载方法.
                    FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters);
                }
                catch(System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,映射数据表并填充数据集.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(conn, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>    
        private static void FillDataset(DbConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames)
        {
            FillDataset(connection, commandType, commandText, dataSet, tableNames, null);
        }

        /// <summary>
        /// 执行指定数据库连接对象的命令,映射数据表并填充数据集,指定参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(conn, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param>
        private static void FillDataset(DbConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters)
        {
            FillDataset(connection, null, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        /// <summary>
        /// 执行指定数据库事务的命令,映射数据表并填充数据集.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        private static void FillDataset(DbTransaction transaction, CommandType commandType,
            string commandText,
            DataSet dataSet, string[] tableNames)
        {
            FillDataset(transaction, commandType, commandText, dataSet, tableNames, null);
        }

        /// <summary>
        /// 执行指定数据库事务的命令,映射数据表并填充数据集,指定参数.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">一个有效的连接事务</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它)</param>
        /// <param name="commandText">存储过程名称或SQL语句</param>
        /// <param name="dataSet">要填充结果集的DataSet实例</param>
        /// <param name="tableNames">表映射的数据表数组
        /// 用户定义的表名 (可有是实际的表名.)
        /// </param>
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组</param>
        private static void FillDataset(DbTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters)
        {
            FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        /// <summary>
        /// [私有方法][内部调用]执行指定数据库连接对象/事务的命令,映射数据表并填充数据集,DataSet/TableNames/DbParameters.
        /// </summary>
        /// <remarks>
        /// 示例:  
        ///  FillDataset(conn, trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new DbParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">一个有效的数据库连接对象.</param>
        /// <param name="transaction">一个有效的连接事务.</param>
        /// <param name="commandType">命令类型 (存储过程,命令文本或其它).</param>
        /// <param name="commandText">存储过程名称或SQL语句.</param>
        /// <param name="dataSet">要填充结果集的DataSet实例.</param>
        /// <param name="tableNames">表映射的数据表数组用户定义的表名(可有是实际的表名).</param>
        /// <param name="commandParameters">分配给命令的SqlParamter参数数组.</param>
        private static void FillDataset(DbConnection connection, DbTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters)
        {
            connection.NotNull("connection");
            dataSet.NotNull("dataSet");

            // 创建DbCommand命令,并进行预处理
            DbCommand command = DbFactory<C, P>.Factory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
            string logText = DbCommon.LogParameters(commandText, commandParameters, command);

            try
            {
                // 执行命令
                using(DbDataAdapter dataAdapter = DbFactory<C, P>.Factory.CreateDataAdapter())
                {
                    dataAdapter.SelectCommand = command;
                    // 追加表映射
                    if(tableNames != null && tableNames.Length > 0)
                    {
                        string tableName = "Table";
                        for(int index = 0; index < tableNames.Length; index++)
                        {
                            if(tableNames[index] == null || tableNames[index].Length == 0)
                            {
                                throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
                            }
                            dataAdapter.TableMappings.Add(tableName, tableNames[index]);
                            tableName += (index + 1).ToString();
                        }
                    }

                    // 填充数据集使用默认表名称
                    dataAdapter.Fill(dataSet);
                    LoggerManager.GetILog("Method-[db]:FillDataset").Error(logText);
                    // 清除参数,以便再次使用.
                    command.Parameters.Clear();
                }
            }
            catch(System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(mustCloseConnection)
                {
                    connection.Close();
                }
            }
        }

        #endregion

    }
}
