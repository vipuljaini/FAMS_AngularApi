using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.TrailBalance
{
    public class GridAllFields
    {
        public Nullable<Decimal> OBDebit { get; set; }
        public Nullable<Decimal> OBCredit { get; set; }
        public Nullable<Decimal> TransDebit { get; set; }
        public Nullable<Decimal> TransCredit { get; set; }
        public Nullable<Decimal> CBCredit { get; set; }
        public Nullable<Decimal> CBDebit { get; set; }
    }
}