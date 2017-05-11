
namespace RMS.DataAccess
{
    /// <summary>
    /// 映射实体相关操作类
    /// </summary>
    /// <typeparam name="T">具体类类型</typeparam>
    public class OracleDbMapper<T> : DbMapper<OracleConn, OracleFactory<OracleConn>, T>, IMapperBase where T : class
    {

    }
}
