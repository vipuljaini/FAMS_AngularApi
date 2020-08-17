using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using BusinessLibrary;
using Encryptions;
using EntityDAL;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;

namespace FAMS_AngularApi.Models.StatementDivident
{
    public class StatementDividentDAL
    {

        FAMSEntities context = new FAMSEntities();
        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            try
            {

                //var UserId = Dbsecurity.Decypt(Data.UserId);
                //var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);
                var CustomerAccountNo =(Data.CustomerAccountNo);
                // string base64 = "";
                // var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementModel>().Execute("@QueryType", "@Fromdate", "@Todate", "BindMainGrid",fromdate,todate));
                //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_StatementDividend]").With<StatementDividentModel>().With<DividendModel>().With<SDSum>().With<SumDividend>().With<HDATE>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "@CustomerAccount", "BindMainGrid", Data.PageCount, Data.fromdate, Data.todate, CustomerAccountNo));

                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_StatementDividend]").With<StatementDividentModel>().With<SDSum>().With<HDATE>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "@CustomerAccount", "BindMainGrid", Data.PageCount, Data.fromdate, Data.todate, CustomerAccountNo));

                // MemoryStream MyMemoryStream = new MemoryStream();

                //Root.Reports.Report report = new Root.Reports.Report(new PdfFormatter());                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
                //FontDef fd = new FontDef(report, "Helvetica");
                //FontProp fp = new FontPropMM(fd, 25);
                //Page page = new Page(report);
                //page.AddCB_MM(80, new RepString(fp, "Hello World!"));
                //RT.ViewPDF(report, "HelloWorld.pdf");

                // base64 = Convert.ToBase64String(MyMemoryStream.ToArray());



                return results;  //
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
                var UserId = Dbsecurity.Decrypt(Data.UserId);
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_StatementDividend]").With<PageLoadData>()
                            .Execute("@Querytype", "@UserId", "@CustomerAccount", "GetDefault_StatemenetOfExpenses", UserId,Data.CustomerAccountNo));
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
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_StatementDividend]").With<PageLoadData>()
                            .Execute("@Querytype", "@CustomerAccount", "@UserId", "@PageCount", "NextRecords", Data.CustomerAccountNo, UserId, Data.PageCount));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindViewGrid(GridFields Data)
        {
            try
            {              
                var CustomerAccountNo = (Data.CustomerAccountNo);
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_StatementDividend]").With<BindViewGridAllFields>()
                    .Execute("@QueryType",  "@CustomerAccount", "@PageType", "@FromDate", "@ToDate", "@UserId", "BindViewGrid",CustomerAccountNo,Data.PageType,Data.fromdate,Data.todate,Data.UserId));
                return results;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> ChangeAccountFun(GridFields Data)
        {
            try
            {
                var CustomerAccountNo = (Data.CustomerAccountNo);
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_StatementDividend]").With<BindViewGridAllFields>()
                    .Execute("@QueryType", "@CustomerAccount", "@PageType", "@UserId", "BindChangeAccountNo", CustomerAccountNo, Data.PageType, Data.UserId));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}