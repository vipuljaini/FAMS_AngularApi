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

        [HttpPost]
        [Route("api/CapitalStatement/BindDefaultData")]
        public Dictionary<string, object> DefaultDataApi(GridFields Data)
        {
            return Obj.BindDefaultData(Data);
        }

        [HttpPost]
        [Route("api/CapitalStatement/BindEmployees")]
        public Dictionary<string, object> BindEmployeesApi(GridFields Data)
        {
            return Obj.BindEmployees(Data);
        }


        [HttpGet]
        [Route("api/CapitalStatement/BindCustomers/{UserId}")]
        public Dictionary<string, object> BindCustomers(string UserId)
        {
            return Obj.BindCustomers(UserId);
        }


        [HttpPost]
        [Route("api/CapitalStatement/BindNextData")]
        public Dictionary<string, object> BindNextDataApi(GridFields Data)
        {
            return Obj.BindNextData(Data);
        }





    }
}
