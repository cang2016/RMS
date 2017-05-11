using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Entities;

namespace UICommon
{
    public class DataCache
    {
        public static IList<SalesPoint> SalesPointList
        {
            get;
            set;
        }

        public static IList<RestaurantType> RestaurantTypeList
        {
            get;
            set;
        }

        public static IList<Workshift> WorkShiftList
        {
            get;
            set;
        }
    }
}
