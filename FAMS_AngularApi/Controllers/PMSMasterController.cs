using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.PMSMaster;
using System.Threading.Tasks;

namespace FAMS_AngularApi.Controllers
{
    public class PMSMasterController : ApiController
    {
        // GET: PMSMaster
        //public ActionResult Index()
        //{
        //    return View();
        //}

        PMSMasterDataAccessLayer objCountry = new PMSMasterDataAccessLayer();
        [HttpGet]
        [Route("api/PMSMaster/BindPMSMaster")]
        public Dictionary<string, object> BindPMSMaster()
        {
            return objCountry.BindPMSMaster();
        }

        [HttpPost]
        [Route("api/PMSMaster/AddPMSMaster/{UserId}")]
        public IEnumerable<PMSMaster> AddPMSMaster([FromBody] PMSMaster PMSMaster, string UserId)
        {
            return objCountry.AddPMSMaster(PMSMaster, UserId);
        }


        [HttpPost]
        [Route("api/PMSMaster/UpdatePMSMaster/{UserId}/{PMSId}")]
        public IEnumerable<PMSMaster> UpdatePMSMaster([FromBody] PMSMaster PMSMaster, string UserId, string PMSId)
        {
            return objCountry.UpdatePMSMaster(PMSMaster, UserId, PMSId);
        }

    }
}