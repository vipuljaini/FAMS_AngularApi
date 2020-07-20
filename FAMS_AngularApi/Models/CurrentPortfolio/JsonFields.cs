using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.CurrentPortfolio
{
    public class JsonFields
    {
        public string UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CustomerAccountNo { get; set; }//
    }
}