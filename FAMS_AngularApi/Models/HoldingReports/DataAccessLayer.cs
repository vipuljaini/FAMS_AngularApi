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
        public Dictionary<string, object> BindGrid(JasonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<GridAllFields>()
                          .Execute("@Querytype", "@CustomerAccount", "@Fromdate", "@Todate", "GetHoldingReportData", Data.CustomerAccount, Data.Fromdate, Data.Todate));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}