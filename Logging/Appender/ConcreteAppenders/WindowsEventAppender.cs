namespace RMS.Logging
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Configuration.Provider;
    using System.Diagnostics;
   
    /// <summary>
    /// 写日志到Windows系统日志中.
    /// </summary>
    public class WindowsEventAppender : IAppender
    {
        #region 实例字段

        private string logName;

        #endregion 实例字段

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WindowsEventAppender()
        {

        }

        #endregion #region 构造函数

        #region 属性
        /// <summary>
        /// 日志名称.
        /// </summary>
        public string LogName
        {
            get { return this.logName; }
        }

        /// <summary>
        /// 日志名称.
        /// </summary>
        public string Name
        {
            get
            {
                return logName;
            }
            set
            {
                logName = value;
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
       /// 写日志到系统事件器中.
       /// </summary>
       /// <param name="entry"></param>
        protected void LogInternal(LogEntry entry)
        {
            EventLog.WriteEntry("Application", entry.Message.ToString(), EventLogEntryType.Information);
        }

        /// <summary>
        /// 生成事件日志信息.
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected virtual string BuildEventLogMessage(LogEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("entry");
            }

            return LoggingHelper.BuildMessageFromLogEntry(entry);
        }

        /// <summary>
        /// 实现IAppender中Close方法.
        /// </summary>
        public void Close()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 实现IAppender中DoAppender方法.
        /// </summary>
        /// <param name="logEntry"></param>
        public void DoAppender(LogEntry logEntry)
        {
            LogInternal(logEntry);
        }

        #endregion  方法
    }
}