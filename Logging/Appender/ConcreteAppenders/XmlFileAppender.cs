namespace RMS.Logging
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
     using RMS.Logging;

    /// <summary>
    /// 以一个XML格式写到附加器中
    /// </summary>
    public class XmlFileAppender : FileLoggingProviderBase
    {
        #region 静态只读字段

        private static readonly byte[] NewLine = new UTF8Encoding(false, true).GetBytes(Environment.NewLine);

        #endregion 静态只读字段

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public XmlFileAppender()
            : this("xmlLog.xml")
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path"></param>
        public XmlFileAppender(string path)
            : base(path)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="threshold"></param>
        /// <param name="path"></param>
        public XmlFileAppender(Level threshold, string path)
        {
        }

        #endregion 构造函数

        #region 公共方法

        /// <summary>
        /// 序列化LogEntry为Xml格式字符串.
        /// </summary>
        /// <param name="entry">日志信息事件.</param>
        /// <returns>字符串形式的LogEntry日志信息.</returns>
        /// <exception cref="ArgumentNullException">抛出ArgumentNullException异常当entry<paramref name="entry"/>为空(Nothing
        /// in VB)引用.</exception>
        public override string SerializeLogEntry(LogEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("entry");
            }

            int initialCapacity = EstimateCapacity(entry);

            using (var stream = new MemoryStream(initialCapacity))
            {
                this.SerializeLogEntryToXml(entry, stream);

                // By writing a new line we ensure pretty formatting.
                AppendWithNewLine(stream);

                return ConvertStreamToString(stream);
            }
        }

        /// <summary>
        /// 写日志事件信息到XmlWriter.
        /// </summary>
        /// <param name="writer">XmlWriter</param>
        /// <param name="entry">日志信息事件.</param>
        protected virtual void WriteEntryInnerElements(XmlWriter writer, LogEntry entry)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            if (entry == null)
            {
                throw new ArgumentNullException("entry");
            }

            WriteElement(writer, "EventTime", this.CurrentTime);
            WriteElement(writer, "Severity", entry.Level.ToString());
            WriteElement(writer, "Message", entry.Message);
            //WriteElement(writer, "Source", entry.Source ?? entry.Message);

            if (entry.ThrownException != null)
            {
                WriteExceptionRecursive(writer, "Exception", entry.ThrownException);
            }
        }

        #endregion  公共方法

        #region 私有方法

        /// <summary>
        /// 序列化LogEntry为Xml格式
        /// </summary>
        /// <param name="entry">日志事件信息</param>
        /// <param name="stream">源</param>
        private void SerializeLogEntryToXml(LogEntry entry, Stream stream)
        {
            using (XmlWriter writer = CreateXmlWriter(stream))
            {
                writer.WriteStartElement("LogEntry");

                this.WriteEntryInnerElements(writer, entry);

                writer.WriteEndElement();
            }
        }

        private static int EstimateCapacity(LogEntry entry)
        {
            return entry.ThrownException != null ? 4096 : 512;
        }

        private static string ConvertStreamToString(Stream stream)
        {
            stream.Position = 0;

            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static XmlWriter CreateXmlWriter(Stream source)
        {
            var settings = new XmlWriterSettings()
            {
                ConformanceLevel = ConformanceLevel.Fragment,
                Indent = true,
                IndentChars = "\t"
            };

            return XmlWriter.Create(source, settings);
        }

        private static void WriteExceptionRecursive(XmlWriter writer, string elementName, Exception exception)
        {
            writer.WriteStartElement(elementName);

            WriteElement(writer, "Message", exception.Message);
            WriteElement(writer, "ExceptionType", exception.GetType().FullName);
            WriteElement(writer, "StackTrace", exception.StackTrace);

            WriteInnerExceptionsRecursive(writer, exception);

            writer.WriteEndElement();
        }

        private static void WriteInnerExceptionsRecursive(XmlWriter writer, Exception parentException)
        {
            var innerExceptions = LoggingHelper.GetInnerExceptions(parentException);

            if (innerExceptions.Length > 0)
            {
                writer.WriteStartElement("InnerExceptions");

                foreach (var innerException in innerExceptions)
                {
                    WriteExceptionRecursive(writer, "InnerException", innerException);
                }

                writer.WriteEndElement();
            }
        }

        private static void WriteElement(XmlWriter writer, string elementName, object value)
        {
            writer.WriteStartElement(elementName);
            writer.WriteValue(value ?? string.Empty);
            writer.WriteEndElement();
        }

        private static void AppendWithNewLine(Stream source)
        {
            source.Write(NewLine, 0, NewLine.Length);
        }

        #endregion 私有方法

        #region 属性
        /// <summary>
        /// 当前时间
        /// </summary>
        internal virtual DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// 附加器名称.
        /// </summary>
        public new string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 关闭附加器.
        /// </summary>
        public override void Close()
        {
            base.Close();
        }

        /// <summary>
        /// 实现IAppender接口DoAppender方法.
        /// </summary>
        /// <param name="logEntry"></param>
        public override void DoAppender(LogEntry logEntry)
        {
            base.LogInternal(logEntry);
        }

        #endregion 属性
    }
}