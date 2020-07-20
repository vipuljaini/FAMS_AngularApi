using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.StatementDivident
{
    public class StatementDividentModel
    {

        public string ExDate { get; set; }
        public string ReceivedDate { get; set; }
        public string Security { get; set; }
        public Nullable<Int64> Quantity { get; set; }
        public Nullable<Int64> Rate { get; set; } //Rate
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> ReceivableAmount { get; set; }
        public Nullable<decimal> ReceivedAmount { get; set; }
        public Nullable<decimal> TDSAmount { get; set; }
        public Nullable<decimal> NetAmount { get; set; }
        public Nullable<decimal> BalanceAmount { get; set; }
       
    }

    public class SDSum
    {
        public Nullable<decimal> SumReceivableAmount { get; set; }
        public Nullable<decimal> SumReceivedAmount { get; set; }
        public Nullable<decimal> SumTDSAmount { get; set; }
        public Nullable<decimal> SumNetAmount { get; set; }
        public Nullable<decimal> SumBalanceAmount { get; set; }//SumBalanceAmount


    }

    public class GridFields
    {
        public string fromdate { get; set; }
        public string PageCount { get; set; }
        public string todate { get; set; }
        public string UserId { get; set; }//UserId
        public string CustomerAccountNo { get; set; }

    }

    public class pagination
    {
        public Nullable<Int32> IsNxtRequired { get; set; }
        public string TR { get; set; }

    }



   public class DividendModel
    {
        public string Trans_desc { get; set; }
        public Nullable<decimal> Total_Dividend_Received { get; set; }
        public Nullable<decimal> Outstanding_Divident { get; set; }
        public Nullable<decimal> Total_Amount { get; set; }
        public Nullable<decimal> TDS_Amount { get; set; }
        //public Nullable<decimal> SumTotal_Dividend_Received { get; set; }
        //public Nullable<decimal> SumOutstanding_Divident { get; set; }
        //public Nullable<decimal> SumTotal_Amount { get; set; }
        //public Nullable<decimal> SumTDS_Amount { get; set; }

    }

    public class SumDividend
    {
        public Nullable<decimal> SumTotal_Dividend_Received { get; set; }
        public Nullable<decimal> SumOutstanding_Divident { get; set; }
        public Nullable<decimal> SumTotal_Amount { get; set; }
        public Nullable<decimal> SumTDS_Amount { get; set; }


    }


}