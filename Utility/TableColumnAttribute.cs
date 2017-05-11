namespace RMS.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    /// <summary>
    /// 自定义属性，用于指示如何从DataTable或者DbDataReader中读取类的属性值
    /// </summary>
    public class TableColumnAttribute : Attribute
    {
        /// <summary>
        /// 类属性对应的列名
        /// </summary>
        public string ColumnName
        {
            get;
            set;
        }


        public bool IsPrimaryKey
        {
            get;
            set;
        }

        public bool IsIdentification
        {
            get;
            set;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="columnName">类属性对应的列名</param>
        public TableColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
