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
    }
}
