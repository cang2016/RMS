

namespace RMS.DataAccess
{
    public class OracleFactory<C> : EntitiesQuery<C, OracleFactory<C>>, IDbProviderName where C : IDbConnectionString, new()
    {
        public string DbProviderName
        {
            get
            {
                return BaseConfigFactory.ConfigurationDic["Oracle"].ProviderName;
            }
        }
    }
}
