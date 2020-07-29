using FAMS_AngularApi.Models.PortfolioFact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static FAMS_AngularApi.Models.PortfolioFact.PortfolioFactModel;

namespace FAMS_AngularApi.Controllers
{
    public class PortfolioFactController : ApiController
    {
        PortfolioFactDAL Obj = new PortfolioFactDAL();


        [HttpPost]
        [Route("api/PortfolioFact/BindGrid/")]
        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            return Obj.BindGrid(Data);
        }

        [HttpPost]
        [Route("api/PortfolioFact/BindDefaultData")]
        public Dictionary<string, object> DefaultDataApi(GridFields Data)
        {
            return Obj.BindDefaultData(Data);
        }

        [HttpPost]
        [Route("api/PortfolioFact/BindNextData")]
        public Dictionary<string, object> BindNextDataApi(GridFields Data)
        {
            return Obj.BindNextData(Data);
        }
    }
}
