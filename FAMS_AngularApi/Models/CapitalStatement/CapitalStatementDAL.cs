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

                //var UserId = Dbsecurity.Decypt(Data.UserId); HDATE
                var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);
                // var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementModel>().Execute("@QueryType", "@Fromdate", "@Todate", "BindMainGrid",fromdate,todate));

                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementModel>().With<CSSum>().With<HDATE>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "@CustomerAccount", "BindMainGrid",Data.PageCount,Data.fromdate,Data.todate, CustomerAccountNo));
                return results;  //
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> BindDefaultData(GridFields Data)
        {
            //FAMSEntities context = new FAMSEntities();
            try
            {
                var UserId = Dbsecurity.Decrypt(Data.UserId);
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<PageLoadData>()
                            .Execute("@Querytype", "@UserId", "GetDefault_StatemenetOfExpenses", UserId));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> BindEmployees(GridFields Data)
        {
            ///FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<BindEmployees>()
                           .Execute("@Querytype", "@UserId", "BindEmployees", Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //BindCustomers



        public Dictionary<string, object> BindCustomers(string UserId)
        {
            ///FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<BindCustomer>()
                           .Execute("@Querytype", "@UserId", "BindCustomers", Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(UserId))));
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
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<PageLoadData>()
                            .Execute("@Querytype", "@CustomerAccount", "@UserId", "@PageCount", "NextRecords", Data.CustomerAccountNo, UserId, Data.PageCount));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public Dictionary<string, object> BindNextData(GridFields Data)
        //{
        //    FAMSEntities context = new FAMSEntities();
        //    try
        //    {
        //        var UserId = Dbsecurity.Decrypt(Data.UserId);
        //        var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<PageLoadData>()
        //                    .Execute("@Querytype", "@CustomerAccount", "@UserId", "@PageCount", "NextRecordBind", Data.CustomerAccountNo, UserId, Data.PageCount));
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}









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