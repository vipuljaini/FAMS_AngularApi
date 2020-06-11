using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.HoldingReports
{
    public class Customer
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
    public class GridAllFields
    {
        public string PMSProvide { get; set; }
        public string CustomerAccount { get; set; }
        public string CustomerName { get; set; }
        public string Security { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> MarketValue { get; set; }
        public Nullable<decimal> GainLoss { get; set; }
        public Nullable<decimal> GainLossPer { get; set; }
        public Nullable<decimal> Assets { get; set; }
    }

    public class GridAllFields1
    {
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<decimal> TotalMarketValue { get; set; }
        public Nullable<decimal> TotalGainLoss { get; set; }
        public Nullable<decimal> TotalGLPerc { get; set; }
        public Nullable<decimal> TotalAssets { get; set; }
    }

    public class GridAllFields2
    {
        public string PMSProvide { get; set; }
        public string CustomerAccount { get; set; }
        public string CustomerName { get; set; }
        public string Security { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> MarketValue { get; set; }
        public Nullable<decimal> GainLoss { get; set; }
        public Nullable<decimal> GainLossPer { get; set; }
        public Nullable<decimal> Assets { get; set; }
    }

    public class GridAllFields3
    {
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<decimal> TotalMarketValue { get; set; }
        public Nullable<decimal> TotalGainLoss { get; set; }
        public Nullable<decimal> TotalGLPerc { get; set; }
        public Nullable<decimal> TotalAssets { get; set; }
    }

    public class GridAllFields4
    {
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<decimal> TotalMarketValue { get; set; }
        public Nullable<decimal> TotalGainLoss { get; set; }
        public Nullable<decimal> TotalGLPerc { get; set; }
        public Nullable<decimal> TotalAssets { get; set; }
    }

    public class GridAllFields5
    {
        //public string PMSProvide { get; set; }
        //public string CustomerAccount { get; set; }
        //public string CustomerName { get; set; }

        public string Security { get; set; }
        public string Quantity { get; set; }
        public string UnitCost { get; set; }
        public string Cost { get; set; }
        public string Price { get; set; }
        public string MarketValue { get; set; }
        public string GainLoss { get; set; }
        public string GainLossPer { get; set; }
        public string Assets { get; set; }
    }

}