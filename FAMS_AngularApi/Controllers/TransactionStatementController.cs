using FAMS_AngularApi.Models.TransactionStatement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class TransactionStatementController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpPost]
        [Route("api/TransactionStatement/BindGrid")]
        public Dictionary<string, object> BindGriidApi(JsonFields Data)
        {
            return ObjDAL.BindGrid(Data);
        }
    }
}
