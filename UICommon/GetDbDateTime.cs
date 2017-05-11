using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using RMS.DataAccess;

namespace RMS.UICommon
{
    /// <summary>
    /// Query 的摘要说明。
    /// </summary>
    public class GetDbDateTime
    {
        private DateTime systemDateTime;
        public GetDbDateTime()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public static DateTime GetSystemDateTime()
        {
            SqlServerExecute sqlServerExe = new SqlServerExecute();
            //string sSQL = "select to_char(sysdate,'yyyy-MM-dd HH24:mi:ss') from dual";    // Oracle数据库,备用
            string sql = "select Convert(varchar(20),getdate(),120)";                       // SqlServer 形式如: 2013-05-22 20:26:34


            object obj = sqlServerExe.ExecuteScalar(sql);
            return Convert.ToDateTime(obj);
        }

        /// <summary>
        /// 同步数据库时间
        /// </summary>
        public void SynchoronizeServerTime()
        {
            try
            {
                systemDateTime = GetSystemDateTime();

                if(!string.IsNullOrEmpty(systemDateTime.ToString()))
                {
                    DateTime ser = DateTime.Parse(systemDateTime.ToString());

                    //调用代码   
                    SYSTEMTIME t = new SYSTEMTIME();
                    t.Year = (short)ser.Year;
                    t.Month = (short)ser.Month;
                    t.Day = (short)ser.Day;
                    t.Hour = (short)(ser.Hour - 8);   //这个函数使用的是0时区的时间,对于我们用+8时区的,时间要自己算一下.如要设12点，则为12-8   
                    t.Minute = (short)(ser.Minute);
                    t.Second = (short)ser.Second;
                    bool v = SetSystemTime(ref   t);
                }
            }
            catch
            {
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short Year;
            public short Month;
            public short DayOfWeek;
            public short Day;
            public short Hour;
            public short Minute;
            public short Second;
            public short Miliseconds;
        }

        //api函数声明   
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public extern static bool SetSystemTime(ref   SYSTEMTIME time);
    }
}
