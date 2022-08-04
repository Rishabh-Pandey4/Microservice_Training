using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PassengerService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PassengerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        PassengerManager context = new PassengerManager();


        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = context.GetAllPassenger();
            return Ok(list);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PassengerModel obj = context.GetPassengerById(id);

            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(PassengerModel obj)
        {
            context.AddPassenger(obj);
            return Ok(obj);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, PassengerModel updatedobj)
        {
            bool a = context.UpdatePassenger(updatedobj);

            if (a == false)
            {
                NotFound();
            }

            return Ok(updatedobj);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool a = context.DeletePassenger(id);

            if (a == false)
                return NotFound();

            return Ok(id);
        }
    }
}
