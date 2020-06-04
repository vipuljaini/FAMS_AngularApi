using FAMS_AngularApi.Models;
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
        [Route("api/SummaryReports/BindGrid")]
        public Dictionary<string, object> BindGriidApi(JasonFields Data)
        {
            return ObjSRDA.BindGrid(Data);
        }
        [HttpPost]
        [Route("api/SummaryReports/BindCustomers")]
        public Dictionary<string, object> BindCustomersApi(CommonFields Data)
        {
            return ObjSRDA.BindCustomers(Data);
        }
    }
}
