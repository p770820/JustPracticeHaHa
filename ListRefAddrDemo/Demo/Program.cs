using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string> { "Peter" };
            Console.WriteLine(JsonSerializer.Serialize(list));

            Proc(ref list);

            Console.WriteLine(JsonSerializer.Serialize(list));
            Console.WriteLine("Hello world!");
        }


        private static void Proc(ref List<string> list)
        {
            //list.Add("William");

            var output = new List<string>() { "William" };
            list = output;
        }
    }
}
