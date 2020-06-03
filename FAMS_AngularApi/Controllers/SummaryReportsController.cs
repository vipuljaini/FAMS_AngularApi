using FAMS_AngularApi.Models.SummaryReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class SummaryReportsController : ApiController
    {
        SummaryReportsDataAccess ObjSRDA = new SummaryReportsDataAccess();
        [HttpPost]
        [Route("api/SummaryReports/BindGrid/{UserId}")]
        public Dictionary<string, object> BindGriidApi(JasonFields Data, string UserId)
        {
            return ObjSRDA.BindGrid(Data, UserId);
        }
        [HttpGet]
        [Route("api/SummaryReports/BindCustomers/{UserId}")]
        public Dictionary<string, object> BindCustomersApi(string UserId)
        {
            return ObjSRDA.BindCustomers(UserId);
        }
    }
}
