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
        public Dictionary<string, object> SaveData(JsonAllFields Data, string UserId)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PMSEmployees]").With<CommonFields>()
                          .Execute("@Querytype", "@EmployeeCode", "@EmployeeName", "@Gender", "@About", "@Custodian", "@CustomerCode", "@CustomerName", "@EmpLinkingDate", "@Qualification", "@InceptionDate", "@UserId", "SaveEmployee", Data.EmployeeCode, Data.EmployeeName, Data.Gender,
                          Data.About, Data.Custodian, Data.CustomerCode, Data.CustomerName , Data.EmpLinkingDate , Data.Qualification , Data.InceptionDate, Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(UserId.Replace("_", "%")))));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindGrid(string UserId)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PMSEmployees]").With<BindAllFields>()
                          .Execute("@Querytype", "@UserId", "BindGrid", Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(UserId.Replace("_", "%")))));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindCustodian(string UserId)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PMSEmployees]").With<BindCustodianFields>()
                          .Execute("@Querytype", "@UserId", "BindCustodian", Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(UserId.Replace("_", "%")))));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}