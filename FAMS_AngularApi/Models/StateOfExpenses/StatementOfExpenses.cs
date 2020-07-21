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
}