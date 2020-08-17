using FAMS_AngularApi.Models;
using FAMS_AngularApi.Models.BankBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class BankBookController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpPost]
        [Route("api/BankBook/BindGrid")]
        public Dictionary<string, object> BindGriidApi(JsonData Data)
        {
            return ObjDAL.BindGrid(Data);
        }

        [HttpPost]
        [Route("api/BankBook/BindEmployees")]
        public Dictionary<string, object> BindEmployeesApi(JsonData Data)
        {
            return ObjDAL.BindEmployees(Data);
        }

        [HttpPost]
        [Route("api/BankBook/BindDefaultData")]
        public Dictionary<string, object> DefaultDataApi(DefaultJson Data)
        {
            return ObjDAL.BindDefaultData(Data);
        }

        [HttpPost]
        [Route("api/BankBook/BindCustomers")]
        public Dictionary<string, object> BindCustomersApi(JsonData Data)
        {
            return ObjDAL.BindCustomers(Data);
        }

        [HttpPost]
        [Route("api/BankBook/BindNextData")]
        public Dictionary<string, object> BindNextDataApi(JsonData Data)
        {
            return ObjDAL.BindNextData(Data);
        }

        [HttpPost]
        [Route("api/BankBook/BindGridView")]
        public Dictionary<string, object> BindGridViewApi(JsonData Data)
        {
            return ObjDAL.BindGridView(Data);
        }

        [HttpPost]
        [Route("api/BankBook/BindGridOncustomerchange")]
        public Dictionary<string, object> BindGridOncustomerchangeApi(JsonData Data)
        {
            return ObjDAL.BindGridOncustomerchange(Data);
        }
    }
}
