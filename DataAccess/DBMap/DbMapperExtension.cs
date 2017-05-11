
namespace RMS.DataAccess
{
    public static class DbMapperExtension
    {
        /// <summary>
        /// 实现对象的自动插入操作.
        /// </summary>
        /// <typeparam name="T">对象类型.</typeparam>
        /// <typeparam name="Mapper">数据库Mapper对象类型.</typeparam>
        /// <param name="entity">对象实例.</param>
        /// <param name="mapperObject">数据库Mapper对象,如SqlServer,Sqlite.</param>
        /// <param name="containsIdentityColumn">是否包含自动插入操作列.</param>
        public static void Insert<T, Mapper>(this T entity, Mapper mapperObject, bool containsIdentityColumn = false)
            where T : class, new()
            where Mapper : IMapperBase
        {
            IDbMapper<T> mapper = mapperObject as IDbMapper<T>;

            mapper.Insert(entity, containsIdentityColumn);
        }
    }
}
