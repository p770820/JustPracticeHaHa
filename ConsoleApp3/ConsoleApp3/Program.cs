using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static string token = "";
        static string columnId = "";

        static void Main(string[] args)
        {
            var column = new List<Column>();
            column = GetColumn();

            if (!column.Any())
                return;

            foreach (var task in column[0].tasks)
            {
                foreach (var date in task.dates)
                {
                }
            }
            Console.WriteLine(column);
        }

        /// <summary>
        /// 取得某泳道的卡片 
        /// </summary>
        /// <returns></returns>
        private static List<Column> GetColumn()
        {
            List<Column> column;
            WebClient client = new WebClient();
            var url = $@"https://kanbanflow.com/api/v1/tasks?apiToken={ token }&columnId={ columnId }";

            byte[] data = client.DownloadData(url);
            string json = Encoding.UTF8.GetString(data);

            Console.WriteLine(json);

            column = JsonConvert.DeserializeObject<List<Column>>(json);

            return column;
        }

        private static void TryOutDemo()
        {
            string result = "A";

            try
            {

                //...
                result += "B";
            }
            catch (MyException myEx)
            {
                throw myEx;
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
