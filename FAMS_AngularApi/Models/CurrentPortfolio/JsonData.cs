using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.CurrentPortfolio
{
    public class JsonData
    {
        public string UserId { get; set; }
        public string ReportDate { get; set; }
        public string CustomerAccount { get; set; }
        public string PageCount { get; set; }
    }
}