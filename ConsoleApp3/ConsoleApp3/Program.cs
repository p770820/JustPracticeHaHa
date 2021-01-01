using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "A";

            try
            {

                //...
                result += "B";
            }
            catch (MyException myEx)
            {
                
            }
            catch
            {
                result += "C";
                throw;
            }
            finally
            {
                result += "D";
            }


            Console.WriteLine(result);
        }
    }

    public class MyException: Exception
    {

    }
}
