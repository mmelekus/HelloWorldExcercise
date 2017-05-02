using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloWorldModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldAPI.Controllers
{
    [Route("api/[controller]")]
    public class WorldMessageController : Controller
    {
        // GET: api/WorldMessage
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new HelloWorldMessage() { Message = "Hello World!" });
        }
    }
}
