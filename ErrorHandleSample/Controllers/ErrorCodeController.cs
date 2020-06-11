using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandleSample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorCodeController : ControllerBase
    {
        public IActionResult Get(string code)
        {
            // logger
            return BadRequest($"Error, status code: {code}");
        }
    }
}