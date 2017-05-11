using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using RMS.Business;
using RMS.DataAccess;
using RMS.Entities;
using RMS.UICommon;
using RMS.Utility;
using WinForms;

namespace RMS.WinForms
{
    public static class Program
    {
        public static string[] NickNameArray = { "Martin", "David", "Tom", "John", "Steven", "Jack", "Jay", "Bruce", "Chris", "Denny", "Jason", "Kevin" };


        #region Extern Method

        // private static ExceptionHandler exceptionHandler;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        #endregion #region Extern Method

        //#region Private Field
        ////private static  mainForm = null;
        private static EventWaitHandle programStarted;

        //private static IniFileHelper iniFile;
        //#endregion  Private Field

        //#region Static Variables

        //private static BaseConfigInfo baseConfigInfo = BaseConfigFactory.Instance;      // 初始化数据库配制信息
        //public static CurrentLocalSetting currLocalSetting = CurrentLocalSettingManage.GetCurrentLocalSetting();

        //public static UsersEntity userInfo = null;

        //#endregion

        #region Main Method
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            #region Exception Process
            AppDomain.CurrentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) =>
            {
                HandleException(e.ExceptionObject as Exception);
            };
            // 处理UI线程异常 
            Application.ThreadException += (object sender, ThreadExceptionEventArgs e) =>
            {
                HandleException(e.Exception);
            };
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadExit += new EventHandler(Application_ThreadExit);

            #endregion  Exception Process

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.DoEvents();
            //Application.Run(new Waiting());
            Waiting.Show("正在加载程序,请稍候...", 20);
     
            bool existRunningInstance = ExistRunInstance();
            if(existRunningInstance)
            {
                CCMsgBox.Show("对不起,你已经运行了该程序!", Application.ProductName, CCMsgBox.CButtons.OK, CCMsgBox.CIcon.Error);
                return;
            }

            Waiting.Show("正在测试数据库连接,请稍候...", 40);
            if(!TestDbConnect())
            {
                CCMsgBox.Show("对不起!数据库连接失败，请联系相关管理人员!", Application.ProductName, CCMsgBox.CButtons.OK, CCMsgBox.CIcon.Error);
                return;
            }

            Waiting.Show("正在检测INI配置文件,请稍候...", 50);
            string iniFilePath = Path.Combine(Application.StartupPath, "ODConfig.ini");
            if(File.Exists(iniFilePath))
            {
                IniManager.Open(iniFilePath);
            }
            else
            {
                CreateIniFile(iniFilePath);
                CCMsgBox.Show("对不起!INI配置文件，请联系相关管理人员!", Application.ProductName, CCMsgBox.CButtons.OK, CCMsgBox.CIcon.Error);
            }

            Waiting.Show("正在检测客户端信息,请稍候...", 60);
            SalesPointBusiness salesPointManage = new SalesPointBusiness();
            string localMacAddress = NetHelper.GetLocalMACAddress();
            if(!salesPointManage.ExistsMacAddress(localMacAddress))
            {
                CCMsgBox.Show("对不起!客户端信息不对，请先注册客户端信息或联系相关管理人员!", Application.ProductName, CCMsgBox.CButtons.OK, CCMsgBox.CIcon.Error);
                return;
            }
            else
            {
              
            }

            Waiting.Show("正在检测营业点信息,请稍候...", 60);
            IniEntry iniEntry = new IniEntry(iniFilePath);
            string salesPointName = iniEntry.Sections["ClientInfo"]["SalesPointName"].ToString();
            if(!salesPointManage.Exists(salesPointName))
            {
                CCMsgBox.Show("对不起!营业点信息不对，请先注册营业点信息或联系相关管理人员!", Application.ProductName, CCMsgBox.CButtons.OK, CCMsgBox.CIcon.Error);

                return;
            }
            else
            {
                CurrentSystemInfo.SalesPoint = salesPointManage.GetInstanceObj( new SalesPoint{ Name = salesPointName});
            }

