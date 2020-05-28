using FAMS_AngularApi.Models.TrailBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class TrailBalanceController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpPost]
        [Route("api/TrailBalanceReports/BindGrid")]
        public Dictionary<string, object> BindGriidApi(JsonFields Data)
        {
            return ObjDAL.BindGrid(Data);
        }
    }
}
