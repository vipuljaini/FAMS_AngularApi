using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.Login
{

    public class Logindetails
    {
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public string AccountNo { get; set; }
        public int UserType { get; set; }
        public int CountryId { get; set; }
        public int PartnerId { get; set; }
        public int EntityId { get; set; }
        public string EmailId { get; set; }
        public Int64 MobileNo { get; set; }
        public int UserRole { get; set; }
        public string Password { get; set; }
        public string PasswordKey { get; set; }
        public int EmpFlag { get; set; }
        public Int64 EmployeeId { get; set; }
        public Int64 WareHouseId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsLogin { get; set; }
        public Nullable<Int64> CreatedBy { get; set; }
        public Nullable<Int64> UpdatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public Nullable<bool> IsDefaultPswdChange { get; set; }
      

    }
}