using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 using RMS.Logging;

namespace RMS.Logging
{
    /// <summary>
    /// 日志接口封装器抽象实现类
    /// </summary>
    public abstract class LoggerWrapperImpl : ILoggerWraper
    {
         /// <summary>
         /// 日志器接口
         /// </summary>
        public ILogger Logger
        {
            get { return m_logger; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        protected LoggerWrapperImpl(ILogger logger)
        {
            m_logger = logger;
        }

        /// <summary>
        /// 私有只读字段
        /// </summary>
        private readonly ILogger m_logger;  
    }
}
