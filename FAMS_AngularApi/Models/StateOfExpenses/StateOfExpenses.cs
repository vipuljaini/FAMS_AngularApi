using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.StateOfExpenses;
using Encryptions;

namespace FAMS_AngularApi.Models.StateOfExpenses
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindCustomer(string EmployeeId)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<Customer>()
                          .Execute("@Querytype","@EmployeeId", "GetCustomerForStatementOfExp",EmployeeId));
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
        public Dictionary<string, object> NextRecordBind(string CustomerAccount, string FromDate, string ToDate,string SeqNo)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<StatementOfExpenses_Default>()
                            .Execute("@Querytype", "@CustomerAccount", "@FromDate", "@ToDate", "@SeqNo", "NextRecordBind",CustomerAccount, FromDate, ToDate,SeqNo));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindDefaultData(string CustomerAccount,string GUserId)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<StatementOfExpenses_Default>()
                            .Execute("@Querytype", "@CustomerAccount", "@GUserId", "GetDefault_StatemenetOfExpenses", CustomerAccount, Dbsecurity.Decrypt(GUserId.Replace(" ","+"))));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindGrid(string CustomerAccount,string FromDate, string ToDate, string SeqNo)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
              //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<StatementOfExpenses>().With<StatementOfExpenses1>().With<StatementOfExpenses2>().With<StatementOfExpenses3>().With<StatementOfExpenses4>()
              //            .Execute("@Querytype", "@CustomerAccount", "@FromDate", "@ToDate", "GetStatementOfExpenses", CustomerAccount, FromDate, ToDate));


                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<StatementOfExpenses3>().With<StatementOfExpenses4>().With<StatementOfExpenses5>()
                        .Execute("@Querytype", "@CustomerAccount", "@FromDate", "@ToDate", "@SeqNo", "GetStatementOfExpenses", CustomerAccount, FromDate, ToDate,SeqNo));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //------------Added By Vimal(13 Aug ) For View Purpose-//

        public Dictionary<string, object> BindMainGridView(PrimaryDetails data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_TransactionStatement]").With<BindMainGridViewdata>()
                           .Execute("@Querytype", "@CustomerAccount", "@GUserId", "@ReportType", "@Fromdate", "@Todate", "GetTransactionStatement_View", data.accountNumber.Trim(), Dbsecurity.Decrypt(data.UserId),data.ReportName,data.Fromdate,data.Todate));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //------------------nd---------------------//
    }
}