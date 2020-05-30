using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace MakeHttpSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClient;
        public BaseController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> CallSkilltree()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://skilltree.my");
            var client = _httpClient.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return Content(result, new MediaTypeHeaderValue("text/html"));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}