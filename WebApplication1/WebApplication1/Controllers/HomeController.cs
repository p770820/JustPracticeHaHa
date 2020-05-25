using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        // Nest partial A
        public ActionResult NPA()
        {
            var model = new Temp();
            model.ShowStr = "我是 NPAAAAA";
            return View(model);
        }

        // Nest partial B
        public ActionResult NPB()
        {
            var model = new Temp();
            model.ShowStr= "我是 NPB B B B B";
            return View(model);
        }
    }

    public class Temp
    {
        public string ShowStr { get; set; }
    }
}
