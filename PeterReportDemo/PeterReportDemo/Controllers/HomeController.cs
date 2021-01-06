using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeterReportDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult DownloadFirstReport()
        {
            // rdlc
            var rdlcDirPath = System.Web.HttpContext.Current.Server.MapPath("~\\Reports");
            var rdlcName = "MyFirstReport.rdlc";
            var rptViewer = new ReportViewer();

            rptViewer.LocalReport.ReportPath = $@"{ rdlcDirPath }/{ rdlcName }";
            //這行可以將報表Render成PDF檔
            var bytes = rptViewer.LocalReport.Render("PDF", null,
                out string mimeType, out string encoding, out string fileNameExtension,
                out string[] streams, out Warning[] warnings);

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(bytes, 0, bytes.Length);
                return File(ms.ToArray(), "application/pdf");
            }
        }
    }
}