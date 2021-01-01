using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DoubleSelectDemoController : Controller
    {
        // GET: DoubleSelectDemo
        public ActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "changhua", Value = "changhua" });
            items.Add(new SelectListItem() { Text = "Taichung", Value = "Taichung" });

            ViewBag.ItemsForDDL_1 = items;
            ViewBag.ItemsForDDL_2 = new List<SelectListItem>();

            return View();
        }

        public ActionResult LetsGetItems(string DDL_1)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            switch (DDL_1)
            {
                case "changhua":
                    items.Add(new SelectListItem() { Text = "Yaunlin", Value = "Yaunlin" });
                    items.Add(new SelectListItem() { Text = "YoungJing", Value = "YoungJing" });
                    break;
                case "Taichung":
                    items.Add(new SelectListItem() { Text = "Taiping", Value = "Taiping" });
                    items.Add(new SelectListItem() { Text = "Beitun", Value = "Beitun" });
                    break;
                default:
                    break;
            }


            ViewBag.ItemsForDDL_2 = items;
            return PartialView();
        }
    }
}