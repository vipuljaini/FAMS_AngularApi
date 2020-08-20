using FAMS_AngularApi.Models.AutoReportRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class AutoReportRequestController : ApiController
    {
        AutoReportRequest objmandate = new AutoReportRequest();
        // GET: AutoReportRequest
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        [Route("api/AutoReportRequest/SaveAutoReportRequest")]
        public Dictionary<string, object> SaveAutoReportRequest(HttpRequestMessage EData)
        {
            var reqData = EData.Content.ReadAsStringAsync().Result;
            return objmandate.SaveAutoReportRequest(reqData);
        }


        [HttpPost]
        [Route("api/AutoReportRequest/BindAutoReportRequest")]
        public Dictionary<string, object> BindAutoReportRequest(JsonFields Data)
        {
            return objmandate.BindAutoReportRequest(Data);
        }

        [HttpGet]
        [Route("api/AutoReportRequest/BindAllAutoReportRequest")]
        public Dictionary<string, object> BindAllAutoReportRequest()
        {
            return objmandate.BindAllAutoReportRequest();
        }
    }
}