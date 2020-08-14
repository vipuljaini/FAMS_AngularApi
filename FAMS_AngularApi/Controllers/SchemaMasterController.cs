using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.SchemaMaster;
using System.Threading.Tasks;


namespace FAMS_AngularApi.Controllers
{
    public class SchemaMasterController : ApiController
    {
        // GET: SchemaMaster
        //public ActionResult Index()
        //{
        //    return View();
        //}
        SchemaDataAccessLayer objCountry = new SchemaDataAccessLayer();

        [HttpGet]
        [Route("api/SchemaMaster/BindAllCustomer")]
        public Dictionary<string, object> BindAllCustomer()
        {
            return objCountry.BindAllCustomer();
        }

        
        [HttpGet]
        [Route("api/SchemaMaster/BindSchemaMaster")]
        public Dictionary<string, object> BindSchemaMaster()
        {
            return objCountry.BindSchemaMaster();
        }

        [HttpGet]
        [Route("api/SchemaMaster/BindSchemaMasterDetails/{SchemaMasterId}")]
        public Dictionary<string, object> BindSchemaMasterDetails(string SchemaMasterId)
        {
            return objCountry.BindSchemaMasterDetails(SchemaMasterId);
        }


        [HttpPost]
        [Route("api/SchemaMaster/AddSchemaMaster/{UserId}")]
        public IEnumerable<SchemaMaster> AddSchemaMaster([FromBody] SchemaMaster SchemaMaster, string UserId)
        {
            return objCountry.AddSchemaMaster(SchemaMaster, UserId);
        }


        [HttpPost]
        [Route("api/SchemaMaster/UpdateSchemaMaster/{UserId}/{SchemeMasterId}")]
        public IEnumerable<SchemaMaster> UpdateSchemaMaster([FromBody] SchemaMaster SchemaMaster, string UserId, string SchemeMasterId)
        {
            return objCountry.UpdateSchemaMaster(SchemaMaster, UserId, SchemeMasterId);
        }
    }
}