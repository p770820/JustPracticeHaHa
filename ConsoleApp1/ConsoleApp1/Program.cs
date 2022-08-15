using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static List<string> fail = new List<string>();
        private static string webpath = $"";
        private static int pageCount = 0;
        private static string savePath = "";
        private static object _lock = new object();
        

        static void Main(string[] args)
        {
            //MailMessage msg = new MailMessage();
            //msg.From = new MailAddress("p770820@gmail.com");
            //msg.To.Add("peter@miniasp.com");
            //msg.Subject = "Subject";
            //msg.Body = "<h1>Hello Peter</h1>";
            //msg.IsBodyHtml = true;
            ////msg.ReplyToList.Add(new MailAddress("receiver@gmail.com", "receiver"));

            //using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            //{

            //    //smtp.Credentials = new NetworkCredential("usedcar@carnews.com", "protousedcar");
            //    //smtp.EnableSsl = true;
            //    //smtp.Send(msg);

            //    smtp.UseDefaultCredentials = false;
            //    smtp.Credentials = new NetworkCredential("p770820@gmail.com", "vzcwsonzknixkvqu");
            //    //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    smtp.EnableSsl = true;
            //    smtp.Send(msg);
            //}


            //CreateRangeDayDirsInYear(2022, @"D:\Peter\2022", a => a.ToString("yyyy-MM-dd"));

            //var testStr = "📆日記 2021-05-05";
            //var pattern = @"\d{4}-\d{2}-\d{2}";

            //var m = Regex.Match(testStr, pattern);

            //Console.WriteLine(m.Value);



            // var last = new DateTime(2021, 11, 15);

            // var next = last.AddDays(7 * 12);

            //Console.WriteLine(next);

            FriendsCompare();
            Console.WriteLine();
        }

        private static void FriendsCompare()
        {
            var aaa = BeforeFriends.Data.Except(AfterFriends.Data);
            var bbb = AfterFriends.Data.Except(BeforeFriends.Data);

            Console.WriteLine("消失的朋友 結果:::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine(string.Join(Environment.NewLine, aaa));
            Console.WriteLine("=================================================");
            Console.WriteLine("新增的朋友 結果:::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine(string.Join(Environment.NewLine, bbb));
        }

        private static void ImgGETGET()
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            for (int i = 1; i <= pageCount; i++)
            {
                string jpg = $"{ i }.jpg";
                string png = $"{ i }.png";
                if (File.Exists($"{savePath}/{jpg}") || File.Exists($"{savePath}/{png}"))
                {
                    Console.WriteLine($"{i} 已經存在圖片!");
                    continue;
                }
                fail.Add(jpg);
                fail.Add(png);
            }

            Loop();

            Console.WriteLine("final!");
            Console.ReadKey();
        }

        private static void Loop()
        {
            try
            {
                while (fail.Any())
                {
                    Task[] tasks;
                    var tempList = new List<string>();
                    foreach (var item in fail)
                    {
                        Console.Write(item + ",");
                        tempList.Add(item);
                    }
                    Console.WriteLine("");

                    tasks = new Task[tempList.Count];

                    int i = 0;
                    foreach (var item in tempList)
                    {
                        var tempFile = item.Replace(".jpg", "")
                            .Replace(".png", "");

                        if (File.Exists($"{savePath}/{ tempFile }.jpg") || File.Exists($"{savePath}/{ tempFile }.png"))
                        {
                            fail.Remove(item);
                        }
                        else
                        {
                            tasks[i] = Task.Run(async () => await DownloadImg(item));
                            i++;
                        }
                    }
                    if(tasks.Length > 0)
                        Task.WaitAll(tasks);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("重新執行...");
                Loop();
            }
        }

        private static async Task DownloadImg(string file, TimeSpan? timeout = null)
        {
            Console.WriteLine($"{ file } downloading ...");
            using (HttpClient client = new HttpClient())
            {
                if (timeout != null)
                {
                    client.Timeout = timeout.Value;
                }

                var url = $"{ webpath }/{file}";
                HttpResponseMessage response = await client.GetAsync(url);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    byte[] content = await response.Content.ReadAsByteArrayAsync();

                    using (Image image = Image.FromStream(new MemoryStream(content)))
                    {
                        Console.WriteLine($"{file} download success");

                        if (file.Contains("jpg"))
                            image.Save($"{savePath}/{file}", ImageFormat.Jpeg);

                        if (file.Contains("png"))
                            image.Save($"{savePath}/{file}", ImageFormat.Png);
                    }
                }
                //else if (response.StatusCode.ToString() == 522.ToString())
                //{
                //    //await DownloadImg(file, TimeSpan.FromMinutes(10));
                //    Console.WriteLine($"{file}: {response.StatusCode}=============================");
                //}
                else
                {
                    lock (_lock)
                    {
                        if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                        {
                            if (!fail.Contains(file))
                                fail.Add(file);
                        }
                        else
                        {
                            fail.Remove(file);
                        }
                    }
                    Console.WriteLine($"{file}: {response.StatusCode}");
                }
            }
        }

        private static void DeeCopyList()
        {
            var list1 = new List<testClass>()
            {
                new testClass() {Number=1, Name="Chad"},
                new testClass() {Number=2, Name="Tom"},
                new testClass() {Number=3, Name="Peter"}
            };

            var json = JsonConvert.SerializeObject(list1);

            var list2 = JsonConvert.DeserializeObject<List<testClass>>(json);
            list2.Single(x => x.Number == 1).Name = "paul";

            Console.WriteLine(JsonConvert.SerializeObject(list1));
            Console.WriteLine(JsonConvert.SerializeObject(list2));
        }

        public class testClass
        {
            public int Number { get; set; }
            public string Name { get; set; }
        }

        /// <summary>
        /// 數值字串格式: 千分位符號加上不限小數位數
        /// https://www.peterchang.tw/2021/03/blog-post_22.html
        /// </summary>
        private static void FormatDemo()
        {
            var i1 = 1000000.01;

            Console.WriteLine(i1.ToString("N"));
            // output: 1,000,000.01

            var i2 = 1000000.1;
            Console.WriteLine(i2.ToString("N"));
            // output: 1,000,000.10
            Console.WriteLine(i2.ToString("#,##.##"));
            // output: 1,000,000.1

            var i3 = 1000000;
            Console.WriteLine(i3.ToString("N"));
            // output: 1,000,000.00
            Console.WriteLine(i3.ToString("#,##.##"));
            // output: 1,000,000

            var i4 = 0.01;
            Console.WriteLine(i4.ToString("#,##.##"));
            // output: .01
            Console.WriteLine(i4.ToString("#,#0.##"));
            // output: 0.01

            var i5 = 0.001;
            Console.WriteLine(i5.ToString("#,#0.##############"));
            // output: 0.001

            Console.WriteLine("ToMoneyFormatString");

            Console.WriteLine(1000000.01M.ToMoneyFormatString());
            // output: 1,000,000.01

            Console.WriteLine(1000000.1M.ToMoneyFormatString());
            // output: 1,000,000.1

            Console.WriteLine(1000000M.ToMoneyFormatString());
            // output: 1,000,000

            Console.WriteLine(0.01M.ToMoneyFormatString());
            // output: 0.01

            Console.WriteLine(0.001M.ToMoneyFormatString());
            // output: 0.001

            Console.WriteLine(0M.ToMoneyFormatString());
            // output: 0
        }

        private static void BigJsonToObject()
        {
            var filepath = @"C:\Users\Peter\Downloads\shops_zh-tw";
            using (var strreader = new StreamReader(filepath))
            {
                using (JsonReader reader = new JsonTextReader(strreader))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    // read the json from a stream
                    // json size doesn't matter because only a small piece is read at a time from the HTTP request
                    dynamic result = serializer.Deserialize<dynamic>(reader);
                    dynamic data = result.data;
                }
            }

            Console.ReadLine();
        }

        private static void FunDemo()
        {
            // Lambda expression as executable code.
            Func<int, bool> deleg = i => i < 5;
            // Invoke the delegate and display the output.
            Console.WriteLine("deleg(4) = {0}", deleg(4));

            // Lambda expression as data in the form of an expression tree.
            System.Linq.Expressions.Expression<Func<int, bool>> expr = i => i < 5;
            // Compile the expression tree into executable code.
            Func<int, bool> deleg2 = expr.Compile();
            // Invoke the method and print the output.
            Console.WriteLine("deleg2(4) = {0}", deleg2(4));

            int i = 0;

            /*  This code produces the following output:

                deleg(4) = True
                deleg2(4) = True
            */
        }

        public static string testMethod(string a, bool b = false, params string[] arr)
        {
            return "";
        }

        public static string testMethod2(string b = "", params string[] arr)
        {
            return "";
        }

        private static void KanbanflowTimeSpendSplite()
        {
            var input = @"還活著 alive
00:00 - 00:30	30m
打道館 || 火箭隊 || GO Battle
01:28 - 01:41	12m
打道館 || 火箭隊 || GO Battle
抓 IV 100 青棉鳥
10:50 - 11:00	10m
打道館 || 火箭隊 || GO Battle
打道館
11:12 - 11:17	5m
整理 07-11
11:25 - 11:33	8m
練唱 06-01
12:19 - 12:44	25m
練唱 11-03
12:50 - 13:03	13m
💥頭目戰 2020-08-01
13:18 - 13:58	40m
Insta360配件
14:06 - 14:31	24m
名偵探柯南 part 3
15:20 - 15:44	24m
Ultra Unlock 2020 (1/5)
15:52 - 15:54	1m
屍人診所
21:04 - 21:10	6m
名偵探柯南 part 3
21:30 - 22:13	43m
打道館 || 火箭隊 || GO Battle
23:52 - 23:58	6m
";


            var pattern = @"(.*)[\n\r][0-9][0-9][:][0-9][0-9]["" ""][-]["" ""][0-9][0-9][:][0-9][0-9](.*)";

            var rows = "";
            foreach (var r in Regex.Matches(input, pattern))
            {
                var taskName = "";
                var timeRange = "";
                var timeTotol = "";
                Console.WriteLine(r.ToString());

                taskName = r.ToString().Split('\n')[0];
                Console.WriteLine($"Task Name: { taskName }");

                timeRange = Regex.Match(r.ToString().Split('\n')[1], @"[0-9][0-9][:][0-9][0-9]["" ""][-]["" ""][0-9][0-9][:][0-9][0-9]").Value;
                Console.WriteLine($"Time Range: { timeRange }");

                timeTotol = Regex.Match(r.ToString().Split('\n')[1], @"[0-9]*m").Value;
                Console.WriteLine($"Time Total: { timeTotol }");

                Console.WriteLine("------------------------");

                rows += "<tr>";

                rows += $"<td>{ taskName }</td>";
                rows += $"<td>{ timeRange }</td>";
                rows += $"<td>{ timeTotol }</td>";

                rows += "</tr>";
            }

            var table = @$"<table border=""1"" cellpadding=""1"" cellspacing=""1"" style=""width: 500px;"">{ rows }</table>";

            Console.WriteLine(table);
        }

        private static void CreateRangeDayDirsInYear(int? year, string root, Func<DateTime, string> dirFormat)
        {
            if (!year.HasValue)
            {
                year = DateTime.Now.Year;
            }

            var start = new DateTime(year.Value, 1, 1);
            var end = new DateTime(year.Value + 1, 1, 1);

            for (DateTime t = start; t < end; t = t.AddDays(1))
            {
                var path = $"{root}\\{dirFormat(t)}";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }

    public static class DecimalExt
    {
        public static string ToMoneyFormatString(this decimal money)
        {
            var arr = money.ToString().Split(".");
            return $"{money.ToString("N0")}{(arr.Length > 1 ? "." + arr[1] : "")}";
        }
    }
}

