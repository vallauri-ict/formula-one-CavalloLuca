using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace formulaOneWebServices
{
    [Route("api/TCDtO")]
    [ApiController]
    public class TeamControllerDtO : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TeamDtO> GetTeamsList()
        {
            DBtools d = new DBtools();
            return d.GetTeamsList();
        }

        [HttpGet("id/{id}")] // GET /api/TCDtO/id/1
        public TeamDtOSpecifics GetTeamSpecifics(int id)
        {
            DBtools d = new DBtools();
            return d.GetTeamSpecifics(id);
        }

    }
}
