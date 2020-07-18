using FAMS_AngularApi.Models.CapitalStatement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class CapitalStatementController : ApiController
    {
        CapitalStatementDAL Obj = new CapitalStatementDAL();
        [HttpPost]
        [Route("api/CapitalStatement/BindGrid/")]
        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            return Obj.BindGrid(Data);
        }

        [HttpGet]
        [Route("api/CapitalStatement/DownloadExcel/")]
        public Dictionary<string, object> DownloadExcel()
        {
            return Obj.DownloadExcel();
        }


    }
}
