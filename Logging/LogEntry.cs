namespace RMS.Logging
{
    using System;
    using RMS.Logging;

    /// <summary>
    /// 日志信息实体
    /// </summary>
    public class LogEntry
    {
        #region 私有字段
        private Type m_callerStackBoundaryDeclaringType;
        private Exception m_thrownException;
        private object m_message;
        private string m_loggerName;
        private Level m_level;
        DateTime m_timeStamp;
        private string m_source;
        #endregion 私有字段

        #region 公共属性

        /// <summary>
        /// 调用类型
        /// </summary>
        public Type CallerStackBoundaryDeclaringType
        {
            get { return m_callerStackBoundaryDeclaringType; }
        }

        /// <summary>
        /// 日志信息
        /// </summary>
        public object Message
        {
            get { return m_message; }
        }

        /// <summary>
        /// 异常
        /// </summary>
        public Exception ThrownException
        {
            get { return m_thrownException; }
        }

        /// <summary>
        /// 日志名称
        /// </summary>
        public string LoggerName
        {
            get { return m_loggerName; }
        }
     
        /// <summary>
        /// 日志级别
        /// </summary>
        public Level Level
        {
            get { return m_level; }
        }

        /// <summary>
        /// 事件源
        /// </summary>
        public string Source
        {
            get { return m_source; }
            set { m_source = value; }
        }

        /// <summary>
        /// 写日志时间.
        /// </summary>
        public DateTime TimeStamp
        {
            get { return m_timeStamp; }
        }

        #endregion 公共属性

        #region 构造函数
        public LogEntry(Type callerStackBoundaryDeclaringType, object message, Level level, string loggerName, Exception exception)
        {
            m_callerStackBoundaryDeclaringType = callerStackBoundaryDeclaringType;
            m_message = message;
            m_thrownException = exception;

            m_loggerName = loggerName;
            m_level = level;

            m_timeStamp = DateTime.Now;
        }

        public LogEntry(Type callerStackBoundaryDeclaringType, object message, Exception exception, Level level)
        {
            m_callerStackBoundaryDeclaringType = callerStackBoundaryDeclaringType;
            m_message = message;
            m_thrownException = exception;

            m_loggerName = "logger";
            m_level = level;

            m_timeStamp = DateTime.Now;
        }

        #endregion 构造函数
    }
}
