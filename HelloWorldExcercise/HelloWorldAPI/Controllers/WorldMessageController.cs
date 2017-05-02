using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloWorldModels;
using Microsoft.Extensions.Options;
using FileAccess;
using HelloWorldInfrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldAPI.Controllers
{
    [Route("api/[controller]")]
    public class WorldMessageController : Controller
    {
        private IRepositoryKey<HelloWorldMessage, string> _repository;
        public WorldMessageController(IRepositoryKey<HelloWorldMessage, string> rep)
        {
            _repository = rep;
        }

        // GET: api/WorldMessage
        [HttpGet]
        public IActionResult Get()
        {
            var message = _repository.GetItem("1").FirstOrDefault();
            return Ok(message);
        }

        // GET api/WorldMessage/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var message = _repository.GetItem(id).FirstOrDefault();
            return Ok(message);
        }

        // POST api/WorldMessage
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/WorldMessage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/WorldMessage/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
