using BusinessLibrary;
using Encryptions;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.PortfolioSummary
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindGrid(JsonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
              var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PerformanceAppraisal]").With<BindmaingridHeader>().With<BindPortfolioAllocation>()
                    .With<BindPortfolioSummary>().With<BindPortfolioPerformance>().With<BindPortfolioAllocationTotal>().Execute("@Querytype", "@CustomerAccount", "@AsOnDate", "@SeqNo","BindAllGrid", Data.CustomerAccount, Data.AsOnDate, Data.SeqNo));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindDefaultData(string CustomerAccount, string GUserId)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_PerformanceAppraisal]").With<PortfolioSummary_Default>()
                            .Execute("@Querytype", "@CustomerAccount", "@GUserId", "GetDefault_PerformanceAppraisal", CustomerAccount, Dbsecurity.Decrypt(GUserId)));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}