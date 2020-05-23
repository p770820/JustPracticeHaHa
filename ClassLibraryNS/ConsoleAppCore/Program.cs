using System;

namespace ConsoleAppCore
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
