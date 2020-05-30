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
        [Route("api/PMSEmployees/SaveData/{UserId}")]
        public Dictionary<string, object> SaveDataApi(JsonAllFields Data, string UserId)
        {
            return ObjDAL.SaveData(Data, UserId);
        }
        [HttpGet]
        [Route("api/PMSEmployees/BindGrid/{UserId}")]
        public Dictionary<string, object> BindGridApi(string UserId)
        {
            return ObjDAL.BindGrid(UserId);
        }
        [HttpGet]
        [Route("api/PMSEmployees/BindCustodian/{UserId}")]
        public Dictionary<string, object> BindCustodianApi(string UserId)
        {
            return ObjDAL.BindCustodian(UserId);
        }

    }
}
