
namespace RMS.DataAccess
{
    /// <summary>
    /// 映射实体相关操作类<支持泛型>
    /// </summary>
    /// <typeparam name="T">具体类类型</typeparam>
    public class SqlServerDbMapper<T> : DbMapper<SqlServerConn, SqlServerFactory<SqlServerConn>, T>, IMapperBase where T : class
    {

    }
}
