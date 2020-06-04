using FAMS_AngularApi.Models;
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
        [HttpPost]
        [Route("api/PMSEmployees/BindGrid")]
        public Dictionary<string, object> BindGridApi(CommonFields Data)
        {
            return ObjDAL.BindGrid(Data);
        }
        [HttpPost]
        [Route("api/PMSEmployees/BindCustodian")] 
        public Dictionary<string, object> BindCustodianApi(CommonFields Data)
        {
            return ObjDAL.BindCustodian(Data);
        }
        [HttpGet]
        [Route("api/PMSEmployees/BindCustomers/{PMSEmpId}")]
        public Dictionary<string, object> BindCustomersApi(string PMSEmpId)
        {
            return ObjDAL.BindCustomers(PMSEmpId);
        }

    }
}
