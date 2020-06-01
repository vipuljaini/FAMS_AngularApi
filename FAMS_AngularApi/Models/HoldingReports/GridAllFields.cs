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
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal MarketValue { get; set; }
        public decimal GainLoss { get; set; }
        public decimal GainLossPer { get; set; }
        public decimal Assets { get; set; }
    }

    public class GridAllFields1
    {
        public decimal TotalCost { get; set; }
        public decimal TotalMarketValue { get; set; }
        public decimal TotalGainLoss { get; set; }
        public decimal TotalGLPerc { get; set; }
        public decimal TotalAssets { get; set; }
    }

    public class GridAllFields2
    {
        public string PMSProvide { get; set; }
        public string CustomerAccount { get; set; }
        public string CustomerName { get; set; }
        public string Security { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal MarketValue { get; set; }
        public decimal GainLoss { get; set; }
        public decimal GainLossPer { get; set; }
        public decimal Assets { get; set; }
    }

    public class GridAllFields3
    {
        public decimal TotalCost { get; set; }
        public decimal TotalMarketValue { get; set; }
        public decimal TotalGainLoss { get; set; }
        public decimal TotalGLPerc { get; set; }
        public decimal TotalAssets { get; set; }
    }

    public class GridAllFields4
    {
        public decimal TotalCost { get; set; }
        public decimal TotalMarketValue { get; set; }
        public decimal TotalGainLoss { get; set; }
        public decimal TotalGLPerc { get; set; }
        public decimal TotalAssets { get; set; }
    }
}