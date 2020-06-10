using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.Country;
using System.Threading.Tasks;

namespace FAMS_AngularApi.Controllers
{
    public class CountryController : ApiController
    {
        // GET: Country
        //public ActionResult Index()
        //{
        //    return View();
        //}

        CountryDataAccessLayer objCountry = new CountryDataAccessLayer();
        [HttpGet]
        [Route("api/Country/BindCountry")]
        public Dictionary<string, object> BindCountry()
        {
            return objCountry.BindCountry();
        }

        [HttpPost]
        [Route("api/Country/AddCountry/{UserId}")]
        public IEnumerable<Country> AddCountry([FromBody] Country country, string UserId)
        {
            return objCountry.AddCountry(country, UserId);
        }


        [HttpPost]
        [Route("api/Country/UpdateCountry/{UserId}/{CountryId}")]
        public IEnumerable<Country> UpdateCountry([FromBody] Country country, string UserId, string CountryId)
        {
            return objCountry.UpdateCountry(country, UserId, CountryId);
        }


    }
}
    