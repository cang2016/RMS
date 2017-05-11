namespace RMS.Logging
{
    using System;
    using System.Configuration;
    using System.Reflection;
    using System.Threading;
    using RMS.Logging;

    /// <summary>
    /// 日志器实现,关联附加器.
    /// </summary>
    public class Logger : IAppenderAttachable, ILogger
    {
        #region 保护的实例构造函数

        /// <summary>
        /// 保护实例构造函数
        /// </summary>
        /// <param name="name"></param>
        protected Logger(string name)
        {
            m_name = string.Intern(name);
            LoggerConfig logger = LoggerConfig.Logger;

            if (logger.Appenders != null && logger.Appenders.Count > 0)
            {
                foreach (AppenderConfig appender in logger.Appenders)
                {
                    IAppender appenderInterface = (IAppender)Activator.CreateInstance(Assembly.GetCallingAssembly().FullName, appender.Type).Unwrap();

                    if(m_name.Contains("[db]"))   // 数据库相关操作不写入到数据库表中，防止循环执行.
                    {
                        if((appenderInterface as SqlDbAppender) != null)
                        {
                            continue;
                        }
                    }

                    appenderInterface.Name = appender.Name;
                    if ((appenderInterface as WindowsEventAppender) != null)
                    {
                        appenderInterface.Name = appenderInterface.Name;        // 从配置文件中获取名称
                    }
                    if ((appenderInterface as FileLoggingProviderBase) != null)
                    {
                        FileLoggingProviderBase fileLoggingAppender = appenderInterface as FileLoggingProviderBase;
                        fileLoggingAppender.Path = appender.Path;
                        appenderInterface = fileLoggingAppender;
                    }
                    if (appenderInterface != null)
                    {
                        this.AddAppender(appenderInterface);
                    }
                }
            }
        }

        #endregion 保护的实例构造函数

        #region 公共实例属性

        /// <summary>
        /// 从配置文件中获取日志级别
        /// </summary>
        public Level Level
        {
            get
            {
                LevelConfig levelConfig = (LevelConfig)ConfigurationManager.GetSection("level");
                m_level = (Level)Enum.Parse(typeof(Level), levelConfig.Level.Value);

                return m_level;
            }
            set
            {
                m_level = value;
            }
        }

        #endregion 公共实例属性

        #region 实现接口IAppenderAttachable

        /// <summary>
        /// 添加附加器.
        /// </summary>
        /// <param name="newAppender">新添加的附加器.</param>
        public void AddAppender(IAppender newAppender)
        {
            if (newAppender == null)
            {
                throw new ArgumentNullException("新添加的附加器");
            }

            m_appenderLock.AcquireWriterLock(100);
            try
            {
                if (m_appenderAttachedImpl == null)
                {
                    m_appenderAttachedImpl = new AppenderAttachedImpl();
                }

                m_appenderAttachedImpl.AddAppender(newAppender);
            }
            finally
            {
                m_appenderLock.ReleaseWriterLock();
            }
        }

        /// <summary>
        /// 附加器集合.
        /// </summary>
        public AppenderCollection Appenders
        {
            get
            {
                m_appenderLock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    if (m_appenderAttachedImpl == null)
                    {
                        return AppenderCollection.EmptyCollection;
                    }
                    else
                    {
                        return m_appenderAttachedImpl.Appenders;
                    }
                }
                finally
                {
                    m_appenderLock.ReleaseReaderLock();
                }
            }
        }

        /// <summary>
        /// 获取指定名称的附加器
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IAppender GetAppender(string name)
        {
            m_appenderLock.AcquireReaderLock(100);
            try
            {
                if (m_appenderAttachedImpl == null || string.IsNullOrEmpty(null))
                {
                    return null;
                }

                return m_appenderAttachedImpl.GetAppender(name);
            }
            finally
            {
                m_appenderLock.ReleaseReaderLock();
            }
        }

        /// <summary>
        /// 删除所在的附加器.
        /// </summary>
        public void RemoveAllAppenders()
        {
            m_appenderLock.AcquireWriterLock(100);
            try
            {
                if (m_appenderAttachedImpl != null)
                {
                    m_appenderAttachedImpl.RemoveAllAppenders();
                    m_appenderAttachedImpl = null;
                }
            }
            finally
            {
                m_appenderLock.ReleaseWriterLock();
            }
        }

        /// <summary>
        /// 删除指定的附加器.
        /// </summary>
        /// <param name="appender">要删除的附加器.</param>
        /// <returns>删除的附加器.</returns>
        public IAppender RemoveAppender(IAppender appender)
        {
            m_appenderLock.AcquireWriterLock(100);
            try
            {
                if (appender != null && m_appenderAttachedImpl != null)
                {
                    return m_appenderAttachedImpl.RemoveAppender(appender);
                }
            }
            finally
            {
                m_appenderLock.ReleaseWriterLock();
            }

            return null;
        }

        /// <summary>
        /// 删除指定名称的附加器.
        /// </summary>
        /// <param name="name">要删除的附加器名称.</param>
        /// <returns>删除的附加器.</returns>
        public IAppender RemoveAppender(string name)
        {
            m_appenderLock.AcquireWriterLock(100);
            try
            {
                if (name != null && m_appenderAttachedImpl != null)
                {
                    return m_appenderAttachedImpl.RemoveAppender(name);
                }
            }
            finally
            {
                m_appenderLock.ReleaseWriterLock();
            }

            return null;
        }

        #endregion 实现接口IAppenderAttachable

        #region 实现接口ILogger

        /// <summary>
        /// 获取日志器名称.
        /// </summary>
        public string Name
        {
            get { return m_name; }
        }

        /// <summary>
        /// 写日志信息到已添加的附加器上.
        /// </summary>
        /// <param name="callerStackBoundaryDeclaringType">调用的定义日志器的类型</param>
        /// <param name="level">日志级别</param>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        public void Log(Type callerStackBoundaryDeclaringType, Level level, object message, Exception exception)
        {
            try
            {
                if (IsEnabledFor(level))
                {
                    ForcedLog((callerStackBoundaryDeclaringType != null) ? callerStackBoundaryDeclaringType : ThisDeclaringType, level, message, exception);
                }
            }
            catch (Exception ex)
            {
                InternalLogger.Log("Log: Exception while logging", ex);
            }
        }

        /// <summary>
        /// 写日志信息到已添加的附加器上
        /// </summary>
        /// <param name="logEntry"></param>
        public void Log(LogEntry logEntry)
        {
            try
            {
                if (logEntry != null)
                {
                    if (IsEnabledFor(logEntry.Level))
                    {
                        ForcedLog(logEntry);
                    }
                }
            }
            catch (Exception ex)
            {
                InternalLogger.Log("Log: Exception while logging", ex);
            }
        }

        /// <summary>
        /// 判断指定的日志级别是否可用
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <returns>可用返回True,否则False</returns>
        public bool IsEnabledFor(Level level)
        {
            try
            {
                if (level != Level.Off)
                {
                    if (IsDisabled(level))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                InternalLogger.Log("Log: Exception while logging", ex);
            }

            return true;
        }

        /// <summary>
        /// 判断指定的日志级别是否不可用.
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <returns>不可用返回True,否则False</returns>
        private bool IsDisabled(Level level)
        {
            if (Configured)
            {
                return Threshold < level;
            }
            else
            {
                // 如何没有在配置文件配置，则默认不可用
                return true;
            }
        }


        #endregion 实现接口ILogger

        #region 实例方法
        /// <summary>
        /// 调用附加器写日志.
        /// </summary>
        /// <param name="logEntry">日志信息实体类,附加日志相关信息.</param>
        protected void CallAppenders(LogEntry logEntry)
        {
            if (logEntry == null)
            {
                throw new ArgumentNullException("loggingEvent");
            }

            int writes = 0;

            if (m_appenderAttachedImpl != null)
            {
                m_appenderLock.AcquireReaderLock(Timeout.Infinite);
                try
                {
                    if (m_appenderAttachedImpl != null)
                    {
                        writes += m_appenderAttachedImpl.AppendLoopOnAppenders(logEntry);
                    }
                }
                finally
                {
                    m_appenderLock.ReleaseReaderLock();
                }
            }

            if (writes == 0)
            {
                InternalLogger.Log("Logger: Please initialize the logger system properly.");
                try
                {
                    InternalLogger.Log("Logger:    Current AppDomain context information: ");
                    InternalLogger.Log("Logger:    BaseDirectory   : " + SystemInfo.ApplicationBaseDirectory);
#if !NETCF
                    InternalLogger.Log("Logger:    FriendlyName    : " + AppDomain.CurrentDomain.FriendlyName);
                    InternalLogger.Log("Logger:    DynamicDirectory: " + AppDomain.CurrentDomain.DynamicDirectory);
#endif
                }
                catch (System.Security.SecurityException ex)
                {
                    InternalLogger.Log(ex.StackTrace);
                }
            }
        }

        /// <summary>
        /// 关闭内嵌的附加器.
        /// </summary>
        public void CloseNestedAppenders()
        {
            m_appenderLock.AcquireWriterLock(100);
            try
            {
                if (m_appenderAttachedImpl != null)
                {
                    AppenderCollection appenders = m_appenderAttachedImpl.Appenders;
                    foreach (IAppender appender in appenders)
                    {
                        if (appender is IAppenderAttachable)
                        {
                            appender.Close();
                        }
                    }
                }
            }
            finally
            {
                m_appenderLock.ReleaseWriterLock();
            }
        }

        /// <summary>
        /// 写日志到已添加的附加器上.
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        public void Log(Level level, object message, Exception exception)
        {
            if (IsEnabledFor(level))
            {
                ForcedLog(ThisDeclaringType, level, message, exception);
            }
        }

        /// <summary>
        /// 写日志到已添加的附加器上.
        /// </summary>
        /// <param name="callerStackBoundaryDeclaringType"></param>
        /// <param name="level">日志级别</param>
        /// <param name="message">日志信息</param>
        /// <param name="exception">异常</param>
        protected void ForcedLog(Type callerStackBoundaryDeclaringType, Level level, object message, Exception exception)
        {
            CallAppenders(new LogEntry(callerStackBoundaryDeclaringType, message, level, this.Name, exception));
        }

        /// <summary>
        /// 写日志到已添加的附加器上.
        /// </summary>
        /// <param name="logEvent">日志信息实体.</param>
        protected void ForcedLog(LogEntry logEvent)
        {
            CallAppenders(logEvent);
        }

        #endregion 实例方法

        #region 私有静态字段

        /// <summary>
        /// Logger类完全限定名称.
        /// </summary>
        private readonly static Type ThisDeclaringType = typeof(Logger);

        #endregion 私有静态字段

        #region 私有实例字段

        /// <summary>
        /// 日志器名称.
        /// </summary>
        private readonly string m_name;

        /// <summary>
        /// 日志级别. 
        /// </summary>
        private Level m_level;

        /// <summary>
        /// 实现接口<see cref="IAppenderAttachable"/>.
        /// </summary>
        private AppenderAttachedImpl m_appenderAttachedImpl;

        /// <summary>
        /// 保护AppenderAttachedImpl的类型m_appenderAttachedImpl的锁.
        /// </summary>
        private readonly ReaderWriterLock m_appenderLock = new ReaderWriterLock();

        #endregion 私有实例字段

        #region 只读属性

        public bool Configured
        {
            get
            {
                return Level != Level.Off;
            }
        }

        public Level Threshold
        {
            get
            {
                return Level;
            }
        }

        #endregion 只读属性
    }
}
