using BusinessLibrary;
using Encryptions;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.BankBook
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindGrid(JsonData Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<BindGrid>().With<TotalSumGrid>().With<HeaderData>()
                           .Execute("@Querytype", "@FromDate", "@ToDate", "@CustomerAccount", "@PageCount", "BindGridNew", Data.FromDate, Data.ToDate,Data.CustomerAccount,Data.PageCount));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindEmployees(JsonData Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<BindEmployees>()
                           .Execute("@Querytype", "@UserId", "BindEmployees", Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
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
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<PageLoadData>()
                            .Execute("@Querytype", "@CustomerAccount", "@UserId", "GetDefault_StatemenetOfExpenses", Data.CustomerAccount, Data.UserId));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindCustomers(JsonData Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<BindCustomers>()
                           .Execute("@Querytype", "@UserId", "BindCustomers", Data.UserId));
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
                            .Execute("@Querytype", "@CustomerAccount", "@UserId","@PageCount", "NextRecords", Data.CustomerAccount, Data.UserId,Data.PageCount));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindGridView(JsonData Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<BindGridView>()
                           .Execute("@Querytype", "@FromDate", "@ToDate", "@CustomerAccount", "@ReportType", "BindGridView", Data.FromDate, Data.ToDate,Data.CustomerAccount,Data.ReportType));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}