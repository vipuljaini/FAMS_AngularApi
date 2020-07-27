using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.BankBook
{
    public class TotalSumGrid
    {
        public Nullable<decimal> Buy_SellAmount { get; set; }
        public Nullable<decimal> Income { get; set; }
        public Nullable<decimal> Expenses { get; set; }
        public Nullable<decimal> Dep_with { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<Int32> Total { get; set; }
    }
}