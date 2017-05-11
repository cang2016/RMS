
namespace RMS.Logging
{
    /// <summary>
    /// 日志器接口封装接口
    /// </summary>
    public interface ILoggerWraper
    {
        /// <summary>
        /// 获取日志器属性
        /// </summary>
        ILogger Logger { get; }
    }
}
