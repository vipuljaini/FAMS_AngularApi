using FAMS_AngularApi.Models.HoldingReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.SummaryReports;

namespace FAMS_AngularApi.Controllers
{
    public class HoldingReportsController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpPost]
        [Route("api/HoldingReports/BindGrid")]
        public Dictionary<string, object> BindGridApi(JasonFields Data)
        {
            return ObjDAL.BindGrid(Data);
        }
    }
}
