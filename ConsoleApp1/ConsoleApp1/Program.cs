using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateEveryDayDirIn2020();
        }

        private static void CreateEveryDayDirIn2020()
        {
            var root = @"D:\Peter\2020";

            var start = new DateTime(2020, 1, 1);
            var end = new DateTime(2021, 1, 1);
            for (DateTime t = start; t < end; t = t.AddDays(1))
            {
                var path = $"{root}\\{t.ToString("yyyy-MM-dd")}";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}
