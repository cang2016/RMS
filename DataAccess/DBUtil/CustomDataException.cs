using System;
using System.Data.Common;
using System.Runtime.Serialization;

namespace RMS.DataAccess
{
    public class CustomDataException : Exception
    {
        private string sqlString = string.Empty;
        private DbParameter[] m_parameters = null;

        public CustomDataException()
            : base()
        {
        }

        public CustomDataException(CustomDataException ex)
            : base(ex.Message, ex.InnerException == null ? ex : ex.InnerException)
        {
            sqlString = ex.sqlString;
            m_parameters = ex.m_parameters;
        }

        public CustomDataException(string message, CustomDataException ex)
            : base(message, ex)
        {
            sqlString = ex.sqlString;
            m_parameters = ex.m_parameters;
        }

        public CustomDataException(string message)
            : base(message)
        {
        }

        public CustomDataException(string message, Exception ex)
            : base(message, ex)
        {
        }

        public CustomDataException(Exception ex)
            : base(ex.Message, ex)
        {
        }

        public CustomDataException(Exception ex, string sql)
            : base(ex.Message, ex)
        {
            if (null != sql)
            {
                sqlString = sql;
            }
        }

        public CustomDataException(SerializationInfo info,  StreamingContext context) 
            : base(info,  context)
        {
            
        }

        public CustomDataException(Exception ex, string sql, DbParameter[] parameters)
            : base(ex.Message, ex)
        {
            if (!string.IsNullOrEmpty(sql))
            {
                sqlString = sql;
            }

            m_parameters = parameters;
        }
    }
}
