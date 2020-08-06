using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.PortfolioAppraisals
{


    public class PortfolioappraisalModel
    {

        public string Security { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> MarketValue { get; set; }
        public Nullable<decimal> Gain_Loss { get; set; }
        public Nullable<decimal> Gain_LossPer { get; set; }
        public Nullable<decimal> PerAsstes { get; set; }

    }

    public class SumPortfolioappraisalModel
    {
        public Nullable<decimal> SumCost { get; set; }
        public Nullable<decimal> SumMarketValue { get; set; }
        public Nullable<decimal> SumGain_Loss { get; set; }
        public Nullable<decimal> SumGain_LossPer { get; set; }
        public Nullable<decimal> SumPerAsstes { get; set; }

    }





    public class cashportfolio
    {
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> MarketValue { get; set; }
        public Nullable<decimal> Gain_Loss { get; set; }
        public Nullable<decimal> Gain_LossPer { get; set; }
        public Nullable<decimal> PerAsstes { get; set; }


    }


    public class Sumcashportfolio
    {

        public Nullable<Int32> cash { get; set; }

    }




    public class HDATE
    {
        public Int32 ID { get; set; }
        public string Date { get; set; }

    }


    public class GridFields
    {
        public string CustomerAccountno { get; set; }
        public string UserID { get; set; }
        public string Fromdate { get; set; }
        public string pagecount { get; set; }

    }




    public class PortfolioAppraisal
    {
        public string Date { get; set; }
        public string SettlementDate { get; set; }
        public string TranRef { get; set; }
        public string Detail { get; set; }
        public string DescNotes { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
    public class StatementOfExpenses1
    {
        public string Date { get; set; }
        public string SettlementDate { get; set; }
        public string TranRef { get; set; }
        public string Detail { get; set; }
        public string DescNotes { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
    public class StatementOfExpenses2
    {
        public string Date { get; set; }
        public string SettlementDate { get; set; }
        public string TranRef { get; set; }
        public string Detail { get; set; }
        public string DescNotes { get; set; }
        public string Amount { get; set; }
    }
    public class StatementOfExpenses3 // fOR HEADING IN CENTER
    {
        public string Date { get; set; }
    }

    public class StatementOfExpenses4 // fOR grid body without header
    {

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CustomerCode { get; set; }
        public string Date { get; set; }
        public string SettlementDate { get; set; }
        public string TranRef { get; set; }
        public string Detail { get; set; }
        public string DescNotes { get; set; }
        public string Amount { get; set; }
    }

    public class StatementOfExpenses_Default
    {
        public string CustomerCode { get; set; }
        public string CustomerAccount { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class StatementOfExpenses5
    {
        public string TransactionDescription { get; set; }
        public string TotalPaidAmount { get; set; }
        public string TotalPayableAmount { get; set; }

    }
    public class BindEmployees
    {
        public Nullable<Int64> PMSEmpId { get; set; }
        public string EmployeeName { get; set; }
    }

    public class Customer
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }


    public class PageLoadData
    {
        public string CustomerCode { get; set; }
        public string CustomerAccountNo { get; set; }
        public string AsOnDate { get; set; }//AsOnDate

    }
}