using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using Encryptions;
using FAMS_AngularApi.Models.PMSEmployees;

namespace FAMS_AngularApi.Models.SummaryReports
{
    public class SummaryReportsDataAccess
    {
        public Dictionary<string, object> BindGrid(JasonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<GridAllFields>()
                          .Execute("@Querytype", "@CustomerAccount", "@Fromdate", "@Todate", "GetSummaryReportData", Data.CustomerAccount, Data.Fromdate, Data.Todate));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindCustomers(CommonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<BindCustomerAllFields>()
                          .Execute("@Querytype", "GetCustomer"));       //,  Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(UserId.Replace("_", "%")))
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}