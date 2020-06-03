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

        [HttpGet]
        [Route("api/Custodian/FillPMSDetails/{PMSCode}")]
        public Dictionary<string, object> FillPMSDetails(string PMSCode)
        {
            return objCustodian.FillPMSDetails(PMSCode);
        }


        [HttpGet]
        [Route("api/Custodian/GetAllPMSDetails/{CustodianId}")]
        public Dictionary<string, object> GetAllPMSDetails(string CustodianId)
        {
            return objCustodian.GetAllPMSDetails(CustodianId);
        }

        [HttpPost]
        [Route("api/Custodian/AddCustodian/{UserId}")]
        public IEnumerable<Custodian> AddCustodian([FromBody] Custodian custodian,string UserId)
        {
            return objCustodian.AddCustodian(custodian, UserId);
        }


        [HttpPost]
        [Route("api/Custodian/UpdateCustodian/{UserId}/{CustodianId}")]
        public IEnumerable<Custodian> UpdateCustodian([FromBody] Custodian custodian, string UserId,string CustodianId)
        {
            return objCustodian.UpdateCustodian(custodian, UserId, CustodianId);
        }


    }
}