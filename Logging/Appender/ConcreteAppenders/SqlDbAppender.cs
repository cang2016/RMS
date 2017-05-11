namespace RMS.Logging
{
    using System;
    using System.ComponentModel;

    public class SqlDbAppender : IAppender
    {
        private string m_name;

        public SqlDbAppender()
        {

        }

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }

        public void DoAppender(LogEntry logEntry)
        {
            DbLoggingHelper.WriteLogToDb(logEntry);
        }

        void IAppender.Close()
        {
            throw new NotImplementedException();
        }
    }
}