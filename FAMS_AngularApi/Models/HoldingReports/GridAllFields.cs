using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.HoldingReports
{
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
}