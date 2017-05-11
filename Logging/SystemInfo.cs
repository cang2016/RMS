namespace RMS.Logging
{
    using System;
    using System.Collections;
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    /// <summary>
    /// 系统相关信息类
    /// </summary>
    public sealed class SystemInfo
    {
        #region 私有常量

        private const string DEFAULT_NULL_TEXT = "(null)";
        private const string DEFAULT_NOT_AVAILABLE_TEXT = "NOT AVAILABLE";

        #endregion

        #region 私有实例构造函数

        /// <summary>
        /// 私有静态构造函数
        /// </summary>
        /// <remarks>
        /// <para>
        /// 这个类型仅仅提供静态方法为外部调用
        /// </para>
        /// </remarks>
        private SystemInfo()
        {
        }

        #endregion 私有实例构造函数

        #region 公共静态构造函数

        /// <summary>
        /// 初始化私有静态字段为默认值.
        /// </summary>
        /// <remarks>
        /// <para>
        /// 这个类型仅仅提供静态方法为外部调用
        /// </para>
        /// </remarks>
        static SystemInfo()
        {
            string nullText = DEFAULT_NULL_TEXT;
            string notAvailableText = DEFAULT_NOT_AVAILABLE_TEXT;

            s_notAvailableText = notAvailableText;
            s_nullText = nullText;
        }

        #endregion

        #region 公共静态属性

        /// <summary>
        /// 换行.
        /// </summary>
        public static string NewLine
        {
            get
            {
                return System.Environment.NewLine;
            }
        }

        /// <summary>
        /// 获取当前应用程序域的基目录
        /// </summary>
        public static string ApplicationBaseDirectory
        {
            get
            {
#if NETCF
				return System.IO.Path.GetDirectoryName(SystemInfo.EntryAssemblyLocation) + System.IO.Path.DirectorySeparatorChar;
#else
                return AppDomain.CurrentDomain.BaseDirectory;
#endif
            }
        }

        /// <summary>
        /// 获取当前应用程序域配置文件名称.
        /// </summary>
        public static string ConfigurationFileLocation
        {
            get
            {
#if NETCF
				return SystemInfo.EntryAssemblyLocation+".config";
#else
                return System.AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
#endif
            }
        }

        /// <summary>
        /// 获取第一次加载的程序集.
        /// </summary>
        public static string EntryAssemblyLocation
        {
            get
            {
#if NETCF
				return SystemInfo.NativeEntryAssemblyLocation;
#else
                return System.Reflection.Assembly.GetEntryAssembly().Location;
#endif
            }
        }

        /// <summary>
        /// 获取当前线程ID.
        /// </summary>
        /// <value>当前线程ID.</value>
        /// <remarks>
        /// <para>
        /// On the .NET framework, the <c>AppDomain.GetCurrentThreadId</c> method
        /// is used to obtain the thread ID for the current thread. This is the 
        /// operating system ID for the thread.
        /// </para>
        /// <para>
        /// On the .NET Compact Framework 1.0 it is not possible to get the 
        /// operating system thread ID for the current thread. The native method 
        /// <c>GetCurrentThreadId</c> is implemented inline in a header file
        /// and cannot be called.
        /// </para>
        /// <para>
        /// On the .NET Framework 2.0 the <c>Thread.ManagedThreadId</c> is used as this
        /// gives a stable id unrelated to the operating system thread ID which may 
        /// change if the runtime is using fibers.
        /// </para>
        /// </remarks>
        public static int CurrentThreadId
        {
            get
            {
#if NETCF_1_0
				return System.Threading.Thread.CurrentThread.GetHashCode();
#elif NET_2_0 || NETCF_2_0 || MONO_2_0
				return System.Threading.Thread.CurrentThread.ManagedThreadId;
#else
                // return AppDomain.GetCurrentThreadId(); // 过时
                return Thread.CurrentThread.ManagedThreadId;
#endif
            }
        }

        /// <summary>
        /// 获取当前主机名或机器名
        /// </summary>
        /// <value>
        /// 当前主机名或机器名
        /// </value>
        /// <remarks>
        /// <para>
        ///获取当前主机名或机器名
        /// </para>
        /// <para>
        /// The host name (<see cref="System.Net.Dns.GetHostName"/>) or
        /// the machine name (<c>Environment.MachineName</c>) for
        /// the current machine, or if neither of these are available
        /// then <c>NOT AVAILABLE</c> is returned.
        /// </para>
        /// </remarks>
        public static string HostName
        {
            get
            {
                if (s_hostName == null)
                {

                    //获取当前机器的DNS主机名
                    try
                    {
                        // 查找主机名.
                        s_hostName = System.Net.Dns.GetHostName();
                    }
                    catch (System.Net.Sockets.SocketException sex)
                    {
                        InternalLogger.Log(sex.StackTrace);
                    }
                    catch (System.Security.SecurityException sex)
                    {
                        InternalLogger.Log(sex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        InternalLogger.Log(ex.StackTrace);
                    }

                    // 获取当前机器名称.
                    if (s_hostName == null || s_hostName.Length == 0)
                    {
                        try
                        {
#if (!SSCLI && !NETCF)
                            s_hostName = Environment.MachineName;
#endif
                        }
                        catch (InvalidOperationException iex)
                        {
                            InternalLogger.Log(iex.StackTrace);
                        }
                        catch (System.Security.SecurityException sex)
                        {
                            InternalLogger.Log(sex.StackTrace);
                        }
                    }

                    // 没有找到一个值.
                    if (s_hostName == null || s_hostName.Length == 0)
                    {
                        s_hostName = s_notAvailableText;
                    }
                }

                return s_hostName;
            }
        }

        /// <summary>
        /// 获取当前应用程序友好名称.
        /// </summary>
        public static string ApplicationFriendlyName
        {
            get
            {
                if (s_appFriendlyName == null)
                {
                    try
                    {
#if !NETCF
                        s_appFriendlyName = AppDomain.CurrentDomain.FriendlyName;
#endif
                    }
                    catch (System.Security.SecurityException sex)
                    {
                        InternalLogger.Log(sex.StackTrace);
                    }

                    if (s_appFriendlyName == null || s_appFriendlyName.Length == 0)
                    {
                        try
                        {
                            string assemblyLocation = SystemInfo.EntryAssemblyLocation;
                            s_appFriendlyName = System.IO.Path.GetFileName(assemblyLocation);
                        }
                        catch (System.Security.SecurityException sex)
                        {
                            InternalLogger.Log(sex.StackTrace);
                        }
                    }

                    if (s_appFriendlyName == null || s_appFriendlyName.Length == 0)
                    {
                        s_appFriendlyName = s_notAvailableText;
                    }
                }

                return s_appFriendlyName;
            }
        }

        /// <summary>
        /// 获取当前进程的开始时间.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is the time at which the logger library was loaded into the
        /// AppDomain. Due to reports of a hang in the call to <c>System.Diagnostics.Process.StartTime</c>
        /// this is not the start time for the current process.
        /// </para>
        /// <para>
        /// The logger library should be loaded by an application early during its
        /// startup, therefore this start time should be a good approximation for
        /// the actual start time.
        /// </para>
        /// <para>
        /// Note that AppDomains may be loaded and unloaded within the
        /// same process without the process terminating, however this start time
        /// will be set per AppDomain.
        /// </para>
        /// </remarks>
        public static DateTime ProcessStartTime
        {
            get { return s_processStartTime; }
        }

        /// <summary>
        /// 空文本.
        /// </summary>
        public static string NullText
        {
            get { return s_nullText; }
            set { s_nullText = value; }
        }

        /// <summary>
        /// 不可用的文本.
        /// </summary>
        public static string NotAvailableText
        {
            get { return s_notAvailableText; }
            set { s_notAvailableText = value; }
        }

        #endregion 公共静态属性

        #region 公共静态方法

        /// <summary>
        /// 获取指定的程序集路径.
        /// </summary>
        /// <param name="myAssembly">要查找的程序集.</param>
        /// <returns>程序集路径.</returns>
        /// <remarks>
        /// <para>
        /// This method does not guarantee to return the correct path
        /// to the assembly. If only tries to give an indication as to
        /// where the assembly was loaded from.
        /// </para>
        /// </remarks>
        public static string AssemblyLocationInfo(Assembly myAssembly)
        {
#if NETCF
			return "Not supported on Microsoft .NET Compact Framework";
#else
            if (myAssembly.GlobalAssemblyCache)
            {
                return "Global Assembly Cache";
            }
            else
            {
                try
                {
#if NET_4_0
					if (myAssembly.IsDynamic)
					{
						return "Dynamic Assembly";
					}
#else
                    if (myAssembly is System.Reflection.Emit.AssemblyBuilder)
                    {
                        return "Dynamic Assembly";
                    }
                    else if (myAssembly.GetType().FullName == "System.Reflection.Emit.InternalAssemblyBuilder")
                    {
                        return "Dynamic Assembly";
                    }
#endif
                    else
                    {
                        // This call requires FileIOPermission for access to the path
                        // if we don't have permission then we just ignore it and
                        // carry on.
                        return myAssembly.Location;
                    }
                }
                catch (NotSupportedException)
                {
                    // The location information may be unavailable for dynamic assemblies and a NotSupportedException
                    // is thrown in those cases. See: http://msdn.microsoft.com/de-de/library/system.reflection.assembly.location.aspx
                    return "Dynamic Assembly";
                }
                catch (TargetInvocationException ex)
                {
                    return "Location Detect Failed (" + ex.Message + ")";
                }
                catch (ArgumentException ex)
                {
                    return "Location Detect Failed (" + ex.Message + ")";
                }
                catch (System.Security.SecurityException)
                {
                    return "Location Permission Denied";
                }
            }
#endif
        }

        /// <summary>
        /// 获取类型的完全限定名称，包括加载类型的程序集名称.
        /// </summary>
        /// <param name="type">The <see cref="Type" /> to get the fully qualified name for.</param>
        /// <returns>The fully qualified name for the <see cref="Type" />.</returns>
        /// <remarks>
        /// <para>
        /// This is equivalent to the <c>Type.AssemblyQualifiedName</c> property,
        /// but this method works on the .NET Compact Framework 1.0 as well as
        /// the full .NET runtime.
        /// </para>
        /// </remarks>
        public static string AssemblyQualifiedName(Type type)
        {
            return type.FullName + ", " + type.Assembly.FullName;
        }

        /// <summary>
        /// 获取短程序集名称. <see cref="Assembly" />.
        /// </summary>
        /// <param name="myAssembly">The <see cref="Assembly" /> to get the name for.</param>
        /// <returns>The short name of the <see cref="Assembly" />.</returns>
        /// <remarks>
        /// <para>
        /// The short name of the assembly is the <see cref="Assembly.FullName" /> 
        /// without the version, culture, or public key. i.e. it is just the 
        /// assembly's file name without the extension.
        /// </para>
        /// <para>
        /// Use this rather than <c>Assembly.GetName().Name</c> because that
        /// is not available on the Compact Framework.
        /// </para>
        /// <para>
        /// Because of a FileIOPermission security demand we cannot do
        /// the obvious Assembly.GetName().Name. We are allowed to get
        /// the <see cref="Assembly.FullName" /> of the assembly so we 
        /// start from there and strip out just the assembly name.
        /// </para>
        /// </remarks>
        public static string AssemblyShortName(Assembly myAssembly)
        {
            string name = myAssembly.FullName;
            int offset = name.IndexOf(',');
            if (offset > 0)
            {
                name = name.Substring(0, offset);
            }
            return name.Trim();

            // TODO: Do we need to unescape the assembly name string? 
            // Doc says '\' is an escape char but has this already been 
            // done by the string loader?
        }

        /// <summary>
        /// 获取程序集名称包含后缀名.<see cref="Assembly" />.
        /// </summary>
        /// <param name="myAssembly">The <see cref="Assembly" /> to get the file name for.</param>
        /// <returns>The file name of the assembly.</returns>
        /// <remarks>
        /// <para>
        /// Gets the file name portion of the <see cref="Assembly" />, including the extension.
        /// </para>
        /// </remarks>
        public static string AssemblyFileName(Assembly myAssembly)
        {
#if NETCF
			// This is not very good because it assumes that only
			// the entry assembly can be an EXE. In fact multiple
			// EXEs can be loaded in to a process.

			string assemblyShortName = SystemInfo.AssemblyShortName(myAssembly);
			string entryAssemblyShortName = System.IO.Path.GetFileNameWithoutExtension(SystemInfo.EntryAssemblyLocation);

			if (string.Compare(assemblyShortName, entryAssemblyShortName, true) == 0)
			{
				// assembly is entry assembly
				return assemblyShortName + ".exe";
			}
			else
			{
				// assembly is not entry assembly
				return assemblyShortName + ".dll";
			}
#else
            return System.IO.Path.GetFileName(myAssembly.Location);
#endif
        }

        /// <summary>
        /// 加载类型使用指定的类型字符串名称.
        /// </summary>
        /// <param name="relativeType">A sibling type to use to load the type.</param>
        /// <param name="typeName">The name of the type to load.</param>
        /// <param name="throwOnError">Flag set to <c>true</c> to throw an exception if the type cannot be loaded.</param>
        /// <param name="ignoreCase"><c>true</c> to ignore the case of the type name; otherwise, <c>false</c></param>
        /// <returns>The type loaded or <c>null</c> if it could not be loaded.</returns>
        /// <remarks>
        /// <para>
        /// If the type name is fully qualified, i.e. if contains an assembly name in 
        /// the type name, the type will be loaded from the system using 
        /// <see cref="M:Type.GetType(string,bool)"/>.
        /// </para>
        /// <para>
        /// If the type name is not fully qualified, it will be loaded from the assembly
        /// containing the specified relative type. If the type is not found in the assembly 
        /// then all the loaded assemblies will be searched for the type.
        /// </para>
        /// </remarks>
        public static Type GetTypeFromString(Type relativeType, string typeName, bool throwOnError, bool ignoreCase)
        {
            return GetTypeFromString(relativeType.Assembly, typeName, throwOnError, ignoreCase);
        }

        /// <summary>
        /// 加载类型使用指定的类型字符串名称.
        /// </summary>
        /// <param name="typeName">The name of the type to load.</param>
        /// <param name="throwOnError">Flag set to <c>true</c> to throw an exception if the type cannot be loaded.</param>
        /// <param name="ignoreCase"><c>true</c> to ignore the case of the type name; otherwise, <c>false</c></param>
        /// <returns>The type loaded or <c>null</c> if it could not be loaded.</returns>		
        /// <remarks>
        /// <para>
        /// If the type name is fully qualified, i.e. if contains an assembly name in 
        /// the type name, the type will be loaded from the system using 
        /// <see cref="M:Type.GetType(string,bool)"/>.
        /// </para>
        /// <para>
        /// If the type name is not fully qualified it will be loaded from the
        /// assembly that is directly calling this method. If the type is not found 
        /// in the assembly then all the loaded assemblies will be searched for the type.
        /// </para>
        /// </remarks>
        public static Type GetTypeFromString(string typeName, bool throwOnError, bool ignoreCase)
        {
            return GetTypeFromString(Assembly.GetCallingAssembly(), typeName, throwOnError, ignoreCase);
        }

        /// <summary>
        /// 加载类型使用指定的类型字符串名称.
        /// </summary>
        /// <param name="relativeAssembly">An assembly to load the type from.</param>
        /// <param name="typeName">The name of the type to load.</param>
        /// <param name="throwOnError">Flag set to <c>true</c> to throw an exception if the type cannot be loaded.</param>
        /// <param name="ignoreCase"><c>true</c> to ignore the case of the type name; otherwise, <c>false</c></param>
        /// <returns>The type loaded or <c>null</c> if it could not be loaded.</returns>
        /// <remarks>
        /// <para>
        /// If the type name is fully qualified, i.e. if contains an assembly name in 
        /// the type name, the type will be loaded from the system using 
        /// <see cref="M:Type.GetType(string,bool)"/>.
        /// </para>
        /// <para>
        /// If the type name is not fully qualified it will be loaded from the specified
        /// assembly. If the type is not found in the assembly then all the loaded assemblies 
        /// will be searched for the type.
        /// </para>
        /// </remarks>
        public static Type GetTypeFromString(Assembly relativeAssembly, string typeName, bool throwOnError, bool ignoreCase)
        {
            // Check if the type name specifies the assembly name
            if (typeName.IndexOf(',') == -1)
            {
                //LogLog.Debug(declaringType, "SystemInfo: Loading type ["+typeName+"] from assembly ["+relativeAssembly.FullName+"]");
#if NETCF
				return relativeAssembly.GetType(typeName, throwOnError);
#else
                // Attempt to lookup the type from the relativeAssembly
                Type type = relativeAssembly.GetType(typeName, false, ignoreCase);
                if (type != null)
                {
                    // Found type in relative assembly
                    //LogLog.Debug(declaringType, "SystemInfo: Loaded type ["+typeName+"] from assembly ["+relativeAssembly.FullName+"]");
                    return type;
                }

                Assembly[] loadedAssemblies = null;
                try
                {
                    loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                }
                catch (System.Security.SecurityException)
                {
                    // Insufficient permissions to get the list of loaded assemblies
                }

                if (loadedAssemblies != null)
                {
                    // Search the loaded assemblies for the type
                    foreach (Assembly assembly in loadedAssemblies)
                    {
                        type = assembly.GetType(typeName, false, ignoreCase);
                        if (type != null)
                        {
                            // Found type in loaded assembly
                            //LogLog.Debug(declaringType, "Loaded type [" + typeName + "] from assembly [" + assembly.FullName + "] by searching loaded assemblies.");
                            return type;
                        }
                    }
                }

                // Didn't find the type
                if (throwOnError)
                {
                    throw new TypeLoadException("Could not load type [" + typeName + "]. Tried assembly [" + relativeAssembly.FullName + "] and all loaded assemblies");
                }
                return null;
#endif
            }
            else
            {
                // Includes explicit assembly name
                //LogLog.Debug(declaringType, "SystemInfo: Loading type ["+typeName+"] from global Type");

#if NETCF
				// In NETCF 2 and 3 arg versions seem to behave differently
				// https://issues.apache.org/jira/browse/logger-113
				return Type.GetType(typeName, throwOnError);
#else
                return Type.GetType(typeName, throwOnError, ignoreCase);
#endif
            }
        }


        /// <summary>
        /// 生成一个新的GUID
        /// </summary>
        /// <returns>一个新的Guid</returns>
        /// <remarks>
        /// <para>
        /// 生成一个新的GUID
        /// </para>
        /// </remarks>
        public static Guid NewGuid()
        {
#if NETCF_1_0
			return PocketGuid.NewGuid();
#else
            return Guid.NewGuid();
#endif
        }

        /// <summary>
        /// 创建一个<see cref="ArgumentOutOfRangeException"/>异常类.
        /// </summary>
        /// <param name="parameterName">The name of the parameter that caused the exception</param>
        /// <param name="actualValue">The value of the argument that causes this exception</param>
        /// <param name="message">The message that describes the error</param>
        /// <returns>the ArgumentOutOfRangeException object</returns>
        /// <remarks>
        /// <para>
        /// Create a new instance of the <see cref="ArgumentOutOfRangeException"/> class 
        /// with a specified error message, the parameter name, and the value 
        /// of the argument.
        /// </para>
        /// <para>
        /// The Compact Framework does not support the 3 parameter constructor for the
        /// <see cref="ArgumentOutOfRangeException"/> type. This method provides an
        /// implementation that works for all platforms.
        /// </para>
        /// </remarks>
        public static ArgumentOutOfRangeException CreateArgumentOutOfRangeException(string parameterName, object actualValue, string message)
        {
#if NETCF_1_0
			return new ArgumentOutOfRangeException(message + " [param=" + parameterName + "] [value=" + actualValue + "]");
#elif NETCF_2_0
			return new ArgumentOutOfRangeException(parameterName, message + " [value=" + actualValue + "]");
#else
            return new ArgumentOutOfRangeException(parameterName, actualValue, message);
#endif
        }


        /// <summary>
        ///将一个字符串转转换为Int32整型.
        /// </summary>
        /// <param name="s">the string to parse</param>
        /// <param name="val">out param where the parsed value is placed</param>
        /// <returns><c>true</c> if the string was able to be parsed into an integer</returns>
        /// <remarks>
        /// <para>
        /// Attempts to parse the string into an integer. If the string cannot
        /// be parsed then this method returns <c>false</c>. The method does not throw an exception.
        /// </para>
        /// </remarks>
        public static bool TryParse(string s, out int val)
        {
#if NETCF
			val = 0;
			try
			{
				val = int.Parse(s, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);
				return true;
			}
			catch
			{
			}

			return false;
#else
            // Initialise out param
            val = 0;

            try
            {
                double doubleVal;
                if (Double.TryParse(s, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out doubleVal))
                {
                    val = Convert.ToInt32(doubleVal);
                    return true;
                }
            }
            catch
            {
                // Ignore exception, just return false
            }

            return false;
#endif
        }

        /// <summary>
        /// 将一个字符串转转换为Int64整型.
        /// </summary>
        /// <param name="s">the string to parse</param>
        /// <param name="val">out param where the parsed value is placed</param>
        /// <returns><c>true</c> if the string was able to be parsed into an integer</returns>
        /// <remarks>
        /// <para>
        /// Attempts to parse the string into an integer. If the string cannot
        /// be parsed then this method returns <c>false</c>. The method does not throw an exception.
        /// </para>
        /// </remarks>
        public static bool TryParse(string s, out long val)
        {
#if NETCF
			val = 0;
			try
			{
				val = long.Parse(s, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);
				return true;
			}
			catch
			{
			}

			return false;
#else
            // Initialise out param
            val = 0;

            try
            {
                double doubleVal;
                if (Double.TryParse(s, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out doubleVal))
                {
                    val = Convert.ToInt64(doubleVal);
                    return true;
                }
            }
            catch
            {
                // Ignore exception, just return false
            }

            return false;
#endif
        }

        /// <summary>
        /// 将一个字符串转转换为Int16整型.
        /// </summary>
        /// <param name="s">the string to parse</param>
        /// <param name="val">out param where the parsed value is placed</param>
        /// <returns><c>true</c> if the string was able to be parsed into an integer</returns>
        /// <remarks>
        /// <para>
        /// Attempts to parse the string into an integer. If the string cannot
        /// be parsed then this method returns <c>false</c>. The method does not throw an exception.
        /// </para>
        /// </remarks>
        public static bool TryParse(string s, out short val)
        {
#if NETCF
			val = 0;
			try
			{
				val = short.Parse(s, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);
				return true;
			}
			catch
			{
			}

			return false;
#else
            // Initialise out param
            val = 0;

            try
            {
                double doubleVal;
                if (Double.TryParse(s, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out doubleVal))
                {
                    val = Convert.ToInt16(doubleVal);
                    return true;
                }
            }
            catch
            {
                // Ignore exception, just return false
            }

            return false;
#endif
        }

        /// <summary>
        /// 查找一个应用程序设置值.
        /// </summary>
        /// <param name="key">the application settings key to lookup</param>
        /// <returns>the value for the key, or <c>null</c></returns>
        /// <remarks>
        /// <para>
        /// Configuration APIs are not supported under the Compact Framework
        /// </para>
        /// </remarks>
        public static string GetAppSetting(string key)
        {
            try
            {
#if NETCF
				// Configuration APIs are not suported under the Compact Framework
#elif NET_2_0
				return ConfigurationManager.AppSettings[key];
#else
                return ConfigurationManager.AppSettings[key];
#endif
            }
            catch (Exception ex)
            {
                InternalLogger.Log(ex.StackTrace);
            }
            return null;
        }

        /// <summary>
        /// 转换一个路径为完全限定文件名称.
        /// </summary>
        /// <param name="path">要转换的路径.</param>
        /// <returns>完全限定文件名称.</returns>
        /// <remarks>
        /// <para>
        /// Converts the path specified to a fully
        /// qualified path. If the path is relative it is
        /// taken as relative from the application base 
        /// directory.
        /// </para>
        /// <para>
        /// The path specified must be a local file path, a URI is not supported.
        /// </para>
        /// </remarks>
        public static string ConvertToFullPath(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            string baseDirectory = "";
            try
            {
                string applicationBaseDirectory = SystemInfo.ApplicationBaseDirectory;
                if (applicationBaseDirectory != null)
                {
                    // applicationBaseDirectory may be a URI not a local file path
                    Uri applicationBaseDirectoryUri = new Uri(applicationBaseDirectory);
                    if (applicationBaseDirectoryUri.IsFile)
                    {
                        baseDirectory = applicationBaseDirectoryUri.LocalPath;
                    }
                }
            }
            catch
            {
                // Ignore URI exceptions & SecurityExceptions from SystemInfo.ApplicationBaseDirectory
            }

            if (baseDirectory != null && baseDirectory.Length > 0)
            {
                // Note that Path.Combine will return the second path if it is rooted
                return Path.GetFullPath(Path.Combine(baseDirectory, path));
            }

            return Path.GetFullPath(path);
        }

        /// <summary>
        /// 创建一个使用默认初始容量忽略大小写的类.
        /// </summary>
        /// <returns>一个使用默认初始容量忽略大小写的类<see cref="Hashtable"/></returns>
        /// <remarks>
        /// <para>
        /// 这个新Hashtable实例使用默认加载因子, the CaseInsensitiveHashCodeProvider, and the CaseInsensitiveComparer.
        /// </para>
        /// </remarks>
        public static Hashtable CreateCaseInsensitiveHashtable()
        {
#if NETCF_1_0
			return new Hashtable(CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default);
#elif NETCF_2_0 || NET_2_0 || MONO_2_0
			return new Hashtable(StringComparer.OrdinalIgnoreCase);
#else
            return System.Collections.Specialized.CollectionsUtil.CreateCaseInsensitiveHashtable();
#endif
        }

        #endregion Public Static Methods

        #region 私有静态方法

#if NETCF
		private static string NativeEntryAssemblyLocation 
		{
			get 
			{
				StringBuilder moduleName = null;

				IntPtr moduleHandle = GetModuleHandle(IntPtr.Zero);

				if (moduleHandle != IntPtr.Zero) 
				{
					moduleName = new StringBuilder(255);
					if (GetModuleFileName(moduleHandle, moduleName,	moduleName.Capacity) == 0) 
					{
						throw new NotSupportedException(NativeError.GetLastError().ToString());
					}
				} 
				else 
				{
					throw new NotSupportedException(NativeError.GetLastError().ToString());
				}

				return moduleName.ToString();
			}
		}

		[DllImport("CoreDll.dll", SetLastError=true, CharSet=CharSet.Unicode)]
		private static extern IntPtr GetModuleHandle(IntPtr ModuleName);

		[DllImport("CoreDll.dll", SetLastError=true, CharSet=CharSet.Unicode)]
		private static extern Int32 GetModuleFileName(
			IntPtr hModule,
			StringBuilder ModuleName,
			Int32 cch);

#endif

        #endregion 私有静态方法

        #region 公共静态字段

        /// <summary>
        /// 获取空类型数组.
        /// </summary>
        public static readonly Type[] EmptyTypes = new Type[0];

        #endregion 公共静态方法

        #region 私有静态字段

        /// <summary>
        /// 当前类型的完全限定名称.
        /// </summary>
        private readonly static Type declaringType = typeof(SystemInfo);

        /// <summary>
        /// 当前机器的主机名.
        /// </summary>
        private static string s_hostName;

        /// <summary>
        /// 应用程序友好名称.
        /// </summary>
        private static string s_appFriendlyName;

        /// <summary>
        /// 封装null的文本.
        /// </summary>
        private static string s_nullText;

        /// <summary>
        /// 不支持的文本.
        /// </summary>
        private static string s_notAvailableText;

        /// <summary>
        /// 当前进程的开始时间.
        /// </summary>
        private static DateTime s_processStartTime = DateTime.Now;

        #endregion
    }
}
