using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Entities;
using RMS.DataAccess;


namespace RMS.Business
{
    public class SalesPointBusiness : BusinessBase<SalesPoint>
    {
        /// <summary>
        /// 根据网卡地址判断是否存在.
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns>True为存在，否则false为不存在.</returns>
        public bool ExistsMacAddress(string macAddress)
        {
            IList<SalesPoint> salesPointList = GetInstanceList();
            return salesPointList.Where(s => s.Address == macAddress).Count() > 0;
        }

        /// <summary>
        /// 指定的销售点是否存在.
        /// </summary>
        /// <param name="salesPointName">销售点名称.</param>
        /// <returns>True为存在，否则false为不存在.</returns>
        public bool Exists(string salesPointName)
        {
            IList<SalesPoint> salesPointList = GetInstanceList();
            return salesPointList.Where(s => s.Name == salesPointName).Count() > 0;
        }
    }
}
