using System;
using RMS.Utility;

namespace RMS.DataAccess
{
    /// <summary>
    /// 异步操作封装类.
    /// </summary>
    public static class AsyncOperation
    {
        /// <summary>
        /// 封装异步操作方法.
        /// </summary>
        /// <typeparam name="TAsyncResult">异步操作的状态接口.</typeparam>
        /// <param name="callback">引用在相应异步操作完成时调用的方法.</param>
        /// <param name="beginOperation">引用带返回值的相应异步操作完成时调用的方法.</param>
        /// <param name="wrappingResultCreator">引用带返回值的相应异步操作完成时调用的方法.</param>
        /// <returns>异步操作的状态接口</returns>
        public static IAsyncResult BeginAsyncOperation<TAsyncResult>(AsyncCallback callback, Func<AsyncCallback, IAsyncResult> beginOperation,
                                                                                        Func<IAsyncResult, TAsyncResult> wrappingResultCreator)
                                                                                        where TAsyncResult : class, IAsyncResult
        {
            callback.NotNull("callback");
            object lockObject = new object();
            TAsyncResult result = null;
            AsyncCallback wrapperCallback = null;

            if(callback != null)
            {
                wrapperCallback = ar =>
                {
                    if(!ar.CompletedSynchronously)
                    {
                        lock(lockObject)
                        {
                            callback(result);
                        }
                    }
                };
            }

            lock(lockObject)
            {
                IAsyncResult innerAsyncResult = beginOperation(wrapperCallback);
                result = wrappingResultCreator(innerAsyncResult);
            }
            if(result.CompletedSynchronously && callback != null)
            {
                callback(result);
            }

            return result;
        }
    }
}
