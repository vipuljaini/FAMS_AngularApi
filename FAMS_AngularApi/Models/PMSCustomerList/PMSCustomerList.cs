using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.PMSCustomerList
{
    public class Custodian
    {
        public string CustodianCode { get; set; }
        public string CustodianName { get; set; }
    }
    public class PortFolio
    {
        public string PortfolioCode { get; set; }
        public string PortfolioName { get; set; }
    }
    public class LinkedPMSEmployee
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
    }
    
    public class PMSCustomerListDetails
    {
        public Int64 SrNo { get; set; }
        public Int64 CustomerListId { get; set; }
        public string CustodianCode { get; set; }
        public string CustodianName { get; set; }
        public string ListCode { get; set; }
        public string Enable { get; set; }
        public string CustomerAccount { get; set; }
        public string CustomerName { get; set; }
    }

    public class PMSCustomerListCodeDetails
    {
        public Int64 SrNo { get; set; }
        public string CustomerAccount { get; set; }
        public string CustomerName { get; set; }
        public string PortfolioName { get; set; }
        public DateTime InceptionDate { get; set; }
        public string EmployeeName { get; set; }
        
    }

    public class PMSCustomerList
    {
        public Int64 SrNo { get; set; }
        public Int32 Result { get; set; }
        public string CustodianCode { get; set; }
        public string ListCode { get; set; }
        public Boolean Enable { get; set; }
        public string CustomerAccount { get; set; }
        public string CustomerName { get; set; }

        public string PortfolioCode { get; set; }
        public string InceptionDate { get; set; }
        public string EmployeeCode { get; set; }
        public Int64 CustomerListId { get; set; }



    }

}