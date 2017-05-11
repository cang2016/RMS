using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Text;
 using RMS.Logging;

namespace RMS.Logging
{
    /// <summary>
    /// 日志记录帮助类.
    /// </summary>
    internal static class LoggingHelper
    {
        #region 程序集方法

        /// <summary>
        /// 生成方法名称.
        /// </summary>
        /// <param name="method">方法</param>
        /// <returns>方法名称</returns>
        internal static string BuildMethodName(MethodBase method)
        {
            ParameterInfo[] parameters = method.GetParameters();

            int initialCapacity = EstimateInitialCapacity(method, parameters);

            StringBuilder methodName = new StringBuilder(initialCapacity);

            methodName
                 .Append(method.DeclaringType.FullName)
                 .Append(".")
                 .Append(method.Name)
                 .Append("(");

            BuildParameters(methodName, parameters);

            methodName.Append(")");

            return methodName.ToString();
        }

        internal static string GetExceptionMessageOrExceptionType(Exception exception)
        {
            string message = exception.Message;

            return String.IsNullOrEmpty(message) ? exception.GetType().Name : message;
        }

        internal static string BuildMessageFromLogEntry(LogEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("entry");
            }

            StringBuilder message = new StringBuilder(256);

            message.AppendLine(Convert.ToString(entry.Message));

            message.Append("Severity: ").AppendLine(entry.Level.ToString());

            if (entry.Source != null)
            {
                message.Append("Source: ").AppendLine(entry.Source);
            }

            AppendExceptionInformation(entry.ThrownException, message);

            return message.ToString();
        }

        internal static string FormatEvent(LogEntry entry)
        {
            StringBuilder builder = new StringBuilder(256);

            builder.Append("LoggingEvent:\t").AppendLine(entry.LoggerName);
            builder.Append("Severity:\t").AppendLine(entry.Level.ToString());
            builder.Append("Message:\t").AppendLine(Convert.ToString(entry.Message));

            if (entry.Source != null)
            {
                builder.Append("Source:\t").AppendLine(entry.Source);
            }

            if (entry.ThrownException != null)
            {
                builder.Append("Exception:\t").AppendLine(entry.ThrownException.Message);
                builder.AppendLine(entry.ThrownException.StackTrace);
                builder.AppendLine();
            }

            return builder.ToString();
        }

        internal static void SetDescriptionWhenMissing(NameValueCollection config, string description)
        {
            if (string.IsNullOrEmpty(config["description"]))
            {
                config["description"] = description;
            }
        }

        internal static Exception[] GetInnerExceptions(Exception exception)
        {
            List<Exception> innerExceptions = new List<Exception>();

            var innerExceptionsProperty = exception.GetType().GetProperty("InnerExceptions");

            if (innerExceptionsProperty != null && innerExceptionsProperty.CanRead)
            {
                var exceptions =
                    innerExceptionsProperty.GetValue(exception, null) as IEnumerable<Exception>;

                if (exceptions != null)
                {
                    foreach (var innerException in exceptions)
                    {
                        if (innerException != null)
                        {
                            innerExceptions.Add(innerException);
                        }
                    }
                }
            }

            if (innerExceptions.Count == 0 && exception.InnerException != null)
            {
                innerExceptions.Add(exception.InnerException);
            }

            return innerExceptions.ToArray();
        }

        #endregion 程序集方法

        #region 私有方法
        private static int EstimateInitialCapacity(MethodBase method, ParameterInfo[] parameters)
        {
            const int AverageLengthOfParameterName = 15;
            const int ExtraLengthJustToBeSure = 20;

            return method.DeclaringType.FullName.Length + method.Name.Length +
                (AverageLengthOfParameterName * parameters.Length) + ExtraLengthJustToBeSure;
        }

        private static void BuildParameters(StringBuilder methodName, ParameterInfo[] parameters)
        {
            for (int index = 0; index < parameters.Length; index++)
            {
                if (index > 0)
                {
                    methodName.Append(", ");
                }

                ParameterInfo parameter = parameters[index];

                BuildParameter(methodName, parameter);
            }
        }

        private static void BuildParameter(StringBuilder methodName, ParameterInfo parameter)
        {
            if (parameter.IsOut == true)
            {
                methodName.Append("out ");
            }

            methodName.Append(parameter.ParameterType.Name);
        }

        private static void AppendExceptionInformation(Exception exception, StringBuilder message)
        {
            if (exception == null)
            {
                return;
            }

            message.AppendLine();
      
            message.Append(exception.ToString());
        }

        #endregion 私有方法
    }
}