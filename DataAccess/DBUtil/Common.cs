using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAccess
{
    /// <summary>
    /// DataBase 公共类,存储一些公共方法.
    /// </summary>
    public class DbCommon
    {
        /// <summary>
        /// 返回数据库实例引擎名称与数据库连接串.
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="connString"></param>
        /// <param name="obj"></param>
        public static void GetDbConfig(ref string providerName, ref string connString, object obj)
        {
            DbConfigurations dbConfigs = DbConfigurationColl.Configuration.DbConnections;
            foreach(DbConfiguration dbConfig in dbConfigs)
            {
                if(dbConfig.Type == obj.GetType().FullName)
                {
                    providerName = dbConfig.ProviderName;
                    connString = dbConfig.ConnectionString;
                }
            }
        }

        /// <summary>
        /// 提取Parameter中的值.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string LogParameters(string commandText, DbParameter[] commandParameters, DbCommand cmd)
        {
            string logsql = string.Empty;
            string commText = string.Empty;
            if(commandParameters != null)
            {
                commText = cmd.CommandText;


                foreach(DbParameter param in commandParameters)
                {
                    object dbValue = param.Value;
                    if(DBNull.Value.Equals(dbValue) || string.IsNullOrWhiteSpace(Convert.ToString(dbValue)))
                    {
                        dbValue = "''";
                    }
                    else
                    {
                        switch(param.DbType)
                        {
                            case System.Data.DbType.AnsiString:
                                dbValue = "'" + dbValue + "'";
                                break;
                            case System.Data.DbType.AnsiStringFixedLength:
                                dbValue = "'" + dbValue + "'";
                                break;
                            case System.Data.DbType.Binary:
                                break;
                            case System.Data.DbType.Boolean:
                                break;
                            case System.Data.DbType.Byte:
                                break;
                            case System.Data.DbType.Currency:
                                break;
                            case System.Data.DbType.Date:
                                break;
                            case System.Data.DbType.DateTime:
                                break;
                            case System.Data.DbType.DateTime2:
                                break;
                            case System.Data.DbType.DateTimeOffset:
                                break;
                            case System.Data.DbType.Decimal:
                                break;
                            case System.Data.DbType.Double:
                                break;
                            case System.Data.DbType.Guid:
                                break;
                            case System.Data.DbType.Int16:
                                break;
                            case System.Data.DbType.Int32:
                                break;
                            case System.Data.DbType.Int64:
                                break;
                            case System.Data.DbType.Object:
                                dbValue = "'" + dbValue + "'";
                                break;
                            case System.Data.DbType.SByte:
                                break;
                            case System.Data.DbType.Single:
                                break;
                            case System.Data.DbType.String:
                                dbValue = "'" + dbValue + "'";
                                break;
                            case System.Data.DbType.StringFixedLength:
                                dbValue = "'" + dbValue + "'";
                                break;
                            case System.Data.DbType.Time:
                                break;
                            case System.Data.DbType.UInt16:
                                break;
                            case System.Data.DbType.UInt32:
                                break;
                            case System.Data.DbType.UInt64:
                                break;
                            case System.Data.DbType.VarNumeric:
                                break;
                            case System.Data.DbType.Xml:
                                dbValue = "'" + dbValue + "'";
                                break;
                            default:
                                break;
                        }
                    }

                    commText = commText.Replace(param.ParameterName,Convert.ToString(dbValue));
                }
            }

            if(!string.IsNullOrEmpty(commText))
            {
                logsql = commText;
            }
            else
            {
                logsql = commandText;
            }
            return logsql;
        }
    }
}
