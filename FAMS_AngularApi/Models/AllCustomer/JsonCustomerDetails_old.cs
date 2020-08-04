﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.AllCustomer
{
    public class JsonCustomerDetails
    {
        public Int64 UserId { get; set; }
        public string CustomerUsername { get; set; }
        public string CustomerEmailID { get; set; }
        public string CustomerAccount { get; set; }
        public string EmployeeCode { get; set; }//EmployeeCode
    }
}