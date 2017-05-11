using System;
using System.Data;
using System.Data.Common;
using RMS.Logging;

namespace RMS.DataAccess
{
    /// <summary>
    /// 数据库工厂类.
    /// </summary>
    /// <typeparam name="C">实现IDbConnectionString接口的连接串类.</typeparam>
    /// <typeparam name="P">实现IDbProviderName接口的数据库引擎名称.</typeparam>
    public class DbFactory<C, P>
        where C : IDbConnectionString, new()
        where P : IDbProviderName, new()
    {
        #region private member

        /// <summary>
        /// 数据引擎实现工厂.
        /// </summary>
        private static DbProviderFactory m_factory;

        /// <summary>
        /// 数据引擎实现工厂接口.
        /// </summary>
        private static IDbProvider m_provider = null;

        private static object lockObject = new object();

        #endregion

        /// <summary>
        /// 返回实现IDbProvider接口的具体数据引擎.
        /// </summary>
        public static IDbProvider Provider
        {
            get
            {
                if (m_provider == null)
                {
                    lock (lockObject)
                    {
                        if (m_provider == null)
                        {
                            string providerName = typeof(DbFactory<C, P>).Namespace + "." + new P().DbProviderName + "Provider";  // 用于反射
                       
                            try
                            {
                                m_provider = (IDbProvider)Activator.CreateInstance(Type.GetType(providerName));
                            }
                            catch (DbException dex)
                            {
                                LoggerManager.GetILog("Data Provider").Error(dex.StackTrace);
                                throw new Exception("创建数据库实例失败，请确认存在 " + providerName + " 的类");
                            }
                        }
                    }
                }

                return m_provider;
            }
        }

        /// <summary>
        ///  数据库引擎实现工厂.
        /// </summary>
        public static DbProviderFactory Factory
        {
            get
            {
                if (m_factory == null)
                {
                    m_factory = Provider.Instance();
                }

                return m_factory;
            }
        }

        /// <summary>
        /// 重置数据引擎.
        /// </summary>
        public static void ResetDbProvider()
        {
            m_factory = null;
            m_provider = null;
        }

        #region Make parameter.
        /// <summary>
        /// 生成参数.
        /// </summary>
        /// <param name="ParamName">参数名称.</param>
        /// <param name="DbType">参数类型.</param>
        /// <param name="Size">参数大小..</param>
        /// <param name="Value">参数值.</param>
        /// <returns>生成后的参数.</returns>
        public static DbParameter MakeInParam(string ParamName, DbTypeWrapper DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// 生成参数.
        /// </summary>
        /// <param name="ParamName">参数名称.</param>
        /// <param name="DbType">参数类型.</param>
        /// <param name="Value">参数值.</param>
        /// <returns>生成后的参数.</returns>
        public static DbParameter MakeInParam(string ParamName, DbTypeWrapper DbType, object Value)
        {
            return MakeParam(ParamName, DbType, 0, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// 生成参数.
        /// </summary>
        /// <param name="ParamName">参数名称.</param>
        /// <param name="DbType">参数类型.</param>
        /// <param name="Size">参数大小.</param>
        /// <returns>生成后的参数.</returns>
        public static DbParameter MakeOutParam(string ParamName, DbTypeWrapper DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// 生成参数.
        /// </summary>
        /// <param name="ParamName">参数名称.</param>
        /// <param name="DbType">参数类型.</param>
        /// <param name="Size">参数大小.</param>
        /// <param name="Direction">参数方向.</param>
        /// <param name="Value">参数值.</param>
        /// <returns>生成后的参数.</returns>
        public static DbParameter MakeParam(string ParamName, DbTypeWrapper DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            DbParameter param;

            param = Provider.MakeParam(ParamName, DbType, Size);

            param.Direction = Direction;
            if(!(Direction == ParameterDirection.Output && Value == null))
            {
                param.Value = Value;
            }

            return param;
        }

        #endregion Make parameter end
    }
}
