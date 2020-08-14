using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.StateOfExpenses
{
    public class StatementOfExpenses
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

    public class StatementOfExpView
    {
        public string SrNo { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CustomerAccount { get; set; }
        public string Scheme { get; set; }
        public string DownloadLink { get; set; }
        public Int16 ReportType { get; set; }
        public string ReportName { get; set; }

    }
    public class JsonFields
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CustomerAccount { get; set; }
        public string ReportType { get; set; }
        
    }

}