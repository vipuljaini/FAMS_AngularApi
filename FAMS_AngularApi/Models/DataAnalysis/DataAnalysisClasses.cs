using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.DataAnalysis
{
    

    public class StatementOfExpenses_DataAnalysic
    {
        public string Date { get; set; }
        public string SettlementDate { get; set; }
        public string TranRef { get; set; }
        public string Detail { get; set; }
        public string DescNotes { get; set; }
        public decimal Amount { get; set; }
    }
    public class StatementOfExpenses1_DataAnalysic
    {
        public Int64 y { get; set; }
        public string label { get; set; }
      
    }
}