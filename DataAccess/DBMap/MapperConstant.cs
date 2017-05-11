using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.DataAccess
{
    /// <summary>
    /// 定义Mapper常量表.
    /// </summary>
    public class MapperConstants
    {
        public static readonly string UPDATE_WITH_NULL_VALUE_STATEMENT = "UPDATE WITH NULL VALUE";
        public const string UPDATE_WITH_NULL_VALUE_STATEMENTC = "UPDATE WITH NULL VALUE";
        /// <summary>
        /// Update.
        /// </summary>
        public const string UPDATESTATEMENTC = "UPDATE";

        /// <summary>
        /// Delete.
        /// </summary>
        public const string DELETESTATEMENTC = "DELETE";

        /// <summary>
        /// Insert.
        /// </summary>
        public const string INSERTSTATEMENTC = "INSERT";

        public static readonly Dictionary<string, object> NullValue = new Dictionary<string, object>() 
        { 
            { "String", "null"/*String.Empty*/ }, 
            { "DateTime", DateTime.MinValue},
            //{ "decimal", Decimal.MinValue},
            { "Decimal", Decimal.MinValue},
            { "Int32", Int32.MinValue},
            { "int", int.MinValue},
            { "Int64", Int64.MinValue},
            { "long", long.MinValue},
            { "Double", Double.MinValue},
            { "double", double.MinValue},
            { "byte[]", null},
            { "Byte[]", null},
            { "Nullable",null},              // 可空类型
            {"TimeSpan", null}
        };

        public static List<Type> DoNotFilterTimeEntities = new List<Type>();
    }
}
