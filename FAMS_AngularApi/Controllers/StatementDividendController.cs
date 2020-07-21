using FAMS_AngularApi.Models.StatementDivident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class StatementDividendController : ApiController
    {

        StatementDividentDAL Obj = new StatementDividentDAL();

        [HttpPost]
        [Route("api/StatementDividend/BindGrid/")]
        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            return Obj.BindGrid(Data);
        }
    }
}
