using System.Data;

namespace RMS.DataAccess
{
    public class SqlServerDbTypeWrapper
    {
        public static DbType WrapSqlDbType(string dbType)
        {
            DbType dbt;
            switch (dbType.ToUpper())
            {
                case "VARCHAR":
                    dbt = (DbType)SqlDbType.VarChar;
                    break;
                case "CHAR":
                    dbt = (DbType)SqlDbType.Char;
                    break;
                case "DATE":
                    dbt = (DbType)SqlDbType.Date;
                    break;
                case "DATETIME":
                    dbt = (DbType)SqlDbType.DateTime;
                    break;
                case "INT32":
                case "INT":
                case "INT64":
                    dbt = (DbType)SqlDbType.Int;
                    break;
                case "FLOAT":
                    dbt = (DbType)SqlDbType.Float;
                    break;
                case "DECIMAL":
                    dbt = (DbType)SqlDbType.Decimal;
                    break;
                default:
                    throw new CustomDataException("未知数据类型");
            }

            return dbt;
        }
    }
}
