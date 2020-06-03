using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.SummaryReports;

namespace FAMS_AngularApi.Models.HoldingReports
{
    public class DataAccessLayer 
    {

        public Dictionary<string, object> BindCustomer()
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<Customer>()
                          .Execute("@Querytype","GetCustomer"));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindGrid(string CustomerAccount, string Date)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<GridAllFields>()
                //          .Execute("@Querytype", "@CustomerAccount", "@Fromdate", "@Todate", "GetHoldingReportData", Data.CustomerAccount, Data.FromDate, Data.ToDate));
                //return results;

                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<GridAllFields>().With<GridAllFields1>().With<GridAllFields2>().With<GridAllFields3>().With<GridAllFields4>()
                          .Execute("@Querytype", "@CustomerAccount", "@Fromdate", "GetHoldingReportData", CustomerAccount, Date));

                //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<GridAllFields1>().With<GridAllFields3>().With<GridAllFields4>()
                //          .Execute("@Querytype", "@CustomerAccount", "@Fromdate", "GetHoldingReportData", CustomerAccount, Date));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}