using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.CurrentPortfolio
{
    public class GridFieldData
    {
        public string Security { get; set; }
        public string Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal MarkedPrice { get; set; }
        public decimal MarketValue { get; set; }
        public decimal Income { get; set; }
        public decimal TotalG_L { get; set; }
        public decimal PercentG_L { get; set; }
        public decimal IRRPercent { get; set; }
        public decimal PercentAssets { get; set; }
    }
}