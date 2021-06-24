using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDumperDemo.ConsoleApp
{
    public static class PeterConsole
    {
        public static void WriteLine(object value)
        {
            // https://github.com/thomasgalliker/ObjectDumper

            var personsDump = ObjectDumper.Dump(value);

            Console.WriteLine(personsDump);
        }
    }
}
