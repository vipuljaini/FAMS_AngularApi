using BusinessLibrary;
using EntityDAL;
using FAMS_AngularApi.Models.StatementDivident;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FAMS_AngularApi.Report
{
    public partial class StatementDividend : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

          //  FAMSEntities context = new FAMSEntities();
          //  FAMSEntities dbcontext = new FAMSEntities();

          ////  var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_StatementDividend]").With<StatementDividentModel>().With<SDSum>().With<HDATE>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "@CustomerAccount", "BindMainGrid", Data.PageCount, Data.fromdate, Data.todate, CustomerAccountNo));

          //  var Result = dbcontext.MultipleResults("[dbo].[Sp_StatementDividend]").With<StatementDividentModel>().With<SDSum>().With<HDATE>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "@CustomerAccount", "BindMainGrid", Data.PageCount, Data.fromdate, Data.todate, CustomerAccountNo);
          //  //            ds = objManager.FillDatasetWithParam("sp_Report", "@QueryType", "@RestroId", "@FromDate", "@ToDate", "@ItemMenuGroupID"
          //  //, "@UserId", "DailySalesReport", restroid, date, todate, itemgroupid, UserId);

          //  //results[0].Cast<StatementDividentModel>().ToList();

          //  DataTable dt = ToDataTable(Result[0].Cast<StatementDividentModel>().ToList());


          //  ReportViewer1.ProcessingMode = ProcessingMode.Local;
          //  ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/StatementDividend.rdlc");
          //  //DateTime dat = DateTime.Parse(date);
          //  //DateTime todat = DateTime.Parse(todate);
          //  //ds.Tables[0].Columns.Add("Date", typeof(System.String));
          //  //foreach (DataRow dr in ds.Tables[0].Rows)
          //  //{
          //  //    //need to set value to MyRow column 
          //  //    //   dr["BranchName"] = "Daily Sales Report";   // or set it to some other value 
          //  //    dr["Date"] = dat.ToString("yyyy-MM-dd HH:mm:ss") + " - " + todat.ToString("yyyy-MM-dd HH:mm:ss");
          //  //}

          //  ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
          //  // ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[1]);
          //  //ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds.Tables[1]);

          //  //ReportViewer1.LocalReport.EnableExternalImages = true;
          //  //var path = "~/RestroImage/" + restroid + ".jpg";
          //  //string imagePath = new Uri(Server.MapPath(path)).AbsoluteUri;
          //  //ReportParameter parameter = new ReportParameter("ImagePath", imagePath);//D:\Rproject\FRD_Web\FRDWeb\FRDWeb\RestroImage\1.jpg
          //  //ReportViewer1.LocalReport.SetParameters(parameter);
          //  //ReportViewer1.LocalReport.Refresh();

          //  ReportViewer1.LocalReport.DataSources.Clear();
          //  ReportViewer1.LocalReport.DataSources.Add(datasource);
          //  //ReportViewer1.LocalReport.DataSources.Add(datasource1);
          //  //ReportViewer1.LocalReport.DataSources.Add(datasource2);
          //  Warning[] warnings;
          //  string[] streamIds;
          //  string mimeType = string.Empty;
          //  string encoding = string.Empty;
          //  string extension = string.Empty;

          //  byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
          //  Response.Buffer = true;
          //  Response.Clear();
          //  Response.ContentType = mimeType;
          //  //Response.AddHeader("content-disposition", "attachment; filename=" + FileName + "." + extension);
          //  Response.OutputStream.Write(bytes, 0, bytes.Length); // create the file  
          //  Response.Flush(); // send it to the client to download 


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
    }
}