using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using RMS.Utility;

namespace RMS.DataAccess
{
    /// <summary>
    /// 实体类读取操作.
    /// </summary>
    public class EntityReader
    {
        private const BindingFlags BindingFlag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        // 将类型与该类型所有的可写且未被忽略属性之间建立映射.
        private static Dictionary<Type, Dictionary<string, PropertyInfo>> propertyMappings = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        /// <summary>
        /// 将DataTable中的所有数据转换成List<T>集合.
        /// </summary>
        /// <typeparam name="T">DataTable中每条数据可以转换的数据类型.</typeparam>
        /// <param name="dataTable">包含有可以转换成数据类型T的数据集合.</param>
        /// <returns></returns>
        public static List<T> GetEntities<T>(DataTable dataTable) where T : new()
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable");
            }
            // 如果T的类型满足以下条件：字符串、ValueType或者是Nullable<ValueType>.
            if (typeof(T) == typeof(string) || typeof(T) == typeof(byte[]) || typeof(T).IsValueType)
            {
                return GetSimpleEntities<T>(dataTable);
            }
            else
            {
                return GetComplexEntities<T>(dataTable);
            }
        }
        /// <summary>
        /// 将DbDataReader中的所有数据转换成List<T>.
        /// </summary>
        /// <typeparam name="T">DbDataReader中每条数据可以转换的数据类型.</typeparam>
        /// <param name="dataTable">包含有可以转换成数据类型T的DbDataReader实例.</param>
        /// <returns></returns>
        public static List<T> GetEntities<T>(DbDataReader reader) where T : new()
        {
            List<T> list = new List<T>();
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            // 如果T的类型满足以下条件：字符串、ValueType或者是Nullable<ValueType>.
            if (typeof(T) == typeof(string) || typeof(T).IsValueType)
            {
                return GetSimpleEntities<T>(reader);
            }
            else
            {
                return GetComplexEntities<T>(reader);
            }
        }

        /// <summary>
        /// 从DataTable中将每一行的第一列转换成T类型的数据.
        /// </summary>
        /// <typeparam name="T">要转换的目标数据类型</typeparam>
        /// <param name="dataTable">包含有可以转换成数据类型T的数据集合.</param>
        /// <returns></returns>
        private static List<T> GetSimpleEntities<T>(DataTable dataTable) where T : new()
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add((T)GetValueFromObject(row[0], typeof(T)));
            }

            return list;
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <param name="targetType">要转换的目标数据类型.</param>
        /// <returns></returns>
        private static object GetValueFromObject(object value, Type targetType)
        {
            if (targetType == typeof(string))// 如果要将value转换成string类型.
            {
                return GetString(value);
            }
            else if (targetType == typeof(byte[]))// 如果要将value转换成byte[]类型.
            {
                return GetBinary(value);
            }
            else if (targetType.IsGenericType)// 如果目标类型是泛型.
            {
                return GetGenericValueFromObject(value, targetType);
            }
            else// 如果是基本数据类型(包括数值类型、枚举和Guid).
            {
                return GetNonGenericValueFromObject(value, targetType);
            }
        }

        /// <summary>
        /// 从DataTable中读取复杂数据类型集合
        /// </summary>
        /// <typeparam name="T">要转换的目标数据类型</typeparam>
        /// <param name="dataTable">包含有可以转换成数据类型T的数据集合</param>
        /// <returns></returns>
        private static List<T> GetComplexEntities<T>(DataTable dataTable) where T : new()
        {
            if (!propertyMappings.ContainsKey(typeof(T)))
            {
                GenerateTypePropertyMapping(typeof(T));
            }
            List<T> list = new List<T>();
            Dictionary<string, PropertyInfo> properties = propertyMappings[typeof(T)];
            T t;
            foreach (DataRow row in dataTable.Rows)
            {
                t = new T();
                foreach (KeyValuePair<string, PropertyInfo> item in properties)
                {
                    // 如果对应的属性名出现在数据源的列中则获取值并设置给对应的属性.
                    if (row[item.Key] != null)
                    {
                        item.Value.SetValue(t, GetValueFromObject(row[item.Key], item.Value.PropertyType), null);
                    }
                }
                list.Add(t);
            }
            return list;
        }

        /// <summary>
        /// 从DbDataReader的实例中读取复杂的数据类型.
        /// </summary>
        /// <typeparam name="T">要转换的目标类.</typeparam>
        /// <param name="reader">DbDataReader的实例.</param>
        /// <returns></returns>
        private static List<T> GetComplexEntities<T>(DbDataReader reader) where T : new()
        {
            if (!propertyMappings.ContainsKey(typeof(T)))  // 检查当前是否已经有该类与类的可写属性之间的映射.
            {
                GenerateTypePropertyMapping(typeof(T));
            }
            List<T> list = new List<T>();
            Dictionary<string, PropertyInfo> properties = propertyMappings[typeof(T)];
            T t;
            while (reader.Read())
            {
                t = new T();
                foreach (KeyValuePair<string, PropertyInfo> item in properties)
                {
                    // 如果对应的属性名出现在数据源的列中则获取值并设置给对应的属性.
                    if (reader[reader.GetOrdinal(item.Key)] != null)
                    {
                        item.Value.SetValue(t, GetValueFromObject(reader[item.Key], item.Value.PropertyType), null);
                    }
                }
                list.Add(t);
            }

            return list;
        }

        /// <summary>
        /// 从DbDataReader的实例中读取简单数据类型（String,ValueType).
        /// </summary>
        /// <typeparam name="T">目标数据类型.</typeparam>
        /// <param name="reader">DbDataReader的实例.</param>
        /// <returns></returns>
        private static List<T> GetSimpleEntities<T>(DbDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
            {
                list.Add((T)GetValueFromObject(reader[0], typeof(T)));
            }

            return list;
        }

        /// <summary>
        /// 将Object转换成字符串类型.
        /// </summary>
        /// <param name="value">object类型的实例.</param>
        /// <returns></returns>
        private static object GetString(object value)
        {
            return Convert.ToString(value);
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object,或者为 null.</param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        private static object GetEnum(object value, Type targetType)
        {
            return Enum.Parse(targetType, value.ToString());
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object,或者为 null.</param>
        /// <returns></returns>
        private static object GetBoolean(object value)
        {
            if (value is Boolean)
            {
                return value;
            }
            else
            {
                byte byteValue = (byte)GetByte(value);
                if (byteValue == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetByte(object value)
        {
            if (value is Byte)
            {
                return value;
            }
            else
            {
                Byte obj;
                if (Byte.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }

                return null;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetSByte(object value)
        {
            if (value is SByte)
            {
                return value;
            }
            else
            {
                SByte obj;
                if (SByte.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }

                return null;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetChar(object value)
        {
            if (value is Char)
            {
                return value;
            }
            else
            {
                Char obj;
                if (Char.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }

                return null;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetGuid(object value)
        {
            if (value is Guid)
            {
                return value;
            }
            else
            {
                return new Guid(value.ToString());
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetInt16(object value)
        {
            if (value is Int16)
            {
                return value;
            }
            else
            {
                if (value == DBNull.Value)
                {
                    return 0;
                }
                Int16 obj;
                if (Int16.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }
                return 0;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetUInt16(object value)
        {
            if (value is UInt16)
            {
                return value;
            }
            else
            {
                if (value == DBNull.Value)
                {
                    return 0;
                }
                UInt16 obj;
                if (UInt16.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }
                return 0;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetInt32(object value)
        {
            if (value is Int32)
            {
                return value;
            }
            else
            {
                if (value == DBNull.Value)
                {
                    return 0;
                }
                Int32 obj;
                if (Int32.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }
                return 0;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetUInt32(object value)
        {
            if (value is UInt32)
            {
                return value;
            }
            else
            {
                if (value == DBNull.Value)
                {
                    return 0;
                }
                UInt32 obj;
                if (UInt32.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }
                return 0;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetInt64(object value)
        {
            if (value is Int64)
            {
                return value;
            }
            else
            {
                if (value == DBNull.Value)
                {
                    return 0;
                }
                long obj;
                if (Int64.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }
                return 0;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetUInt64(object value)
        {
            if (value is UInt64)
            {
                return value;
            }
            else
            {
                if (value == DBNull.Value)
                {
                    return 0;
                }
                ulong obj;
                if (UInt64.TryParse(value.ToString(), out obj))
                {
                    return obj;
                }
                return 0;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetSingle(object value)
        {
            if (value is Single)
            {
                return value;
            }
            else
            {
                Single ts;
                if (Single.TryParse(value.ToString(), out ts))
                {
                    return ts;
                }

                return null;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetDouble(object value)
        {
            if (value is Double)
            {
                return value;
            }
            else
            {
                Double ts;
                if (Double.TryParse(value.ToString(), out ts))
                {
                    return ts;
                }

                return null;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetDecimal(object value)
        {
            if (value is Decimal)
            {
                return value;
            }
            else
            {
                Decimal ts;
                if (Decimal.TryParse(value.ToString(), out ts))
                {
                    return ts;
                }

                return null;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetDateTime(object value)
        {
            if (value is DateTime)
            {
                return value;
            }
            else
            {
                DateTime ts;
                if (DateTime.TryParse(value.ToString(), out ts))
                {
                    return ts;
                }

                return null;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static object GetTimeSpan(object value)
        {
            if (value is TimeSpan)
            {
                return value;
            }
            else
            {
                TimeSpan ts;
                if (TimeSpan.TryParse(value.ToString(), out ts))
                {
                    return ts;
                }

                return null;
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定枚举类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <returns></returns>
        private static byte[] GetBinary(object value)
        {
            // 如果该字段为NULL则返回null.
            if (value == DBNull.Value)
            {
                return null;
            }
            else if (value is Byte[])
            {
                return (byte[])(value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将Object类型数据转换成对应的可空数值类型表示.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <param name="targetType">可空数值类型.</param>
        /// <returns></returns>
        private static object GetGenericValueFromObject(object value, Type targetType)
        {
            if (value == DBNull.Value)
            {
                return null;
            }
            else
            {
                //获取可空数值类型对应的基本数值类型，如int?->int,long?->long
                //Type nonGenericType = genericTypeMappings[targetType];
                Type nonGenericType = targetType.GetGenericArguments()[0];
                return GetNonGenericValueFromObject(value, nonGenericType);
            }
        }

        /// <summary>
        /// 将指定的 Object 的值转换为指定类型的值.
        /// </summary>
        /// <param name="value">实现 IConvertible 接口的 Object，或者为 null.</param>
        /// <param name="targetType">目标对象的类型.</param>
        /// <returns></returns>
        private static object GetNonGenericValueFromObject(object value, Type targetType)
        {
            if (targetType.IsEnum)  // 枚举
            {
                return GetEnum(value, targetType);
            }
            else
            {
                switch (targetType.Name)
                {
                    case "Byte": return GetByte(value);
                    case "SByte": return GetSByte(value);
                    case "Char": return GetChar(value);
                    case "Boolean": return GetBoolean(value);
                    case "Guid": return GetGuid(value);
                    case "Int16": return GetInt16(value);
                    case "UInt16": return GetUInt16(value);
                    case "Int32": return GetInt32(value);
                    case "UInt32": return GetUInt32(value);
                    case "Int64": return GetInt64(value);
                    case "UInt64": return GetUInt64(value);
                    case "Single": return GetSingle(value);
                    case "Double": return GetDouble(value);
                    case "Decimal": return GetDecimal(value);
                    case "DateTime": return GetDateTime(value);
                    case "TimeSpan": return GetTimeSpan(value);
                    default: return null;
                }
            }
        }

        /// <summary>
        /// 获取该类型中属性与数据库字段的对应关系映射.
        /// </summary>
        /// <param name="type"></param>
        private static void GenerateTypePropertyMapping(Type type)
        {
            if (type != null)
            {
                PropertyInfo[] properties = type.GetProperties(BindingFlag);
                Dictionary<string, PropertyInfo> propertyColumnMapping = new Dictionary<string, PropertyInfo>(properties.Length);
                string description = string.Empty;
                Attribute[] attibutes = null;
                string columnName = string.Empty;
                foreach (PropertyInfo p in properties)
                {
                    columnName = string.Empty;
                    attibutes = Attribute.GetCustomAttributes(p);
                    foreach (Attribute attribute in attibutes)
                    {
                        // 检查是否设置了ColumnName属性.
                        if (attribute.GetType() == typeof(TableColumnAttribute))
                        {
                            columnName = ((TableColumnAttribute)attribute).ColumnName;
                            break;
                        }
                    }
                    // 如果该属性是可读并且未被忽略的，则有可能在实例化该属性对应的类时用得上.
                    if (p.CanWrite)
                    {
                        // 如果没有设置ColumnName属性，则直接将该属性名作为数据库字段的映射.
                        if (string.IsNullOrEmpty(columnName))
                        {
                            columnName = p.Name;
                        }

                        propertyColumnMapping.Add(columnName, p);
                    }
                }
                propertyMappings.Add(type, propertyColumnMapping);
            }
        }
    }
}
