using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace formulaOneWebServices
{
    [Route("api/Driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        // GET: api/Driver
        [HttpGet]
        public IEnumerable<Driver> get_driver()
        {
            DBtools db = new DBtools();
            return db.GetDriversObj();
        }

        /*// GET: api/Driver/10
        [HttpGet("{number}")]
        public Driver GetNumber(int number)
        {
            DBtools db = new DBtools();
            return db.GetDriver(number);
        }*/

        [HttpGet("number/{number}")] // GET /api/driver/number/10
        public Driver GetDriverFromNumber(int number)
        {
            DBtools d = new DBtools();
            return d.GetDriver_number(number);
        }

        [HttpGet("name/{name}")] // GET /api/driver/name/Lewis Hamilton
        public Driver GetDriverFromName(string name)
        {
            DBtools d = new DBtools();
            return d.GetDriver_name(name);
        }

        // POST: api/Driver
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Driver/it
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/it
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
