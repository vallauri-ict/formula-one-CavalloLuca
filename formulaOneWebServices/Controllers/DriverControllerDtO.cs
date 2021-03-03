using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOneDLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace formulaOneWebServices
{
    [Route("api/DCDtO")]
    [ApiController]
    public class DriverControllerDtO : ControllerBase
    {
        [HttpGet]
        public IEnumerable<DriverDtO> GetDriversList()
        {
            DBtools d = new DBtools();
            return d.GetDriversList();
        }

        [HttpGet("number/{number}")] // GET /api/DCDtO/number/10
        public DriverDtOSpecifics GetDriverSpecifics(int number)
        {
            DBtools d = new DBtools();
            return d.GetDriverSpecifics(number);
        }

    }
}
