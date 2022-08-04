using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriverService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DriverService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        DriverManager context = new DriverManager();

        // GET: api/<DriverController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = context.GetAllDrivers();
            return Ok(list);
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DriverModel obj = context.GetDriverById(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        // POST api/<DriverController>
        [HttpPost]
        public IActionResult Post(DriverModel obj)
        {
            context.AddDriver(obj);
            return Ok(obj);
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")] 
        public IActionResult Put(int id, DriverModel updatedobj)
        {
            
            bool a = context.UpdateDriver(updatedobj);

            if (a == false)
                return NotFound();

            return Ok(updatedobj);
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            bool a  = context.DeleteDriver(id);
            if (a == false)
                return NotFound();

            return Ok(id);
        }
    }
}
