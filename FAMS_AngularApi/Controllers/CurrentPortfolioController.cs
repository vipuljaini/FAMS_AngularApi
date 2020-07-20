using System;
using FAMS_AngularApi.Models.CurrentPortfolio;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class CurrentPortfolioController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpPost]
        [Route("api/CurrentPortfolio/BindGrid")]
        public Dictionary<string, object> BindGriidApi(JsonFields Data)
        {
            return ObjDAL.BindGrid(Data);
        }
    }
}
