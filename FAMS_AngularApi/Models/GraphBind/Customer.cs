using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.GraphBind
{
    public class Customer
    {
        public Nullable<Int64> CustId { get; set; }
        public Nullable<Int64> PMSEmpId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public Nullable<Int64> CustodianId { get; set; }
    }
}