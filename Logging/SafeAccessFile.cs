namespace RMS.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// 安全访问文件类,在不需要时会清理.
    /// </summary>
    public sealed class SafeAccessFile : IDisposable
    {
        Action callback;

        #region 构造函数

        public SafeAccessFile(Action callback)
        {
            if (callback == null)
            {
                throw new ArgumentNullException("callback");
            }

            this.callback = callback;
        }

        #endregion 构造函数

        #region 公共方法
        /// <summary>
        /// Dispose方法
        /// </summary>
        public void Dispose()
        {
            Action action = Interlocked.Exchange(ref callback, null);
            if (action != null)
            {
                action();
#if DEBUG
                GC.SuppressFinalize(this);
#endif
            }
        }


        #endregion 公共方法

        #region 析造函数
#if DEBUG
        ~SafeAccessFile()
        {
            InternalLogger.Log("CallbackOnDispose was finalized without being disposed.");
        }
#endif


        #endregion 析造函数
    }
}