            Waiting.Show("正在检测餐牌信息,请稍候...", 80);
            RestaurantTypeBusiness typeManage = new RestaurantTypeBusiness();

            if(!typeManage.Exists(iniEntry.Sections["ClientInfo"]["DishType"]))
            {
                CCMsgBox.Show("对不起!餐牌信息不对，请先配制餐牌信息或联系相关管理人员!", Application.ProductName, CCMsgBox.CButtons.OK, CCMsgBox.CIcon.Error);
                return;
            }
            else
            {
                CurrentSystemInfo.RestaurantType = typeManage.GetInstanceObj( new RestaurantType{ Name = iniEntry.Sections["ClientInfo"]["DishType"]});
            }

            Waiting.Show("正在读取餐段信息,请稍候...", 90);

            //string mealTypeId = new MealTimeManage().GetMealTimeId();

            MealTimesBusiness workShiftManager = new MealTimesBusiness();

            if(workShiftManager.GetInstanceList().Count < 1)
            {
                MessageBox.Show("对不起,没有找着餐段信息,请先配制餐牌信息!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                
            }

            //Waiting.Show("正在同步系统时间,请稍候....", 80);
            // 同步时间
            //GetDbDateTime dbcomm = new GetDbDateTime();
            //dbcomm.SynchoronizeServerTime();

            ////InitForm();

            Waiting.Show("准备登录界面,请稍候....", 90);
            frmLogin login = new frmLogin();

            Waiting.Show("程序加载完成", 100);
            Waiting.Hide();

         

            //new FormMain().ShowDialog();
            while(login.ShowDialog() == DialogResult.OK)
            {
            //    dbcomm.SynchoronizeServerTime();                        // 再次同步时间
              
                login.Close();
            }
        }

        #endregion Main Method

        #region Private Method
        private static bool ExistRunInstance()
        {
            bool createdNew = false;
            programStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "CC.OD", out createdNew);

            if(!createdNew)
            {
                Thread.Sleep(200);

                string processName = Process.GetCurrentProcess().ProcessName;
                Process currentProcesses = Process.GetCurrentProcess();

                // 将焦点转移到另外一个实例
                foreach(Process tempProcess in Process.GetProcessesByName(processName))
                {
                    if(tempProcess.Id != currentProcesses.Id && tempProcess.MainWindowHandle != IntPtr.Zero)
                    {
                        ShowWindowAsync(tempProcess.MainWindowHandle, 9);
                        SetForegroundWindow(tempProcess.MainWindowHandle);

                        break;
                    }
                }

                RMS.Logging.LoggerManager.GetILog("Main").Info("An application instance exists, set it on focus.");
            }

            return !createdNew;
        }

        private static void HandleException(System.Exception ex)
        {
            MessageBox.Show(ex.Message);
            RMS.Logging.LoggerManager.GetILog("Main").Error(ex.StackTrace);
        }

        static void Application_ThreadExit(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        /// <summary>
        /// 测试数据库能否连接成功
        /// </summary>
        /// <returns></returns>
        static bool TestDbConnect()
        {
            try
            {
                SqlServerExecute sqlExe = new SqlServerExecute();
                System.Data.Common.DbConnection conn = SqlServerExecute.CreateConnection();
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 创建INI配制文件，使用默认键值
        /// </summary>
        /// <param name="iniFilePath"></param>
        static void CreateIniFile(string iniFilePath)
        {
            try
            {
                string writeText = "[ClientInfo]" + Constants.vbCrLf +
                            "HotelName = 酒店名称" + Constants.vbCrLf +
                            "SalesPointName = 服务器名称" + Constants.vbCrLf +
                            "DishType = 餐牌名称";
                StreamWriter sw = new StreamWriter(iniFilePath, false);
                sw.Write(writeText);
                sw.Flush();
                sw.Close();
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.Message);
                RMS.Logging.LoggerManager.GetILog("Main").Error(ex.Message, ex);
            }
        }

        #endregion End Private Method
    }
}
