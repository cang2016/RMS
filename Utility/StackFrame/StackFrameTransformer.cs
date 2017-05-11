using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RMS.Utility
{
    /// <summary>
    /// 提取并输出堆栈信息.
    /// </summary>
    public static class StackFrameTransformer
    {
        static Regex regex;

        static StackFrameTransformer()
        {
            regex = new Regex(@"^\s*at (?<method>.*) in (?<file>.*):(line )?(?<line>\d+)$");
        }

        /// <summary>
        /// 提取并输出堆栈信息.
        /// </summary>
        /// <param name="stackFrame">堆栈信息文本.</param>
        /// <param name="defaultDirectory">默认目录.</param>
        /// <returns>调整后的信息.</returns>
        public static string TransformFrame(string stackFrame, string defaultDirectory)
        {
            if(stackFrame == null)
            {
                return null;
            }

            var match = regex.Match(stackFrame);
            if(match == Match.Empty)
            {
                return stackFrame;
            }

            var file = match.Groups["file"].Value;
            if(file.StartsWith(defaultDirectory, StringComparison.OrdinalIgnoreCase))
            {
                file = file.Substring(defaultDirectory.Length);
            }

            return String.Format("{0}({1},0): at {2}",
                                 file,
                                 match.Groups["line"].Value,
                                 match.Groups["method"].Value);
        }

        /// <summary>
        /// 提取并输出堆栈信息.
        /// </summary>
        /// <param name="stack">堆栈信息文本.</param>
        /// <param name="defaultDirectory">默认目录.</param>
        /// <returns>调整后的信息.</returns>
        public static string TransformStack(string stack, string defaultDirectory)
        {
            if(stack == null)
            {
                return null;
            }

            List<string> results = new List<string>();

            foreach(string frame in stack.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                results.Add(TransformFrame(frame, defaultDirectory));
            }

            return String.Join(Environment.NewLine, results.ToArray());
        }
    }
}
