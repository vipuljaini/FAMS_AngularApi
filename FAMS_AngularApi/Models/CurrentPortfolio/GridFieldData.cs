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
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<decimal> MarkedPrice { get; set; }
        public Nullable<decimal> MarketValue { get; set; }
        public Nullable<decimal> Income { get; set; }
        public Nullable<decimal> TotalG_L { get; set; }
        public Nullable<decimal> PercentG_L { get; set; }
        public Nullable<decimal> IRRPercent { get; set; }
        public Nullable<decimal> PercentAssets { get; set; }
    }
}