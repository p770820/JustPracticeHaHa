using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Ｈelper
{
    public class Helper
    {
        public static string DateTimeToString(DateTime str)
        {
            return str.ToString("yyyy年mm月dd日");
        }
    }
}