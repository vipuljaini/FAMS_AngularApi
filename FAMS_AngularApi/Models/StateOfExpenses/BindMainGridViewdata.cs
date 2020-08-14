using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.StateOfExpenses
{
    public class BindMainGridViewdata
    {
        public string SrNo { get; set; }        
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CustomerAccount { get; set; }
        public string Scheme { get; set; }
        public string DownloadLink { get; set; }
        public Int16 ReportType { get; set; }
        public string ReportName { get; set; }
        
    }
}