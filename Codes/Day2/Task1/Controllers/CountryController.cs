using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task1.Models;

namespace Task1.Controllers
{
    [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {
        static List<Country> countrylist = new List<Country>()
        {
            new Country{Id=1, Countryname="India",Capital="Delhi"},
            new Country{Id=2, Countryname="USA",Capital="Washington DC"},
            new Country{Id=3, Countryname="UK",Capital="London"},
            new Country{Id=4, Countryname="France",Capital="Paris"},
        };

        [HttpGet]
        [Route("Listall")] // http://localhost:64515/api/Country/Listall 
        public IHttpActionResult ListAllCountries()
        {
            if (countrylist is null)
                return NotFound();

            return Ok(countrylist);
        }

        [HttpGet]
        [Route("GetById/{id}")] //http://localhost:64515/api/Country/GetById/1
        public IHttpActionResult GetById(int id)
        {
            Country obj = countrylist.Find(item => item.Id == id);

            if (countrylist is null)
                return NotFound();

            return Ok(obj);
        }

        [HttpPost] // http://localhost:64515/api/Country/AddCountry
        public IHttpActionResult AddCountry([FromBody] Country obj)
        {
            if(obj != null)
            {
                countrylist.Add(obj);
                return Ok(obj);
            }

            return NotFound();
        }

        [HttpPut]
        [Route("UpdateCountry/{id}")] //http://localhost:64515/api/Country/UpdateCountry/5
        public IHttpActionResult UpdateCountry([FromBody] Country updatedobj)
        {
            //countrylist[updatedobj.Id - 1] = updatedobj;

            foreach(Country c in countrylist)
            {
                if (updatedobj.Id == c.Id)
                {
                    c.Countryname = updatedobj.Countryname;
                    c.Capital = updatedobj.Countryname;
                }
            }
            return Ok(updatedobj);
        }

        [HttpDelete]
        [Route("DeleteById/{id}")] //http://localhost:64515/api/Country/DeleteById/5
        public IHttpActionResult DeleteById(int id)
        {
            Country obj = countrylist.Find(item => item.Id == id);

            if (countrylist != null)
            {
                bool isRemoved = countrylist.Remove(obj);
                if (isRemoved)
                    return Ok(obj);
            }
            
            return NotFound();            
        }
    }
}
