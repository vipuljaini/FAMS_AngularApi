using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using Encryptions;

namespace FAMS_AngularApi.Models.PMSEmployees
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> SaveData(JsonAllFields Data)
        {
            string Active = "";
            if(Data.Active == true) { Active = "1"; }
            else { Active = "0"; }
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PMSEmployees]").With<CommonFields>()
                          .Execute("@Querytype", "@EmployeeCode", "@EmployeeName", "@Gender", "@About", "@Custodian", "@CustomerCode", "@CustomerName", "@EmpLinkingDate", "@Qualification", "@InceptionDate", "@PMSEmpId", "@Active", "@UserId", "SaveEmployee", Data.EmployeeCode, Data.EmployeeName, Data.Gender,
                          Data.About, Data.Custodian, Data.CustomerCode, Data.CustomerName , Data.EmpLinkingDate , Data.Qualification , Data.InceptionDate , Data.PMSEmpId , Active ,  Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));  
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindGrid(CommonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PMSEmployees]").With<BindAllFields>()
                          .Execute("@Querytype", "@UserId", "BindGrid", Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%"))))); 
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindCustodian(CommonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PMSEmployees]").With<BindCustodianFields>()
                          .Execute("@Querytype", "@UserId", "BindCustodian", Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));  
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindCustomers(string PMSEmpId)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PMSEmployees]").With<BindAllCustomersFields>()
                          .Execute("@Querytype", "@PMSEmpId", "BindCustomers", PMSEmpId)); 
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}