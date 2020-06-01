using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.PMSEmployees
{
    public class JsonAllFields
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string About { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Custodian { get; set; }
        public string InceptionDate { get; set; }
        public string EmpLinkingDate { get; set; }
        public string UserId { get; set; }
    }
}