using System;
using System.IO;

namespace VS4Mac.Sweeper.Extensions
{
    public static class DateTimeExtensions
    {
        public static string AppendTimeStamp(this string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Path.GetExtension(fileName));
        }
    }
}