using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace formulaOneWebServices
{
    [Route("api/Team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        // GET: api/Team
        [HttpGet]
        public IEnumerable<Team> get_country()
        {
            DBtools db = new DBtools();
            return db.GetTeamsObj();
        }

        /*// GET: api/Team/id
        [HttpGet("{ID}", Name = "GetTeam")]
        public Team Get(int id)
        {
            DBtools db = new DBtools();
            return db.GetTeam(id);
        }*/

        [HttpGet("id/{id}")] // GET /api/team/id/1
        public Team GetDriverFromNumber(int id)
        {
            DBtools d = new DBtools();
            return d.GetTeam_id(id);
        }

        [HttpGet("teamname/{teamname}")] // GET /api/team/teamName/Mercedes-AMG Petronas F1 Team
        public Team GetDriverFromName(string teamname)
        {
            DBtools d = new DBtools();
            return d.GetTeam_teamname(teamname);
        }

        // POST: api/Team
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Team/it
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
