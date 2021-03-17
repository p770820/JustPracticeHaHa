using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class XSSTESTController : Controller
    {
        // GET: XSSTEST
        public ActionResult Index(string v)
        {
            ViewBag.QueryString = v;
            return View();
        }
    }
}