namespace RMS.DataAccess
{
    /// <summary>
    /// 提供数据库连接串接口.
    /// </summary>
    public interface IDbConnectionString
    {
        /// <summary>
        /// 数据库连接串接口.
        /// </summary>
        string ConnectionString
        {
            get;
        }
    }
}
