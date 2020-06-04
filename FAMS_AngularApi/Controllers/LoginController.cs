using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.Login;

namespace FAMS_AngularApi.Controllers
{
    public class LoginController : ApiController
    {
            Login objlogin = new Login();
            [HttpPost]
            [Route("api/Login/getlogindetails")]
            public IEnumerable<CommonFlag> getlogindetails([FromBody] Formdataget Login)
            {
                return objlogin.Binddetails(Login);
            }

        [HttpGet]
        [Route("api/Login/SentEmail/{email}")]
        public IEnumerable<EmailSent> SentEmail(string email)
        {
            return objlogin.SendMail(email);
        }
        [HttpPost]
        [Route("api/Login/Updatepassword")]
        public IEnumerable<ChangePasswordRes> Updatepassword([FromBody] ChangePasswordJsn Changepassword)
        {
            return objlogin.UpdatePassworddtail(Changepassword);
        }

        //[HttpPost]
        //[Route("api/Login/ChangePasswordForNewUser")]
        //public Dictionary<string, object> ChangePasswordForNewUser([FromBody] ChangePasswordJson Changepassword)
        //{
        //    //return objlogin.ChangePasswordForNewUser(Changepassword);
        //}
    }
}
