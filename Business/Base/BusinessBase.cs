using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.DataAccess;

namespace RMS.Business
{
    public class BusinessBase<T> : IBusinessBase<T> where T : class
    {
        SqlServerDbMapper<T> mapper = new SqlServerDbMapper<T>();

        /// <summary>
        /// 获取对象实例列表.
        /// </summary>
        /// <returns>具体实例列表.</returns>
        public IList<T> GetInstanceList()
        {
            return (IList<T>)mapper.GetAllObjectInstanceList();
        }

        /// <summary>
        /// 获取单个对象实例.
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>T的具体实例.</returns>
        public T GetInstanceObj(T instance)
        {
            return mapper.GetObjectInstance(instance) as T;
        }

        /// <summary>
        /// 插入对象实例到数据库表.
        /// </summary>
        /// <param name="instance"></param>
        public void InsertInstanceObj(T instance)
        {
            mapper.Insert(instance);
        }

        /// <summary>
        /// 更新对象实例到数据库表.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="newInstance"></param>
        public void UpdateInstanceObj(T instance, T newInstance)
        {
            mapper.Update(instance, newInstance);
        }

        /// <summary>
        /// 删除对象实例到数据表.
        /// </summary>
        /// <param name="instance"></param>
        public void DeleteInstanceObj(T instance)
        {
            mapper.Delete(instance);
        }
    }
}
