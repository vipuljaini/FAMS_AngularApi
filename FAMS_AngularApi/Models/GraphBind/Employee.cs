using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.GraphBind
{
    public class Employee
    {
        public Nullable<Int64> PMSEmpId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<Int64> PMSId { get; set; }
      
    }
}