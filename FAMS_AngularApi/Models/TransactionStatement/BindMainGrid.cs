using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.TransactionStatement
{
    public class BindmaingridHeader // fOR HEADING IN CENTER
    {
        public string Date { get; set; }
    }
    public class BindmaingridDetails
    {
        public string NoOfPage { get; set; }
        public string CustomerAccountNo { get; set; }
        public string TransactionDesc { get; set; }
        public string TransactionDate { get; set; }
        public string SettlementDate { get; set; }
        public string Security { get; set; }
        public string Exchange { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string Brkg { get; set; }
        public string STT { get; set; }
        public string SettlementAmount { get; set; }
    }

    public class BindmaingridDetails_Summary
    {
        public string TransactionDesc { get; set; }
        public string PreviousPeriodTranNotSettle { get; set; }
        public string PreviousPeriodTranSettledCurrentPeriod { get; set; }
        public string CurrentPeriodTranSettledDuringPeriod { get; set; }
        public string CurrentPeriodTranNotSettled{ get; set; }
        public string TotalCurrentPeriodTran { get; set; }
        public string TotalCurrentPeriodSettled{ get; set; }
      
    }

    public class TransactionStatement_Default
    {
        public string CustomerCode { get; set; }
        public string CustomerAccount { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public string NoOfPage { get; set; }
        public string SeqNo { get; set; }
    }
}