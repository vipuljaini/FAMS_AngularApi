using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.Country
{
    public class Country
    {
        
        public Int64 SrNo { get; set; }
        
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
       

        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }

        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }

        public Int32 CountryID { get; set; }
        public Int32 Result { get; set; }
    }
}