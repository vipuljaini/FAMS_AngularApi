using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.FetchLatestReport;
using FAMS_AngularApi.Models.TransactionStatement;

namespace FAMS_AngularApi.Models.FetchLatestReport
{
    public class FetchLatestDataAccessLayer
    {
        public Dictionary<string, object> GetFetchLatestReport(FetchLatestReport Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[RohitToPutSp]").With<TransactionStatementView>()
                          .Execute("@Querytype", "@ReportType", "@FromDate", "@ToDate", "@CustomerAccount", "TestQueryType", Data.ReportName, Data.CustomerAccount));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}