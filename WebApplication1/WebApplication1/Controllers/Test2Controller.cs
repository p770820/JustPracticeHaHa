using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class Test2Controller : Controller
    {
        // GET: Test2
        public ActionResult Index()
        {
            ViewBag.MyDate = DateTime.Now;
            return View();
        }

        public ActionResult Index2()
        {
            ViewBag.MyDate = DateTime.Now;
            return View();
        }
    }
}