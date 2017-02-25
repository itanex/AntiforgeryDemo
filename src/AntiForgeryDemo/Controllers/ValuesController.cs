using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AntiForgeryDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(string data)
        {
            return Ok(data);
        }
    }
}
