using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using RMS.Logging;

namespace RMS.DataAccess
{
    /// <summary>
    /// 数据库基本操作扩展类.
    /// </summary>
    /// <typeparam name="C">实现IDbConnectionString接口的连接串类.</typeparam>
    /// <typeparam name="P">实现IDbProviderName接口的数据库引擎名称.</typeparam>
    public partial class DbOperationExx<C, P> : DbOperationEx<C, P>
        where C : IDbConnectionString, new()
        where P : IDbProviderName, new()
    {
        public DbOperationExx()
        {

        }

        #region FillDataSet
        //do not need focus on string para method
        private DataSet FillDataSet(string tbName, string[] dbParams, object[] dbValues)
        {
            using(DbConnection _conn = CreateConnection())
            {
                try
                {
                    return FillDataset(_conn, tbName, dbParams, dbValues);
                }
                catch(Exception ex)
                {
                    LoggerManager.GetILog("MethodName:GetDataSet-" + ex.StackTrace);
                    return null;
                }
                finally
                {
                    DisposeDBConnection(_conn);
                }
            }
        }

        public DataSet FillDataset(DbConnection connection, string tableName, string[] dbParams, object[] dbValues)
        {
            int index = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Select * From {0} Where ", tableName);
            List<DbParameter> paramList = new List<DbParameter>();
            DbCommand cmd = connection.CreateCommand();
            foreach(string param in dbParams)
            {
                if(index == 0)
                {
                    if(Convert.ToString(dbValues[index]) != Convert.ToString(OperationType.Select))
                    {
                        return null;
                    }
                }
                else
                {
                    if(dbValues[index] != DBNull.Value)
                    {
                        sb.AppendFormat("{0} = @{0} AND ", param);
                        DbParameter dbpara = cmd.CreateParameter();
                        dbpara.ParameterName = ("@" + param);
                        dbpara.Value = dbValues[index];
                        paramList.Add(dbpara);
                    }
                }
                index++;
            }
            sb.Append("1=1;");
            string commandText = sb.ToString();

            DbParameter[] paraArr = null;
            if(paramList.Count != 0)
            {
                paraArr = paramList.ToArray();
            }

            DisposeCommand(cmd);
            return GetDataset(connection, commandText, paraArr);
        }

        #endregion

        #region DbCommand and DbParameter Generator

        private static string GenerateNonQueryCommand(string tbName, string[] dbParams, object[] parameterValues, out DbParameter[] parameters, bool containsIdentityColumn = false)
        {
            string cmdText = String.Empty;
            List<DbParameter> paramList = new List<DbParameter>();
            switch(((string)parameterValues[0]).ToUpper())
            {
                case MapperConstants.INSERTSTATEMENTC:
                    cmdText = GenerateInsertCommand(tbName, dbParams, parameterValues, paramList, containsIdentityColumn);
                    break;
                case MapperConstants.DELETESTATEMENTC:
                    cmdText = GenerateDeleteCommand(tbName, dbParams, parameterValues, paramList);
                    break;
                case MapperConstants.UPDATESTATEMENTC:
                    cmdText = GenerateUpdateCommand(tbName, dbParams, parameterValues, paramList, false, containsIdentityColumn);
                    break;
                case MapperConstants.UPDATE_WITH_NULL_VALUE_STATEMENTC:
                    cmdText = GenerateUpdateCommand(tbName, dbParams, parameterValues, paramList, true, containsIdentityColumn);
                    break;
                default:
                    parameters = null;
                    return "Fail";
            }

            parameters = null;
            if(paramList.Count != 0)
            {
                parameters = paramList.ToArray();
            }
            return cmdText;
        }

        private static string GenerateInsertCommand(string tbName, string[] dbParams, object[] parameterValues, List<DbParameter> paramList, bool containsIdentityColumn = false)
        {
            int index = 0;
            StringBuilder sbFront = new StringBuilder();
            StringBuilder sbBack = new StringBuilder();

            sbFront.AppendFormat("Insert into {0} (", tbName);
            sbBack.Append(") Values(");

            DbCommand cmd = DbFactory<C, P>.Factory.CreateCommand();
            foreach(string param in dbParams)
            {
                if(index == 0)
                {

                }
                else
                {
                    if(containsIdentityColumn)
                    {
                        if(param.Equals("Id", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }
                        else
                        {
                            GenerateParas(parameterValues, paramList, index, sbFront, sbBack, cmd, param);
                        }
                    }
                    else
                    {
                        GenerateParas(parameterValues, paramList, index, sbFront, sbBack, cmd, param);
                    }
                }
                index++;
            }
            string strFront = sbFront.ToString();
            strFront = strFront.Substring(0, strFront.Length - 2);
            string strBack = sbBack.ToString();
            strBack = strBack.Substring(0, strBack.Length - 2);
            string cmdText = strFront + strBack + ");";
            DisposeCommand(cmd);

            return cmdText;
        }

        private static void GenerateParas(object[] parameterValues, List<DbParameter> paramList, int index, StringBuilder sbFront, StringBuilder sbBack, DbCommand cmd, string param)
        {
            sbFront.AppendFormat("{0}, ", param);
            sbBack.AppendFormat("@{0}, ", param);
            DbParameter dbpara = cmd.CreateParameter();
            dbpara.ParameterName = ("@" + param);
            dbpara.Value = parameterValues[index];
            paramList.Add(dbpara);
        }

        private static string GenerateDeleteCommand(string tableName, string[] dbParams, object[] parameterValues, List<DbParameter> paramList)
        {
            int index = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Delete From {0} Where ", tableName);
            DbCommand cmd = DbFactory<C, P>.Factory.CreateCommand();
            foreach(string param in dbParams)
            {
                if(index == 0)
                {
                    //continue;
                }
                else
                {
                    if(parameterValues[index] != DBNull.Value)
                    {
                        sb.AppendFormat("{0} = @{0} AND ", param);
                        DbParameter dbpara = cmd.CreateParameter();
                        dbpara.ParameterName = ("@" + param);
                        dbpara.Value = parameterValues[index];
                        paramList.Add(dbpara);
                    }
                }
                index++;
            }
            sb.Append("1=1;");
            string commandText = sb.ToString();
            DisposeCommand(cmd);

            return commandText;
        }

        private static string GenerateUpdateCommand(string tbName, string[] dbParams, object[] parameterValues, List<DbParameter> paramList, bool isWithNullValue, bool containsIdentityColumn = false)
        {
            List<DbParameter> searchParamList = new List<DbParameter>();

            int colCount = (parameterValues.Length - 1) / 2;
            StringBuilder sbFront = new StringBuilder();
            StringBuilder sbBack = new StringBuilder();
            sbFront.AppendFormat("Update {0} Set ", tbName);
            sbBack.Append(" Where ");
            DbCommand cmd = DbFactory<C, P>.Factory.CreateCommand();
            for(int index = 1; index <= colCount; index++)
            {
                if(containsIdentityColumn)
                {
                    if(index == 1)
                    {
                        goto Step;
                    }
                }

                if(isWithNullValue)
                {
                    sbFront.AppendFormat("{0} = @{0}, ", dbParams[index]);
                    DbParameter dbpara = cmd.CreateParameter();
                    dbpara.ParameterName = ("@" + dbParams[index]);
                    dbpara.Value = parameterValues[index];
                    paramList.Add(dbpara);
                }
                else
                {
                    if(parameterValues[index] != DBNull.Value)
                    {
                        sbFront.AppendFormat("{0} = @{0}, ", dbParams[index]);
                        DbParameter dbpara = cmd.CreateParameter();
                        dbpara.ParameterName = ("@" + dbParams[index]);
                        dbpara.Value = parameterValues[index];
                        paramList.Add(dbpara);
                    }
                    else
                    {
                        sbFront.AppendFormat("{0} = {0}, ", dbParams[index]);
                    }
                }

            Step:
                if(parameterValues[index + colCount] != DBNull.Value)
                {
                    sbBack.AppendFormat("{0} = @{1} AND ", dbParams[index], dbParams[index + colCount]);
                    DbParameter dbpara = cmd.CreateParameter();
                    dbpara.ParameterName = ("@" + dbParams[index + colCount]);
                    dbpara.Value = parameterValues[index + colCount];
                    paramList.Add(dbpara);
                }
            }
            sbBack.Append("1=1;");
            string strFront = sbFront.ToString();
            strFront = strFront.Substring(0, strFront.Length - 2);
            string strBack = sbBack.ToString();
            string cmdText = strFront + strBack;
            DisposeCommand(cmd);

            return cmdText;
        }

        #endregion

        #region Dispose and Close

        private static void DisposeDBConnection(DbConnection conn)
        {
            if(conn == null)
            {
                return;
            }
            if(conn.State.Equals(ConnectionState.Open))
            {
                conn.Close();
            }

            conn.Dispose();
            conn = null;
        }

        private static void DisposeDataAdapter(DbDataAdapter dataAdapter)
        {
            if(dataAdapter != null)
            {
                dataAdapter.Dispose();
            }
        }

        private static void DisposeCommand(DbCommand command)
        {
            if(command == null)
                return;

            //DisposeCursors(command);

            foreach(DbParameter param in command.Parameters)
            {
                if(param.Direction == ParameterDirection.Output
                    && typeof(DbDataReader).Equals(param.Value.GetType()))
                {
                    ((DbDataReader)param.Value).Close();
                    ((DbDataReader)param.Value).Dispose();
                }
            }
            command.Parameters.Clear();
            command.Dispose();
            command = null;
        }

        #endregion

        #region  Private Method
        private static int GetIndexFromArray(string[] names, string name)
        {
            for(int i = 0; i < names.Length; i++)
            {
                if(name.Equals(names[i], StringComparison.CurrentCultureIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        #region ExecuteNoneQuery

        public int ExecuteNonQuery(
                                string connectionString,
                                string tbName,
                                string[] dbParams,
                                object[] parameterValues
                            )
        {
            using(DbConnection _conn = DbFactory<C, P>.Factory.CreateConnection())
            {
                try
                {
                    return ExecuteNonQuery(tbName, dbParams, parameterValues);
                }
                catch(Exception)
                {
                    throw;
                }
                finally
                {
                    DisposeDBConnection(_conn);
                }
            }
        }

        public int ExecuteNonQuery(
                                string tbName,
                                string[] dbParams,
                                object[] parameterValues,
                              bool containsIdentityColumn = false
                            )
        {
            DbParameter[] parameters = null;
            string command = "";
            command = GenerateNonQueryCommand(tbName, dbParams, parameterValues, out parameters, containsIdentityColumn);

            if(command == "Fail")
            {
                return -1;
            }

            return base.ExecuteNonQuery(command, parameters);
        }

        #endregion

        public void ExecuteNonQuery(
            string[] dbParams,
            object[] dbValues,
            string tbName,
            bool containsIdentityColumn = false
            )
        {
            using(DbConnection _conn = CreateConnection())
            {
                try
                {
                    ExecuteNonQuery(tbName, dbParams, dbValues, containsIdentityColumn);
                }
                catch(Exception ex)
                {
                    LoggerManager.GetILog("MethodName:[db]-ExecuteNonQuery-" + ex.StackTrace);
                }
                finally
                {
                    DisposeConnection(_conn);
                }

            }
        }

        public static void DisposeConnection(IDbConnection connection)
        {
            if(connection == null)
            {
                return;
            }

            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Dispose();
            connection = null;
        }

        public static void DisposeTransaction(IDbTransaction transaction)
        {
            if(transaction == null)
            {
                return;
            }

            transaction.Dispose();
            transaction = null;
        }

        public DataTable FillDataTable(
          string tableName,
          string[] dbParams,
          object[] dbValues)
        {
            using(DbConnection _conn = CreateConnection())
            {
                try
                {
                    DataTable dt = FillDataSet(
                        tableName,
                        dbParams,
                        dbValues).Tables[0];
                    return dt;
                }
                catch(Exception ex)
                {
                    LoggerManager.GetILog("GetDataTable:SqlServerConfigInfo-" + ex.StackTrace);
                    return null;
                }
                finally
                {
                    DisposeConnection(_conn);
                }
            }
        }

        #endregion
    }
}
