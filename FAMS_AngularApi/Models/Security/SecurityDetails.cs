using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.Security
{
    public class SecurityDetails
    {
        public Int32 Result { get; set; } 
        public Int64 SrNo { get; set; }
        public string CountryName { get; set; }
        public string CustodianName { get; set; }

        public string CountryCode { get; set; }
        public string CustodianCode { get; set; }
        public string SecurityCode { get; set; }
        public string SectorCode { get; set; }

        public string ListCode { get; set; }
        public string NAME { get; set; }
        public string Active { get; set; }
        
    }
}