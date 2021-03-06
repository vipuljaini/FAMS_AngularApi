﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.CurrentPortfolio
{
    public class JsonFields
    {
        public string CustomerAccountNo { get; set; }
        public string UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string ReportDate { get; set; }
        public string PageCount { get; set; }
        public string ReportType { get; set; }
        public string Scheme { get; set; }
    }
}