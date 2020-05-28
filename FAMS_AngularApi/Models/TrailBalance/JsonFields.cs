using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.TrailBalance
{
    public class JsonFields
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CustomerAccount { get; set; }
        public string Accounts { get; set; }
        public string AccountSubLayer { get; set; }
    }
}