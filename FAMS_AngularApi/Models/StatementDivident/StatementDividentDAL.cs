using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using BusinessLibrary;
using Encryptions;
using EntityDAL;

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
                var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);
                // string base64 = "";
                // var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementModel>().Execute("@QueryType", "@Fromdate", "@Todate", "BindMainGrid",fromdate,todate));
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_StatementDividend]").With<StatementDividentModel>().With<DividendModel>().With<SDSum>().With<SumDividend>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "@CustomerAccount", "BindMainGrid", Data.PageCount, Data.fromdate, Data.todate, CustomerAccountNo));

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



    }
}