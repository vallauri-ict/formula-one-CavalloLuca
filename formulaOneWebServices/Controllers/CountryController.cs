using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace formulaOneWebServices
{
    [Route("api/Country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        // GET: api/Country
        [HttpGet]
        public IEnumerable<Country> get_country()
        {
            DBtools db = new DBtools();
            return db.GetCountriesObj();
        }

        // GET: api/Country/it
        [HttpGet("{isoCode}", Name = "GetCountry")]
        public Country Get(string isoCode)
        {
            DBtools db = new DBtools();
            return db.GetCountry(isoCode);
        }

        // POST: api/Country
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Country/it
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
