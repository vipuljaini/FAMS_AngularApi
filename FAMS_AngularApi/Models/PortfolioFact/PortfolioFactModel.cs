using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.PortfolioFact
{
    public class PortfolioFactModel
    {

        public class GridFields
        {
            public string fromdate { get; set; }
            public string PageCount { get; set; }
            public string todate { get; set; }
            public string UserId { get; set; }//UserId
            public string CustomerAccountNo { get; set; }

        }

        public class SectorAllocation
        {
            public Nullable<Int64> SeqNum1 { get; set; }
            public string Sector { get; set; }
            public Nullable<decimal> Asstes { get; set; }
        }



        public class HDATE
        {
            public string Data { get; set; }
        }

        public class SUMSectorAllocation
        {
            public Nullable<decimal> SumAsstes { get; set; }
            public Nullable<Int32> Total { get; set; }

        }

        public class PortfolioHolding
        {
            public Nullable<Int64> SeqNum1 { get; set; }
            public string Security { get; set; }
            public string Sector { get; set; }
            public Nullable<decimal> MktValue { get; set; }
            public Nullable<decimal> PerAssets { get; set; }
        }


        public class SUMPortfolioHolding
        {

            public Nullable<decimal> SumMktValue { get; set; }
            public Nullable<decimal> SumPerAssets { get; set; } //Total
            public Nullable<Int32> Total { get; set; }
        }

        public class portfolioSummary
        {
            
            public string Heading { get; set; }
            public string Data { get; set; }

        }
        public class PortfolioPerformance
        {
            
            public string Heading { get; set; }
            public string Data1 { get; set; }
            public string Data2 { get; set; }
            public string Data3 { get; set; }
            public string Data4 { get; set; }
            public string Data5 { get; set; }

        }

        public class PageLoadData
        {
            public string CustomerCode { get; set; }
            public string CustomerAccountNo { get; set; }
            public string AsOnDate { get; set; }//AsOnDate

        }
    }
}