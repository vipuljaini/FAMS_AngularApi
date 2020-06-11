using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.Designation;
using System.Threading.Tasks;

namespace FAMS_AngularApi.Controllers
{
    public class DesignationController : ApiController
    {
        // GET: Designation
        //public ActionResult Index()
        //{
        //    return View();
        //}
        DesignationDataAccessLayer objCountry = new DesignationDataAccessLayer();
        [HttpGet]
        [Route("api/Designation/BindDesignation")]
        public Dictionary<string, object> BindDesignation()
        {
            return objCountry.BindDesignation();
        }

        [HttpPost]
        [Route("api/Designation/AddDesignation/{UserId}")]
        public IEnumerable<Designation> AddDesignation([FromBody] Designation Designation, string UserId)
        {
            return objCountry.AddDesignation(Designation, UserId);
        }


        [HttpPost]
        [Route("api/Designation/UpdateDesignation/{UserId}/{DesignationId}")]
        public IEnumerable<Designation> UpdateDesignation([FromBody] Designation Designation, string UserId, string DesignationId)
        {
            return objCountry.UpdateDesignation(Designation, UserId, DesignationId);
        }


    }
}
