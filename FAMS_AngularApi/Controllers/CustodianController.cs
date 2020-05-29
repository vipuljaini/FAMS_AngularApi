using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.Custodian;
using System.Threading.Tasks;


namespace FAMS_AngularApi.Controllers
{
    public class CustodianController : ApiController
    {
        //// GET: Custodian
        //public ActionResult Index()
        //{
        //    return View();
        //}
        CustodianDataAccessLayer objCustodian = new CustodianDataAccessLayer();
        [HttpGet]
        [Route("api/Custodian/BindCountry")]
        public Dictionary<string, object> BindCountry()
        {
            return objCustodian.BindCountry();
        }

        [HttpGet]
        [Route("api/Custodian/BindPMS")]
        public Dictionary<string, object> BindPMS()
        {
            return objCustodian.BindPMS();
        }

        [HttpGet]
        [Route("api/Custodian/GetAllCustodian")]
        public Dictionary<string, object> GetAllCustodian()
        {
            return objCustodian.GetAllCustodian();
        }

        [HttpPost]
        [Route("api/Custodian/AddCustodian")]
        public IEnumerable<Custodian> AddCustodian([FromBody] Custodian custodian,string UserId)
        {
            return objCustodian.AddCustodian(custodian, UserId);
        }


    }
}