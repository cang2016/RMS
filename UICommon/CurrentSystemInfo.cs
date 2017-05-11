using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Utility;
using RMS.Entities;


namespace RMS.UICommon
{
    public class CurrentSystemInfo
    {
        private static MultiDictionary<string, IList<EntitiesBase>> currentSysInfo = new MultiDictionary<string, IList<EntitiesBase>>(false);

        public static  MultiDictionary<string, IList<EntitiesBase>> CurrentSysInfo
        {
            get
            {
                return currentSysInfo;
            }
            set
            {
                currentSysInfo = value;
            }
        }

        public static SalesPoint SalesPoint
        {
            get;
            set;
        }

        public static RestaurantType RestaurantType
        {
            get;
            set;
        }

        public static Workshift WorkShift
        {
            get;
            set;
        }


    }
}
