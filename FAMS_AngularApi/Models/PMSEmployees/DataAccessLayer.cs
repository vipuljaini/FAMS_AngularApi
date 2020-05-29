using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;

namespace FAMS_AngularApi.Models.PMSEmployees
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> SaveData(JsonAllFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PMSEmployee]").With<CommonFields>()
                          .Execute("@Querytype", "@EmployeeCode", "@EmployeeName", "@Gender", "@About", "@Custodian", "@CustomerCode", "@CustomerName", "@EmpLinkingDate", "@Qualification", "@InceptionDate", "SaveEmployee", Data.EmployeeCode, Data.EmployeeName, Data.Gender,
                          Data.About, Data.Custodian, Data.CustomerCode, Data.CustomerName , Data.EmpLinkingDate , Data.Qualification , Data.InceptionDate));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindGrid()
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PMSEmployee]").With<CommonFields>()
                          .Execute("@Querytype", "BindGrid"));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindCustodian()
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PMSEmployee]").With<CommonFields>()
                          .Execute("@Querytype", "BindCustodian"));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}