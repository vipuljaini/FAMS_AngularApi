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
        [HttpPost]
        [Route("api/AllCustomer/BindGrid")]
        public Dictionary<string, object> BindGridApi(JsonUserDetails Data)
        {
            return ObjDAL.BindGrid(Data);
        }


        [HttpPost]
        [Route("api/AllCustomer/InsertCustomerDetails")]
        public Dictionary<string, object> SaveCustomerDetails(JsonCustomerDetails Data)
        {
            return ObjDAL.SaveCustomer(Data);
        }
    }
}
