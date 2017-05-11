namespace RMS.Logging
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// 文本文件附加器.
    /// </summary>
    public class TextFileAppender : FileLoggingProviderBase
    {
        #region 构造函数

        /// <summary>
        /// 构造函数.
        /// </summary>
        public TextFileAppender()
            : this("txtFile.txt")
        {

        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="path"></param>
        public TextFileAppender(string path)
            : base(path)
        {

        }

        #endregion 构造函数

        #region 实例属性

        /// <summary>
        /// 附加器名称.
        /// </summary>
        public new string Name
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

        #endregion 实例属性

        #region  公共方法
      
        /// <summary>
        /// 格式化日志信息.
        /// </summary>
        /// <param name="logEntry">日志信息实体.</param>
        /// <returns>字符串形式的日志信息实体.</returns>
        public override string SerializeLogEntry(LogEntry logEntry)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("DateTime:{0} ", logEntry.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendFormat("[{0}]- ", logEntry.Level);
            if (!string.IsNullOrEmpty(Convert.ToString(logEntry.Message)))
            {
                sb.AppendFormat("Message：{0} ", logEntry.Message);
            }
            if (logEntry.ThrownException != null)
            {
                sb.AppendFormat(logEntry.ThrownException.StackTrace.ToString());
            }

            return sb.ToString();
        }

   

        /// <summary>
        /// 关闭附加器.
        /// </summary>
        public new void Close()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 实现IAppender接口DoAppender方法.
        /// </summary>
        /// <param name="logEntry"></param>
        public override void DoAppender(LogEntry logEntry)
        {
            string contents = SerializeLogEntry(logEntry);
            Write(contents);
        }


        #endregion 公共方法
    }
}
