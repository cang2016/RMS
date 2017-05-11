using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RMS.Logging;
using RMS.DataAccess;
using RMS.Utility;
using RMS.Entities;

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
            //string ss = string.Empty;
            //writeLine(ss);

            MySqlConn mysql = new MySqlConn();
            DataTable s  =      mysql.FillDataTable(CommandType.Text, "select * from api_admin");

            foreach (DataRow r in s.Rows)
            {
                foreach (DataColumn c in s.Columns)
                {
                     Console.WriteLine(r[c.ColumnName]);
                }
               
            }

            Console.Read();


            TestCls cls = new TestCls
            {
                Name = "cc",
                Age = 3,
                Memo = "memo"
            };

            //Func<TestCls, object> ss = c => (object)c.Name;
            ////MethodInfo methodInfo = StaticReflection.GetPropertyGetMethodInfo<TestCls, string>(c => c.Name);
            //ConstructorInfo info = StaticReflection.GetConstructorInfo<TestCls>(() => new TestCls());
            //object obj = info.Invoke(cls, null);
            //string sss = PropertyEvaluator.ExtractPropertyName<TestCls>( p => p.Memo);
            ////object o = methodInfo.Invoke(cls, null);

            //PropertyAccessor pa = new PropertyAccessor(typeof(TestCls));
            //pa.SetProperty(cls, "Name", "cccccccccccccccc");
            //object o = pa.GetProperty(cls, "Name");



            //log.Info("rrrrrrrrrrrrr");

            //ChineseCharacterConvertToAlphabetic py = new ChineseCharacterConvertToAlphabetic();
            //string outletter;
            //string ssrr = py.ConvertToAllAlphabetic("银行", out outletter);
            ////LoggerManager.ILog.Info(ssrr);
            //string ssrrrrsss = py.ConvertToAllAlphabetic("自行车", out outletter);
            //LoggerManager.GetILog("cc").Info(ssrrrrsss);

            //ChineseCharacterConvertToFirstAlphabetic pys = new ChineseCharacterConvertToFirstAlphabetic();
            //string sss = pys.GetFirstLetter("银行");
            //string scss = pys.GetFirstLetter("自行车");

            //string scsssssss = ChineseCharacterConvertToFirstAlphabetic.GetFirstAlphabetic("自行车");
            //LoggerManager.ILog.Info(scsssssss);



            AppLog app = new AppLog
            {
                Id = 200
                //ApplicationFriendlyName = "appliaction",
                //HostName = "cc",
                //AssemblyLocationInfo = "f:\\ss",
                //ExceptionMsg = "dfd",
                //LogLevel = "Info0"
            };

            AppLog app2 = new AppLog
            {
                //Id = 4444,
                //ApplicationFriendlyName = "appldfdfdfdiaction",
                HostName = "yyyyyyyyyyyyyyyyy"
                //AssemblyLocationInfo = "f:\\sdfdfdfs",
                //ExceptionMsg = "dfdfdfdfdfd",
                //LogLevel = "Infdfdfdfo0"
            };

            //app.SqlServerTransaction(OperationType.Insert, true);
            //app.SqlServerTransaction(OperationType.Update, false, app2);

            //SqlServerDbMapper<AppLog> appLogDbMapper = new SqlServerDbMapper<AppLog>();
            //appLogDbMapper.GetAllObjectInstanceList();

            //appLogDbMapper.Update(app, app2);

            Workshift ws = new Workshift()
            {
                Id = 5
            };


            Workshift ws2 = new Workshift()
             {
                 Name = "ccc4444"
             };


            //ws.SqlServerTransaction(OperationType.Update,true, ws2);
            //ws.SqlServerTransaction(OperationType.Delete, false);
        }


        static void writeLine(string aa)
        {
            aa.NotNullOrEmptyOrSpaceWhite("ss");
            Console.WriteLine(aa.ToString());
        }
    }
}
