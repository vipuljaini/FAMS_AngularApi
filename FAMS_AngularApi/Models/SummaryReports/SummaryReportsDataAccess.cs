using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;

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
                          .Execute("@Querytype", "@CustomerAccount", "@Fromdate", "@Todate", "GetSummaryReportData", Data.CustomerAccount, Data.FromDate, Data.ToDate));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}