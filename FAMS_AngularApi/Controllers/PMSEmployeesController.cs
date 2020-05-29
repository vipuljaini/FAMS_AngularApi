using FAMS_AngularApi.Models.PMSEmployees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class PMSEmployeesController : ApiController 
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpPost]
        [Route("api/PMSEmployees/SaveData")]
        public Dictionary<string, object> SaveDataApi(JsonAllFields Data)
        {
            return ObjDAL.SaveData(Data);
        }
        [HttpGet]
        [Route("api/PMSEmployees/BindGrid")]
        public Dictionary<string, object> BindGridApi()
        {
            return ObjDAL.BindGrid();
        }
        [HttpGet]
        [Route("api/PMSEmployees/BindCustodian")]
        public Dictionary<string, object> BindCustodianApi()
        {
            return ObjDAL.BindCustodian();
        }
    }
}
