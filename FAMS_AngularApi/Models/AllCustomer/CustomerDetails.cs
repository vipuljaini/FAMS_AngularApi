using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.AllCustomer
{
    public class CustomerDetails
    {
        public string UserId { get; set; }
        public string Sno { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string AccountNo { get; set; }
        public string Active { get; set; }

        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public string Flag { get; set; }
        public string FlagValue { get; set; }
    }
}