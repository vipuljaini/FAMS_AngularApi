using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.State;
using System.Threading.Tasks;

namespace FAMS_AngularApi.Controllers
{
    public class StateController : ApiController
    {
        // GET: State
        //public ActionResult Index()
        //{
        //    return View();
        //}
        StateDataAccessLayer objCountry = new StateDataAccessLayer();
        [HttpGet]
        [Route("api/State/BindState")]
        public Dictionary<string, object> BindState()
        {
            return objCountry.BindState();
        }

        [HttpPost]
        [Route("api/State/AddState/{UserId}")]
        public IEnumerable<State> AddState([FromBody] State State, string UserId)
        {
            return objCountry.AddState(State, UserId);
        }


        [HttpPost]
        [Route("api/State/UpdateState/{UserId}/{StateId}")]
        public IEnumerable<State> UpdateState([FromBody] State State, string UserId, string StateId)
        {
            return objCountry.UpdateState(State, UserId, StateId);
        }


    }
}
