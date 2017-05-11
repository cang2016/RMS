namespace RMS.Utility
{
    using System;

    public static class ArgumentsGuard
    {
        public static void NotNull(this object obj, string argName)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(argName);
            }
        }

        public static void NotNullOrEmptyOrSpaceWhite(this string arg, string argName)
        {
            if(string.IsNullOrWhiteSpace(arg))
            {
                throw new ArgumentException(argName);
            }
        }
    }
}
