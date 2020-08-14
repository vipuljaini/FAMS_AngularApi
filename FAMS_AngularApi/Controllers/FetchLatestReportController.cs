using FAMS_AngularApi.Models.FetchLatestReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace FAMS_AngularApi.Controllers
{
    public class FetchLatestReportController : ApiController
    {
        //// GET: FetchLatestReport
        //public ActionResult Index()
        //{
        //    return View();
        //}
        FetchLatestDataAccessLayer ObjDAL = new FetchLatestDataAccessLayer();
        [HttpPost]
        [Route("api/FetchLatestReport/GetFetchLatestReport")]
        public Dictionary<string, object> GetFetchLatestReport(FetchLatestReport Data)
        {
            return ObjDAL.GetFetchLatestReport(Data);
        }
    }
}