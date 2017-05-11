using System;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Linq;
using RMS.Utility;


namespace RMS.Logging
{
    /// <summary>
    /// Helper methods for Logging providers that communicate with a SQL Server database.
    /// </summary>
    internal static class DbLoggingHelper
    {
        static Assembly assembly;
        static Type dbExecute;
        static DbLoggingHelper()
        {
            assembly = Assembly.LoadFrom(Path.Combine(@"E:\RMS\RMS\build", "DataAccess.dll"));
            dbExecute = TypeLoader.LoadFrom(Path.Combine(@"E:\RMS\RMS\build", "DataAccess.dll"), "RMS.DataAccess.SqlServerExecute", true);
        }

        const string CREATE_LOG_TABLE_STATEMENT = "Create table AppLog" +
                                                    "(  Id int primary key  identity(1,1)," +
                                                     "  ThreadId int," +
                                                     "  HostName varchar(30)," +
                                                     "	ApplicationFriendlyName varchar(40)," +
                                                     "	AssemblyLocationInfo varchar(40), " +
                                                     "	LogLevel varchar(20)," +
                                                     "	LoggerName varchar(50)," +
                                                     "	LogMessage varchar(600)," +
                                                     "	ExceptionMsg varchar(3000)," +
                                                     "	LogDate date," +
                                                     "  LogTime time)";


        internal static void WriteLogToDb(LogEntry logEntry)
        {
            object sqlserver = assembly.CreateInstance("RMS.DataAccess.SqlServerExecute");

            int result = 0;
            object exists = dbExecute.GetMethod("TableExists").Invoke(sqlserver, new object[] { "AppLog" });


            string exceptionMsg = logEntry.ThrownException == null ? string.Empty : logEntry.ThrownException.StackTrace;
            string sql = "insert into AppLog values(" + SystemInfo.CurrentThreadId.ToString() + "," + SystemInfo.HostName + "," + SystemInfo.ApplicationFriendlyName +
                "," + SystemInfo.EntryAssemblyLocation + "," + logEntry.Level.ToString() + "," + logEntry.LoggerName + "," + Convert.ToString(logEntry.Message) + "," +
                 logEntry.TimeStamp.ToShortDateString() + "," + logEntry.TimeStamp.ToLongTimeString() + "," + exceptionMsg + ")";

            if(!Convert.ToBoolean(exists))
            {
                result = Convert.ToInt32(dbExecute.GetMethod("ExecuteNonQuery").Invoke(sqlserver, new object[] { CREATE_LOG_TABLE_STATEMENT }));

                WriteLogTodb(logEntry);
            }
            else
            {
                WriteLogTodb(logEntry);
            }
        }

        private static void WriteLogTodb(LogEntry logEntry)
        {
            object sqlserverObj = assembly.CreateInstance("RMS.DataAccess.SqlServerExecute");

            string exceptionMsg = logEntry.ThrownException == null ? string.Empty : logEntry.ThrownException.StackTrace;
            string sql = "insert into AppLog values(" + SystemInfo.CurrentThreadId.ToString() + "," + "'" + SystemInfo.HostName + "'" + "," + "'" + SystemInfo.ApplicationFriendlyName +
                "'" + "," + "'" + SystemInfo.EntryAssemblyLocation + "'" + "," + "'" + logEntry.Level.ToString() + "','" + logEntry.LoggerName + "','" + Convert.ToString(logEntry.Message) + "'" + "," + "'" + exceptionMsg + "'" + "," + "'" +
                 logEntry.TimeStamp.ToShortDateString() + "'" + "," + "'" + logEntry.TimeStamp.ToLongTimeString() + "'" + ")";

            int result = Convert.ToInt32(dbExecute.GetMethod("ExecuteNonQuery", new Type[] { typeof(string) }).Invoke(sqlserverObj, new object[] { sql }));

        }
    }


    public class AppLog
    {
        public AppLog()
        {
            Id = int.MinValue;
            ThreadId = int.MinValue;
        }
        public int Id
        {
            get;
            set;
        }
        public string HostName
        {
            get;
            set;
        }
        public int ThreadId
        {
            get;
            set;
        }
        public string ApplicationFriendlyName
        {
            get;
            set;
        }
        public string AssemblyLocationInfo
        {
            get;
            set;
        }
        public string LogLevel
        {
            get;
            set;
        }
        public string LoggerName
        {
            get;
            set;
        }
        public string LogMessage
        {
            get;
            set;
        }
        public string ExceptionMsg
        {
            get;
            set;
        }
        public DateTime LogDate
        {
            get;
            set;
        }
        public DateTime LogTime
        {
            get;
            set;
        }
    }



}
