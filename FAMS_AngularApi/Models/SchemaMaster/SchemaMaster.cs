using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.SchemaMaster
{
    public class SchemaMaster
    {
        public Int64 SchemaMasterId { get; set; }
        public string PMSCode { get; set; }
        public string PMSName { get; set; }

        public string CustodianCode { get; set; }
        public string CustodianName { get; set; }

        
        public string SchemaNumber { get; set; }
        public Int32 Result { get; set; }
        public Int64 SrNo { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
    }
}