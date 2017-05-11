namespace RMS.Logging
{
    using System;

    /// <summary>
    /// 日志器日志实现接口，所有的日志输出方法定义在此，必须实现此接口
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 写一个deubg日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        void Debug(object message);

        /// <summary>
        /// 写一个deubg日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        void Debug(object message, Exception exception);

        /// <summary>
        /// 写一个参数化信息的日志信息
        /// </summary>
        /// <param name="format">日志信息</param>
        /// <param name="args">参数</param>
        void DebugFormat(string format, params object[] args);

        /// <summary>
        /// 写一个Info日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        void Info(object message);

        /// <summary>
        /// 写一个Info日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        void Info(object message, Exception exception);


        /// <summary>
        /// 写一个参数化信息的日志信息
        /// </summary>
        /// <param name="format">日志信息</param>
        /// <param name="args">参数</param>
        void InfoFormat(string format, params object[] args);

        /// <summary>
        /// 写一个Warn日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        void Warn(object message);

        /// <summary>
        /// 写一个Warn日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        void Warn(object message, Exception exception);

        /// <summary>
        /// 写一个参数化信息的日志信息
        /// </summary>
        /// <param name="format">日志信息</param>
        /// <param name="args">参数</param>
        void WarnFormat(string format, params object[] args);

        /// <summary>
        /// 写一个Error日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        void Error(object message);

        /// <summary>
        /// 写一个Error日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        void Error(object message, Exception exception);

        /// <summary>
        /// 写一个参数化信息的日志信息
        /// </summary>
        /// <param name="format">日志信息</param>
        /// <param name="args">参数</param>
        void ErrorFormat(string format, params object[] args);

        /// <summary>
        /// 写一个Fatal日志信息.
        /// </summary>
        /// <param name="message">日志信息</param>
        void Fatal(object message);

        /// <summary>
        /// 写一个Fatal日志信息.
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        void Fatal(object message, Exception exception);

        /// <summary>
        /// 写一个参数化信息的日志信息
        /// </summary>
        /// <param name="format">日志信息</param>
        /// <param name="args">参数</param>
        void FatalFormat(string format, params object[] args);

        /// <summary>
        /// Debug是否启用
        /// </summary>
        bool IsDebugEnabled
        {
            get;
        }

        /// <summary>
        /// Info是否启用
        /// </summary>
        bool IsInfoEnabled
        {
            get;
        }

        /// <summary>
        /// Error是否启用
        /// </summary>
        bool IsErrorEnabled
        {
            get;
        }

        /// <summary>
        /// Warn是否启用
        /// </summary>
        bool IsWarnEnabled
        {
            get;
        }

        /// <summary>
        /// Fatal是否启用
        /// </summary>
        bool IsFatalEnabled
        {
            get;
        }
    }
}
