using System;
using System.Data;
using System.Data.OracleClient;

namespace RMS.DataAccess
{
    public class OracleDbTypeWrapper
    {
        public static DbType WrapDbType(string strDbType)
        {
            DbType dbt;
            switch (strDbType.ToUpper())
            {
                case "VARCHAR2":
                case "VARCHAR":
                    dbt = (DbType)OracleType.VarChar;
                    break;
                case "CHAR":
                    dbt = (DbType)OracleType.Char;
                    break;
                case "NUMBER":
                    dbt = (DbType)OracleType.Number;
                    break;
                case "DATE":
                    dbt = (DbType)OracleType.DateTime;
                    break;
                default:
                    throw new Exception("未知的数据类型");
            }

            return dbt;
        }
    }
}
