using FAMS_AngularApi.Models.StatementDivident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;

using System.Net.Http.Headers;
using System.IO;
using System.Data;
using EntityDAL;
using BusinessLibrary;
using System.Reflection;

namespace FAMS_AngularApi.Controllers
{
    public class StatementDividendController : ApiController
    {

        StatementDividentDAL Obj = new StatementDividentDAL();

        [HttpPost]
        [Route("api/StatementDividend/BindGrid/")]
        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            return Obj.BindGrid(Data);
        }

        [HttpPost]
        [Route("api/StatementDividend/BindDefaultData")]
        public Dictionary<string, object> DefaultDataApi(GridFields Data)
        {
            return Obj.BindDefaultData(Data);
        }

        [HttpPost]
        [Route("api/StatementDividend/BindNextData")]
        public Dictionary<string, object> BindNextDataApi(GridFields Data)
        {
            return Obj.BindNextData(Data);
        }


        [HttpPost]
        [Route("api/StatementDividend/PDFReport")]
        public string PDFReport(GridFields Data)
        {
            //var reportDto = JsonConvert.DeserializeObject<User>("abhi");

            //byte[] bytes;
            //using (var reportViewer = new ReportViewer())
            //{
            //    reportViewer.ProcessingMode = ProcessingMode.Local;
            //    reportViewer.LocalReport.ReportEmbeddedResource = reportDto.Location;

            //    if (reportDto.Accounts != null)
            //    {
            //        foreach (ParameterDTO parameter in reportDto.Accounts)
            //        {
            //            reportViewer.LocalReport.SetParameters(new ReportParameter(parameter.Name, parameter.Data));
            //        }
            //    }

            //    if (reportDto.Badges != null)
            //    {
            //        var dt = new DataTable();

            //        foreach (DataSourceDto dataSource in reportDto.Badges)
            //        {
            //            dt.Columns.Add(dataSource.Name, typeof(string));
            //        }

            //        DataRow dr = dt.NewRow();

            //        for (int index = 0; index < reportDto.Badges.Count; index++)
            //        {
            //            dr[index] = reportDto.DataSources[index].Data;
            //        }

            //        dt.Rows.Add(dr);

            //        reportViewer.LocalReport.DataSources.Add(new ReportDataSource(reportDto.ReportDataSourceName, dt));
            //    }





            FAMSEntities context = new FAMSEntities();
            FAMSEntities dbcontext = new FAMSEntities();
            
           // var reportViewer = new ReportViewer();

            //  var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_StatementDividend]").With<StatementDividentModel>().With<SDSum>().With<HDATE>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "@CustomerAccount", "BindMainGrid", Data.PageCount, Data.fromdate, Data.todate, CustomerAccountNo));

            var Result = dbcontext.MultipleResults("[dbo].[Sp_StatementDividend]").With<StatementDividentModel>().With<SDSum>().With<HDATE>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "@CustomerAccount", "BindMainGrid", Data.PageCount, Data.fromdate, Data.todate, Data.CustomerAccountNo);
            //            ds = objManager.FillDatasetWithParam("sp_Report", "@QueryType", "@RestroId", "@FromDate", "@ToDate", "@ItemMenuGroupID"
            //, "@UserId", "DailySalesReport", restroid, date, todate, itemgroupid, UserId);

            //results[0].Cast<StatementDividentModel>().ToList();

            DataTable dt = ToDataTable(Result[0].Cast<StatementDividentModel>().ToList());

            DataTable dt1 = ToDataTable(Result[2].Cast<HDATE>().ToList());

            DataTable dt2 = ToDataTable(Result[1].Cast<SDSum>().ToList());

            byte[] bytes;
            using (var reportViewer = new ReportViewer())
            {
                reportViewer.ProcessingMode = ProcessingMode.Local;
            //reportViewer.LocalReport.ReportPath = Server.MapPath("~/Report/StatementDividend.rdlc");
            reportViewer.LocalReport.ReportPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Report/StatementDividend.rdlc");
            //DateTime dat = DateTime.Parse(date);
            //DateTime todat = DateTime.Parse(todate);
            //ds.Tables[0].Columns.Add("Date", typeof(System.String));
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    //need to set value to MyRow column 
            //    //   dr["BranchName"] = "Daily Sales Report";   // or set it to some other value 
            //    dr["Date"] = dat.ToString("yyyy-MM-dd HH:mm:ss") + " - " + todat.ToString("yyyy-MM-dd HH:mm:ss");
            //}

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                ReportDataSource datasource1 = new ReportDataSource("DataSet2", dt1);
                ReportDataSource datasource2 = new ReportDataSource("DataSet3", dt2);

                //ReportViewer1.LocalReport.EnableExternalImages = true;
                //var path = "~/RestroImage/" + restroid + ".jpg";
                //string imagePath = new Uri(Server.MapPath(path)).AbsoluteUri;
                //ReportParameter parameter = new ReportParameter("ImagePath", imagePath);//D:\Rproject\FRD_Web\FRDWeb\FRDWeb\RestroImage\1.jpg
                //ReportViewer1.LocalReport.SetParameters(parameter);
                //ReportViewer1.LocalReport.Refresh();

                reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(datasource);
            reportViewer.LocalReport.DataSources.Add(datasource1);
            reportViewer.LocalReport.DataSources.Add(datasource2);

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                bytes = reportViewer.LocalReport.Render("Pdf", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            }

            //var cd = new System.Net.Mime.ContentDisposition
            //{
            //    FileName = string.Format("SampleReport.pdf"),
            //    Inline = true,
            //};

            var result1 = new HttpResponseMessage(HttpStatusCode.OK);
            //Stream stream = new MemoryStream(bytes);
            MemoryStream stream = new MemoryStream(bytes);
            //result.Content = new StreamContent(stream);
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            //return result;
            return Convert.ToBase64String(stream.ToArray());
        }



        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        [HttpPost]
        [Route("api/StatementDividend/BindViewGrid/")]
        public Dictionary<string, object> BindViewGrid(GridFields Data)
        {
            return Obj.BindViewGrid(Data);
        }

        [HttpPost]
        [Route("api/StatementDividend/ChangeAccountFun/")]
        public Dictionary<string, object> ChangeAccountFunApi(GridFields Data)
        {
            return Obj.ChangeAccountFun(Data);
        }

    }
}
