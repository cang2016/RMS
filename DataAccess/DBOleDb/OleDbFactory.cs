

namespace RMS.DataAccess
{
    public class OleDbFactory<C> : EntitiesQuery<C, OleDbFactory<C>>, IDbProviderName where C : IDbConnectionString, new()
    {
        public string DbProviderName
        {
            get
            {
                return BaseConfigFactory.ConfigurationDic["OleDb"].ProviderName;
            }
        }
    }
}
