using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 using RMS.Logging;
using System.Globalization;

namespace RMS.Logging
{
    /// <summary>
    /// 日志器实现类.
    /// </summary>
    public class LogImpl : LoggerWrapperImpl, ILog
    {

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        public LogImpl(ILogger logger)
            : base(logger)
        {
        }
        #endregion 构造函数

        #region 静态私有字段
        private readonly static Type ThisDeclaringType = typeof(LogImpl);
        #endregion 静态私有字段

        #region 私有字段

        private Level m_levelDebug;
        private Level m_levelInfo;
        private Level m_levelWarn;
        private Level m_levelError;
        private Level m_levelFatal;

#endregion 私有字段

        #region 虚公共属性

        /// <summary>
        /// Debug
        /// </summary>
        public Level LevelDebug
        {
            get
            {
                return Level.Debug;
            }
            set { m_levelDebug = value; }
        }
       
        /// <summary>
        /// Info
        /// </summary>
        public Level LevelInfo
        {
            get
            {
                return Level.Info;
            }
            set { m_levelInfo = value; }
        }
      
        /// <summary>
        /// Warn
        /// </summary>
        public Level LevelWarn
        {
            get
            {
                return Level.Warn;
            }
            set { m_levelWarn = value; }
        }
       
        /// <summary>
        /// Error
        /// </summary>
        public Level LevelError
        {
            get
            {
                return Level.Error;
            }
            set { m_levelError = value; }
        }
        
        /// <summary>
        /// Fatal
        /// </summary>
        public Level LevelFatal
        {
            get
            {
                return Level.Fatal;
            }
            set { m_levelFatal = value; }
        }

        /// <summary>
        /// Debug是否启用
        /// </summary>
        virtual public bool IsDebugEnabled
        {
            get { return Logger.IsEnabledFor(m_levelDebug); }
        }

        /// <summary>
        /// Info是否启用
        /// </summary>
        virtual public bool IsInfoEnabled
        {
            get { return Logger.IsEnabledFor(m_levelInfo); }
        }

        /// <summary>
        /// Error是否启用
        /// </summary>
        virtual public bool IsErrorEnabled
        {
            get { return Logger.IsEnabledFor(m_levelError); }
        }

        /// <summary>
        /// Warn是否启用
        /// </summary>
        virtual public bool IsWarnEnabled
        {
            get { return Logger.IsEnabledFor(m_levelWarn); }
        }

        /// <summary>
        /// Fatal是否启用
        /// </summary>
        virtual public bool IsFatalEnabled
        {
            get { return Logger.IsEnabledFor(m_levelFatal); }
        }

        #endregion 虚公共属性

        #region 虚公共方法

        /// <summary>
        /// 写一个deubg日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        virtual public void Debug(object message)
        {
            Logger.Log(ThisDeclaringType, LevelDebug, message, null);
        }

        /// <summary>
        /// 写一个deubg日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        virtual public void Debug(object message, Exception exception)
        {
            Logger.Log(ThisDeclaringType, LevelDebug, message, exception);
        }

        /// <summary>
        /// 写一个参数化信息的日志信息
        /// </summary>
        /// <param name="format">日志信息</param>
        /// <param name="args">参数</param>
        virtual public void DebugFormat(string format, params object[] args)
        {
            if (IsDebugEnabled)
            {
                Logger.Log(ThisDeclaringType, LevelDebug, new StringFormat(CultureInfo.InvariantCulture, format, args), null);
            }
        }

        /// <summary>
        /// 写一个Info日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        virtual public void Info(object message)
        {
            Logger.Log(ThisDeclaringType, LevelInfo, message, null);
        }

        /// <summary>
        /// 写一个Info日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        virtual public void Info(object message, Exception exception)
        {
            Logger.Log(ThisDeclaringType, LevelInfo, message, exception);
        }

        /// <summary>
        /// 写一个参数化信息的日志信息
        /// </summary>
        /// <param name="format">日志信息</param>
        /// <param name="args">参数</param>
        virtual public void InfoFormat(string format, params object[] args)
        {
            if (IsInfoEnabled)
            {
                Logger.Log(ThisDeclaringType, LevelInfo, new StringFormat(CultureInfo.InvariantCulture, format, args), null);
            }
        }

        /// <summary>
        /// 写一个Warn日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        virtual public void Warn(object message)
        {
            Logger.Log(ThisDeclaringType, LevelWarn, message, null);
        }

        /// <summary>
        /// 写一个Warn日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        virtual public void Warn(object message, Exception exception)
        {
            Logger.Log(ThisDeclaringType, LevelWarn, message, exception);
        }

        /// <summary>
        /// 写一个参数化信息的日志信息
        /// </summary>
        /// <param name="format">日志信息</param>
        /// <param name="args">参数</param>
        virtual public void WarnFormat(string format, params object[] args)
        {
            if (IsWarnEnabled)
            {
                Logger.Log(ThisDeclaringType, LevelWarn, new StringFormat(CultureInfo.InvariantCulture, format, args), null);
            }
        }

        /// <summary>
        /// 写一个Error日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        virtual public void Error(object message)
        {
            Logger.Log(ThisDeclaringType, LevelError, message, null);
        }

        /// <summary>
        /// 写一个Error日志信息
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        virtual public void Error(object message, Exception exception)
        {
            Logger.Log(ThisDeclaringType, LevelError, message, exception);
        }

        /// <summary>
        /// 写一个参数化信息的日志信息
        /// </summary>
        /// <param name="format">日志信息</param>
        /// <param name="args">参数</param>
        virtual public void ErrorFormat(string format, params object[] args)
        {
            if (IsErrorEnabled)
            {
                Logger.Log(ThisDeclaringType, LevelError, new StringFormat(CultureInfo.InvariantCulture, format, args), null);
            }
        }

        /// <summary>
        /// 写一个Fatal日志信息.
        /// </summary>
        /// <param name="message">日志信息</param>
        virtual public void Fatal(object message)
        {
            Logger.Log(ThisDeclaringType, LevelFatal, message, null);
        }

        /// <summary>
        /// 写一个Fatal日志信息.
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        virtual public void Fatal(object message, Exception exception)
        {
            Logger.Log(ThisDeclaringType, LevelFatal, message, exception);
        }

        /// <summary>
        /// 写一个参数化信息的日志信息
        /// </summary>
        /// <param name="format">日志信息</param>
        /// <param name="args">参数</param>
        virtual public void FatalFormat(string format, params object[] args)
        {
            if (IsFatalEnabled)
            {
                Logger.Log(ThisDeclaringType, LevelFatal, new StringFormat(CultureInfo.InvariantCulture, format, args), null);
            }
        }

        #endregion 虚公共方法

    }
}
