using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.PMSMaster
{
    public class PMSMaster
    {
        public Int64 PMSId { get; set; }
        public string PMSCode { get; set; }
        public string PMSName { get; set; }
        public string PMSAccountNumber { get; set; }
        public Int32 Result { get; set; }
        public Int64 SrNo { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}