using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Encryptions;
using BusinessLibrary;
using FAMS_AngularApi.Models.PortfolioAppraisals;


namespace FAMS_AngularApi.Models.PortfolioAppraisals
{
    public class PortfolioAppraisalsDAL1
    {
        public Dictionary<string, object> BindCustomer(string EmployeeId)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[SP_PortfolioAppraisal]").With<Customer>()
                          .Execute("@Querytype", "@EmployeeId", "GetCustomer", EmployeeId));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindEmployees(string UserId)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<BindEmployees>()
                           .Execute("@Querytype", "@UserId", "BindEmployees", Dbsecurity.Decrypt(UserId)));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> NextRecordBind(string CustomerAccount, string FromDate, string ToDate, string SeqNo)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[SP_PortfolioAppraisal]").With<PageLoadData>()
                            .Execute("@Querytype", "@CustomerAccount", "@FromDate", "@SeqNo", "NextRecordBind", CustomerAccount, FromDate, SeqNo));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindDefaultData(GridFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[SP_PortfolioAppraisal]").With<PageLoadData>()
                            .Execute("@Querytype", "@CustomerAccount", "@GUserId", "GetDefault_PortfolioAppraisal", Data.CustomerAccountno, Dbsecurity.Decrypt(Data.UserID)));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindGrid(string CustomerAccount, string FromDate, string ToDate, string SeqNo)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<StatementOfExpenses>().With<StatementOfExpenses1>().With<StatementOfExpenses2>().With<StatementOfExpenses3>().With<StatementOfExpenses4>()
                //            .Execute("@Querytype", "@CustomerAccount", "@FromDate", "@ToDate", "GetStatementOfExpenses", CustomerAccount, FromDate, ToDate));


                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<StatementOfExpenses3>().With<StatementOfExpenses4>().With<StatementOfExpenses5>()
                        .Execute("@Querytype", "@CustomerAccount", "@FromDate", "@ToDate", "@SeqNo", "GetStatementOfExpenses", CustomerAccount, FromDate, ToDate, SeqNo));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            try
            {
                FAMSEntities context = new FAMSEntities();

                // var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);

                // var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementModel>().Execute("@QueryType", "@Fromdate", "@Todate", "BindMainGrid",fromdate,todate));
                var results = Common.Getdata(context.MultipleResults("[dbo].[SP_PortfolioAppraisal]").With<PortfolioappraisalModel>().With<SumPortfolioappraisalModel>().With<cashportfolio>().With<PortfolioappraisalModel>().With<HDATE>().Execute("@QueryType", "@SeqNo", "@Fromdate", "@CustomerAccount", "GetPortfolioAppraisal", Data.pagecount, Data.Fromdate, Data.CustomerAccountno));




                return results;  //
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //BindGridView
        public Dictionary<string, object> BindGridView(GridFields Data)
        {
            try
            {
                FAMSEntities context = new FAMSEntities();

                // var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);


                //var results = Common.Getdata(context.MultipleResults("[dbo].[SP_PortfolioAppraisal]").With<PortfolioappraisalModel>().With<SumPortfolioappraisalModel>().With<cashportfolio>().With<PortfolioappraisalModel>().With<HDATE>().Execute("@QueryType", "@SeqNo", "@Fromdate", "@CustomerAccount", "GetPortfolioAppraisal", Data.pagecount, Data.Fromdate, Data.CustomerAccountno));

                //   var results = Common.Getdata(context.MultipleResults("[dbo].[SP_PortfolioAppraisal]").With<gridview>().Execute("@QueryType", "@SeqNo", "@Fromdate", "@CustomerAccount", "BindGridView", Data.pagecount, Data.Fromdate, Data.CustomerAccountno));
                var results = Common.Getdata(context.MultipleResults("[dbo].[SP_PortfolioAppraisal]").With<gridview>().Execute("@QueryType", "@SeqNo", "@Fromdate", "@CustomerAccount", "@ReportType", "@GUserId", "BindGridView", Data.pagecount, Data.Fromdate, Data.CustomerAccountno, Data.ReportType, Data.UserID));

                return results;  //
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}