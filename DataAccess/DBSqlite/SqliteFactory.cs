



namespace RMS.DataAccess
{
    public class SqliteFactory<C> : EntitiesQuery<C, SqliteFactory<C>>, IDbProviderName where C : IDbConnectionString, new()
    {
        public string DbProviderName
        {
            get
            {
                //return BaseConfigFactory.ConfigurationDic["Sqlite"].ProviderName;
                return new SqliteConfigInfo().ProviderName;
            }
        }
    }
}
