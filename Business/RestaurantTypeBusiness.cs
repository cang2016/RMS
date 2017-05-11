using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Entities;
using RMS.DataAccess;

namespace RMS.Business
{
    public class RestaurantTypeBusiness : BusinessBase<RestaurantType>
    {
        public RestaurantTypeBusiness()
        {

        }

        /// <summary>
        /// 判断指定的餐厅类型是否存在.
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns>True为存在，否则false为不存在.</returns>
        public bool Exists(string typeName)
        {
            IList<RestaurantType> restaurantTypeList = GetInstanceList();

            return restaurantTypeList.Where(s => s.Name == typeName).Count() > 0;
        }
    }
}
