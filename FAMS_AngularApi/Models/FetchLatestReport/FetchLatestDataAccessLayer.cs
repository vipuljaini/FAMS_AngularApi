using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.FetchLatestReport;
using FAMS_AngularApi.Models.TransactionStatement;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Acrobat;
using AFORMAUTLib;
using System.Collections;
using System.IO;
using System.Text;
using System.Reflection;
using System.Diagnostics;
namespace FAMS_AngularApi.Models.FetchLatestReport
{
    public class FetchLatestDataAccessLayer
    {
        string Reportname = ""; string FORM_NAME = ""; string pageText = "";
        public string GetFetchLatestReport(FetchLatestReport Data)
        {
            try
            {
                // int Reporttype = 8; pageText = "6010001"; string shortpath = string.Empty; string Fromdate = string.Empty; string Todate = string.Empty; string[] datecheckarr;
                int Reporttype = Data.ReportName; pageText = Data.CustomerAccount; string shortpath = string.Empty; string Fromdate = string.Empty; string Todate = string.Empty; string[] datecheckarr;
                Int64 schemeid = 0;
                List<SchemeMasterdata> dataList = new List<SchemeMasterdata>();
                switch (Reporttype)
                {
                    case 1:
                        Reportname = "BANK BOOK Client" + ".pdf";
                        break;
                    case 2:
                        Reportname = "Current Portfolio Clientwise" + ".pdf";
                        break;
                    case 3:
                        Reportname = "Performance Appraisal Clientwise" + ".pdf";
                        break;
                    case 4:
                        Reportname = "Portfolio Appraisal Clientwise" + ".pdf";
                        break;
                    case 5:
                        Reportname = "Portfolio Fact Sheet" + ".pdf";
                        break;
                    case 6:
                        Reportname = "Statement of Capital Gain clientwise" + ".pdf";
                        break;
                    case 7:
                        Reportname = "Statement of Dividend Clientwise" + ".pdf";
                        break;
                    case 8:
                        Reportname = "Statement of Expenses Clientwise" + ".pdf";
                        break;

                    case 9:
                        Reportname = "Transaction Statement Cleintwise" + ".pdf";
                        break;

                }

                string SourceDirectorypath = ""; string[] files; string pdffilename = ""; string DestinationDirectorypath = "";
                SourceDirectorypath = HttpContext.Current.Server.MapPath("//FAMSIN//");
                DestinationDirectorypath = HttpContext.Current.Server.MapPath("//FAMSOUT//");
                files = Directory.GetFiles(SourceDirectorypath, "*.pdf");
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        pdffilename = Path.GetFileName(file);
                        if (pdffilename == Reportname && pageText != "")
                        {
                            FORM_NAME = SourceDirectorypath + Reportname;
                            CAcroApp acroApp = new AcroAppClass();
                            acroApp.Show();
                            string datewisedata = string.Empty; string pagefromdate = ""; string pagelastindex = "";
                            string Pagescheme = string.Empty; string DatabasePagescheme = string.Empty;
                            Dictionary<Int64, string> Schemelist = new Dictionary<Int64, string>();
                            FAMSEntities context = new FAMSEntities();
                            try
                            {

                                var results = context.MultipleResults("[dbo].[BindSchememaster]").With<SchemeMasterdata>()
                                          .Execute("@Querytype", "@Cust_code", "BindScheme", pageText);

                                foreach (var schemedatab in results)
                                {

                                    dataList = schemedatab.Cast<SchemeMasterdata>().ToList();
                                    if (dataList.Count > 0)
                                    {
                                        for (int i = 0; i < dataList.Count; i++)
                                        {


                                            Schemelist.Add(Convert.ToInt32(dataList[i].SMDID), Convert.ToString(dataList[i].SchemaNumber.ToString()));
                                        }

                                    }
                                }

                                //   break;
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }

                            CAcroAVDoc avDoc = new AcroAVDocClass();
                            if (!avDoc.Open(FORM_NAME, ""))
                            {
                                //string szMsg = "Cannot open" + FORM_NAME + ".\n";
                                //Console.WriteLine(szMsg);
                                //return;
                            }
                            AcroPDDoc doc = (AcroPDDoc)avDoc.GetPDDoc();
                            AcroPDPage page; Object newDoc = null; ArrayList kk = new ArrayList();
                            int pages = doc.GetNumPages();
                            object jso, jsNumWords, jsWord;
                            jso = doc.GetJSObject();
                            for (int i = 0; i < pages; i++)
                            {
                                page = (AcroPDPage)doc.AcquirePage(i);
                                List<string> words = new List<string>();
                                try
                                {
                                    if (jso != null)
                                    {
                                        object[] argsy = new object[] { i };
                                        jsNumWords = jso.GetType().InvokeMember("getPageNumWords",
                                            System.Reflection.BindingFlags.InvokeMethod, null, jso, argsy, null);
                                        int numWords = Int32.Parse(jsNumWords.ToString());
                                        for (int j = 0; j <= numWords; j++)
                                        {
                                            object[] argsj = new object[] { i, j, false };
                                            jsWord = jso.GetType().InvokeMember("getPageNthWord", System.Reflection.BindingFlags.InvokeMethod, null, jso, argsj, null);
                                            words.Add((string)jsWord);
                                        }
                                    }
                                    for (int x = 0; x < words.Count; x++)
                                    {
                                        int result = String.Compare(words[x].ToString().Trim(), pageText.Trim());
                                        if (result == 0)
                                        {
                                            newDoc = null;
                                            pagelastindex += i + ",";
                                            if (Reporttype == 1 || Reporttype == 6 || Reporttype == 7 || Reporttype == 8 || Reporttype == 9)
                                            {

                                                if (string.IsNullOrEmpty(datewisedata))
                                                {
                                                    pagefromdate = "From";
                                                    for (int m = x; m < words.Count; m++)
                                                    {
                                                        int datecheck = String.Compare(words[m].ToString().Trim(), pagefromdate.Trim());
                                                        if (datecheck == 0)
                                                        {
                                                            for (int y = m + 1; y < m + 8; y++)
                                                            {
                                                                datewisedata += words[y].ToString();


                                                            }
                                                            datecheckarr = datewisedata.Replace("\n", "").Replace("\r", "").Trim().Split('T');
                                                            Fromdate = datecheckarr[0].ToString().Trim();
                                                            Todate = datecheckarr[1].ToString().Replace("o", "").Trim();
                                                            break;
                                                        }
                                                    }

                                                }
                                            }
                                            else if (Reporttype == 2)
                                            {
                                                if (string.IsNullOrEmpty(datewisedata))
                                                {
                                                    pagefromdate = "Report";
                                                    for (int m = x; m < words.Count; m++)
                                                    {
                                                        int datecheck = String.Compare(words[m].ToString().Trim(), pagefromdate.Trim());
                                                        if (datecheck == 0)
                                                        {
                                                            for (int y = m + 3; y < m + 6; y++)
                                                            {
                                                                datewisedata += words[y].ToString();
                                                            }
                                                            Fromdate = datewisedata.Replace("\n", "").Replace("\r", "").Trim();
                                                            break;
                                                        }
                                                    }

                                                }
                                            }
                                            else if (Reporttype == 3 || Reporttype == 4)
                                            {
                                                if (string.IsNullOrEmpty(datewisedata))
                                                {
                                                    pagefromdate = "As";
                                                    for (int m = x; m < words.Count; m++)
                                                    {
                                                        int datecheck = String.Compare(words[m].ToString().Trim(), pagefromdate.Trim());
                                                        if (datecheck == 0)
                                                        {
                                                            for (int y = m + 2; y < m + 5; y++)
                                                            {
                                                                datewisedata += words[y].ToString();
                                                            }
                                                            Fromdate = datewisedata.Replace("\n", "").Replace("\r", "").Trim();
                                                            break;
                                                        }
                                                    }

                                                }
                                            }

                                            else if (Reporttype == 5)
                                            {
                                                if (string.IsNullOrEmpty(datewisedata))
                                                {
                                                    pagefromdate = "As";
                                                    for (int m = 0; m < words.Count; m++)
                                                    {
                                                        int datecheck = String.Compare(words[m].ToString().Trim(), pagefromdate.Trim());
                                                        if (datecheck == 0)
                                                        {
                                                            for (int y = m + 2; y < m + 5; y++)
                                                            {
                                                                datewisedata += words[y].ToString();
                                                            }
                                                            Fromdate = datewisedata.Replace("\n", "").Replace("\r", "").Trim();
                                                            break;
                                                        }
                                                    }

                                                }
                                            }

                                            //DMSNEWEntities context = new DMSNEWEntities();
                                            //Dictionary<Int64, string> Partnerid = new Dictionary<Int64, string>();
                                            //Partnerid = context.DMS_Partner().AsEnumerable().Select(x => new { Partid = x.PartnerId, PartCode = x.PartnerCode }).Distinct().ToDictionary(o => o.Partid, o => o.PartCode);
                                            if (string.IsNullOrEmpty(Pagescheme))
                                            {
                                                for (int m = 0; m < words.Count; m++)
                                                {
                                                    if (Schemelist.Count > 0)
                                                    {
                                                        for (int count = 0; count < Schemelist.Count; count++)
                                                        {
                                                            var element = Schemelist.ElementAt(count);
                                                            var Key = element.Key;
                                                            var Value = element.Value;
                                                            DatabasePagescheme = Value;
                                                            string kk1 = words[m].ToString();
                                                            int schemecheck = String.Compare(words[m].ToString().Replace("\n", "").Replace("\r", "").Trim(), DatabasePagescheme.Trim());
                                                            if (schemecheck == 0)
                                                            {
                                                                Pagescheme = words[m].ToString();
                                                                schemeid = Key;
                                                                break;
                                                            }
                                                        }

                                                    }


                                                }

                                            }



                                        }

                                    }
                                    //  }




                                }
                                catch
                                {
                                }

                            }
                            try
                            {
                                if (pagelastindex != "")
                                {
                                    string[] data = pagelastindex.Split(',');
                                    kk.Add(data[0]);
                                    if (data.Length > 2)
                                    {
                                        kk.Add(data[data.Length - 2]);
                                    }

                                }
                                if (kk.Count > 0)
                                {
                                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Customerwisedata/" + Reporttype + "/" + pageText)))
                                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Customerwisedata/" + Reporttype + "/" + pageText));
                                    string filename = string.Empty;
                                    string targetPath = string.Empty;
                                    filename = pageText + "_" + datewisedata.Replace("\n", "").Replace("\r", "").Trim().Replace(" ", "").Replace("/", "-") + ".pdf";
                                    object[] extractPagesParam = kk.ToArray();
                                    //kk.ToArray();

                                    newDoc = jso.GetType().InvokeMember(
                                        "extractPages",
                                        BindingFlags.InvokeMethod |
                                        BindingFlags.Public |
                                        BindingFlags.Instance,
                                        null, jso, extractPagesParam);

                                    targetPath = HttpContext.Current.Server.MapPath("~/Customerwisedata/" + Reporttype + "/" + pageText + "/" + @"\" + filename);
                                    shortpath = "Customerwisedata/" + Reporttype + "/" + pageText + "/" + filename;
                                    object[] saveAsParam = { targetPath };
                                    newDoc.GetType().InvokeMember(
                                        "saveAs", System.Reflection.BindingFlags.InvokeMethod, null, newDoc, saveAsParam);


                                    if (pageText != "" && Reporttype != 0 && pageText != "0")
                                    {
                                        FAMSEntities dbcontext = new FAMSEntities();


                                        var results = dbcontext.MultipleResults("[dbo].[BindSchememaster]").With<Responsecls>()
                                                  .Execute("@Querytype", "@Fromdate", "@Todate", "@Cust_code", "@Schemeid", "@Shortpath", "@Reporttype", "@ReportName", "InsertAllReportHistoryData", Fromdate.Trim(), Todate.Trim(), pageText, Convert.ToString(schemeid), shortpath, Convert.ToString(Reporttype), Reportname);
                                    }

                                }
                            }
                            catch { }

                            avDoc.Close(0);
                            avDoc.ClearSelection();
                            acroApp.CloseAllDocs();
                            doc.Close();
                            acroApp.Hide();
                            acroApp.Exit();
                            //string pname = "Acrobat";
                            //string localMachineName = Environment.MachineName;
                            //var runningProcess = Process.GetProcesses(localMachineName);
                            //int c= runningProcess.Count();
                            //foreach (var process in runningProcess)
                            //{
                            //    if (process.ProcessName.Trim() == pname)
                            //    {
                            //        process.Kill();
                            //    }

                            //}
                            //string sourceFile = System.IO.Path.Combine(SourceDirectorypath, pdffilename);
                            //String Todaysdate = DateTime.Now.ToString("yyyy-MM-dd");
                            //if (!Directory.Exists(DestinationDirectorypath + Todaysdate))
                            //{
                            //    var DIR = Directory.CreateDirectory(DestinationDirectorypath + Todaysdate);

                            //}

                            //string destFile = System.IO.Path.Combine(DestinationDirectorypath + Todaysdate, pdffilename);
                            //System.IO.File.Copy(sourceFile, destFile, true);

                            //if (File.Exists(destFile))
                            //{

                            //     System.IO.File.Delete(sourceFile);
                            //}

                        }

                        /////////////Move file from source to destination


                    }
                  

                }

            }
            catch (Exception ex) { }

            return "1";
        }

    }
}