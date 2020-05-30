using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.Security;
using System.Threading.Tasks;

namespace FAMS_AngularApi.Controllers
{
    public class SecurityDetailsController : ApiController
    {
        // GET: SecurityDetails
        //public ActionResult Index()
        //{
        //    return View();
        //}
        SecurityDataAccessLayer objSecurityDetails = new SecurityDataAccessLayer();
        [HttpGet]
        [Route("api/SecurityDetails/BindCountry")]
        public Dictionary<string, object> BindCountry()
        {
            return objSecurityDetails.BindCountry();
        }

        [HttpGet]
        [Route("api/SecurityDetails/GetAllCustodian")]
        public Dictionary<string, object> GetAllCustodian()
        {
            return objSecurityDetails.GetAllCustodian();
        }

        [HttpGet]
        [Route("api/SecurityDetails/GetAllSector")]
        public Dictionary<string, object> GetAllSector()
        {
            return objSecurityDetails.GetAllSector();
        }

        [HttpGet]
        [Route("api/SecurityDetails/GetAllSecurity")]
        public Dictionary<string, object> GetAllSecurity()
        {
            return objSecurityDetails.GetAllSecurity();
        }

        [HttpGet]
        [Route("api/SecurityDetails/BindAllSecurityDetails")]
        public Dictionary<string, object> BindAllSecurityDetails()
        {
            return objSecurityDetails.GetAllSector();
        }

        [HttpPost]
        [Route("api/SecurityDetails/AddSecurityDetails")]
        public IEnumerable<Custodian> AddSecurityDetails([FromBody] SecurityDetails securityDetails, string UserId)
        {
            return objSecurityDetails.AddSecurityDetails(securityDetails, UserId);
        }
    }
}