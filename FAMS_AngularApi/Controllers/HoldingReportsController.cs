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

        [HttpGet]
        [Route("api/HoldingReports/BindCustomer")]
        public Dictionary<string, object> BindCustomer()
        {
            return ObjDAL.BindCustomer();
        }
        //[HttpPost]
        //[Route("api/HoldingReports/BindGridAllFields")]
        //public Dictionary<string, object> BindGridApi(JasonFields Data)
        //{
        //    return ObjDAL.BindGrid(Data);
        //}

        [HttpGet]
        [Route("api/HoldingReports/BindGridAllFields/{CustomerAccount}/{UserId}")]
        public Dictionary<string, object> BindGridApi(string CustomerAccount,string UserId)
        {
            return ObjDAL.BindGrid(CustomerAccount,UserId);
        }
    }
}
