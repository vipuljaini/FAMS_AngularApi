using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.BankBook
{
    public class BindGridView
    {
        public Nullable<Int64> Srno { get; set; }
        public string ReportDate { get; set; }
        public string CustomerAccountNo { get; set; }
        public string DownloadLink { get; set; }
        public string ToDate { get; set; }




    }
}