namespace RMS.Logging
{
    using System;
    /// <summary>
    /// 日志器接口
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 日志器名称
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// 日志器Log接口方法
        /// </summary>
        /// <param name="callerStatckBoundaryDeclaringType"></param>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Log(Type callerStatckBoundaryDeclaringType, Level level, object message, Exception exception);

        /// <summary>
        /// 日志器Log接口方法
        /// </summary>
        /// <param name="logEntry"></param>
        void Log(LogEntry logEntry);

        /// <summary>
        /// 判断指定的Level是否启用
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabledFor(Level level);
    }
}
