using BusinessLibrary;
using Encryptions;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.CapitalStatement
{
    public class CapitalStatementDAL
    {

        FAMSEntities context = new FAMSEntities();
        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            try
            {

                //var UserId = Dbsecurity.Decypt(Data.UserId);
                var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);
                // var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementModel>().Execute("@QueryType", "@Fromdate", "@Todate", "BindMainGrid",fromdate,todate));
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementModel>().With<CSSum>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "@CustomerAccount", "BindMainGrid",Data.PageCount,Data.fromdate,Data.todate, CustomerAccountNo));
                return results;  //
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> DownloadExcel()
        {
            try
            {
                //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementModel>().Execute("@QueryType", "@Fromdate", "@Todate", "BindMainGrid",fromdate,todate));
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementDownloadModel>().Execute("@QueryType", "DownloadMainGrid"));
                return results;  //
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}