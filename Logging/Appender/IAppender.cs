using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMS.Logging
{
    /// <summary>
    /// 附加器接口
    /// </summary>
    public interface IAppender
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 关闭附加器
        /// </summary>
        void Close();

        /// <summary>
        /// 写日志信息实体到已添加的附加器.
        /// </summary>
        /// <param name="logEntry"></param>
        void DoAppender(LogEntry logEntry);
    }
}
