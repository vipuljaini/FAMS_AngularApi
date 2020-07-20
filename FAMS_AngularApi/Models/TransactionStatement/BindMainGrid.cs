using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.TransactionStatement
{
    public class BindMainGrid
    {
        public string TransactionDesc { get; set; }
        public string TransactionDate { get; set; }
        public string SettlementDate { get; set; }
        public string Security { get; set; }
        public string Exchange { get; set; }
        public Nullable<Decimal> Quantity { get; set; }
        public Nullable<Decimal> UnitPrice { get; set; }
        public string Brkg { get; set; }
        public string STT { get; set; }
        public Nullable<Decimal> SettlementAmount { get; set; }
    }
}