using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFx
{
    class Program
    {
        static void Main(string[] args)
        {
            var ns = new ClassLibraryNS.Class1();
            Console.WriteLine(ns.GetString());
            Console.ReadKey();
        }
    }
}
