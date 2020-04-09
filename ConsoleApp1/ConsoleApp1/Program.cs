using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateRangeDayDirsInYear(2020, @"D:\Peter\2020", f => f.ToString("yyyy-MM-dd"));
        }

        private static void CreateRangeDayDirsInYear(int? year, string root, Func<DateTime, string> dirFormat)
        {
            if (!year.HasValue)
            {
                year = DateTime.Now.Year;
            }

            var start = new DateTime(year.Value, 1, 1);
            var end = new DateTime(year.Value + 1, 1, 1);

            for (DateTime t = start; t < end; t = t.AddDays(1))
            {
                var path = $"{root}\\{dirFormat}";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}
