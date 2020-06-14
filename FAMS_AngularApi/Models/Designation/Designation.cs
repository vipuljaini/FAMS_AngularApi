using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.Designation
{
    public class Designation
    {
        public Int32 DesignationId { get; set; }
        public string DesignationCode { get; set; }
        public string DesignationName { get; set; }
        public Int32 Result { get; set; }  
        public Int64 SrNo { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }

   
    
}