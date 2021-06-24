using System.Collections.Generic;

namespace ObjectDumperDemo.ConsoleApp
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] NickName { get; set; }
        public List<Person> FamilyMembers { get; set; }
    }
}