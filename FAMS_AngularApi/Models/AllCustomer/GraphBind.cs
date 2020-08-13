using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.AllCustomer
{
    public class GraphBind
    {
        public string Fromdate { get; set; }
        public string Todate { get; set; }
        public string AccountNo { get; set; }
        public string ReportType { get; set; }
        public string Linkid { get; set; }
    }
}