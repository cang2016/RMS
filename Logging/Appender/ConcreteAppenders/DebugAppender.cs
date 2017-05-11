namespace RMS.Logging
{
    using System;
    using System.Diagnostics;
    /// <summary>
    /// 写日志信息到Debug输出窗口.
    /// </summary>
    public class DebugAppender : IAppender
    {
        #region 实例字段

        private Action<string> writeToDebugWindow;

        #endregion 实例字段

        #region 构造函数
        /// <summary>
       /// 构造函数
       /// </summary>
        public DebugAppender()
        {
            Initialize();
        }

        #endregion 构造函数

        #region 私有方法

        private void SetWriteToDebugWindow(Action<string> writeToDebugWindow)
        {
            this.writeToDebugWindow = writeToDebugWindow;
        }

        private object LogInternal(LogEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("entry");
            }

            string formattedEvent = LoggingHelper.FormatEvent(entry);

            this.writeToDebugWindow(formattedEvent);

            return null;
        }

        /// <summary>
        /// 初始化委托
        /// </summary>
        private void Initialize()
        {
            this.SetWriteToDebugWindow((formattedEvent) => Trace.Write(formattedEvent));
        }

        #endregion 私有方法

        #region 公共属性
        /// <summary>
        /// 附加器名称.
        /// </summary>
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion 公共属性

        #region 公共实例属性
        /// <summary>
        ///  关闭附加器.
        /// </summary>
        public void Close()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 实现IAppender接口DoAppender方法.
        /// </summary>
        /// <param name="logEntry">日志信息实体.</param>
        public void DoAppender(LogEntry logEntry)
        {
             LogInternal(logEntry);
        }

        #endregion 公共实例属性
    }
}