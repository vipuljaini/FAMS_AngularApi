using FAMS_AngularApi.Models.PortfolioSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class PortfolioSummaryController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpPost]
        [Route("api/PortfolioSummary/BindGrid")]
        public Dictionary<string, object> BindGriidApi(JsonFields Data)
        {
            return ObjDAL.BindGrid(Data);
        }

        [HttpGet]
        [Route("api/PortfolioSummary/BindDefaultData/{CustomerAccount}/{GUserId}")]
        public Dictionary<string, object> BindDefaultData(string CustomerAccount, string GUserId)
        {
            return ObjDAL.BindDefaultData(CustomerAccount, GUserId);
        }


    }
}