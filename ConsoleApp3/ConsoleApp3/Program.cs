using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static string token = "";
        static string columnId = "";

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var column = new List<Column>();
            column = await GetColumnAsync();

            if (!column.Any())
                return;

            foreach (var task in column[0].tasks)
            {
                await UpdateTaskDate(task);
            }
            Console.WriteLine("Finish!");
            Console.ReadLine();
        }

        private static async System.Threading.Tasks.Task UpdateTaskDate(Task task)
        {
            var url = $@"https://kanbanflow.com/api/v1/tasks/{ task._id }/dates?apiToken={ token }";

            Console.WriteLine($"{task._id}  { task.name }");
            Console.WriteLine(" ============ task update date start =============");
            foreach (var date in task.dates)
            {
                if (date.dueTimestampLocal > DateTime.Now)
                {
                    Console.WriteLine("not due date!");
                    continue;
                }

                using (HttpClient client = new HttpClient())
                {
                    Date newDate = new Date();
                    newDate.targetColumnId = date.targetColumnId;
                    newDate.status = "active";
                    newDate.dateType = "dueDate";

                    var newTime = new DateTime(
                        date.dueTimestampLocal.Year, 
                        5,// date.dueTimestampLocal.Month, 
                        date.dueTimestampLocal.Day, 
                        date.dueTimestampLocal.Hour, 
                        date.dueTimestampLocal.Minute, 
                        0);
                    newDate.dueTimestamp = newTime.ToUniversalTime();
                    newDate.dueTimestampLocal = newTime.ToLocalTime();

                    string json = JsonConvert.SerializeObject(newDate);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    Console.WriteLine(response.StatusCode);
                }
            }
            Console.WriteLine(" ============ task update date end =============");
        }

        /// <summary>
        /// 取得某泳道的卡片 
        /// </summary>
        /// <returns></returns>
        private static async Task<List<Column>> GetColumnAsync()
        {
            List<Column> column = new List<Column>();
            var url = $@"https://kanbanflow.com/api/v1/tasks?apiToken={ token }&columnId={ columnId }";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                column = JsonConvert.DeserializeObject<List<Column>>(responseBody);
            }
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

    public class MyException : Exception
    {

    }
}
