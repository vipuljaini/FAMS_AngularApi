using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.PMSEmployees
{
    public class BindAllFields
    {
        public Nullable<Int64> PMSEmpId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string About { get; set; }
        public Nullable<Int64> srNo { get; set; }
        //public string CustId { get; set; }
    }
}