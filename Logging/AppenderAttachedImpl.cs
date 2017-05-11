using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RMS.Logging;

namespace RMS.Logging
{
    /// <summary>
    /// 已附加的附加器相关操作类.
    /// </summary>
    public class AppenderAttachedImpl : IAppenderAttachable
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public AppenderAttachedImpl()
        {
        }

        #endregion 构造函数

        #region 实现方法
        /// <summary>
        /// 添加到所有已附加的附加器.
        /// </summary>
        /// <param name="logEntry">日志事件信息实体.</param>
        /// <returns>附加器数量.</returns>
        public int AppendLoopOnAppenders(LogEntry logEntry)
        {
            if (logEntry == null)
            {
                throw new ArgumentNullException("loggingEvent");
            }

            if (m_appenderList == null)
            {
                return 0;
            }

            if (m_appenderArray == null)
            {
                m_appenderArray = m_appenderList.ToArray();
            }

            foreach (IAppender appender in m_appenderArray)
            {
                try
                {
                    appender.DoAppender(logEntry);
                }
                catch (Exception ex)
                {
                    InternalLogger.Log("AppenderAttachedImpl: Failed to append to appender [" + appender.Name + "]", ex);
                }
            }

            return m_appenderList.Count;
        }

        /// <summary>
        /// 添加到所有已附加的附加器.
        /// </summary>
        /// <param name="loggingEvents">日志事件信息数组.</param>
        /// <returns>调用的附加器数量.</returns>
        /// <remarks>
        /// <para>
        /// 所有添加的附加器调用<see cref="IAppender.DoAppend" /> 方法
        /// </para>
        /// </remarks>
        public int AppendLoopOnAppenders(LogEntry[] loggingEvents)
        {
            if (loggingEvents == null)
            {
                throw new ArgumentNullException("loggingEvents");
            }
            if (loggingEvents.Length == 0)
            {
                throw new ArgumentException("loggingEvents array must not be empty", "loggingEvents");
            }
            if (loggingEvents.Length == 1)
            {
                return AppendLoopOnAppenders(loggingEvents[0]);
            }
            if (m_appenderList == null)
            {
                return 0;
            }
            if (m_appenderArray == null)
            {
                m_appenderArray = m_appenderList.ToArray();
            }

            foreach (IAppender appender in m_appenderArray)
            {
                try
                {
                    CallAppend(appender, loggingEvents);
                }
                catch (Exception ex)
                {
                    InternalLogger.Log("AppenderAttachedImpl: Failed to append to appender [" + appender.Name + "]", ex);
                }
            }

            return m_appenderList.Count;
        }

        /// <summary>
        /// 调用接口<see cref="IAppender"/>DoAppende方法使用 <see cref="LoggingEvent"/> 事件信息参数
        /// </summary>
        /// <param name="appender">附加器</param>
        /// <param name="loggingEvents">事件信息</param>
        private static void CallAppend(IAppender appender, LogEntry[] logEntrys)
        {
            foreach (LogEntry loggingEvent in logEntrys)
            {
                appender.DoAppender(loggingEvent);
            }
        }

        #endregion 实现方法

        #region 实现接口IAppenderAttachable

        /// <summary>
        /// 附加一个附加器.
        /// </summary>
        /// <param name="newAppender">要附加的附加器.</param>
        /// <remarks>
        /// <para>
        /// 如果存在则不再添加.
        /// </para>
        /// </remarks>
        public void AddAppender(IAppender newAppender)
        {
            if (newAppender == null)
            {
                throw new ArgumentNullException("没有附加器");
            }

            m_appenderArray = null;
            if (m_appenderList == null)
            {
                m_appenderList = new AppenderCollection(1);
            }

            if (!m_appenderList.Contains(newAppender))
            {
                m_appenderList.Add(newAppender);
            }
        }

        /// <summary>
        /// 获取所有的附加器.
        /// </summary>
        /// <returns>
        /// 所有附加器集合, 或者null <c>null</c> 如果没有添加的附加器.
        /// </returns>
        /// <remarks>
        /// <para>
        /// 当前已添加的附加器集合.
        /// </para>
        /// </remarks>
        public AppenderCollection Appenders
        {
            get
            {
                if (m_appenderList == null)
                {
                    return AppenderCollection.EmptyCollection;
                }
                else
                {
                    return AppenderCollection.ReadOnly(m_appenderList);
                }
            }
        }

        /// <summary>
        /// 通过指定名称获取一个附加器.
        /// </summary>
        /// <param name="name">要获取的附加器名称.</param>
        /// <returns>
        /// 指定名称的附加器, 或者null<c>null</c>如果没有找到指定名称的附加器.
        /// </returns>
        /// <remarks>
        /// <para>
        /// 从添加的附加器列表中查找一个附加器.
        /// </para>
        /// </remarks>
        public IAppender GetAppender(string name)
        {
            if (m_appenderList != null && !string.IsNullOrWhiteSpace(name))
            {
                if (m_appenderList.Count > 0)
                {
                    foreach (IAppender appender in m_appenderList)
                    {
                        if (name == appender.Name)
                        {
                            return appender;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 删除所有附加的附加器.
        /// </summary>
        /// <remarks>
        /// <para>
        /// 删除并关闭所在附加的附加器
        /// </para>
        /// </remarks>
        public void RemoveAllAppenders()
        {
            if (m_appenderList != null && m_appenderList.Count > 0)
            {
                foreach (IAppender appender in m_appenderList)
                {
                    try
                    {
                        appender.Close();
                    }
                    catch (Exception ex)
                    {
                        InternalLogger.Log("AppenderAttachedImpl: Failed to Close appender [" + appender.Name + "]", ex);
                    }
                }

                m_appenderList = null;
                m_appenderArray = null;
            }
        }

        /// <summary>
        /// 从所有已添加的附加器列表中删除指定的附加器.
        /// </summary>
        /// <param name="appender">要删除的附加器.</param>
        /// <returns>从列表中删除的附加器.</returns>
        /// <remarks>
        /// <para>
        /// 附加器并没有关闭.
        /// 如果你想关闭它，你必须调用
        /// <see cref="IAppender.Close"/>方法在这个附加器上.
        /// </para>
        /// </remarks>
        public IAppender RemoveAppender(IAppender appender)
        {
            if (appender != null && m_appenderList != null)
            {
                m_appenderList.Remove(appender);

                if (m_appenderList.Count == 0)
                {
                    m_appenderList = null;
                }

                m_appenderArray = null;
            }

            return appender;
        }

        /// <summary>
        /// 删除从附加器列表中指定名称的附加器
        /// </summary>
        /// <param name="name">要删除的附加器名称.</param>
        /// <returns>已删除的附加器</returns>
        /// <remarks>
        /// <para>
        /// 附加器并没有关闭.
        /// 如果你想关闭它，你必须调用
        /// <see cref="IAppender.Close"/>方法在这个附加器上.
        /// </para>
        /// </remarks>
        public IAppender RemoveAppender(string name)
        {
            return RemoveAppender(GetAppender(name));
        }

        #endregion  实现接口IAppenderAttachable

        #region 私有实例字段

        /// <summary>
        /// 附加器列表.
        /// </summary>
        private AppenderCollection m_appenderList;

        /// <summary>
        /// 附加器数组, 用来存储m_appenderList列表.
        /// </summary>
        private IAppender[] m_appenderArray;

        #endregion 私有实例字段
    }
}
