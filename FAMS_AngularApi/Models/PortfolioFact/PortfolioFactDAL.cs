using BusinessLibrary;
using Encryptions;
using EntityDAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static FAMS_AngularApi.Models.PortfolioFact.PortfolioFactModel;

namespace FAMS_AngularApi.Models.PortfolioFact
{
    public class PortfolioFactDAL
    {

        FAMSEntities context = new FAMSEntities();
        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            try
            {

                //var UserId = Dbsecurity.Decypt(Data.UserId);
                //var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);
                var CustomerAccountNo = (Data.CustomerAccountNo);


                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_Portfolio_Fact]").With<SectorAllocation>().With<SUMSectorAllocation>().With<PortfolioHolding>().With<SUMPortfolioHolding>().With<portfolioSummary>().With<PortfolioPerformance>().With<HDATE>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "@CustomerAccount", "BindMainGrid", Data.PageCount, Data.fromdate, Data.todate, CustomerAccountNo));




                return results;  //
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //public Dictionary<string, object> BindDefaultData(GridFields Data)
        //{
        //    FAMSEntities context = new FAMSEntities();
        //    try
        //    {
        //        var UserId = Dbsecurity.Decrypt(Data.UserId);
        //        var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_Portfolio_Fact]").With<PageLoadData>()
        //                    .Execute("@Querytype", "@UserId", "GetDefault_StatemenetOfExpenses", UserId));
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public Dictionary<string, object> BindDefaultData(GridFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var UserId = Dbsecurity.Decrypt(Data.UserId);
                // var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);
                var CustomerAccountNo = (Data.CustomerAccountNo);

                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_Portfolio_Fact]").With<PageLoadData>()
                            .Execute("@Querytype", "@UserId", "@CustomerAccount", "GetDefault_Factportfolio2", UserId, CustomerAccountNo));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Dictionary<string, object> BindNextData(GridFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                //Data.PageCount = Data.PageCount - 1;
                var UserId = Dbsecurity.Decrypt(Data.UserId);
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_Portfolio_Fact]").With<PageLoadData>()
                            .Execute("@Querytype", "@CustomerAccount", "@UserId", "@PageCount", "NextRecords", Data.CustomerAccountNo, UserId, Data.PageCount));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}