using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.TBStructure
{
    public class TBStructure
    {
        public Int32 Result { get; set; }
        public Int64 SrNo { get; set; }
        public string CountryName { get; set; }
        public string CustodianName { get; set; }

        public string CountryCode { get; set; }
        public string CustodianCode { get; set; }     
      

        public string ListCode { get; set; }
        public string ListName { get; set; }
        public string Active { get; set; }
        public Int64 TBStructureId { get; set; }
        public string ParentCode { get; set; }
        public string ParentName { get; set; }
        public string TBHeadCode { get; set; }
        public string TBHeadName { get; set; }
    }

    public class Parent
    {
        public string ParentCode { get; set; }
        public string ParentName { get; set; }
    }

    public class TBStructureDetails
    {
        public Int32 Result { get; set; }
        public Int64 SrNo { get; set; }
       
        public string TBHeadCode { get; set; }
        public string TBHeadName { get; set; }
        public string ParentCode { get; set; }
        public string ParentName { get; set; }


        public string Active { get; set; }
        public Int64 TBStructureDetId { get; set; }



    }
}