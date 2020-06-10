using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.City
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
    public class State
    {
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }
    public class City
    {

        public Int64 CityId { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public Int32 Result { get; set; }
        public Int64 SrNo { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public string StateCode { get; set; }
        public string StateName { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}