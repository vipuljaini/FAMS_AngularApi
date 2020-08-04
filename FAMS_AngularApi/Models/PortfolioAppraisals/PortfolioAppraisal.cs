using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.PortfolioAppraisals
{
   
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
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
    }
}