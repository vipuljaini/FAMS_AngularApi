using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.AllCustomer;


namespace FAMS_AngularApi.Controllers
{
    public class AllCustomerController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpGet]
        [Route("api/AllCustomer/BindGrid/{UserId}")]
        public Dictionary<string, object> BindGridApi(string UserId)
        {
            return ObjDAL.BindGrid(UserId);
        }


        [HttpPost]
        [Route("api/AllCustomer/InsertCustomerDetails")]
        public Dictionary<string, object> SaveCustomerDetails(JsonCustomerDetails Data)
        {
            return ObjDAL.SaveCustomer(Data);
        }
    }
}
