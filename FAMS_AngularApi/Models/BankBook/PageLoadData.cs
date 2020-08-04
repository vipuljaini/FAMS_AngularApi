using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.BankBook
{
    public class PageLoadData
    {
      public string  CustomerAccount { get; set; }
      public string FromDate { get; set; }
      public string ToDate { get; set; }
    }
}