using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class TestController : ApiController
    {
        // GET api/Test/?url=www.google.com
        public IHttpActionResult Get(string url)
        {
            return Redirect(url);
        }
    }
}
