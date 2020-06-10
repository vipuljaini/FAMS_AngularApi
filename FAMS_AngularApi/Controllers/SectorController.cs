using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.Sector;
using System.Threading.Tasks;

namespace FAMS_AngularApi.Controllers
{
    public class SectorController : ApiController
    {
        // GET: Sector
        //public ActionResult Index()
        //{
        //    return View();
        //}
        SectorDataAccessLayer objCountry = new SectorDataAccessLayer();
        [HttpGet]
        [Route("api/Sector/BindSector")]
        public Dictionary<string, object> BindSector()
        {
            return objCountry.BindSector();
        }

        [HttpPost]
        [Route("api/Sector/AddSector/{UserId}")]
        public IEnumerable<Sector> AddSector([FromBody] Sector Sector, string UserId)
        {
            return objCountry.AddSector(Sector, UserId);
        }


        [HttpPost]
        [Route("api/Sector/UpdateSector/{UserId}/{SectorId}")]
        public IEnumerable<Sector> UpdateSector([FromBody] Sector Sector, string UserId, string SectorId)
        {
            return objCountry.UpdateSector(Sector, UserId, SectorId);
        }


    }
}

