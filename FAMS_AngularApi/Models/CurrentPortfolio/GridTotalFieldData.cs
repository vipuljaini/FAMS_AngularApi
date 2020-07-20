using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.CurrentPortfolio
{
    public class GridTotalFieldData
    {
        public string Security { get; set; }
        public decimal SumTotalCost { get; set; }
        public decimal SumMarketValue { get; set; }
        public decimal SumIncome { get; set; }
        public decimal SumGL { get; set; }
        public decimal SumPercentG_L { get; set; }
        public decimal SumPercentAssets { get; set; }
    }
}