namespace RMS.Logging
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Configuration.Provider;
    using RMS.Logging;

    /// <summary>
    /// 控制台附加器
    /// </summary>
    public class ConsoleAppender : IAppender
    {
        #region 实例字段

        private Action<string> writeToConsole;
        private string m_name;

        #endregion 实例字段

        #region 实例方法

        /// <summary>
        /// 构造函数.
        /// </summary>
        public ConsoleAppender()
        {
            this.Initialize();
        }

        /// <summary>
        /// 设置日志到控制台附加器.
        /// </summary>
        /// <param name="writeToConsole"></param>
        internal void SetWriteToConsole(Action<string> writeToConsole)
        {
            this.writeToConsole = writeToConsole;
        }

        /// <summary>
        /// 内部写日志到控制台
        /// </summary>
        /// <param name="entry"></param>
        protected void LogInternal(LogEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("日志事件实体");
            }

            string formattedEvent = LoggingHelper.FormatEvent(entry);

            this.writeToConsole(formattedEvent);

            Console.Read();
        }

        /// <summary>
        /// 初始化写日志方法
        /// </summary>
        private void Initialize()
        {
            this.SetWriteToConsole((msg) => Write(msg));
        }

        /// <summary>
        /// 写日志到控制台.
        /// </summary>
        /// <param name="msg"></param>
        private void Write(string msg)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.WriteLine(msg);
            Console.ForegroundColor = oldColor;
        }

        #endregion 实例方法

        #region 实现接口IAppender

        /// <summary>
        /// 附加器名称.
        /// </summary>
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        /// <summary>
        /// 关闭附加器.
        /// </summary>
        public void Close()
        {
            this.Close();
        }

        /// <summary>
        /// 实现接口IAppender接口方法DoAppender.
        /// </summary>
        /// <param name="logEntry"></param>
        public void DoAppender(LogEntry logEntry)
        {
            LogInternal(logEntry);
        }

        #endregion 实现接口IAppender
    }
}