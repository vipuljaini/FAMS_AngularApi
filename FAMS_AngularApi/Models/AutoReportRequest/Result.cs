using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.AutoReportRequest
{
    public class JsonFields
    {
        //public string FromDate { get; set; }
        //public string ToDate { get; set; }
        public string CustomerAccount { get; set; }
        //public string ReportType { get; set; }
        //public string SeqNo { get; set; }

    }

    public class BindAutoReportRequestData
    {
        //public string FromDate { get; set; }
        //public string ToDate { get; set; }
        public string CustomerAccount { get; set; }
        public string ReportType { get; set; }
        public string FrequencyId { get; set; }
    }

    public class BindAllAutoReportRequestData
    {
        public Int64 SrNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAccount { get; set; }
        public string EmailId { get; set; }
        public string CreatedOn { get; set; }
        public Int64 CreatedBy { get; set; }
        public string UserId { get; set; }
    }
    public class Result
    {
        public string ResultSaveUpdate { get; set; }
    }
    public class ViewAllAutoReportRequest
    {
        public string ReportName { get; set; }
        public string FrequencyType { get; set; }
    }

    public class SendMailAllAutoReportRequest
    {
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string AccountNo { get; set; }
        public string DownloadLink { get; set; }
    }


}