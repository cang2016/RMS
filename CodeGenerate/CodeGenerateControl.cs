using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.DataAccess;
using RMS.Logging;

namespace CodeGenerate
{
    public class CodeGenerateControl
    {
        public string GetServerName()
        {
            SqlServerExecute sqlServerExe = new SqlServerExecute();

            return sqlServerExe.ExecuteScalarToStr("select @@Servername");
        }

        public DataTable GetDatabases()
        {
            SqlServerExecute sqlServerExe = new SqlServerExecute();

            return sqlServerExe.FillDataTable(CommandType.Text,"select name from master..sysdatabases");
        }

        public List<DataTable> GetTablesInDatabase(List<string> tableNameList)
        {
            SqlServerExecute sqlServerExe = new SqlServerExecute();
            //DataTable userTables = sqlServerExe.FillDataTable(CommandType.Text, "select name from sysobjects where type = 'U'");
            List<DataTable> tableList = new List<DataTable>();
            foreach(String tableName in tableNameList)
            {
                string sql = string.Format("select * from {0}", tableName);
                DataTable dt = sqlServerExe.FillDataTable(CommandType.Text, sql);
                dt.TableName = tableName;
                tableList.Add(dt);
            }

            return tableList;
        }

        public List<string> GetTableNamesInDatabase(string dataBaseName)
        {
            SqlServerExecute sqlServerExe = new SqlServerExecute();
            DataTable userTables = sqlServerExe.FillDataTable(CommandType.Text, "use " + dataBaseName + "; select name from sysobjects where type = 'U'");
            List<string> tableList = new List<string>();
            foreach(DataRow row in userTables.Rows)
            {
                string sql = string.Format("select * from {0}", row["Name"].ToString());

                if(row["name"] != DBNull.Value)
                {
                    tableList.Add(Convert.ToString(row["Name"]));
                }
            }

            return tableList;
        }



    }
}
