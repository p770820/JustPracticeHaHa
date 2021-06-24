using System;
using System.Collections.Generic;

namespace ObjectDumperDemo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://github.com/thomasgalliker/ObjectDumper
            var persons = new List<Person>
            {
                new Person { Name = "John", Age = 20, },
                new Person { Name = "Thomas", Age = 30, },
            };

            var personsDump = ObjectDumper.Dump(persons);

            Console.WriteLine(personsDump);
            Console.ReadLine();
        }
    }
}
