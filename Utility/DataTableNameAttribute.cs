using System;

namespace RMS.Utility
{
    public class DataTableNameAttribute : Attribute
    {
        private string m_tableName;

        public DataTableNameAttribute(string tableName)
        {
            this.m_tableName = tableName;
        }

        public string TableName
        {
            get
            {
                return m_tableName;
            }
            set
            {
                m_tableName = value;
            }
        }

        public bool ContainsIdentification
        {
            get;
            set;
        }

    }
}
