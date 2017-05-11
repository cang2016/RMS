using System.Text;

namespace RMS.Logging
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    /// <summary>
    /// 写日志到文件基类
    /// </summary>
    public abstract class FileLoggingProviderBase : IAppender
    {
        #region 实例字段

        private FileStream fileStream;
        private string m_path;

        #endregion 实例字段

        #region 私有静态只读字段

        private static readonly Dictionary<string, object> pathLockers =
    new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        private static readonly object lockObj = new object();
        private string m_name;

        #endregion 私有静态只读字段

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="path"></param>
        protected FileLoggingProviderBase(string path)
        {
            this.m_path = GetFullCanonicalPath(path);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FileLoggingProviderBase()
        {

        }

        #endregion 构造函数

        #region 公共属性

        /// <summary>
        /// 文件路径
        /// </summary>
        public string Path
        {
            get
            {
                return this.m_path;
            }
            set
            {
                m_path = value;
            }
        }

        /// <summary>
        /// 附加器名称.
        /// </summary>
        public string Name
        {
            get
            {
                return this.m_name;
            }
            set
            {
                this.m_name = value;
            }
        }

        #endregion 公共属性

        #region 抽象方法

        public abstract string SerializeLogEntry(LogEntry entry);

        #endregion 抽象方法

        #region 保护方法

        protected object LogInternal(LogEntry entry)
        {
            var locker = this.GetLockObjectForCurrentPath();

            string contents = this.SerializeLogEntry(entry);

            lock(locker)
            {
                this.Write(contents);
            }

            return null;
        }

        #endregion 保护方法

        #region 私有方法

        /// <summary>
        /// 初始化路径
        /// </summary>
        private void Initialized()
        {
            string directoryName = System.IO.Path.GetDirectoryName(Path);
            if(!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            
            if(!File.Exists(Path))
            {
                fileStream = File.Create(Path);
            }
            else
            {
                fileStream = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.Write);
            }
        }

        /// <summary>
        /// 同步写日志到文本文件中.
        /// </summary>
        /// <param name="contents">日志内容.</param>
        private void WriteAsync(string contents)
        {
            lock(lockObj)
            {

                try
                {
                    Initialized();
                    using(LockPropertyFile())
                    {
                        //Byte[] bytes = new System.Text.UTF8Encoding(true).GetBytes(contents);
                        //Byte[] rn = new System.Text.UTF8Encoding(true).GetBytes(Environment.NewLine);


                        StreamWriter sw = new StreamWriter(fileStream, Encoding.Default);   // Add Encoding.Default parameter, else 中文显示乱码.
                        sw.Write(Environment.NewLine);
                        sw.WriteLine(contents);
                        sw.Flush();
                        sw.Close();

                        //fileStream.Write(rn, 0, rn.Length);
                        //fileStream.Write(bytes, 0, bytes.Length);
                        //fileStream.Flush();
                        //fileStream.Close();
                    }
                }
                catch
                {
                    if(fileStream != null)
                        fileStream.Close();
                }
                finally
                {
                    if(fileStream != null)
                    {
                        fileStream.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 写日志到文件中.
        /// </summary>
        /// <param name="contents">日志信息内容.</param>
        protected void Write(string contents)
        {
            WriteAsync(contents);
        }

        private static IDisposable LockPropertyFile()
        {
            Mutex mutex = new Mutex(false);
            mutex.WaitOne();
            return new SafeAccessFile(() =>
            {
                mutex.ReleaseMutex();
                mutex.Close();
            });
        }

        private object GetLockObjectForCurrentPath()
        {
            object pathLocker;

            lock(pathLockers)
            {
                if(!pathLockers.TryGetValue(this.Path, out pathLocker))
                {
                    pathLocker = new object();
                    pathLockers.Add(this.Path, pathLocker);
                }
            }

            return pathLocker;
        }

        private static string GetFullCanonicalPath(string path)
        {
            string fullPath;

            if(System.IO.Path.IsPathRooted(path))
            {
                fullPath = path;
            }
            else
            {
                fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            }

            return GetCanonicalPath(fullPath);
        }

        private static string GetCanonicalPath(string fullPath)
        {
            return System.IO.Path.GetFullPath(fullPath);
        }

        #endregion 私有方法

        #region 实现IAppender接口.

        /// <summary>
        ///  实现接口IAppender中的Close方法.
        /// </summary>
        public virtual void Close()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 实现接口IAppender中的DoAppender方法.
        /// </summary>
        /// <param name="logEntry"></param>
        virtual public void DoAppender(LogEntry logEntry)
        {

        }

        #endregion 实现IAppender接口.
    }
}