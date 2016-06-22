using System;

namespace MVVMReports
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        public static string PassportTrim(this string source)
        {
            return source.Replace("_", "").Trim();
        }

        public static string SQLCleanup(this string source)
        {
            return source.Replace("'", "''").Replace("0=0", "").Replace(";", "");

        }
    }
}
