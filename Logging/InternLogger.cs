namespace RMS.Logging
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// 日志的日志(内部日志器).
    /// </summary>
    internal static class InternalLogger
    {
        #region 静态只读字段
        /// <summary>
        /// 日志文件.
        /// </summary>
        private static readonly string LogFile = Path.GetFullPath(Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, ".log"));

        /// <summary>
        /// 日志备份文件.
        /// </summary>
        private static readonly string LogFileBackup = Path.ChangeExtension(LogFile, ".log.bak");

        /// <summary>
        /// 是否同步.
        /// </summary>
        private static readonly object SyncRoot = new object();

        #endregion 静态只读字段

        #region 方法

        /// <summary>
        ///  写日志方法.
        /// </summary>
        /// <param name="objs">诊断信息或要写入日志的对象信息.</param>
        public static void Log(params object[] objs)
        {
#if DEBUG
            if (objs != null)
            {
                lock (SyncRoot)
                {
                    if (objs != null)
                    {
                        try
                        {
                            string message = RenderLog(objs);
                            Debug.WriteLine(message);
                            Console.WriteLine(message);
                            AppendToFile(message);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.ToString());
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
            }
#endif
        }

        /// <summary>
        /// 生成一个可读堆栈跟踪信息.
        /// </summary>
        /// <param name="skipFrames">要路过的Stack Frame个数.</param>
        /// <returns>一个可读堆栈跟踪信息.</returns>
        public static string GetStackFrameInfo(int skipFrames)
        {
            StackFrame stackFrame = new StackFrame(skipFrames < 1 ? 1 : skipFrames + 1, true);

            MethodBase method = stackFrame.GetMethod();

            if (method != null)
            {
                StringBuilder result = new StringBuilder();

                result.Append(method.Name);

                if (method is MethodInfo && ((MethodInfo)method).IsGenericMethod)
                {
                    Type[] genericArguments = ((MethodInfo)method).GetGenericArguments();

                    result.Append("<");

                    int i = 0;

                    bool flag = true;

                    while (i < genericArguments.Length)
                    {
                        if (!flag)
                        {
                            result.Append(",");
                        }
                        else
                        {
                            flag = false;
                        }

                        result.Append(genericArguments[i].Name);

                        i++;
                    }

                    result.Append(">");
                }

                result.Append(" in ");
                result.Append(Path.GetFileName(stackFrame.GetFileName()) ?? "<unknown>");
                result.Append(":");
                result.Append(stackFrame.GetFileLineNumber());

                return result.ToString();
            }
            else
            {
                return "<null>";
            }
        }

        /// <summary>
        ///呈现一个字符串表示的参数信息.
        /// </summary>
        /// <param name="objs">Diagnostic messages or objects to log.</param>
        /// <returns>The rendered layout string.</returns>
        private static string RenderLog(object[] objs)
        {
            StringBuilder result = new StringBuilder();

            result.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
            result.Append("【INTERNAL】");
            result.Append(Environment.UserName);
            result.Append("|");
            result.Append(Thread.CurrentThread.ManagedThreadId.ToString("000"));
            result.Append("|");

            if (objs != null && objs.Length > 0)
            {
                foreach (var item in objs)
                {
                    result.Append(" [");
                    result.Append(item == null ? string.Empty : item.ToString());
                    result.Append("]");
                }
            }

            result.Append(" |");
            result.Append(GetStackFrameInfo(2));
            result.Append(Environment.NewLine);

            return result.ToString();
        }

        /// <summary>
        /// 以附加的形式写日志到指定文件.
        /// </summary>
        /// <param name="message">Log message to append.</param>
        private static void AppendToFile(string message)
        {
            try
            {
            }
            finally
            {
                FileStream fileStream = null;

                try
                {
                    fileStream = File.Open(LogFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                    if (fileStream.Length > 10485760)
                    {
                        try
                        {
                            File.Copy(LogFile, LogFileBackup, true);
                        }
                        catch
                        {
                        }

                        fileStream.SetLength(0);
                    }

                    fileStream.Seek(0, SeekOrigin.End);
                    byte[] bytes = Encoding.UTF8.GetBytes(message);
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Flush();
                }
                catch
                {
                }
                finally
                {
                    if (fileStream != null)
                    {
                        fileStream.Dispose();
                        fileStream = null;
                    }
                }
            }
        }

        #endregion 方法
    }
}
