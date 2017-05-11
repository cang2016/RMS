
namespace RMS.DataAccess
{
    public class OleDbMapper<T> : DbMapper<OleDbConn, OleDbFactory<OleDbConn>, T>, IMapperBase where T : class
    {
    }
}
