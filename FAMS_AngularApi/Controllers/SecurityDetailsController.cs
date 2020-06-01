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
        [Route("api/SecurityDetails/GetAllSecurityCodeDetails")]
        public Dictionary<string, object> GetAllSecurityCodeDetails()
        {
            return objSecurityDetails.GetAllSecurityCodeDetails();
        }

        [HttpGet]
        [Route("api/SecurityDetails/GetAllSecurity/{SecurityDetailsId}")]
        public Dictionary<string, object> GetAllSecurity(string SecurityDetailsId)
        {
            return objSecurityDetails.GetAllSecurity(SecurityDetailsId);
        }

        [HttpGet]
        [Route("api/SecurityDetails/BindAllSecurityDetails")]
        public Dictionary<string, object> BindAllSecurityDetails()
        {
            return objSecurityDetails.BindAllSecurityDetails();
        }

        [HttpGet]
        [Route("api/SecurityDetails/FillSecurityCodeDetails/{SecurityCode}")]
        public Dictionary<string, object> FillSecurityCodeDetails(string SecurityCode)
        {
            return objSecurityDetails.FillSecurityCodeDetails(SecurityCode);
        }

        [HttpPost]
        [Route("api/SecurityDetails/AddSecurityDetails/{UserId}")]
        public IEnumerable<Custodian> AddSecurityDetails([FromBody] SecurityDetails securityDetails, string UserId)
        {
            return objSecurityDetails.AddSecurityDetails(securityDetails, UserId);
        }
    }
}