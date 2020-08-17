using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using Encryptions;
using EntityDAL;



namespace FAMS_AngularApi.Models.CurrentPortfolio
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindGrid(JsonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                // var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);

                //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CurrentPortfolio]").With<GridFieldData>().With<GridTotalFieldData>().With<GridTotalFieldData>().With<GridFieldData>()
                //           .Execute("@Querytype", "@Fromdate", "@Todate", "@CustomerAccount", "BindGrid", Data.FromDate, Data.ToDate, CustomerAccountNo));
                //return results;
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CurrentPortfolio]").With<GridFieldData>().With<Header>().With<GridTotalFieldData>().With<NextGrid>()
                          .Execute("@Querytype", "@ReportDate", "@CustomerAccount", "@PageCount", "BindGrid", Data.ReportDate, Data.CustomerAccountNo , Data.PageCount));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public Dictionary<string, object> BindGridView(JsonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {

                //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CurrentPortfolio]").With<GridFieldData>().With<Header>().With<GridTotalFieldData>().With<NextGrid>()
                //          .Execute("@Querytype", "@ReportDate", "@CustomerAccount", "@PageCount", "BindGrid", Data.ReportDate, Data.CustomerAccountNo, Data.PageCount));

                // var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CurrentPortfolio]").With<GridFieldDataView>().Execute("@Querytype", "@ReportDate", "@CustomerAccount", "@PageCount", "BindGridView", Data.ReportDate, Data.CustomerAccountNo, Data.PageCount));
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CurrentPortfolio]").With<GridFieldDataView>().Execute("@Querytype", "@ReportDate", "@CustomerAccount", "@PageCount", "@ReportType", "BindGridView", Data.ReportDate, Data.CustomerAccountNo, Data.PageCount, Data.ReportType));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindDefaultData(DefaultJson Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CurrentPortfolio]").With<PageLoadData>()
                            .Execute("@Querytype", "@CustomerAccount", "@UserId", "GetDefault_StatemenetOfExpenses", Data.CustomerAccountNo, Data.UserId));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindNextData(JsonData Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<PageLoadData>()
                            .Execute("@Querytype", "@CustomerAccount", "@UserId", "@PageCount", "NextRecords", Data.CustomerAccount, Data.UserId, Data.PageCount));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}