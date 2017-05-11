using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAccess.DBMySql
{
    public class MySqlDbMapper<T> : DbMapper<MySqlConn, MySqlFactory<MySqlConn>, T>, IMapperBase where T : class
    {
    }
}
