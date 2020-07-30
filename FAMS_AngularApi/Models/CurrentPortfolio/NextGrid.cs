using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.CurrentPortfolio
{
    public class NextGrid
    {
        public string Security { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string UnitCost { get; set; }
        public string TotalCost { get; set; }
        public string MarkedPrice { get; set; }
        public string Income { get; set; }
        public string TotalG_L { get; set; }
        public string PercentG_L { get; set; }
        public string IRRPercent { get; set; }
        public string PercentAssets { get; set; }
    }
}