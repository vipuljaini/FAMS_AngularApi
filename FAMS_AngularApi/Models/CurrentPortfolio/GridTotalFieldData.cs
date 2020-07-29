using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.CurrentPortfolio
{
    public class GridTotalFieldData
    {
        public string Security { get; set; }
        public Nullable<decimal> SumTotalCost { get; set; }
        public Nullable<decimal> SumMarketValue { get; set; }
        public Nullable<decimal> SumIncome { get; set; }
        public Nullable<decimal> SumGL { get; set; }
        public Nullable<decimal> SumPercentG_L { get; set; }
        public Nullable<decimal> SumPercentAssets { get; set; }
    }
}