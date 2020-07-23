using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.CapitalStatement
{
    public class CapitalStatementModel
    {
        //public Nullable<Int64> TCSID { get; set; }
        public string Security { get; set; }
        public string SaleDate { get; set; }
        public Nullable<Int64> SaleQty { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> SaleAmount { get; set; }
        public string PurchaseDate { get; set; }
        public Nullable<decimal> PurchaseRate { get; set; }
        public string Price { get; set; }
        public Nullable<decimal> PurchaseAmount { get; set; }
        public Nullable<decimal> IndexedCost { get; set; }
        public Nullable<Int64> DaysHeld { get; set; }
        public Nullable<decimal> ST { get; set; }
        public Nullable<decimal> LT { get; set; }
        public Nullable<decimal> AfterIndex_LT { get; set; }
        

    }

    public class CSSum
    {
        public Nullable<decimal> SumSaleAmount { get; set; }
        public Nullable<decimal> SumPurchaseAmount { get; set; }
        public Nullable<decimal> SumIndexedCost { get; set; }
        public Nullable<decimal> SumST { get; set; }
        public Nullable<decimal> SumLT { get; set; }
        public Nullable<decimal> SumAfterIndex_LT { get; set; }
        
    }

    public class HDATE
    {
        public string Date { get; set; }
    }
    public class CapitalStatementDownloadModel
    {
        //public Nullable<Int64> TCSID { get; set; }
        public string Security { get; set; }
        public string SaleDate { get; set; }
        public Nullable<Int64> SaleQty { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> SaleAmount { get; set; }
        public string PurchaseDate { get; set; }
        public Nullable<decimal> PurchaseRate { get; set; }
        public string Price { get; set; }
        public Nullable<decimal> PurchaseAmount { get; set; }
        public Nullable<decimal> IndexedCost { get; set; }
        public Nullable<Int64> DaysHeld { get; set; }
        public Nullable<decimal> ST { get; set; }
        public Nullable<decimal> LT { get; set; }
        public Nullable<decimal> AfterIndex_LT { get; set; }

    }


    public class GridFields
    {
        public string fromdate { get; set; }
        public string PageCount { get; set; }
        public string todate { get; set; } //UserId
        public string UserId { get; set; } //
        public string CustomerAccountNo { get; set; }
    }

    public class pagination
    {
        public Nullable<Int32> IsNxtRequired { get; set; }
        public string TR { get; set; }

    }
}