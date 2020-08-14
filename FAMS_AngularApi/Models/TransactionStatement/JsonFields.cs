using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.TransactionStatement
{
    public class JsonFields
    {
        public string UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CustomerAccount { get; set; }
        public string SeqNo { get; set; }
        public string SummarySeqNo { get; set; }
    }

    public class TransactionStatementView
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
    public class JsonFieldsTS
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CustomerAccount { get; set; }
        public string ReportName { get; set; }

    }

}