using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.Custodian
{
    public class Custodian
    {
       
        public Int32 Result { get; set; }
        public Int64 SrNo { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CustodianCode { get; set; }
        public string CustodianName { get; set; }

        public string PMSCode { get; set; }
        public string PMSName { get; set; }
        public string PMSAccountNumber { get; set; }
        public Boolean Active { get; set; }
        public Int64 CustodianId { get; set; }
    }
}