using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.SummaryReports
{
    public class GridAllFields
    {
        public Nullable<decimal> OpeningMarketValue { get; set; }
        public Nullable<decimal> OpeningNAV { get; set; }
        public Nullable<decimal> OpeningOutstandingUnits { get; set; }
        public Nullable<decimal> CapitalInOut { get; set; }
        public Nullable<decimal> RealizedGain { get; set; }
        public Nullable<decimal> UnrealizedGain { get; set; }
        public Nullable<decimal> GainPrior { get; set; }
        public Nullable<decimal> Income { get; set; }
        public Nullable<decimal> Fees { get; set; }
        public Nullable<decimal> Expenses { get; set; }
        public Nullable<decimal> AccruedIncome { get; set; }
        public Nullable<decimal> ClosingMarketValue { get; set; }
        public Nullable<decimal> ClosingNAV { get; set; }
        public Nullable<decimal> ClosingOutstanding { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }


        public string CustomerAccountNo { get; set; }
        public string CustomerName { get; set; }

    }
}