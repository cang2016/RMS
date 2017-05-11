using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.Logging
{
    /// <summary>
    /// 要添加的附加器接口.
    /// </summary>
    public interface IAppenderAttachable
    {
        /// <summary>
        /// 添加一个附加器.
        /// </summary>
        /// <param name="appender">要添加的附加器.</param>
        /// <remarks>
        /// <para>
        /// 添加一个指定的附加器,允许选择添加一个不存在的附加器
        /// </para>
        /// </remarks>
        void AddAppender(IAppender appender);

        /// <summary>
        /// 获取所在添加的附加器.
        /// </summary>
        /// <value>
        /// 一个附加器集合.
        /// </value>
        /// <remarks>
        /// <para>
        /// 一个附加器集合.
        /// 如果不存在,则返回一个空集合.
        /// </para>
        /// </remarks>
        AppenderCollection Appenders { get; }

        /// <summary>
        /// 返回指定名称的附加器.
        /// </summary>
        /// <param name="name">指定要获取的名附加器名称.</param>
        /// <returns>
        IAppender GetAppender(string name);

        /// <summary>
        /// 删除所有的附加器.
        /// </summary>
        /// <remarks>
        /// <para>
        /// 删除并关闭所有的附加器
        /// </para>
        /// </remarks>
        void RemoveAllAppenders();

        /// <summary>
        /// 删除从附加器列表中指定的附加器.
        /// </summary>
        /// <param name="appender">要删除的附加器.</param>
        /// <returns>从列表中删除的附加器.</returns>
        /// <remarks>
        /// <para>
        IAppender RemoveAppender(IAppender appender);

        /// <summary>
        /// 删除从附加器列表中指定名称的附加器.
        /// </summary>
        /// <param name="name">指定要删除的附加器的名称.</param>
        /// <returns>从列表中删除的附加器</returns>
        /// <remarks>
        /// <para>
        IAppender RemoveAppender(string name);
    }
}
