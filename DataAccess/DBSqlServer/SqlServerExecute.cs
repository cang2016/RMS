using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RMS.DataAccess
{
    /// <summary>
    /// 支持SqlServer数据库相关操作类<含通用数据库操作>
    /// </summary>
    public class SqlServerExecute : SqlServerConn, IDbOperation
    {
        /// <summary>
        /// 获取某个表的信息--SqlServer
        /// cname   - 字段名
        /// coltype - 字段类型
        /// width   - 字段长度
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>数据集</returns>
        public DataSet GetSqlTableInfo(string tableName)
        {
            tableName = tableName.ToUpper();

            string sql = "select col.name as cname, (select name from sys.types where system_type_id= col.system_type_id) as coltype,col.max_length as width"
                          + " from sys.columns col where object_id in (select object_id from sys.tables t where t.name = @tname)";

            DbParameter[] dbParams =
	        {
		         DbFactory<SqlServerConn, SqlServerFactory<SqlServerConn>>.MakeInParam("@tname", SqlDbType.Char, 30, tableName),                       //此外的","不能省略
	        };
            IDbOperation db = new SqlServerExecute();

            DataSet dataSet = db.FillDataset(sql, dbParams);

            return dataSet;
        }

        /// <summary>
        /// 获取表的约束条件
        /// constraint_name - 约束名称
        /// column_name     - 约束的字段
        /// constraint_type - 约束类型，PK: 主键，U: 唯一键，R: 外键
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public ConstraintCollection GetSqlTableConstraint(string tableName)
        {
            tableName = tableName.ToUpper();

            //此处取SqlServer2008中表的主键列信息，注意建表时主键列排第一列,此处通过列ID来检索
            string sql = "select col.name as column_name,con.name as constraint_name,con.type as constraint_type"
                         + " from sys.columns col, sys.key_constraints con "
                         + " where col.object_id = con.parent_object_id and col.column_id = 1 and col.is_nullable = 0"
                         + " and col.object_id in (select object_id from sys.tables where name  = @table_name)";

            try
            {
                DbParameter[] dbParams =
                {
                     DbFactory<SqlServerConn, SqlServerFactory<SqlServerConn>>.MakeInParam("@table_name", SqlDbType.VarChar, 30, tableName),
                };

                IDbOperation db = new SqlServerExecute();
                DataSet dataSet = db.FillDataset(sql, dbParams);
                DataSet dsEmtpy = GetEmptyTable(tableName);

                string prevType = string.Empty;
                string prevColumnName = string.Empty;
                List<DataColumn> cols = null;
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    string constraintName = dr["constraint_name"].ToString();
                    string columnName = dr["column_name"].ToString();
                    string constraintType = dr["constraint_type"].ToString();

                    if (constraintType != prevType || constraintName != prevColumnName)
                    {
                        if (prevType.Length > 0)
                        {
                            UniqueConstraint uc = new UniqueConstraint(prevColumnName, cols.ToArray(), prevType == "PK");
                            dsEmtpy.Tables[0].Constraints.Add(uc);
                        }

                        cols = new List<DataColumn>();
                    }

                    cols.Add(dsEmtpy.Tables[0].Columns[columnName]);
                    prevType = constraintType;
                    prevColumnName = constraintName;
                }

                if (prevType.Length > 0)
                {
                    UniqueConstraint uc = new UniqueConstraint(prevColumnName, cols.ToArray(), prevType == "PK");
                    dsEmtpy.Tables[0].Constraints.Add(uc);
                }

                return dsEmtpy.Tables[0].Constraints;
            }
            catch (CustomDataException exdb)
            {
                throw exdb;
            }
            catch (System.Exception ex)
            {
                throw new CustomDataException(ex, sql);
            }
        }

        /// <summary>
        /// 判断某个表数据是否为空
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>true-是,false-否</returns>
        public bool IsEmptyTable(string tableName)
        {
            string sql = "select count(*) from " + tableName;

            try
            {
                return Convert.ToInt32(ExecuteScalar(sql)) == 0;
            }
            catch (Exception ex)
            {
                throw new CustomDataException(ex, sql);
            }
        }

        /// <summary>
        /// 检测某个表是否存在,可以在系统表中查看是否存在此名称的表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public bool TableExists(string tableName)
        {
            tableName = tableName.ToUpper();
            string sql = "select count(*) from sys.tables where name = @tname";

            DbParameter[] dbParams =
	        {
		         DbFactory<SqlServerConn, SqlServerFactory<SqlServerConn>>.MakeInParam("@tname", SqlDbType.VarChar, 30, tableName),
	        };

            return Convert.ToInt32(base.ExecuteScalar(sql, dbParams)) > 0;
        }

        /// <summary>
        /// 获取表结构<不包含数据>
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        private static DataSet GetEmptyTable(string tableName)
        {
            string sql = "select * from " + tableName + " where 0 = 1";

            try
            {
                IDbOperation db = new SqlServerExecute();
                return db.FillDataset(sql);
            }
            catch (Exception ex)
            {
                throw new CustomDataException(ex, sql);
            }
        }

        /// <summary>
        /// 将DataSet中的数据插入到表中
        /// </summary>
        /// <param name="ds">数据集</param>
        public void AutoInsert(DataSet ds)
        {
            if (null == ds || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return;
            }

            DbConnection conn = CreateConnection();
            conn.Open();
            DbTransaction tran = conn.BeginTransaction();
            try
            {
                foreach (DataTable dt in ds.Tables)
                {
                    AutoInsert(tran, dt);
                }

                tran.Commit();
            }
            catch (CustomDataException exdb)
            {
                tran.Rollback();
                throw new CustomDataException(exdb);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new CustomDataException(ex.Message, ex);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 将源表中的数据插入到表中
        /// </summary>
        /// <param name="dt">表名</param>
        public void AutoInsert(DataTable dt)
        {
            AutoInsert(null, dt);
        }

        /// <summary>
        /// 将源表中的数据插入到表中(含事务)
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <param name="dt">表名</param>
        public void AutoInsert(DbTransaction transaction, DataTable dt)
        {
            DataSet dataSet = GetSqlTableInfo(dt.TableName);
            if (null == dataSet || dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
            {
                throw new CustomDataException("未找到 " + dt.TableName + " 表的信息");
            }

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            foreach (DataRow drTable1 in dataSet.Tables[0].Rows)
            {
                string cName = drTable1["cname"].ToString();
                if (dt.Columns.Contains(cName))
                {
                    if (sb1.Length > 0)
                    {
                        sb1.Append(", ");
                        sb2.Append(", ");
                    }
                    sb1.Append(cName);
                    sb2.Append("@" + cName);
                }
            }

            if (sb1.Capacity == 0)
            {
                return;
            }

            string sql = "insert into " + dt.TableName + " (" + sb1.ToString() + ") values (" + sb2.ToString() + ")";
            DbParameter[] parameters = null;

            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    List<DbParameter> paramList = new List<DbParameter>();
                    foreach (DataRow drTable in dataSet.Tables[0].Rows)
                    {
                        string cName2 = drTable["cname"].ToString();
                        if (!dt.Columns.Contains(cName2))
                        {
                            continue;
                        }

                        DbType dbt = SqlServerDbTypeWrapper.WrapSqlDbType(drTable["coltype"].ToString());
                        object objValue = dr.IsNull(cName2) ? null : dr[cName2];
                        paramList.Add(DbFactory<SqlServerConn, SqlServerFactory<SqlServerConn>>.MakeInParam("@" + cName2, dbt, Convert.ToInt32(drTable["width"]), objValue));
                    }

                    parameters = paramList.ToArray();

                    IDbOperation db = new SqlServerExecute();

                    if (transaction == null)
                    {
                        db.ExecuteNonQuery(sql, parameters);
                    }
                    else
                    {
                        db.ExecuteNonQuery(transaction, sql, parameters);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new CustomDataException(ex, sql, parameters);
            }
        }

        /// <summary>
        /// 将DataSet中的数据插入到表中
        /// </summary>
        /// <param name="dataSet"></param>
        public void AutoInsertWithoutTransaction(DataSet dataSet)
        {
            if (null == dataSet || dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
            {
                return;
            }

            foreach (DataTable dt in dataSet.Tables)
            {
                AutoInsert(null, dt);
            }
        }

        public void AutoInsertWithoutTransaction(DataTable dt)
        {
            AutoInsert(null, dt);
        }

        /// <summary>
        /// 对表进行增量式更新
        /// </summary>
        /// <param name="dataTable">目标表，dt.TableName 必须包含要更新的表名</param>
        public void AutoInsertOrUpdate(DataTable dataTable)
        {
            AutoProcess(null, dataTable, ExistingItemProcessType.Update);
        }

        private void AutoProcess(DataTable dataTable, ExistingItemProcessType processType)
        {
            AutoProcess(null, dataTable, processType);
        }

        private void AutoProcess(DbTransaction transaction, DataTable dataTable, ExistingItemProcessType processType)
        {
            if (string.IsNullOrEmpty(dataTable.TableName))
            {
                throw new CustomDataException("表名为空");
            }

            if (dataTable.Rows.Count == 0)
            {
                return;
            }

            string sql = string.Empty;
            bool owerConnection = transaction == null;
            DbConnection conn = null;
            DbTransaction tran = null;
            try
            {
                ConstraintCollection ucList = GetSqlTableConstraint(dataTable.TableName);
                if (ucList.Count == 0)
                {
                    AutoInsert(null, dataTable);
                    return;
                }

                if (owerConnection)
                {
                    conn = CreateConnection();
                    conn.Open();
                    tran = conn.BeginTransaction();
                }
                else
                {
                    conn = transaction.Connection;
                    tran = transaction;
                }

                //sql = "select * from " + dt.TableName;
                //DataSet ds = GetDataSet(tran, sql);

                sql = "select count(*) from " + dataTable.TableName + " where ";
                Dictionary<string, bool> keyColumnList = new Dictionary<string, bool>();
                foreach (UniqueConstraint uc in ucList)
                {
                    if (uc == null || uc.Columns.Length == 0)
                    {
                        continue;
                    }

                    foreach (DataColumn dc in uc.Columns)
                    {
                        keyColumnList[dc.ColumnName] = true;
                    }
                }

                int idx = 0;
                foreach (string strColumnName in keyColumnList.Keys)
                {
                    if (idx > 0)
                    {
                        sql += " and ";
                    }
                    sql += strColumnName + "= @" + strColumnName;
                    ++idx;
                }

                DataSet dsTable = GetSqlTableInfo(dataTable.TableName);

                DataTable dtInsert = dataTable.Clone();
                DataTable dtExist = dataTable.Clone();
                foreach (DataRow dr in dataTable.Rows)
                {
                    DbParameter[] pList = new DbParameter[keyColumnList.Keys.Count];
                    idx = 0;
                    foreach (DataRow dr2 in dsTable.Tables[0].Rows)
                    {
                        if (keyColumnList.ContainsKey(dr2["cname"].ToString()))
                        {
                            pList[idx] = DbFactory<SqlServerConn, SqlServerFactory<SqlServerConn>>.MakeInParam("@" + dr2["cname"].ToString(), SqlServerDbTypeWrapper.WrapSqlDbType(dr2["coltype"].ToString()), Convert.ToInt32(dr2["width"]), dr[dr2["cname"].ToString()]);
                            ++idx;
                        }
                    }
                    bool bContain = Convert.ToInt32(ExecuteScalar(tran, CommandType.Text, sql, pList)) > 0;

                    if (!bContain)
                    {
                        dtInsert.ImportRow(dr);
                    }
                    else
                    {
                        dtExist.ImportRow(dr);
                    }
                }

                if (dtInsert.Rows.Count > 0)
                {
                    AutoInsert(tran, dtInsert);
                }

                if (processType == ExistingItemProcessType.Update && dtExist.Rows.Count > 0)
                {
                    AutoUpdate(tran, dtExist);
                }

                if (owerConnection)
                {
                    tran.Commit();
                }
            }
            catch (System.Exception ex)
            {
                if (owerConnection)
                {
                    tran.Rollback();
                }
                throw new CustomDataException(ex, sql);
            }
            finally
            {
                if (owerConnection && conn != null)
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 自动更新表
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="dataTable"></param>
        public void AutoUpdate(DbTransaction transaction, DataTable dataTable)
        {
            DataSet dsTable = GetSqlTableInfo(dataTable.TableName);

            if (null == dsTable || dsTable.Tables.Count == 0 || dsTable.Tables[0].Rows.Count == 0)
            {
                throw new CustomDataException("未找到 " + dataTable.TableName + " 表的信息");
            }

            ConstraintCollection ucList = GetSqlTableConstraint(dataTable.TableName);

            if (ucList.Count == 0)
            {
                throw new CustomDataException("表 " + dataTable.TableName + " 没有主键，无法自动更新");
            }

            Dictionary<string, bool> keyTable = new Dictionary<string, bool>();
            foreach (UniqueConstraint uc in ucList)
            {
                if (uc == null || uc.Columns.Length == 0)
                {
                    continue;
                }

                foreach (DataColumn dc in uc.Columns)
                {
                    keyTable[dc.ColumnName] = true;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("update ");
            sb.Append(dataTable.TableName);
            int idx = 0;
            foreach (DataRow drTable1 in dsTable.Tables[0].Rows)
            {
                string cName = drTable1["cname"].ToString();
                if (dataTable.Columns.Contains(cName) && !keyTable.ContainsKey(cName))
                {
                    if (idx == 0)
                    {
                        sb.Append(" set ");
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                    sb.Append(cName);
                    sb.Append(" = @");
                    sb.Append(cName);

                    ++idx;
                }
            }

            if (idx == 0)
            {
                return;
            }

            idx = 0;
            foreach (UniqueConstraint uc in ucList)
            {
                if (uc == null || uc.Columns.Length == 0)
                {
                    continue;
                }

                foreach (DataColumn dc in uc.Columns)
                {
                    if (idx == 0)
                    {
                        sb.Append(" where ");
                    }
                    else
                    {
                        sb.Append(" and ");
                    }

                    sb.Append(dc.ColumnName);
                    sb.Append(" = @");
                    sb.Append(dc.ColumnName);
                    ++idx;
                }
            }

            string sql = sb.ToString();
            DbParameter[] parameters = null;

            try
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    List<DbParameter> paramList = new List<DbParameter>();
                    foreach (DataRow drTable in dsTable.Tables[0].Rows)
                    {
                        string cName2 = drTable["cname"].ToString();
                        if (!dataTable.Columns.Contains(cName2))
                        {
                            continue;
                        }

                        DbType dbt = SqlServerDbTypeWrapper.WrapSqlDbType(drTable["coltype"].ToString());
                        object objValue = dr.IsNull(cName2) ? null : dr[cName2];

                        paramList.Add(DbFactory<SqlServerConn, SqlServerFactory<SqlServerConn>>.MakeInParam("@" + cName2, dbt, Convert.ToInt32(drTable["width"]), objValue));
                    }
                    parameters = paramList.ToArray();

                    IDbOperation db = new SqlServerExecute();
                    if (transaction == null)
                    {

                        db.ExecuteNonQuery(sql, parameters);
                    }
                    else
                    {
                        db.ExecuteNonQuery(transaction, sql, parameters);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new CustomDataException(ex, sql, parameters);
            }
        }

        /// <summary>
        /// 复制表结构及主键、唯一键
        /// </summary>
        /// <param name="srcTableName">源表</param>
        /// <param name="destTableName">新表名称，必须是不存在的</param>
        public void CopyTableStruct(string srcTableName, string destTableName)
        {
            if (srcTableName == destTableName)
            {
                throw new CustomDataException("源表和目标表名称冲突");
            }

            string sql = string.Empty;
            try
            {
                ConstraintCollection ucList = GetSqlTableConstraint(srcTableName);

                //sql = "create table " + destTableName + " as select * from " + srcTableName + " where 1=2";
                //上面语句为Oracle数据库中的复制表结构的Sql语句
                //下面语句为SqlServer数据库中复制表结构的Sql语句
                sql = "select * into " + destTableName + " from " + srcTableName + " where 1 = 2";
                IDbOperation db = new SqlServerExecute();
                db.ExecuteNonQuery(sql);

                // 添加主键、唯一键约束
                foreach (UniqueConstraint uc in ucList)
                {
                    if (uc == null || uc.Columns.Length <= 0)
                    {
                        continue;
                    }

                    string newConstraintName = uc.ConstraintName;
                    if (newConstraintName.IndexOf(srcTableName) > -1)
                    {
                        newConstraintName = newConstraintName.Replace(srcTableName, destTableName);
                    }
                    else
                    {
                        newConstraintName += "_" + destTableName;
                    }

                    StringBuilder sb = new StringBuilder("alter table ");
                    sb.Append(destTableName);
                    sb.Append(" add constraint ");
                    sb.Append(newConstraintName);
                    if (uc.IsPrimaryKey)
                    {
                        sb.Append(" primary key (");
                    }
                    else
                    {
                        sb.Append(" unique (");
                    }

                    for (int i = 0; i < uc.Columns.Length; ++i)
                    {
                        if (i > 0)
                        {
                            sb.Append(", ");
                        }
                        sb.Append(uc.Columns[i].ColumnName);
                    }
                    sb.Append(")");
                    sql = sb.ToString();
                    IDbOperation dbOperation = new SqlServerExecute();
                    dbOperation.ExecuteNonQuery(sql); ;
                }
            }
            catch (CustomDataException exdb)
            {
                throw exdb;
            }
            catch (System.Exception ex)
            {
                throw new CustomDataException(ex, sql);
            }
        }

        /// <summary>
        /// 向表中增加记录
        /// </summary>
        /// <param name="descObject">实体类</param>
        /// <param name="tableName">表名称</param>
        ///  <param name="keyName">主键名</param>
        /// <param name="isAutoIncCol">主键是否是自动增长列</param>
        public void InsertTableRec(object descObject, string tableName, string keyName, bool isAutoIncCol)
        {
            string sqlStatement = string.Empty;
            string sqlStatement2 = "insert into [" + tableName + "](";
            string sqlStatement3 = " values(";
            Type type = descObject.GetType();
            foreach (PropertyInfo info in type.GetProperties())
            {
                if (isAutoIncCol)
                {
                    if (info.Name.ToLower().Equals(keyName))
                    {
                        continue;
                    }
                }

                sqlStatement2 = sqlStatement2 + info.Name + ",";
                if (info.PropertyType.ToString().Equals("System.String"))
                {
                    sqlStatement3 = sqlStatement3 + "'" + (type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null) as string).Replace("'", "''") + "',";
                }
                else if (info.PropertyType.ToString().Equals("System.Boolean"))
                {
                    if ((bool)type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null))
                    {
                        sqlStatement3 = sqlStatement3 + "1,";
                    }
                    else
                    {
                        sqlStatement3 = sqlStatement3 + "0,";
                    }
                }
                else if (info.PropertyType.ToString().Equals("System.Int32"))
                {
                    sqlStatement3 = sqlStatement3 + ((int)type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null)) + ",";
                }
                else if (info.PropertyType.ToString().Equals("System.Int64"))
                {
                    sqlStatement3 = sqlStatement3 + ((long)type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null)) + ",";
                }
                else if (info.PropertyType.ToString().Equals("System.Double"))
                {
                    sqlStatement3 = sqlStatement3 + ((double)type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null)) + ",";
                }
                else if (info.PropertyType.ToString().Equals("System.Decimal"))
                {
                    sqlStatement3 = sqlStatement3 + ((decimal)type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null)) + ",";
                }
                else if (info.PropertyType.ToString().Equals("System.DateTime"))
                {
                    if (Convert.ToDateTime(type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null)) == DateTime.MinValue)
                    {
                        sqlStatement3 = sqlStatement3 + "null,";
                    }
                    else
                    {
                        sqlStatement3 = sqlStatement3 + "cast('" + Convert.ToString(type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null)) + "' as datetime),";
                    }
                }
                else
                {
                    sqlStatement3 = sqlStatement3 + (type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null) as string) + ",";
                }
            }

            sqlStatement = sqlStatement2.Substring(0, sqlStatement2.Length - 1) + ") " + sqlStatement3.Substring(0, sqlStatement3.Length - 1) + ")";

            IDbOperation db = new SqlServerExecute();
            db.ExecuteNonQuery(sqlStatement);
        }

        /// <summary>
        /// 根据主键修改表记录
        /// </summary>
        /// <param name="descObject">实体类名</param>
        /// <param name="tableName">表名</param>
        /// <param name="notUpdateFields">不要更新的列集合</param>
        public void UpdateTableRec(object descObject, string tableName, string keyName, string[] notUpdateFields)
        {
            string cmdText = string.Empty;
            string sqlStatement1 = "update [" + tableName + "] set ";
            int index = 0;
            Type type = descObject.GetType();
            SqlParameter[] parameterArray = new SqlParameter[type.GetProperties().Length - 1];
            int num = (int)type.InvokeMember(keyName, BindingFlags.GetProperty, null, descObject, null);
            foreach (PropertyInfo info in type.GetProperties())
            {
                if (!info.Name.ToLower().Equals(keyName) && !IsInArray(notUpdateFields, info.Name.ToLower()))
                {
                    string sqlStatement2 = sqlStatement1;
                    sqlStatement1 = sqlStatement2 + info.Name + "=@" + info.Name + ",";
                    if (info.PropertyType.ToString().Equals("System.String"))
                    {
                        parameterArray[index] = new SqlParameter("@" + info.Name, SqlDbType.VarChar);
                    }
                    if (info.PropertyType.ToString().Equals("System.Int32"))
                    {
                        parameterArray[index] = new SqlParameter("@" + info.Name, SqlDbType.Int);
                    }
                    if (info.PropertyType.ToString().Equals("System.Double"))
                    {
                        parameterArray[index] = new SqlParameter("@" + info.Name, SqlDbType.Float);
                    }
                    if (info.PropertyType.ToString().Equals("System.Decimal"))
                    {
                        parameterArray[index] = new SqlParameter("@" + info.Name, SqlDbType.Decimal);
                    }
                    if (info.PropertyType.ToString().Equals("System.DateTime"))
                    {
                        parameterArray[index] = new SqlParameter("@" + info.Name, SqlDbType.DateTime);
                    }
                    if (info.PropertyType.ToString().Equals("System.Byte[]"))
                    {
                        parameterArray[index] = new SqlParameter("@" + info.Name, SqlDbType.Image);
                    }
                    if (parameterArray[index] == null)
                    {
                        parameterArray[index] = new SqlParameter("@" + info.Name, SqlDbType.VarChar);
                    }
                    if (info.PropertyType.ToString().Equals("System.DateTime"))
                    {
                        DateTime dateTime = Convert.ToDateTime(type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null));
                        if (dateTime <= DateTime.MinValue)
                        {
                            parameterArray[index].Value = DBNull.Value;
                        }
                        else
                        {
                            parameterArray[index].Value = dateTime;
                        }
                    }
                    else
                    {
                        parameterArray[index].Value = type.InvokeMember(info.Name, BindingFlags.GetProperty, null, descObject, null);
                    }
                    index++;
                }
            }

            cmdText = sqlStatement1.Substring(0, sqlStatement1.Length - 1) + " where " + keyName + " = " + num;

            //DbCommand cmd = SqlServerFactory<SqlServerConn>.Factory.CreateCommand();
            DbCommand cmd = DbFactory<SqlServerConn, SqlServerFactory<SqlServerConn>>.Factory.CreateCommand();
            cmd.Connection = CreateConnection();
            cmd.CommandText = cmdText;

            cmd.Connection.Open();
            for (index = 0; index < parameterArray.Length; index++)
            {
                if (parameterArray != null)
                {
                    cmd.Parameters.Add(parameterArray[index]);
                }
            }

            int num3 = cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
        }

        private static bool IsInArray(string[] args, string item)
        {
            return args.Contains(item);

            //********  非Linq方法  *********//
            //if (args != null)
            //{
            //    for (int i = 0; i < args.Length; i++)
            //    {
            //        if (item.ToLower().Equals(args[i].ToLower()))
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;

            //********  非Linq方法  *********//
        }


        // xucj<Apr/29/14>(存储过程封装参数)

        //private DataTable GetStoredProcedureParaDataTableByName(string spName)
        //{
        //    string sql = string.Format("SELECT col.name, (SELECT name FROM systypes t WHERE t.xusertype = col.usertype) AS typeName, col.length AS length,col.isoutparam " +
        //                  " FROM syscolumns col INNER JOIN sysobjects obj ON obj.id = col.id AND obj.name = '{0}' ORDER by col.colorder", spName);

        //    return GetDataTable(sql);
        //}

        /// <summary>
        /// Execute store procedure with paramenters
        /// </summary>
        /// <param name="spName">store procedure name</param>
        /// <param name="paramValues">parameter values</param>
        /// <param name="outId">store procedure output value</param>
        public int ExecuteNonQuery(string spName, Object[] paramValues, ref int outId)
        {
            //DataTable paramDataTable = GetStoredProcedureParaDataTableByName(spName);

            DbCommand comm = CreateCommandWithStoreProcedure(spName, paramValues);
            comm.CommandText = spName;

            int result = comm.ExecuteNonQuery();

            for (int i = 0; i < comm.Parameters.Count; i++)
            {
                if (comm.Parameters[i].Direction == ParameterDirection.Output)
                {
                    paramValues[i] = comm.Parameters[i].Value;

                    if (comm.Parameters[i].ParameterName.ToUpper().Contains("ID"))
                    {
                        outId = (int)comm.Parameters[i].Value;
                    }
                }
                else if (comm.Parameters[i].Direction == ParameterDirection.Input)
                {
                    continue;
                }
            }

            return result;
        }

        public object ExecuteScalar(string spName, Object[] paramValues, ref int outId)
        {
            //DataTable paramDataTable = GetStoredProcedureParaDataTableByName(spName);

            DbCommand comm = CreateCommandWithStoreProcedure(spName, paramValues);
            comm.CommandText = spName;

            object result = comm.ExecuteScalar();

            for (int i = 0; i < comm.Parameters.Count; i++)
            {
                if (comm.Parameters[i].Direction == ParameterDirection.Output)
                {
                    paramValues[i] = comm.Parameters[i].Value;

                    if (comm.Parameters[i].ParameterName.ToUpper().Contains("ID"))
                    {
                        outId = (int)comm.Parameters[i].Value;
                    }
                }
                else if (comm.Parameters[i].Direction == ParameterDirection.Input)
                {
                    continue;
                }
            }

            return result;
        }

        public object ExecuteScalar(string spName, Object[] paramValues)
        {
            //DataTable paramDataTable = GetStoredProcedureParaDataTableByName(spName);

            DbCommand comm = CreateCommandWithStoreProcedure(spName, paramValues);
            comm.CommandText = spName;

            object result = comm.ExecuteScalar();

            for (int i = 0; i < comm.Parameters.Count; i++)
            {
                if (comm.Parameters[i].Direction == ParameterDirection.Output)
                {
                    paramValues[i] = comm.Parameters[i].Value;
                }
                else if (comm.Parameters[i].Direction == ParameterDirection.Input)
                {
                    continue;
                }
            }

            return result;
        }

        public object ExecuteScalarWithStoreProcedure(string spName)
        {
            return ExecuteScalar(spName, null);
        }

        /// <summary>
        /// Get the store procedure result.
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public DataSet GetDataSetWithStoreProcedureParas(string spName, Object[] paramValues)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            //DataTable paramDataTable = GetStoredProcedureParaDataTableByName(spName);

            DbCommand comm = CreateStoreProcedureCommand(spName, paramValues);

            DbDataReader dr = comm.ExecuteReader();

            if (dr.HasRows)
            {
                dt.Load(dr, LoadOption.Upsert);
            }

            ds.Tables.Add(dt);
            return ds;
        }
        /// <summary>
        /// Get the store procedure result.
        /// </summary>
        /// <param name="spName"></param>
        /// <returns></returns>
        public DataSet GetDataSetWithStoreProcedure(string spName)
        {
            return GetDataSetWithStoreProcedureParas(spName, null);
        }

        /// <summary>
        /// Retrieve the dataTable data via stored procedure.
        /// </summary>
        /// <param name="spName">stored procedure name</param>
        /// <returns></returns>
        public new DataTable FillDataTable(string spName)
        {
            return GetDataSetWithStoreProcedure(spName).Tables[0];
        }

        /// <summary>
        /// Retrieve the dataTable data via stored procedure and object parameters.
        /// </summary>
        /// <param name="spName">stored procedure name</param>
        /// <param name="paramValues">object parameters, must by type following the parameters in stored procedure.</param>
        /// <returns></returns>
        public DataTable GetDataTable(string spName, Object[] paramValues)
        {
            return GetDataSetWithStoreProcedureParas(spName, paramValues).Tables[0];
        }

        public int ExecuteNonQuery(string spName, Object[] paramValues)
        {
            int id = 0;
            return ExecuteNonQuery(spName, paramValues, ref id);
        }

        private static DbCommand CreateStoreProcedureCommand(string spName, Object[] paramValues)
        {
            DbCommand comm = new SqlCommand();
            comm.Connection = CreateConnection();
            if (comm.Connection.State != ConnectionState.Open)
            {
                comm.Connection.Open();
            }

            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = spName;
            GetStoreProcedureParaValue(paramValues, comm);

            return comm;
        }

        private static void GetStoreProcedureParaValue(Object[] paramValues, DbCommand comm)
        {
            SqlCommandBuilder.DeriveParameters((SqlCommand)comm);

            if (paramValues != null)
            {
                int paraValueIndex = 0;
                for (int i = 0; i < comm.Parameters.Count; i++)
                {
                    if (comm.Parameters[i].ParameterName.ToUpper().Contains("RETURN_VALUE"))
                    {
                        continue;
                    }
                    if (comm.Parameters[i].Direction == ParameterDirection.Input)
                    {
                        comm.Parameters[i].Value = paramValues[paraValueIndex];
                    }
                    else if (comm.Parameters[i].Direction == ParameterDirection.Output)
                    {
                        continue;
                    }
                    paraValueIndex++;
                }
            }
        }

        private static DbCommand CreateCommandWithStoreProcedure(string spName, Object[] paramValues)
        {
            DbCommand comm = CreateStoreProcedureCommand(spName, paramValues);
            comm.CommandType = CommandType.StoredProcedure;
            return comm;
        }
    }
}
