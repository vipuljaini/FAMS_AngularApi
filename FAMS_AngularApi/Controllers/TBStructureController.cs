using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.Security;
using FAMS_AngularApi.Models.TBStructure;
using System.Threading.Tasks;
namespace FAMS_AngularApi.Controllers
{
    public class TBStructureController : ApiController
    {
        // GET: TBStructure
        //public ActionResult Index()
        //{
        //    return View();
        //}
        SecurityDataAccessLayer objSecurityDetails = new SecurityDataAccessLayer();
        TBStructureDataAccessLayer objTBStructure = new TBStructureDataAccessLayer();
        [HttpGet]
        [Route("api/TBStructure/BindCountry")]
        public Dictionary<string, object> BindCountry()
        {
            return objSecurityDetails.BindCountry();
        }

        [HttpGet]
        [Route("api/TBStructure/GetAllCustodian")]
        public Dictionary<string, object> GetAllCustodian()
        {
            return objSecurityDetails.GetAllCustodian();
        }

        [HttpGet]
        [Route("api/TBStructure/GetAllParent")]
        public Dictionary<string, object> GetAllParent()
        {
            return objTBStructure.GetAllParent();
        }

        [HttpGet]
        [Route("api/TBStructure/GetAllTBStructure")]
        public Dictionary<string, object> GetAllTBStructure()
        {
            return objTBStructure.BindAllTBStructure();
        }

       

        [HttpGet]
        [Route("api/TBStructure/GetAllTBStructureDetails/{TBStructureId}")]
        public Dictionary<string, object> GetAllTBStructureDetails(string TBStructureId)
        {
            return objTBStructure.BindAllTBStructureDetails(TBStructureId);
        }

      

        [HttpPost]
        [Route("api/TBStructure/AddTBStructure/{UserId}")]
        public IEnumerable<TBStructure> AddTBStructure([FromBody] TBStructure TBStructure, string UserId)
        {
            return objTBStructure.AddTBStructure(TBStructure, UserId);
        }

        [HttpPost]
        [Route("api/TBStructure/UpdateTBStructure/{UserId}/{TBStructureId}")]
        public IEnumerable<TBStructure> UpdateTBStructure([FromBody] TBStructure TBStructure, string UserId, string TBStructureId)
        {
            return objTBStructure.UpdateTBStructure(TBStructure, UserId, TBStructureId);
        }
    }
}