using System.Collections.Generic;

namespace RMS.DataAccess
{
    /// <summary>
    /// DbMapper接口，定义数据库相关操作.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDbMapper<T>
    {
        /// <summary>
        /// 获取单条对象记录.
        /// </summary>
        /// <param name="selection">有筛选条件的对象数据.</param>
        /// <example>T singleObj =new Mapper<T>.GetSingleObj(new T {Id = value }).</example>
        /// <returns>T所代表的实际对象</returns>
        T GetObjectInstance(T entity);

        /// <summary>
        /// 获取单条记录列表.
        /// </summary>
        /// <param name="selection">有筛选条件的对象数据.</param>
        /// <example>T singleObj =new Mapper<T>.GetSingleObj(new T {Id = value }).</example>
        /// <returns>T所代表的实际对象.</returns>
        IList<T> GetObjectInstanceList(T entity);

        /// <summary>
        /// 获取所有记录.
        /// </summary>
        /// <returns>List列表.</returns>
        IList<T> GetAllObjectInstanceList();

        /// <summary>
        /// 插入记录.
        /// </summary>
        /// <param name="record">要插入的对象数据记录.</param>
        /// <example>new Mapper<T>.Insert(new T {Id = value, Name1 = value1, Name2 = value2.... }).</example>
        void Insert(T record);


        /// <summary>
        /// 插入记录.
        /// </summary>
        /// <param name="record">要插入的对象数据记录.</param>
        /// <param name="containsIdentityColumn">是否有自动增长列.</param>
        /// <example>>new Mapper<T>.Insert(new T {Id = value, Name1 = value1, Name2 = value2.... },true).</example>
        void Insert(T entity, bool containsIdentityColumn);

        /// <summary>
        /// 删除记录.
        /// </summary>
        /// <param name="selection">有筛选条件的对象数据.</param>
        /// <example>T singleObj =new Mapper<T>.Delete(new T {Id = value }).</example>
        void Delete(T entity);

        /// <summary>
        /// 更新记录.
        /// </summary>
        /// <param name="selection">更新前的记录,有筛选条件的对象数据.</param>
        /// <param name="newRecord">更新后的记录,有要更新后的对象数据.</param>
        /// <example>T singleObj =new Mapper<T>.Update(new T {Id = value }, new T {Name = "CC"}).</example>
        void Update(T entity, T newEntity);

    }
}
