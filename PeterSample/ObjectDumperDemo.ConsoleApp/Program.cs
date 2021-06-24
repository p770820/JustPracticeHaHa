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
                new Person { Name = "John", Age = 20,
                    NickName = new string[] { "猛John", "JJ" },
                    FamilyMembers = new List<Person>() { 
                        new Person(){ Name = "JohnPa", Age = 50, NickName = new string[]{ "JPapa" } },
                        new Person(){ Name = "JohnMa", Age = 45, NickName = new string[]{ "JMama" } },
                        new Person(){ Name = "JohnOni", Age = 21, NickName = new string[]{ "JOni" } },
                    }
                },
                new Person { Name = "Thomas", Age = 30,
                    NickName = new string[] { "滅霸", "響指哥" }},
            };

            PeterConsole.WriteLine(persons);
            PeterConsole.WriteLine(new { Name = "Peter", Date = DateTime.Now });
            PeterConsole.WriteLine(null);
            PeterConsole.WriteLine("");

            Console.ReadLine();
        }
    }
}
