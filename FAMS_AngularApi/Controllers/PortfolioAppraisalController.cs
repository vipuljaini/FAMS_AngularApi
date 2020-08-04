using FAMS_AngularApi.Models.portfolioappraisal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class PortfolioAppraisalController : ApiController
    {



        PortfolioAppraisalDAL Obj = new PortfolioAppraisalDAL();
        [HttpPost]
        [Route("api/PortfolioAppraisal/BindGrid/")]
        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            return Obj.BindGrid(Data);
        }

    }
}
