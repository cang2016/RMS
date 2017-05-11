namespace RMS.Logging
{
    /// <summary>
    /// 日志级别枚举
    /// </summary>
    public enum Level
    {
        /// <summary>
        /// 最高级别，关闭所有
        /// </summary>
        Off,

        /// <summary>
        /// 第二高级别,仅仅严重
        /// </summary>
        Fatal,

        /// <summary>
        /// 第三高级别,错误之上
        /// </summary>
        Error,

        /// <summary>
        /// 第四高级别,警告之上
        /// </summary>
        Warn,

        /// <summary>
        /// 第五高级别,信息之上
        /// </summary>
        Info,
        /// <summary>
        /// 第六高级别,高度之上
        /// </summary>
        Debug,

        /// <summary>
        /// 最低级别,启用所有
        /// </summary>
        All
    }
}
