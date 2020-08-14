using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.StateOfExpenses
{
    public class PrimaryDetails
    {
        public string userType { get; set; }
        public string UserId { get; set; }
        public string accountNumber { get; set; }
        public string ReportName { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }

    }
}