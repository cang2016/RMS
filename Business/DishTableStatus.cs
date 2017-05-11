using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Business
{
    [Flags]
    public enum DishTableStatus
    {
        None = 0x00000000,
        Empty = 0x00000001,    // 空  台
        Opened = 0x00000010,    // 已开台
        HasServed = 0x00000100,    // 已上菜
        Checkout = 0x00001000,    // 结帐中
        MultiUnit = 0x00010000,    // 多  单 
        Reservation = 0x00100000,    // 预定中
        All = DishTableStatus.Opened | DishTableStatus.HasServed | DishTableStatus.MultiUnit | DishTableStatus.Checkout | DishTableStatus.Reservation
    }
}
