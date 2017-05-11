using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 using RMS.Logging;

namespace RMS.Logging
{
    /// <summary>
    /// 日志器管理类,具体写日志入口.
    /// </summary>
    public class LoggerManager : Logger
    {
        private static ILog log = null;

        public static ILog ILog
        {
            get
            {
                Logger logger = new LoggerManager();
                log = new LogImpl(logger);

                return log;
            }
        }

        /// <summary>
        /// 获取ILog接口.
        /// </summary>
        /// <param name="loggerName"></param>
        /// <returns></returns>
        public static ILog GetILog(string loggerName = "default")
        {
            Logger logger = new LoggerManager(loggerName);
            log = new LogImpl(logger);

            return log;
        }

        internal LoggerManager()
            : base("default")
        {
        }

        internal LoggerManager(string name)
            : base(name)
        {
        }
    }
}
