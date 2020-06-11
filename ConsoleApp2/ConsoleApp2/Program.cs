using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = $@"www.xxx.com/group/{ Guid.NewGuid() }/report/{ Guid.NewGuid() }";

            var groupRegex = new Regex(@"(?<=group/)(.*?)(?=/report)");
            var reportRegex = new Regex(@"(?<=report/)(.*)");


            Console.WriteLine(url);
            Console.WriteLine(groupRegex.Match(url).Value);
            Console.WriteLine(reportRegex.Match(url).Value);
        }
    }
}
