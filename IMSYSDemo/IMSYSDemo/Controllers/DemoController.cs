using IMSYSDemo.Models.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSYSDemo.Controllers
{
    public class DemoController : Controller
    {
        [HttpGet]
        public ActionResult DDLDemo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DDLDemo(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ///... 一些儲存的商業邏輯

            return View();
        }
    }
}