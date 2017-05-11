using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Text;

namespace RMS.DataAccess
{
    public class OracleExecute : OracleConn
    {
        /// <summary>
        /// 获取某个表的信息
        /// cname - 字段名
        /// coltype - 字段类型
        /// width - 字段长度
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetTableInfo(string tableName)
        {
            tableName = tableName.ToUpper();
            string sql = "select cname, coltype, width from col where tname = :tname";
            DbParameter[] dbParams =
	        {
		        DbFactory<OracleConn, OracleFactory<OracleConn>>.MakeInParam(":tname", OracleType.VarChar, 30, tableName),
	        };

            IDbOperation db = new OracleExecute();
            DataSet dataSet =db.FillDataset(sql, dbParams);
            return dataSet;
        }

        /// <summary>
        /// 获取表的约束条件
        /// constraint_name - 约束名称
        /// column_name - 约束的字段
        /// constraint_type - 约束类型，P: 主键，U: 唯一键，R: 外键
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public ConstraintCollection GetTableConstraint(string tableName)
        {
            tableName = tableName.ToUpper();
            string sql = "select col.constraint_name, col.column_name, c.constraint_type from user_cons_columns col, user_constraints c where col.constraint_name = c.constraint_name and c.constraint_type in ('P', 'U') and col.table_name = :table_name order by c.constraint_type, col.constraint_name, col.position";
            try
            {
                DbParameter[] prams =
	            {
		            DbFactory<OracleConn, OracleFactory<OracleConn>>.MakeInParam(":table_name", OracleType.VarChar, 30, tableName),
	            };
                IDbOperation db = new OracleExecute();

                DataSet ds = db.FillDataset(sql, prams);
                DataSet dsEmtpy = GetEmptyTable(tableName);

                string prevType = "", prevColName = "";
                List<DataColumn> cols = null;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string constraintName = dr["constraint_name"].ToString();
                    string columnName = dr["column_name"].ToString();
                    string constraintType = dr["constraint_type"].ToString();

                    if (constraintType != prevType || constraintName != prevColName)
                    {
                        if (prevType.Length > 0)
                        {
                            UniqueConstraint uc = new UniqueConstraint(prevColName, cols.ToArray(), prevType == "P");
                            dsEmtpy.Tables[0].Constraints.Add(uc);
                        }

                        cols = new List<DataColumn>();
                    }

                    cols.Add(dsEmtpy.Tables[0].Columns[columnName]);
                    prevType = constraintType;
                    prevColName = constraintName;
                }

                if (prevType.Length > 0)
                {
                    UniqueConstraint uc = new UniqueConstraint(prevColName, cols.ToArray(), prevType == "P");
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

        public DataSet GetEmptyTable(string tableName)
        {
            string sql = "select * from " + tableName + " where 0 = 1";
            try
            {
                IDbOperation db = new OracleExecute();
                return db.FillDataset(sql);
            }
            catch (System.Exception ex)
            {
                throw new CustomDataException(ex, sql);
            }
        }

        /// <summary>
        /// 判断某个表是否为空
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool IsTableEmpty(string tableName)
        {
            string sql = "select count(*) from " + tableName;
            try
            {
                return Convert.ToInt32(ExecuteScalar(sql)) == 0;
            }
            catch (System.Exception ex)
            {
                throw new CustomDataException(ex, sql);
            }
        }

        /// <summary>
        /// 检测某个表是否存在
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <returns></returns>
        public bool TableExists(string tableName)
        {
            tableName = tableName.ToUpper();
            string sql = "select count(*) from sys.user_all_tables where table_name = :tname";
            DbParameter[] prams =
	        {
		        DbFactory<OracleConn, OracleFactory<OracleConn>>.MakeInParam(":tname", OracleType.VarChar, 30, tableName),
	        };

            return Convert.ToInt32(ExecuteScalar(sql, prams)) > 0;
        }

        public void AutoInsert(DataSet dataSet)
        {
            if (null == dataSet || dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
            {
                return;
            }

            DbConnection conn = CreateConnection();
            conn.Open();
            DbTransaction tran = conn.BeginTransaction();
            try
            {
                foreach (DataTable dt in dataSet.Tables)
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
            catch (System.Exception ex)
            {
                tran.Rollback();
                throw new CustomDataException(ex.Message, ex);
            }
            finally
            {
                conn.Close();
            }
        }

        public void AutoInsert(DataTable dataTable)
        {
            AutoInsert(null, dataTable);
        }

        public void AutoInsert(DbTransaction transaction, DataTable dataTable)
        {
            DataSet dsTable = GetTableInfo(dataTable.TableName);
            if (null == dsTable || dsTable.Tables.Count == 0 || dsTable.Tables[0].Rows.Count == 0)
            {
                throw new Exception("未找到 " + dataTable.TableName + " 表的信息");
            }

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            foreach (DataRow drTable1 in dsTable.Tables[0].Rows)
            {
                string cName = drTable1["CNAME"].ToString();
                if (dataTable.Columns.Contains(cName))
                {
                    if (sb1.Length > 0)
                    {
                        sb1.Append(", ");
                        sb2.Append(", ");
                    }
                    sb1.Append(cName);
                    sb2.Append(":" + cName);
                }
            }

            if (sb1.Capacity == 0)
            {
                return;
            }

            string sql = "insert into " + dataTable.TableName + " (" + sb1.ToString() + ") values (" + sb2.ToString() + ")";
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

                        DbType dbt = OracleDbTypeWrapper.WrapDbType(drTable["coltype"].ToString());
                        object o = dr.IsNull(cName2) ? null : dr[cName2];
                        paramList.Add(DbFactory<OracleConn, OracleFactory<OracleConn>>.MakeInParam(":" + cName2, dbt, Convert.ToInt32(drTable["width"]), o));
                    }

                    parameters = paramList.ToArray();

                    IDbOperation db = new OracleExecute();
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

        public void AutoInsertWithoutTransaction(DataSet dataSet)
        {
            if (null == dataSet || dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
            {
                return;
            }
            foreach (DataTable dataTable in dataSet.Tables)
            {
                AutoInsert(null, dataTable);
            }
        }

        public void AutoInsertWithoutTransaction(DataTable dataTable)
        {
            AutoInsert(null, dataTable);
        }

        /// <summary>
        /// 对表进行增量式更新
        /// </summary>
        /// <param name="dataTable">目标表，dt.TableName 必须包含要更新的表名</param>
        public void AutoInsertOrUpdate(DataTable dataTable)
        {
            AutoProcess(null, dataTable, ExistingItemProcessType.Update);
        }

        public void AutoProcess(DataTable dataTable, ExistingItemProcessType processType)
        {
            AutoProcess(null, dataTable, processType);
        }

        public void AutoProcess(DbTransaction transaction, DataTable dataTable, ExistingItemProcessType processType)
        {
            if (dataTable.TableName.Length == 0)
            {
                throw new Exception("表名为空");
            }

            if (dataTable.Rows.Count == 0)
            {
                return;
            }

            string sql = "";
            bool owerConnection = transaction == null;
            DbConnection conn = null;
            DbTransaction tran = null;
            try
            {
                ConstraintCollection ucList = GetTableConstraint(dataTable.TableName);
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
                //DataSet ds = ExecuteDataset(tran, sql);

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
                foreach (string columnName in keyColumnList.Keys)
                {
                    if (idx > 0)
                    {
                        sql += " and ";
                    }
                    sql += columnName + "=:" + columnName;
                    ++idx;
                }

                DataSet dsTable = GetTableInfo(dataTable.TableName);

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
                            pList[idx] = DbFactory<OracleConn, OracleFactory<OracleConn>>.MakeInParam(":" + dr2["cname"].ToString(), OracleDbTypeWrapper.WrapDbType(dr2["coltype"].ToString()), Convert.ToInt32(dr2["width"]), dr[dr2["cname"].ToString()]);
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

        public void AutoUpdate(DbTransaction transaction, DataTable dataTable)
        {
            DataSet dsTable = GetTableInfo(dataTable.TableName);
            if (null == dsTable || dsTable.Tables.Count == 0 || dsTable.Tables[0].Rows.Count == 0)
            {
                throw new Exception("未找到 " + dataTable.TableName + " 表的信息");
            }

            ConstraintCollection ucList = GetTableConstraint(dataTable.TableName);
            if (ucList.Count == 0)
            {
                throw new Exception("表 " + dataTable.TableName + " 没有主键，无法自动更新");
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
            foreach (DataRow dataRow in dsTable.Tables[0].Rows)
            {
                string cName = dataRow["CNAME"].ToString();
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
                    sb.Append(" = :");
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
                    sb.Append(" = :");
                    sb.Append(dc.ColumnName);
                    ++idx;
                }
            }

            string sql = sb.ToString();
            DbParameter[] parameters = null;

            try
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    List<DbParameter> paramList = new List<DbParameter>();
                    foreach (DataRow drTable in dsTable.Tables[0].Rows)
                    {
                        string cName2 = drTable["cname"].ToString();
                        if (!dataTable.Columns.Contains(cName2))
                        {
                            continue;
                        }

                        DbType dbt = OracleDbTypeWrapper.WrapDbType(drTable["coltype"].ToString());
                        object o = dataRow.IsNull(cName2) ? null : dataRow[cName2];
                        paramList.Add(DbFactory<OracleConn, OracleFactory<OracleConn>>.MakeInParam(":" + cName2, dbt, Convert.ToInt32(drTable["WIDTH"]), o));
                    }
                    parameters = paramList.ToArray();

                    IDbOperation db = new OracleExecute();
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
                throw new Exception("源表和目标表名称冲突");
            }

            string sql = "";
            try
            {
                ConstraintCollection ucList = GetTableConstraint(srcTableName);

                sql = "create table " + destTableName + " as select * from " + srcTableName + " where 1=2";
                IDbOperation db = new OracleExecute();
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
                    IDbOperation dbOperation = new OracleExecute();
                    dbOperation.ExecuteNonQuery(sql);
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
    }
}
