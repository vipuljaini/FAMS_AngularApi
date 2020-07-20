using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.BankBook
{
    public class BindGrid
    {
       public string Code { get; set; }
       public string Name { get; set; }
       public string BankAcc { get; set; }
       public string BankName { get; set; }
       public string SetDate { get; set; }
       public string TransAccount { get; set; }
       public string TransactionDesc { get; set; }
       public string Security { get; set; }
       public Nullable<decimal> Buy_SellAmount { get; set; }
       public Nullable<decimal> Income { get; set; }
       public Nullable<decimal> Expenses { get; set; }
       public string Dep_with { get; set; }
       public Nullable<decimal> Balance { get; set; }
        public string CustodianAcc { get; set; }
        public string AccountCode { get; set; }
    }
}