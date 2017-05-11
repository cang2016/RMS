using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Logging
{
    public class SqlStateAppender : TextFileAppender
    {
        public override string SerializeLogEntry(LogEntry logEntry)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("--DateTime:{0} " + Environment.NewLine, logEntry.TimeStamp);
            sb.AppendFormat("--{0} " + Environment.NewLine, logEntry.LoggerName);
            //sb.AppendFormat("[{0}]- ", logEntry.Level);
            if(!string.IsNullOrEmpty(Convert.ToString(logEntry.Message)))
            {
                sb.AppendFormat("--Query statement as below:" + Environment.NewLine + "{0}", logEntry.Message);
            }
            if(logEntry.ThrownException != null)
            {
                sb.AppendFormat(logEntry.ThrownException.StackTrace.ToString());
            }

            return sb.ToString();
        }
    }
}
