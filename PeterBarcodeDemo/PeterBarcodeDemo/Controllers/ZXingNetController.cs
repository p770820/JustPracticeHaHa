using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;

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

        public ActionResult Barcode()
        {
            BarcodeWriter bw = new BarcodeWriter();
            bw.Format = BarcodeFormat.CODE_39;
            bw.Options = new ZXing.Common.EncodingOptions()
            {
                Height = 250,
                Width = 370,
                Margin = 0
            };

            using (var stream = new MemoryStream())
            {
                var bmp = bw.Write("ABC1234");
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return File(stream.ToArray(), "image/jpeg");
            }
        }
    }
}