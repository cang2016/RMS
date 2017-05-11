using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAccess.DBMySql
{
    public class MySqlFactory<C> : EntitiesQuery<C, MySqlFactory<C>>, IDbProviderName where C : IDbConnectionString, new()
    {
        public string DbProviderName
        {
            get
            {
                return new MySqlConfigInfo().ProviderName;
            }
        }
    }
}
