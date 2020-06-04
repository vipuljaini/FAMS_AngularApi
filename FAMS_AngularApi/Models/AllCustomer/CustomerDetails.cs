using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.AllCustomer
{
    public class CustomerDetails
    {
        public Int64 UserId { get; set; }
        public Int64 Sno { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string AccountNo { get; set; }
        public string Active { get; set; }

        public string Password { get; set; }
        public string PasswordKey { get; set; }
    }
}