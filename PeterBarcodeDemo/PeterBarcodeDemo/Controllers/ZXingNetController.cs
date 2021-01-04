using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeterBarcodeDemo.Controllers
{
    // https://github.com/micjahn/ZXing.Net
    /// <summary>
    /// 
    /// </summary>
    public class ZXingNetController : Controller
    {
        // GET: ZXingNet
        public ActionResult Index()
        {
            return View();
        }
    }
}