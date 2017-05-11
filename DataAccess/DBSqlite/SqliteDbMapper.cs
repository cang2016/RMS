


namespace RMS.DataAccess
{
    /// <summary>
    /// SQLite包装操作类<直接以对象为参数进行操作>
    /// </summary>
    /// <typeparam name="T">实体类对象</typeparam>
    public class SqliteDbMapper<T> : DbMapper<SqliteConn, SqliteFactory<SqliteConn>, T>, IMapperBase where T : class
    {
       
    }
}
