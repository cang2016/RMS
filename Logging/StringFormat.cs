namespace RMS.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 格式化
    /// </summary>
    public sealed class StringFormat
    {
        #region 只读字段

        private readonly IFormatProvider m_provider;
        private readonly string m_format;
        private readonly object[] m_args;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化StringFormat对象
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public StringFormat(IFormatProvider provider, string format, params object[] args)
        {
            m_provider = provider;
            m_format = format;
            m_args = args;
        }

        #endregion 构造函数

        #region 重写方法
        /// <summary>
        /// 格式化StringFormat与参数
        /// </summary>
        /// <returns>the formatted string</returns>
        public override string ToString()
        {
            return FormatString(m_provider, m_format, m_args);
        }

        #endregion

        #region 格式化

        /// <summary>
        /// 格式化StringFormat与参数
        /// </summary>
        /// <param name="provider">格式控制器</param>
        /// <param name="format">要格式的字符串</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        private static string FormatString(IFormatProvider provider, string format, params object[] args)
        {
            try
            {
                if (format == null)
                {
                    return null;
                }

                // 如果args参数为空，则直接返回format，不用格式化
                if (args == null)
                {
                    return format;
                }

                // 格式化
                return String.Format(provider, format, args);
            }
            catch (Exception ex)
            {
                return StringFormatError(ex, format, args);
            }
        }

        /// <summary>
        /// 处理一个错误当格式化时
        /// </summary>
        private static string StringFormatError(Exception formatException, string format, object[] args)
        {
            try
            {
                StringBuilder buf = new StringBuilder("<Error>");

                if (formatException != null)
                {
                    buf.Append("Exception during StringFormat: ").Append(formatException.Message);
                }
                else
                {
                    buf.Append("Exception during StringFormat");
                }
                buf.Append(" <format>").Append(format).Append("</format>");
                buf.Append("<args>");
                RenderArray(args, buf);
                buf.Append("</args>");
                buf.Append("</logger.Error>");

                return buf.ToString();
            }
            catch (Exception ex)
            {
                InternalLogger.Log(ex.StackTrace);
                return "<logger.Error>Exception during StringFormat. See Internal Log.</logger.Error>";
            }
        }

        /// <summary>
        /// 提取数组内容到stringBuilder.
        /// </summary>
        private static void RenderArray(Array array, StringBuilder buffer)
        {
            if (array == null)
            {
                buffer.Append(SystemInfo.NullText);
            }
            else
            {
                if (array.Rank != 1)
                {
                    buffer.Append(array.ToString());
                }
                else
                {
                    buffer.Append("{");
                    int len = array.Length;

                    if (len > 0)
                    {
                        RenderObject(array.GetValue(0), buffer);
                        for (int i = 1; i < len; i++)
                        {
                            buffer.Append(", ");
                            RenderObject(array.GetValue(i), buffer);
                        }
                    }
                    buffer.Append("}");
                }
            }
        }

        /// <summary>
        /// 将对象表示成string形式.
        /// </summary>
        private static void RenderObject(Object obj, StringBuilder buffer)
        {
            if (obj == null)
            {
                buffer.Append(SystemInfo.NullText);
            }
            else
            {
                try
                {
                    buffer.Append(obj);
                }
                catch (Exception ex)
                {
                    buffer.Append("<Exception: ").Append(ex.Message).Append(">");
                }
            }
        }

        #endregion 格式化
    }
}
