using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.PortfolioSummary
{
    //public class BindMainGrid
    //{
    //}

    public class BindmaingridHeader // fOR HEADING IN CENTER
    {
        public string Date { get; set; }
    }
    public class BindPortfolioAllocation
    {
        public string Description { get; set; }
        public string PerAsstes { get; set; }
        public string MarketValue { get; set; }
    }

    public class BindPortfolioSummary
    {
        public string Heading { get; set; }
        public string Data { get; set; }
    }

    public class BindPortfolioPerformance
    {
        public string Period { get; set; }
        public string Portfolio { get; set; }
        public string NIFTY { get; set; }
        public string BSE500 { get; set; }
    }




    public class PortfolioSummary_Default
    {
        public string CustomerAccount { get; set; }
        public string AsOnDate { get; set; }
        public string SeqNo { get; set; }
    }

    public class BindPortfolioAllocationTotal
    {
        public string Total { get; set; }
        public string PerAsstes { get; set; }
        public string MarketValue { get; set; }
    }

}