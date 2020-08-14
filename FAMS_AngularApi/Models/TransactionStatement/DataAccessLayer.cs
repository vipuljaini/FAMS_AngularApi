using BusinessLibrary;
using Encryptions;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.TransactionStatement
{
    public class DataAccessLayer
    {

        public Dictionary<string, object> BindTransactionStatementView(JsonFieldsTS Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_TransactionStatement]").With<TransactionStatementView>()
                          .Execute("@Querytype", "@ReportName", "@FromDate", "@ToDate", "@CustomerAccount", "GetTransactionStatement_View", Data.ReportName, Data.FromDate, Data.ToDate, Data.CustomerAccount));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindGrid(JsonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_TransactionStatement]").With<BindmaingridHeader>().With<BindmaingridDetails>().With<BindmaingridDetails_Summary>()
                //           .Execute("@Querytype", "@FromDate", "@ToDate", "@CustomerAccount", "@SeqNo", "@Summary_SeqNo", "BindMainGrid", Data.FromDate, Data.ToDate,Data.CustomerAccount,Data.SeqNo,Data.SummarySeqNo));
                //return results;

                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_TransactionStatement]").With<BindmaingridHeader>().With<BindmaingridDetails>()
                          .Execute("@Querytype", "@FromDate", "@ToDate", "@CustomerAccount", "@SeqNo", "@Summary_SeqNo", "BindMainGrid", Data.FromDate, Data.ToDate, Data.CustomerAccount, Data.SeqNo, Data.SummarySeqNo));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Dictionary<string, object> BindCustomer(string EmployeeId)
        //{
        //    FAMSEntities context = new FAMSEntities();
        //    try
        //    {
        //        var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<Customer>()
        //                  .Execute("@Querytype", "@EmployeeId", "GetCustomerForStatementOfExp", EmployeeId));
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public Dictionary<string, object> BindEmployees(string UserId)
        //{
        //    FAMSEntities context = new FAMSEntities();
        //    try
        //    {
        //        var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<BindEmployees>()
        //                   .Execute("@Querytype", "@UserId", "BindEmployees", Dbsecurity.Decrypt(UserId)));
        //        return results;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public Dictionary<string, object> NextRecordBind(string CustomerAccount, string FromDate, string ToDate, string SeqNo)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_TransactionStatement]").With<TransactionStatement_Default>()
                            .Execute("@Querytype", "@CustomerAccount", "@FromDate", "@ToDate", "@SeqNo", "NextRecordBind", CustomerAccount, FromDate, ToDate, SeqNo));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> GetSummary(string CustomerAccount)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_TransactionStatement]").With<BindmaingridDetails_Summary>()
                            .Execute("@Querytype", "@CustomerAccount", "Summary", CustomerAccount));
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
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_TransactionStatement]").With<TransactionStatement_Default>()
                            .Execute("@Querytype", "@CustomerAccount", "@GUserId", "GetDefault_TransactionStatemenet", CustomerAccount, Dbsecurity.Decrypt(GUserId.Replace(" ", "+"))));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public Dictionary<string, object> BindGrid(string CustomerAccount, string FromDate, string ToDate, string SeqNo)
        //{
        //    FAMSEntities context = new FAMSEntities();
        //    try
        //    {
        //        //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<StatementOfExpenses>().With<StatementOfExpenses1>().With<StatementOfExpenses2>().With<StatementOfExpenses3>().With<StatementOfExpenses4>()
        //        //            .Execute("@Querytype", "@CustomerAccount", "@FromDate", "@ToDate", "GetStatementOfExpenses", CustomerAccount, FromDate, ToDate));


        //        var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<StatementOfExpenses3>().With<StatementOfExpenses4>().With<StatementOfExpenses5>()
        //                .Execute("@Querytype", "@CustomerAccount", "@FromDate", "@ToDate", "@SeqNo", "GetStatementOfExpenses", CustomerAccount, FromDate, ToDate, SeqNo));
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}