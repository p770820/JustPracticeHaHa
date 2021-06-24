using System;
using System.Collections.Generic;

namespace ObjectDumperDemo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person { Name = "John", Age = 20, },
                new Person { Name = "Thomas", Age = 30, },
            };

            PeterConsole.WriteLine(persons);
            PeterConsole.WriteLine(new { Name = "Peter", Date = DateTime.Now });
            PeterConsole.WriteLine(null);
            PeterConsole.WriteLine("");

            Console.ReadLine();
        }
    }
}
