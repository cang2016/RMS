using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.DataAccess
{
    public class SqlServerFactory<C> : EntitiesQuery<C, SqlServerFactory<C>>, IDbProviderName where C : IDbConnectionString, new()
    {
        public string DbProviderName
        {
            get
            {
                //return BaseConfigFactory.ConfigurationDic["SqlServer"].ProviderName;

                return new SqlServerConfigInfo().ProviderName;
            }
        }
    }
}
