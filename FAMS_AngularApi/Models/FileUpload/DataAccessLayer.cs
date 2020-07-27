using BusinessLibrary;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FAMS_AngularApi.Models.FileUpload
{
    public class DataAccessLayer
    {

        public Dictionary<string, object> ReadAndInsertBankBook(string FilePath)
        {
            DataTable dt; SplitCsv csv = new SplitCsv();
            FAMSEntities context = new FAMSEntities();
            try
            {
                    dt = new DataTable(); string @XmlBankBook = "";
                dt.Clear(); dt.Columns.Clear(); dt.Columns.Add("Col1", typeof(String)); dt.Columns.Add("Col2", typeof(String)); dt.Columns.Add("Col3", typeof(String)); dt.Columns.Add("Col4", typeof(String)); dt.Columns.Add("Col5", typeof(String)); dt.Columns.Add("Col6", typeof(String)); dt.Columns.Add("Col7", typeof(String)); dt.Columns.Add("Col8", typeof(String)); dt.Columns.Add("Col9", typeof(String)); dt.Columns.Add("Col10", typeof(String)); dt.Columns.Add("Col11", typeof(String)); dt.Columns.Add("Col12", typeof(String)); dt.Columns.Add("Col13", typeof(String)); dt.Columns.Add("Col14", typeof(String)); dt.Columns.Add("Col15", typeof(String));
                    if (dt != null)
                    {
                        if (dt.Columns.Count > 0)
                        {
                            using (StreamReader sr = new StreamReader(FilePath))
                            {
                                while (!sr.EndOfStream)
                                {
                                    DataRow dr = dt.NewRow();
                                    string line = sr.ReadLine();
                                    string[] rows = SplitCsv.Split(line);
                                    //FAMSEntities dbcontext = new FAMSEntities();
                                    for (int i = 0; i < rows.Length; i++)
                                    {
                                        dr[i] = rows[i];
                                    }
                                    dt.Rows.Add(dr);
                                    //if (flag == 1)
                                    //{
                                    //    dbcontext.INSERTTBTransactions(Convert.ToString(dt.Rows[0]["Col1"]), Convert.ToString(dt.Rows[0]["Col2"]), Convert.ToString(dt.Rows[0]["Col3"]), Convert.ToString(dt.Rows[0]["Col4"]), Convert.ToString(dt.Rows[0]["Col5"]), Convert.ToString(dt.Rows[0]["Col6"]), Convert.ToString(dt.Rows[0]["Col7"]), Convert.ToString(dt.Rows[0]["Col8"]), Convert.ToString(dt.Rows[0]["Col9"]));
                                    //    dt.Rows.Clear();
                                    //    dbcontext.SaveChanges();
                                    //}
                                }
                                int Row = 1;
                                string PMSProvider = "";
                                string FromDate = ""; string ToDate = "";
                                string Column1 = ""; string Column2 = ""; string Column3 = ""; string Column4 = ""; string Column5 = ""; string Column6 = ""; string Column7 = ""; string Column8 = ""; string Column9 = ""; string Column10 = ""; string Column11 = ""; string Column12 = ""; string Column13 = ""; string Column14 = ""; string Column15 = "";
                                 Boolean XMLFlag = false; Boolean IsXMLCreate = false; int FromdateCount = 1;
                                @XmlBankBook = "<dtXml>";
                                Row = 1;
                                foreach (DataRow dr in dt.Rows)
                                {

                                    if (Convert.ToString(dr["Col1"]).Trim() == PMSProvider)
                                    {
                                        FromdateCount = 1;
                                        XMLFlag = false;
                                    }

                                    if (Row == 1)
                                    {
                                        PMSProvider = Convert.ToString(dr["Col1"]);
                                        FromdateCount = 1;
                                    }
                                    if (FromdateCount == 6)
                                    {
                                        string DateRange = Convert.ToString(dr["Col1"]);
                                        string[] parts = DateRange.Split("To".ToCharArray());
                                        string[] parts2 = parts[1].Split("m".ToCharArray()); ;
                                    string[] FromDate1 = parts2[1].Split("/".ToCharArray());
                                     FromDate = FromDate1[2].Trim() + '-' + FromDate1[1].Trim() + '-' + FromDate1[0].Trim();
                                    string[] ToDate1 = parts[3].Split("/".ToCharArray());
                                     ToDate = ToDate1[2].Trim() + '-' + ToDate1[1].Trim() + '-' + ToDate1[0].Trim();
                                }
                                    if (XMLFlag == true && Convert.ToString(dr["Col1"]).Trim() != "Bank Total" && Convert.ToString(dr["Col1"]).Trim() != "" && Convert.ToString(dr["Col1"]).Trim() != "Total" && IsXMLCreate == true)
                                    {
                                        @XmlBankBook += "<dtXml ";
                                        @XmlBankBook += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                        @XmlBankBook += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                        @XmlBankBook += " ToDate=" + @"""" + Convert.ToString(ToDate).Trim() + @"""";
                                        @XmlBankBook += " " + Column1 + " =" + @"""" + Convert.ToString(dr["Col1"]) + @"""";
                                        @XmlBankBook += " " + Column2 + " =" + @"""" + Convert.ToString(dr["Col2"]).Substring(0, Convert.ToString(dr["Col2"]).IndexOf("-")).Trim() + @"""";
                                        @XmlBankBook += " " + Column3 + " =" + @"""" + Convert.ToString(dr["Col3"]) + @"""";
                                        @XmlBankBook += " " + Column4 + " =" + @"""" + Convert.ToString(dr["Col4"]) + @"""";
                                        @XmlBankBook += " " + Column5 + " =" + @"""" + Convert.ToString(dr["Col5"]) + @"""";
                                        @XmlBankBook += " " + Column6 + " =" + @"""" + Convert.ToString(dr["Col6"]) + @"""";
                                        @XmlBankBook += " " + Column7 + " =" + @"""" + Convert.ToString(dr["Col7"]) + @"""";
                                        @XmlBankBook += " " + Column8 + " =" + @"""" + Convert.ToString(dr["Col8"]) + @"""";
                                        @XmlBankBook += " " + Column9 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col9"]), ",", "") + @"""";
                                        @XmlBankBook += " " + Column10 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col10"]), ",", "") + @"""";
                                        @XmlBankBook += " " + Column11 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col11"]), ",", "") + @"""";
                                        @XmlBankBook += " " + Column12 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col12"]), ",", "") + @"""";
                                        @XmlBankBook += " " + Column13 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col13"]), ",", "") + @"""";
                                        @XmlBankBook += " " + Column14 + " =" + @"""" + Convert.ToString(dr["Col14"]) + @"""";
                                        @XmlBankBook += " " + Column15 + " =" + @"""" + Convert.ToString(dr["Col15"]) + @"""";
                                        @XmlBankBook += " />";
                                    }
                                    if (Convert.ToString(dr["Col1"]) == "Code")
                                    {
                                        Column1 = Regex.Replace(Convert.ToString(dr["Col1"]), @"\s+", "");
                                        Column2 = Regex.Replace(Convert.ToString(dr["Col2"]), @"\s+", "");
                                        Column3 = Regex.Replace(Convert.ToString(dr["Col3"]), @"\s+", "");
                                        Column4 = Regex.Replace(Convert.ToString(dr["Col4"]), @"\s+", "");
                                        Column5 = Regex.Replace(Convert.ToString(dr["Col5"]), @"\s+", "");
                                        Column6 = Regex.Replace(Convert.ToString(dr["Col6"]), @"\s+", "");
                                        Column7 = Regex.Replace(Convert.ToString(dr["Col7"]), @"\s+", "");
                                        Column8 = Regex.Replace(Convert.ToString(dr["Col8"]), @"\s+", "");
                                        Column9 = Regex.Replace(Regex.Replace(Convert.ToString(dr["Col9"]), @"\s+", ""), "/", "_");
                                        Column10 = Regex.Replace(Convert.ToString(dr["Col10"]), @"\s+", "");
                                        Column11 = Regex.Replace(Convert.ToString(dr["Col11"]), @"\s+", "");
                                        Column12 = Regex.Replace(Regex.Replace(Convert.ToString(dr["Col12"]), @"\s+", ""), "/", "_");
                                        Column13 = Regex.Replace(Convert.ToString(dr["Col13"]), @"\s+", "");
                                        Column14 = Regex.Replace(Convert.ToString(dr["Col14"]), @"\s+", "");
                                        Column15 = Regex.Replace(Convert.ToString(dr["Col15"]), @"\s+", "");
                                        XMLFlag = true;
                                        IsXMLCreate = true;
                                    }
                                    Row = Row + 1;
                                    FromdateCount = FromdateCount + 1;
                                }
                                @XmlBankBook += "</dtXml>";
                        }

                        }
                    }
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_InsertReportsData]").With<ResponseClass>()
                                               .Execute("@Querytype", "@XmlData", "InsertBankBook", @XmlBankBook));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> ReadAndInsertStatementOfDividend(string FilePath)
        {
            DataTable dt; SplitCsv csv = new SplitCsv();
            FAMSEntities context = new FAMSEntities();
            try
            {
                dt = new DataTable(); string @XmlBankBook = "";
                dt.Clear(); dt.Columns.Clear(); dt.Columns.Add("Col1", typeof(String)); dt.Columns.Add("Col2", typeof(String)); dt.Columns.Add("Col3", typeof(String)); dt.Columns.Add("Col4", typeof(String)); dt.Columns.Add("Col5", typeof(String)); dt.Columns.Add("Col6", typeof(String)); dt.Columns.Add("Col7", typeof(String)); dt.Columns.Add("Col8", typeof(String)); dt.Columns.Add("Col9", typeof(String)); dt.Columns.Add("Col10", typeof(String));
                if (dt != null)
                {
                    if (dt.Columns.Count > 0)
                    {
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            while (!sr.EndOfStream)
                            {
                                DataRow dr = dt.NewRow();
                                string line = sr.ReadLine();
                                string[] rows = SplitCsv.Split(line);
                                //FAMSEntities dbcontext = new FAMSEntities();
                                for (int i = 0; i < rows.Length; i++)
                                {
                                    dr[i] = rows[i];
                                }
                                dt.Rows.Add(dr);
                            }
                            int Row = 1;
                            string PMSProvider = "";
                            string FromDate = ""; string ToDate = "";
                            string Column1 = ""; string Column2 = ""; string Column3 = ""; string Column4 = ""; string Column5 = ""; string Column6 = ""; string Column7 = ""; string Column8 = ""; string Column9 = ""; string Column10 = ""; 
                            Boolean XMLFlag = false; Boolean IsXMLCreate = false; int FromdateCount = 1; string CustomerAccount = "";
                            string CustomerName ="";
                            string AccountCode ="";
                            @XmlBankBook = "<dtXml>";
                            Row = 1;
                            foreach (DataRow dr in dt.Rows)
                            {

                                if (Convert.ToString(dr["Col1"]).Trim() == PMSProvider)
                                {
                                    FromdateCount = 1;
                                    XMLFlag = false;
                                }

                                if (Row == 1)
                                {
                                    PMSProvider = Convert.ToString(dr["Col1"]);
                                    FromdateCount = 1;
                                }
                                if (FromdateCount == 6)
                                {
                                    string DateRange = Convert.ToString(dr["Col1"]);
                                    string[] parts = DateRange.Split("To".ToCharArray());
                                    string[] parts2 = parts[1].Split("m".ToCharArray()); ;
                                    string[] FromDate1 = parts2[1].Split("/".ToCharArray());
                                    FromDate = FromDate1[2].Trim() + '-' + FromDate1[1].Trim() + '-' + FromDate1[0].Trim();
                                    string[] ToDate1 = parts[3].Split("/".ToCharArray());
                                    ToDate = ToDate1[2].Trim() + '-' + ToDate1[1].Trim() + '-' + ToDate1[0].Trim();
                                }
                                if (FromdateCount == 7)
                                {
                                    string CustomerDetails = Convert.ToString(dr["Col1"]);
                                    string[] parts = CustomerDetails.Split(":".ToCharArray());
                                    string[] parts2 = parts[1].Split("  ".ToCharArray());
                                     CustomerAccount = parts2[1];
                                     CustomerName = parts2[6] + " " + parts2[7];
                                     AccountCode = parts2[11];
                                }
                                if (XMLFlag == true && Convert.ToString(dr["Col1"]).Trim() != "Bank Total" && Convert.ToString(dr["Col1"]).Trim() != "" && Convert.ToString(dr["Col1"]).Trim() != "Total" && IsXMLCreate == true)
                                {
                                    @XmlBankBook += "<dtXml ";
                                    @XmlBankBook += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlBankBook += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlBankBook += " ToDate=" + @"""" + Convert.ToString(ToDate).Trim() + @"""";
                                    @XmlBankBook += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlBankBook += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlBankBook += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlBankBook += " " + Column1 + " =" + @"""" + Convert.ToString(dr["Col1"]) + @"""";
                                    @XmlBankBook += " " + Column2 + " =" + @"""" + Convert.ToString(dr["Col2"]) + @"""";
                                    @XmlBankBook += " " + Column3 + " =" + @"""" + Convert.ToString(dr["Col3"]) + @"""";
                                    @XmlBankBook += " " + Column4 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col4"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column5 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col5"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column6 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col6"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column7 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col7"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column8 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col8"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column9 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col9"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column10 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col10"]), ",", "") + @"""";
                                    @XmlBankBook += " />";
                                }
                                if (Convert.ToString(dr["Col1"]) == "Ex Date")
                                {
                                    Column1 = Regex.Replace(Convert.ToString(dr["Col1"]), @"\s+", "");
                                    Column2 = Regex.Replace(Convert.ToString(dr["Col2"]), @"\s+", "");
                                    Column3 = Regex.Replace(Convert.ToString(dr["Col3"]), @"\s+", "");
                                    Column4 = Regex.Replace(Convert.ToString(dr["Col4"]), @"\s+", "");
                                    Column5 = Regex.Replace(Regex.Replace(Convert.ToString(dr["Col5"]), @"\s+", ""), "/", "_");
                                    Column6 = Regex.Replace(Convert.ToString(dr["Col6"]), @"\s+", "");
                                    Column7 = Regex.Replace(Convert.ToString(dr["Col7"]), @"\s+", "");
                                    Column8 = Regex.Replace(Convert.ToString(dr["Col8"]), @"\s+", "");
                                    Column9 = Regex.Replace(Convert.ToString(dr["Col9"]), @"\s+", "");
                                    Column10 = Regex.Replace(Convert.ToString(dr["Col10"]), @"\s+", "");
                                    XMLFlag = true;
                                    IsXMLCreate = true;
                                }
                                Row = Row + 1;
                                FromdateCount = FromdateCount + 1;
                            }
                            @XmlBankBook += "</dtXml>";
                        }

                    }
                }
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_InsertReportsData]").With<ResponseClass>()
                                               .Execute("@Querytype", "@XmlData", "InsertStatementDividend", @XmlBankBook));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> ReadAndInsertStatementOfExpenses(string FilePath)
        {
            DataTable dt; SplitCsv csv = new SplitCsv();
            FAMSEntities context = new FAMSEntities();
            try
            {
                dt = new DataTable(); string @XmlBankBook = "";
                dt.Clear(); dt.Columns.Clear(); dt.Columns.Add("Col1", typeof(String)); dt.Columns.Add("Col2", typeof(String)); dt.Columns.Add("Col3", typeof(String)); dt.Columns.Add("Col4", typeof(String)); dt.Columns.Add("Col5", typeof(String)); dt.Columns.Add("Col6", typeof(String));
                if (dt != null)
                {
                    if (dt.Columns.Count > 0)
                    {
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            while (!sr.EndOfStream)
                            {
                                DataRow dr = dt.NewRow();
                                string line = sr.ReadLine();
                                string[] rows = SplitCsv.Split(line);
                                //FAMSEntities dbcontext = new FAMSEntities();
                                for (int i = 0; i < rows.Length; i++)
                                {
                                    dr[i] = rows[i];
                                }
                                dt.Rows.Add(dr);
                            }
                            int Row = 1;
                            string PMSProvider = "";
                            string FromDate = ""; string ToDate = "";
                            string Column1 = ""; string Column2 = ""; string Column3 = ""; string Column4 = ""; string Column5 = ""; string Column6 = "";
                            Boolean XMLFlag = false; Boolean IsXMLCreate = false; int FromdateCount = 1; string CustomerAccount = "";
                            string CustomerName = "";
                            string AccountCode = "";
                            @XmlBankBook = "<dtXml>";
                            Row = 1;
                            foreach (DataRow dr in dt.Rows)
                            {

                                if (Convert.ToString(dr["Col1"]).Trim() == PMSProvider)
                                {
                                    FromdateCount = 1;
                                    XMLFlag = false;
                                }

                                if (Row == 1)
                                {
                                    PMSProvider = Convert.ToString(dr["Col1"]);
                                    FromdateCount = 1;
                                }
                                if (FromdateCount == 6)
                                {
                                    string DateRange = Convert.ToString(dr["Col1"]);
                                    string[] parts = DateRange.Split("To".ToCharArray());
                                    string[] parts2 = parts[1].Split("m".ToCharArray()); ;
                                    string[] FromDate1 = parts2[1].Split("/".ToCharArray());
                                    FromDate = FromDate1[2].Trim() + '-' + FromDate1[1].Trim() + '-' + FromDate1[0].Trim();
                                    string[] ToDate1 = parts[3].Split("/".ToCharArray());
                                    ToDate = ToDate1[2].Trim() + '-' + ToDate1[1].Trim() + '-' + ToDate1[0].Trim();
                                }
                                if (FromdateCount == 7)
                                {
                                    string CustomerDetails = Convert.ToString(dr["Col1"]);
                                    string[] parts = CustomerDetails.Split(":".ToCharArray());
                                    string[] parts2 = parts[1].Split("  ".ToCharArray());
                                    CustomerAccount = parts2[1];
                                    CustomerName = parts2[6] + " " + parts2[7];
                                    AccountCode = parts2[11];
                                }
                                if (XMLFlag == true && Convert.ToString(dr["Col1"]).Trim() != "Total Expenses - Paid" && Convert.ToString(dr["Col1"]).Trim() != "Expenses - Paid" && Convert.ToString(dr["Col1"]).Trim() != "" && Convert.ToString(dr["Col1"]).Trim() != "Total" && IsXMLCreate == true)
                                {
                                    @XmlBankBook += "<dtXml ";
                                    @XmlBankBook += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlBankBook += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlBankBook += " ToDate=" + @"""" + Convert.ToString(ToDate).Trim() + @"""";
                                    @XmlBankBook += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlBankBook += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlBankBook += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlBankBook += " " + Column1 + " =" + @"""" + Convert.ToString(dr["Col1"]) + @"""";
                                    @XmlBankBook += " " + Column2 + " =" + @"""" + Convert.ToString(dr["Col2"]) + @"""";
                                    @XmlBankBook += " TranRef=" + @"""" + Convert.ToString(dr["Col3"]) + @"""";
                                    @XmlBankBook += " " + Column4 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col4"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column5 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col5"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column6 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col6"]), ",", "") + @"""";
                                    @XmlBankBook += " />";
                                }
                                if (Convert.ToString(dr["Col1"]) == "Date")
                                {
                                    Column1 = Regex.Replace(Convert.ToString(dr["Col1"]), @"\s+", "");
                                    Column2 = Regex.Replace(Convert.ToString(dr["Col2"]), @"\s+", "");
                                    Column3 = Regex.Replace(Regex.Replace(Convert.ToString(dr["Col3"]), @"\s+", ""), ".", "");
                                    Column4 = Regex.Replace(Convert.ToString(dr["Col4"]), @"\s+", "");
                                    Column5 = Regex.Replace(Regex.Replace(Convert.ToString(dr["Col5"]), @"\s+", ""), "/", "_");
                                    Column6 = Regex.Replace(Convert.ToString(dr["Col6"]), @"\s+", "");
                                    XMLFlag = true;
                                    IsXMLCreate = true;
                                }
                                Row = Row + 1;
                                FromdateCount = FromdateCount + 1;
                            }
                            @XmlBankBook += "</dtXml>";
                        }

                    }
                }
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_InsertReportsData]").With<ResponseClass>()
                                               .Execute("@Querytype", "@XmlData", "InsertStatementExpenses", @XmlBankBook));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> ReadAndInsertTransactionStatement(string FilePath)
        {
            DataTable dt; SplitCsv csv = new SplitCsv();
            FAMSEntities context = new FAMSEntities();
            try
            {
                dt = new DataTable(); string @XmlBankBook = "";
                dt.Clear(); dt.Columns.Clear(); dt.Columns.Add("Col1", typeof(String)); dt.Columns.Add("Col2", typeof(String)); dt.Columns.Add("Col3", typeof(String)); dt.Columns.Add("Col4", typeof(String)); dt.Columns.Add("Col5", typeof(String)); dt.Columns.Add("Col6", typeof(String)); dt.Columns.Add("Col7", typeof(String)); dt.Columns.Add("Col8", typeof(String)); dt.Columns.Add("Col9", typeof(String)); dt.Columns.Add("Col10", typeof(String));
                if (dt != null)
                {
                    if (dt.Columns.Count > 0)
                    {
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            while (!sr.EndOfStream)
                            {
                                DataRow dr = dt.NewRow();
                                string line = sr.ReadLine();
                                string[] rows = SplitCsv.Split(line);
                                //FAMSEntities dbcontext = new FAMSEntities();
                                for (int i = 0; i < rows.Length; i++)
                                {
                                    dr[i] = rows[i];
                                }
                                dt.Rows.Add(dr);
                            }
                            int Row = 1;
                            string PMSProvider = "";
                            string FromDate = ""; string ToDate = "";
                            string Column1 = ""; string Column2 = ""; string Column3 = ""; string Column4 = ""; string Column5 = ""; string Column6 = ""; string Column7 = ""; string Column8 = ""; string Column9 = ""; string Column10 = "";
                            Boolean XMLFlag = false; Boolean IsXMLCreate = false; int FromdateCount = 1; string CustomerAccount = "";
                            string CustomerName = "";
                            string AccountCode = ""; Boolean IsFutureData = false;
                            @XmlBankBook = "<dtXml>";
                            Row = 1;
                            foreach (DataRow dr in dt.Rows)
                            {

                                if (Convert.ToString(dr["Col1"]).Trim() == PMSProvider)
                                {
                                    FromdateCount = 1;
                                    XMLFlag = false;
                                    IsFutureData = false;
                                }

                                if (Row == 1)
                                {
                                    PMSProvider = Convert.ToString(dr["Col1"]);
                                    FromdateCount = 1;
                                }
                                if (FromdateCount == 6)
                                {
                                    string DateRange = Convert.ToString(dr["Col1"]);
                                    string[] parts = DateRange.Split("To".ToCharArray());
                                    string[] parts2 = parts[1].Split("m".ToCharArray()); ;
                                    string[] FromDate1 = parts2[1].Split("/".ToCharArray());
                                    FromDate = FromDate1[2].Trim() + '-' + FromDate1[1].Trim() + '-' + FromDate1[0].Trim();
                                    string[] ToDate1 = parts[3].Split("/".ToCharArray());
                                    ToDate = ToDate1[2].Trim() + '-' + ToDate1[1].Trim() + '-' + ToDate1[0].Trim();
                                    IsFutureData = false;
                                }
                                if (FromdateCount == 7)
                                {
                                    string CustomerDetails = Convert.ToString(dr["Col1"]);
                                    string[] parts = CustomerDetails.Split(":".ToCharArray());
                                    string[] parts2 = parts[1].Split("  ".ToCharArray());
                                    CustomerAccount = parts2[1];
                                    CustomerName = parts2[6] + " " + parts2[7];
                                    AccountCode = parts2[11];
                                    IsFutureData = false;
                                }
                                if(IsFutureData==true)
                                {
                                    @XmlBankBook += "<dtXml ";
                                    @XmlBankBook += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlBankBook += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlBankBook += " ToDate=" + @"""" + Convert.ToString(ToDate).Trim() + @"""";
                                    @XmlBankBook += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlBankBook += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlBankBook += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlBankBook += " " + Column1 + " =" + @"""" + Convert.ToString(dr["Col1"]) + @"""";
                                    @XmlBankBook += " " + Column2 + " =" + @"""" + Convert.ToString(dr["Col2"]) + @"""";
                                    @XmlBankBook += " " + Column3 + " =" + @"""" + Convert.ToString(dr["Col3"]) + @"""";
                                    @XmlBankBook += " " + Column4 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col4"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column5 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col5"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column6 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col6"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column7 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col7"]), ",", "") + @"""";
                                    @XmlBankBook += " Brkg=" + @"""" + Regex.Replace(Convert.ToString(dr["Col8"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column9 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col9"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column10 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col10"]), ",", "") + @"""";
                                    @XmlBankBook += " IsFutureStock = " + @"""" + 1 + @"""";
                                    @XmlBankBook += " />";

                                }
                                if(Convert.ToString(dr["Col1"]).Trim() == "Futures - Stock")
                                {
                                    IsFutureData = true;
                                }
                                if (XMLFlag == true && Convert.ToString(dr["Col1"]).Trim() != "Current Period Transactions" && Convert.ToString(dr["Col1"]).Trim() != "" && Convert.ToString(dr["Col1"]).Trim() != "Current Period Settled  Transactions" && Convert.ToString(dr["Col1"]).Trim() != "Shares - Listed" && IsXMLCreate == true && IsFutureData == false)
                                {
                                    @XmlBankBook += "<dtXml ";
                                    @XmlBankBook += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlBankBook += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlBankBook += " ToDate=" + @"""" + Convert.ToString(ToDate).Trim() + @"""";
                                    @XmlBankBook += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlBankBook += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlBankBook += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlBankBook += " " + Column1 + " =" + @"""" + Convert.ToString(dr["Col1"]) + @"""";
                                    @XmlBankBook += " " + Column2 + " =" + @"""" + Convert.ToString(dr["Col2"]) + @"""";
                                    @XmlBankBook += " " + Column3 + " =" + @"""" + Convert.ToString(dr["Col3"]) + @"""";
                                    @XmlBankBook += " " + Column4 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col4"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column5 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col5"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column6 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col6"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column7 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col7"]), ",", "") + @"""";
                                    @XmlBankBook += " Brkg=" + @"""" + Regex.Replace(Convert.ToString(dr["Col8"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column9 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col9"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column10 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col10"]), ",", "") + @"""";
                                    @XmlBankBook += " IsFutureStock = " + @"""" + 0 + @"""";
                                    @XmlBankBook += " />";
                                    IsFutureData = false;
                                }
                                if (Convert.ToString(dr["Col1"]) == "Transaction Description")
                                {
                                    Column1 = Regex.Replace(Convert.ToString(dr["Col1"]), @"\s+", "");
                                    Column2 = Regex.Replace(Convert.ToString(dr["Col2"]), @"\s+", "");
                                    Column3 = Regex.Replace(Convert.ToString(dr["Col3"]), @"\s+", "");
                                    Column4 = Regex.Replace(Convert.ToString(dr["Col4"]), @"\s+", "");
                                    Column5 = Regex.Replace(Regex.Replace(Convert.ToString(dr["Col5"]), @"\s+", ""), "/", "_");
                                    Column6 = Regex.Replace(Convert.ToString(dr["Col6"]), @"\s+", "");
                                    Column7 = Regex.Replace(Convert.ToString(dr["Col7"]), @"\s+", "");
                                    Column8 = Regex.Replace(Convert.ToString(dr["Col8"]), @"\s+", "");
                                    Column9 = Regex.Replace(Convert.ToString(dr["Col9"]), @"\s+", "");
                                    Column10 = Regex.Replace(Convert.ToString(dr["Col10"]), @"\s+", "");
                                    XMLFlag = true;
                                    IsXMLCreate = true;
                                    IsFutureData = false;
                                }
                                Row = Row + 1;
                                FromdateCount = FromdateCount + 1;
                            }
                            @XmlBankBook += "</dtXml>";
                        }

                    }
                }
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_InsertReportsData]").With<ResponseClass>()
                                               .Execute("@Querytype", "@XmlData", "InsertTransStatement", @XmlBankBook));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> ReadAndInsertCapitalStatement(string FilePath)
        {
            DataTable dt; SplitCsv csv = new SplitCsv();
            FAMSEntities context = new FAMSEntities();
            try
            {
                dt = new DataTable(); string @XmlBankBook = "";
                dt.Clear(); dt.Columns.Clear(); dt.Columns.Add("Col1", typeof(String)); dt.Columns.Add("Col2", typeof(String)); dt.Columns.Add("Col3", typeof(String)); dt.Columns.Add("Col4", typeof(String)); dt.Columns.Add("Col5", typeof(String)); dt.Columns.Add("Col6", typeof(String)); dt.Columns.Add("Col7", typeof(String)); dt.Columns.Add("Col8", typeof(String)); dt.Columns.Add("Col9", typeof(String)); dt.Columns.Add("Col10", typeof(String)); dt.Columns.Add("Col11", typeof(String)); dt.Columns.Add("Col12", typeof(String)); dt.Columns.Add("Col13", typeof(String)); dt.Columns.Add("Col14", typeof(String)); dt.Columns.Add("Col15", typeof(String)); dt.Columns.Add("Col16", typeof(String)); dt.Columns.Add("Col17", typeof(String)); dt.Columns.Add("Col18", typeof(String)); dt.Columns.Add("Col19", typeof(String)); dt.Columns.Add("Col20", typeof(String)); dt.Columns.Add("Col21", typeof(String));
                if (dt != null)
                {
                    if (dt.Columns.Count > 0)
                    {
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            while (!sr.EndOfStream)
                            {
                                DataRow dr = dt.NewRow();
                                 string line = sr.ReadLine();
                                string[] rows = SplitCsv.Split(line);
                                //FAMSEntities dbcontext = new FAMSEntities();
                                for (int i = 0; i < rows.Length; i++)
                                {
                                    dr[i] = rows[i];
                                }
                                dt.Rows.Add(dr);
                            }
                            int Row = 1;
                            string PMSProvider = "";
                            string FromDate = ""; string ToDate = "";
                            string Column1 = ""; string Column2 = ""; string Column3 = ""; string Column4 = ""; string Column5 = ""; string Column6 = ""; string Column7 = ""; string Column8 = ""; string Column9 = ""; string Column10 = ""; string Column11 = ""; string Column12 = ""; string Column13 = ""; string Column14 = ""; string Column15 = "";
                            Boolean XMLFlag = false; int FromdateCount = 1; string CustomerAccount = "";
                            string CustomerName = "";
                            string AccountCode = ""; Boolean IsSecurity = false; Boolean IsTotal = false;
                            @XmlBankBook = "<dtXml>";
                            Row = 1;
                            foreach (DataRow dr in dt.Rows)
                            {

                                if (Convert.ToString(dr["Col1"]).Trim() == PMSProvider)
                                {
                                    FromdateCount = 1;
                                    IsTotal = false;
                                }
                                if(Convert.ToString(dr["Col1"]) == "Total")
                                {
                                    IsTotal = true;
                                }

                                    if (Row == 1)
                                {
                                    PMSProvider = Convert.ToString(dr["Col1"]);
                                    FromdateCount = 1;
                                }
                                if (FromdateCount == 6)
                                {
                                    string DateRange = Convert.ToString(dr["Col1"]);
                                    string[] parts = DateRange.Split("To".ToCharArray());
                                    string[] parts2 = parts[1].Split("m".ToCharArray()); ;
                                    string[] FromDate1 = parts2[1].Split("/".ToCharArray());
                                    FromDate = FromDate1[2].Trim() + '-' + FromDate1[1].Trim() + '-' + FromDate1[0].Trim();
                                    string[] ToDate1 = parts[3].Split("/".ToCharArray());
                                    ToDate = ToDate1[2].Trim() + '-' + ToDate1[1].Trim() + '-' + ToDate1[0].Trim();
                                }
                                if (FromdateCount == 7)
                                {
                                    string CustomerDetails = Convert.ToString(dr["Col1"]);
                                    string[] parts = CustomerDetails.Split(":".ToCharArray());
                                    string[] parts2 = parts[1].Split("  ".ToCharArray());
                                    CustomerAccount = parts2[1];
                                    CustomerName = parts2[6] + " " + parts2[7];
                                    AccountCode = parts2[11];
                                }
                               
                                if (FromdateCount>=11 && IsTotal==false)
                                {
                                    @XmlBankBook += "<dtXml ";
                                    @XmlBankBook += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlBankBook += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlBankBook += " ToDate=" + @"""" + Convert.ToString(ToDate).Trim() + @"""";
                                    @XmlBankBook += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlBankBook += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlBankBook += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlBankBook += " " + Column1 + " =" + @"""" + Convert.ToString(dr["Col1"]) + @"""";
                                    @XmlBankBook += " " + Column2 + " =" + @"""" + Convert.ToString(dr["Col2"]) + @"""";
                                    @XmlBankBook += " " + Column3 + " =" + @"""" + Convert.ToString(dr["Col3"]) + @"""";
                                    @XmlBankBook += " SaleRate =" + @"""" + Regex.Replace(Convert.ToString(dr["Col4"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column5 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col5"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column6 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col6"]), ",", "") + @"""";
                                    @XmlBankBook += " PurchaseRate =" + @"""" + Regex.Replace(Convert.ToString(dr["Col7"]), ",", "") + @"""";
                                    @XmlBankBook += " PriceOn =" + @"""" + Regex.Replace(Convert.ToString(dr["Col8"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column9 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col9"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column10 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col10"]), ",", "") + @"""";
                                    //@XmlBankBook += " " + Column11 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col11"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column12 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col12"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column13 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col13"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column14 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col14"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column15 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col15"]), ",", "") + @"""";
                                    @XmlBankBook += " />";
                                }
                                if (Convert.ToString(dr["Col1"]) == "Security" && IsTotal==false)
                                {
                                    Column1 = Regex.Replace(Convert.ToString(dr["Col1"]), @"\s+", "");
                                    Column2 = Regex.Replace(Convert.ToString(dr["Col2"]), @"\s+", "");
                                    Column3 = Regex.Replace(Convert.ToString(dr["Col3"]), @"\s+", "");
                                    Column4 = Regex.Replace(Convert.ToString(dr["Col4"]), @"\s+", "");
                                    Column5 = Regex.Replace(Regex.Replace(Convert.ToString(dr["Col5"]), @"\s+", ""), "/", "_");
                                    Column6 = Regex.Replace(Convert.ToString(dr["Col6"]), @"\s+", "");
                                    Column7 = Regex.Replace(Convert.ToString(dr["Col7"]), @"\s+", "");
                                    Column8 = Regex.Replace(Convert.ToString(dr["Col8"]), @"\s+", "");
                                    Column9 = Regex.Replace(Convert.ToString(dr["Col9"]), @"\s+", "");
                                    Column10 = Regex.Replace(Convert.ToString(dr["Col10"]), @"\s+", "");
                                    //Column11 = Regex.Replace(Convert.ToString(dr["Col11"]), @"\s+", "");
                                    Column12 = Regex.Replace(Convert.ToString(dr["Col12"]), @"\s+", "");
                                    Column13 = Regex.Replace(Convert.ToString(dr["Col13"]), @"\s+", "");
                                    Column14 = Regex.Replace(Convert.ToString(dr["Col14"]), @"\s+", "");
                                    Column15 = Regex.Replace(Regex.Replace(Convert.ToString(dr["Col15"]), @"\s+", ""), "-", "_"); ;

                                    XMLFlag = true;
                                }
                                Row = Row + 1;
                                FromdateCount = FromdateCount + 1;
                            }
                            @XmlBankBook += "</dtXml>";
                        }

                    }
                }
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_InsertReportsData]").With<ResponseClass>()
                                               .Execute("@Querytype", "@XmlData", "InsertCapitalStatement", @XmlBankBook));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> ReadAndInsertCurrentPortfolio(string FilePath)
        {
            DataTable dt; SplitCsv csv = new SplitCsv();
            FAMSEntities context = new FAMSEntities();
            try
            {
                dt = new DataTable(); string @XmlBankBook = "";
                dt.Clear(); dt.Columns.Clear(); dt.Columns.Add("Col1", typeof(String)); dt.Columns.Add("Col2", typeof(String)); dt.Columns.Add("Col3", typeof(String)); dt.Columns.Add("Col4", typeof(String)); dt.Columns.Add("Col5", typeof(String)); dt.Columns.Add("Col6", typeof(String)); dt.Columns.Add("Col7", typeof(String)); dt.Columns.Add("Col8", typeof(String)); dt.Columns.Add("Col9", typeof(String));
                dt.Columns.Add("Col10", typeof(String)); dt.Columns.Add("Col11", typeof(String)); dt.Columns.Add("Col12", typeof(String)); dt.Columns.Add("Col13", typeof(String));
                if (dt != null)
                {
                    if (dt.Columns.Count > 0)
                    {
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            while (!sr.EndOfStream)
                            {
                                DataRow dr = dt.NewRow();
                                string line = sr.ReadLine();
                                string[] rows = SplitCsv.Split(line);
                                //FAMSEntities dbcontext = new FAMSEntities();
                                for (int i = 0; i < rows.Length; i++)
                                {
                                    dr[i] = rows[i];
                                }
                                dt.Rows.Add(dr);
                            }
                            int Row = 1;
                            string PMSProvider = "";
                            string FromDate = ""; string ToDate = "";
                            string Column1 = ""; string Column2 = ""; string Column3 = ""; string Column4 = ""; string Column5 = ""; string Column6 = ""; string Column7 = ""; string Column8 = ""; string Column9 = "";
                            string Column10 = ""; string Column11 = ""; string Column12 = ""; string Column13 = "";
                            Boolean XMLFlag = false; int FromdateCount = 1; string CustomerAccount = "";
                            string CustomerName = "";
                            string AccountCode = ""; Boolean IsSecurity = false; Boolean IsCash = false;
                            @XmlBankBook = "<dtXml>";
                            Row = 1;
                            foreach (DataRow dr in dt.Rows)
                            {

                                if (Convert.ToString(dr["Col1"]).Trim() == PMSProvider)
                                {
                                    FromdateCount = 1;
                                    IsCash = false;
                                }
                                if (Convert.ToString(dr["Col1"]) == "Shares - Total")
                                {
                                    IsCash = true;
                                }

                                if (Row == 1)
                                {
                                    PMSProvider = Convert.ToString(dr["Col1"]);
                                    FromdateCount = 1;
                                }
                                if (FromdateCount == 6)
                                {
                                    string DateRange = Convert.ToString(dr["Col1"]);
                                    string[] parts = DateRange.Split(":".ToCharArray());
                                    string[] FromDate1 = parts[1].Split("/".ToCharArray());
                                     FromDate = FromDate1[2].Trim() + '-' + FromDate1[1].Trim() + '-' + FromDate1[0].Trim();
                                }
                                if (FromdateCount == 7)
                                {
                                    string CustomerDetails = Convert.ToString(dr["Col1"]);
                                    string[] parts = CustomerDetails.Split(":".ToCharArray());
                                    string[] parts2 = parts[1].Split("  ".ToCharArray());
                                    CustomerAccount = parts2[1];
                                    CustomerName = parts2[5] + " " + parts2[6];
                                    AccountCode = parts2[10];
                                }
                              

                                    if (FromdateCount >= 16 && IsCash == false && Convert.ToString(dr["Col1"]) != "")
                                {
                                    @XmlBankBook += "<dtXml ";
                                    @XmlBankBook += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlBankBook += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlBankBook += " ToDate=" + @"""" + Convert.ToString(ToDate).Trim() + @"""";
                                    @XmlBankBook += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlBankBook += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlBankBook += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlBankBook += " " + Column1 + " =" + @"""" + Convert.ToString(dr["Col1"]) + @"""";
                                    @XmlBankBook += " " + Column2 + " =" + @"""" + Convert.ToString(dr["Col2"]) + @"""";
                                    //@XmlBankBook += " " + Column3 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col3"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column4 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col4"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column5 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col5"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column6 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col6"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column7 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col7"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column8 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col8"]), ",", "") + @"""";
                                    @XmlBankBook += " " + Column9 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col9"]), ",", "") + @"""";
                                    @XmlBankBook += " TotalG_L=" + @"""" + Regex.Replace(Convert.ToString(dr["Col10"]), ",", "") + @"""";
                                    @XmlBankBook += " PerG_L=" + @"""" + Regex.Replace(Convert.ToString(dr["Col11"]), ",", "") + @"""";
                                    @XmlBankBook += " IRRPer=" + @"""" + Regex.Replace(Convert.ToString(dr["Col12"]), ",", "") + @"""";
                                    @XmlBankBook += " PerAssets=" + @"""" + Regex.Replace(Convert.ToString(dr["Col13"]), ",", "") + @"""";


                                    @XmlBankBook += " />";
                                }
                                if (Convert.ToString(dr["Col1"]) == "Security" && IsCash == false)
                                {
                                    Column1 = Regex.Replace(Convert.ToString(dr["Col1"]), @"\s+", "");
                                    Column2 = Regex.Replace(Convert.ToString(dr["Col2"]), @"\s+", "");
                                    //Column3 = Regex.Replace(Convert.ToString(dr["Col3"]), @"\s+", "");
                                    Column4 = Regex.Replace(Convert.ToString(dr["Col4"]), @"\s+", "");
                                    Column5 = Regex.Replace(Regex.Replace(Convert.ToString(dr["Col5"]), @"\s+", ""), "/", "_");
                                    Column6 = Regex.Replace(Convert.ToString(dr["Col6"]), @"\s+", "");
                                    Column7 = Regex.Replace(Convert.ToString(dr["Col7"]), @"\s+", "");
                                    Column8 = Regex.Replace(Convert.ToString(dr["Col8"]), @"\s+", "");
                                    Column9 = Regex.Replace(Convert.ToString(dr["Col9"]), @"\s+", "");
                                    Column10 = Regex.Replace(Regex.Replace(Convert.ToString(dr["Col10"]), @"\s+", ""), "/", "_");
                                    Column11 = Regex.Replace(Convert.ToString(dr["Col11"]), @"\s+", "");
                                    Column12 = Regex.Replace(Convert.ToString(dr["Col12"]), @"\s+", "");
                                    Column13 = Regex.Replace(Convert.ToString(dr["Col13"]), @"\s+", "");


                                    XMLFlag = true;
                                }
                                Row = Row + 1;
                                FromdateCount = FromdateCount + 1;
                            }
                            @XmlBankBook += "</dtXml>";
                        }

                    }
                }
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_InsertReportsData]").With<ResponseClass>()
                                               .Execute("@Querytype", "@XmlData", "InsertCurrentPortfolio", @XmlBankBook));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Dictionary<string, object> ReadAndInsertPerformanceAppraisal(string FilePath)
        {
            DataTable dt; SplitCsv csv = new SplitCsv();
            FAMSEntities context = new FAMSEntities();
            try
            {
                dt = new DataTable(); string @XmlBankBook = ""; string @XmlPortfolioSummary = ""; string @XmlPortfolioAllocation = ""; string @XmlPortfolioPerformance = "";
                dt.Clear(); dt.Columns.Clear(); dt.Columns.Add("Col1", typeof(String)); dt.Columns.Add("Col2", typeof(String)); dt.Columns.Add("Col3", typeof(String)); dt.Columns.Add("Col4", typeof(String)); dt.Columns.Add("Col5", typeof(String)); dt.Columns.Add("Col6", typeof(String)); dt.Columns.Add("Col7", typeof(String)); dt.Columns.Add("Col8", typeof(String)); dt.Columns.Add("Col9", typeof(String));
                dt.Columns.Add("Col10", typeof(String)); dt.Columns.Add("Col11", typeof(String)); dt.Columns.Add("Col12", typeof(String)); dt.Columns.Add("Col13", typeof(String)); dt.Columns.Add("Col14", typeof(String));
                if (dt != null)
                {
                    if (dt.Columns.Count > 0)
                    {
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            while (!sr.EndOfStream)
                            {
                                DataRow dr = dt.NewRow();
                                string line = sr.ReadLine();
                                string[] rows = SplitCsv.Split(line);
                                //FAMSEntities dbcontext = new FAMSEntities();
                                for (int i = 0; i < rows.Length; i++)
                                {
                                    dr[i] = rows[i];
                                }
                                dt.Rows.Add(dr);
                            }
                            int Row = 1;
                            string PMSProvider = "";
                            string FromDate = ""; string ToDate = "";
                            string Column1 = ""; string Column2 = ""; string Column3 = ""; string Column4 = ""; string Column5 = ""; string Column6 = ""; string Column7 = ""; string Column8 = ""; string Column9 = "";
                            string Column10 = ""; string Column11 = ""; string Column12 = ""; string Column13 = ""; string Column14 = "";
                            Boolean XMLFlag = false; int FromdateCount = 1; string CustomerAccount = ""; string CustomerName = "";
                            string AccountCode = ""; 
                            @XmlPortfolioAllocation = "<dtXml>";
                            @XmlPortfolioSummary = "<dtXml>";
                            XmlPortfolioPerformance = "<dtXml>";
                            @XmlBankBook = "<dtXml>";
                            Row = 1;
                            foreach (DataRow dr in dt.Rows)
                            {

                                if (Convert.ToString(dr["Col3"]).Trim() == PMSProvider)
                                {
                                    FromdateCount = 1;
                                }
                               

                                if (Row == 1)
                                {
                                    PMSProvider = Convert.ToString(dr["Col3"]);
                                    FromdateCount = 1;
                                }
                                if (FromdateCount == 6)
                                {
                                    string DateRange = Convert.ToString(dr["Col1"]);
                                    string[] parts = DateRange.Split("Of".ToCharArray());
                                    string[] FromDate1 = parts[2].Split("/".ToCharArray());
                                    FromDate = FromDate1[2].Trim() + '-' + FromDate1[1].Trim() + '-' + FromDate1[0].Trim();
                                }
                                if (FromdateCount == 7)
                                {
                                    string CustomerDetails = Convert.ToString(dr["Col1"]);
                                    string[] parts = CustomerDetails.Split(":".ToCharArray());
                                    string[] parts2 = parts[1].Split("  ".ToCharArray());
                                    CustomerAccount = parts2[1];
                                    CustomerName = parts2[6] + " " + parts2[7];
                                    AccountCode = parts2[11];
                                }

                                if (Convert.ToString(dr["Col4"]) != "Portfolio Allocation" && Convert.ToString(dr["Col4"]) != "" && Convert.ToString(dr["Col4"]) != "Description" && Convert.ToString(dr["Col4"]) != "Total")
                                {
                                    XmlPortfolioAllocation += "<dtXml ";
                                    XmlPortfolioAllocation += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    XmlPortfolioAllocation += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    XmlPortfolioAllocation += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    XmlPortfolioAllocation += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    XmlPortfolioAllocation += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    XmlPortfolioAllocation += " Description=" + @"""" + Convert.ToString(dr["Col4"]) + @""""; 
                                    XmlPortfolioAllocation += " MarketValue=" + @"""" + Regex.Replace(Convert.ToString(dr["Col7"]).Replace("(", "-").Replace(")", ""), ",", "") + @"""";
                                    XmlPortfolioAllocation += " PerAsstes=" + @"""" + Regex.Replace(Convert.ToString(dr["Col9"]), " %", "") + @"""";
                                    //@XmlBankBook += " " + Column3 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col3"]), ",", "") + @"""";
                                    XmlPortfolioAllocation += " />";
                                }
                                if (Convert.ToString(dr["Col5"]) != "Portfolio Performance" && Convert.ToString(dr["Col5"]) != "" && Convert.ToString(dr["Col5"]) != "Period" && Convert.ToString(dr["Col5"]) != "Returns over 1 year period are annualized.")
                                {
                                    @XmlPortfolioPerformance += "<dtXml ";
                                    @XmlPortfolioPerformance += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlPortfolioPerformance += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlPortfolioPerformance += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlPortfolioPerformance += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlPortfolioPerformance += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlPortfolioPerformance += " Period=" + @"""" + Convert.ToString(dr["Col5"]) + @"""";
                                    @XmlPortfolioPerformance += " Portfolio= " + @"""" + Regex.Replace(Regex.Replace(Convert.ToString(dr["Col10"]), "%", ""), @"\s+", "") + @"""";
                                    @XmlPortfolioPerformance += " NIFTY= " + @"""" + Regex.Replace(Regex.Replace(Convert.ToString(dr["Col11"]), "%", ""), @"\s+", "") + @"""";
                                    @XmlPortfolioPerformance += " BSE500= " + @"""" + Regex.Replace(Regex.Replace(Convert.ToString(dr["Col13"]), "%", ""), @"\s+", "") + @"""";
                                    //@XmlBankBook += " " + Column3 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col3"]), ",", "") + @"""";
                                    @XmlPortfolioPerformance += " />";
                                }

                                if (Convert.ToString(dr["Col12"]) != "Portfolio Summary" && Convert.ToString(dr["Col12"]) != "")
                                {
                                    @XmlPortfolioSummary += "<dtXml ";
                                    @XmlPortfolioSummary += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlPortfolioSummary += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlPortfolioSummary += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlPortfolioSummary += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlPortfolioSummary += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlPortfolioSummary += " Heading=" + @"""" + Convert.ToString(dr["Col12"]) + @"""";
                                    @XmlPortfolioSummary += " Data=" + @"""" + Regex.Replace(Convert.ToString(dr["Col14"]), ",", "") + @"""";
                                    @XmlPortfolioSummary += " />";
                                    }
            
                                Row = Row + 1;
                                FromdateCount = FromdateCount + 1;
                            }
                           // @XmlBankBook += "</dtXml>";
                            XmlPortfolioAllocation += "</dtXml>";
                            @XmlPortfolioPerformance += "</dtXml>";
                            @XmlPortfolioSummary += "</dtXml>";


                            }

                    }
                }
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_InsertReportsData]").With<ResponseClass>()
                                               .Execute("@Querytype", "@XmlPortfolioAllocation", "@XmlPortfolioPerformance", "@XmlPortfolioSummary", "InsertPerformanceAppraisal", XmlPortfolioAllocation, @XmlPortfolioPerformance, @XmlPortfolioSummary));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> ReadAndInsertPortfolioFactSheet(string FilePath)
        {
            DataTable dt; SplitCsv csv = new SplitCsv();
            FAMSEntities context = new FAMSEntities();
            try
            {
                dt = new DataTable(); string @XmlPortfolioSummary = ""; string @XmlSectorAllocation = ""; string @XmlPortfolioHolding = "";
                dt.Clear(); dt.Columns.Clear(); dt.Columns.Add("Col1", typeof(String)); dt.Columns.Add("Col2", typeof(String)); dt.Columns.Add("Col3", typeof(String)); dt.Columns.Add("Col4", typeof(String)); dt.Columns.Add("Col5", typeof(String)); dt.Columns.Add("Col6", typeof(String)); dt.Columns.Add("Col7", typeof(String)); dt.Columns.Add("Col8", typeof(String)); dt.Columns.Add("Col9", typeof(String));
                dt.Columns.Add("Col10", typeof(String)); dt.Columns.Add("Col11", typeof(String)); dt.Columns.Add("Col12", typeof(String)); dt.Columns.Add("Col13", typeof(String)); dt.Columns.Add("Col14", typeof(String));
                if (dt != null)
                {
                    if (dt.Columns.Count > 0)
                    {
                        using (StreamReader sr = new StreamReader(FilePath))
                        {
                            while (!sr.EndOfStream)
                            {
                                DataRow dr = dt.NewRow();
                                string line = sr.ReadLine();
                                string[] rows = SplitCsv.Split(line);
                                //FAMSEntities dbcontext = new FAMSEntities();
                                for (int i = 0; i < rows.Length; i++)
                                {
                                    dr[i] = rows[i];
                                }
                                dt.Rows.Add(dr);
                            }
                            int Row = 1;

                            string PMSProvider = "";
                            string FromDate = ""; string ToDate = "";
                            string Column1 = ""; string Column2 = ""; string Column3 = ""; string Column4 = ""; string Column5 = ""; string Column6 = ""; string Column7 = ""; string Column8 = ""; string Column9 = "";
                            string Column10 = ""; string Column11 = ""; string Column12 = ""; string Column13 = ""; string Column14 = "";
                            Boolean XMLFlag = false; int FromdateCount = 1; string CustomerAccount = ""; string CustomerName = "";
                            string AccountCode = "";
                            @XmlPortfolioHolding = "<dtXml>";
                            @XmlSectorAllocation = "<dtXml>";
                            @XmlPortfolioSummary = "<dtXml>";
                            Row = 1;
                            foreach (DataRow dr in dt.Rows)
                            {

                                if (Convert.ToString(dr["Col1"]).Trim() == PMSProvider)
                                {
                                    FromdateCount = 1;
                                }


                                if (Row == 1)
                                {
                                    PMSProvider = Convert.ToString(dr["Col1"]);
                                    FromdateCount = 1;
                                }
                                if (FromdateCount == 7)
                                {
                                    string DateRange = Convert.ToString(dr["Col1"]);
                                    string[] parts = DateRange.Split(":".ToCharArray());
                                    string[] FromDate1 = parts[1].Split("/".ToCharArray());
                                    FromDate = FromDate1[2].Trim() + '-' + FromDate1[1].Trim() + '-' + FromDate1[0].Trim();
                                }
                                if (FromdateCount == 6)
                                {
                                    string CustomerDetails = Convert.ToString(dr["Col1"]);
                                    string[] parts = CustomerDetails.Split(":".ToCharArray());
                                    string[] parts2 = parts[1].Split("  ".ToCharArray());
                                    CustomerAccount = parts2[2];
                                    CustomerName = parts2[4] + " " + parts2[5];
                                    AccountCode = parts2[9];
                                }

                                if (Convert.ToString(dr["Col4"]) != "Sector" && Convert.ToString(dr["Col4"]) != "")
                                {
                                    @XmlSectorAllocation += "<dtXml ";
                                    @XmlSectorAllocation += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlSectorAllocation += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlSectorAllocation += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlSectorAllocation += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlSectorAllocation += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlSectorAllocation += " Sector=" + @"""" + Convert.ToString(dr["Col4"]) + @"""";
                                    @XmlSectorAllocation += " Asstes=" + @"""" + Regex.Replace(Regex.Replace(Convert.ToString(dr["Col8"]), "%", ""), ",", "") + @"""";
                                    //@XmlBankBook += " " + Column3 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col3"]), ",", "") + @"""";
                                    @XmlSectorAllocation += " />";
                                }
                                if (Convert.ToString(dr["Col11"]) != "Security" && Convert.ToString(dr["Col11"]) != "")
                                {
                                    @XmlPortfolioHolding += "<dtXml ";
                                    @XmlPortfolioHolding += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlPortfolioHolding += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlPortfolioHolding += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlPortfolioHolding += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlPortfolioHolding += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlPortfolioHolding += " Security=" + @"""" + Convert.ToString(dr["Col11"]) + @"""";
                                    @XmlPortfolioHolding += " Sector= " + @"""" + Regex.Replace(Regex.Replace(Convert.ToString(dr["Col12"]), "%", ""), @"\s+", "") + @"""";
                                    @XmlPortfolioHolding += " MktValue= " + @"""" + Regex.Replace(Regex.Replace(Convert.ToString(dr["Col13"]), ",", ""), @"\s+", "") + @"""";
                                    @XmlPortfolioHolding += " PerAssets= " + @"""" + Regex.Replace(Regex.Replace(Convert.ToString(dr["Col14"]), "%", ""), @",", "") + @"""";
                                    //@XmlBankBook += " " + Column3 + " =" + @"""" + Regex.Replace(Convert.ToString(dr["Col3"]), ",", "") + @"""";
                                    @XmlPortfolioHolding += " />";
                                }

                               
                                if (Convert.ToString(dr["Col1"]) == "Performance(TWRR)")
                                {
                                    XMLFlag = false;
                                }
                                    if (XMLFlag==true && Convert.ToString(dr["Col1"]) != "")
                                { 
                                    @XmlPortfolioSummary += "<dtXml ";
                                    @XmlPortfolioSummary += " PMSProvider=" + @"""" + PMSProvider + @"""";
                                    @XmlPortfolioSummary += " FromDate=" + @"""" + Convert.ToString(FromDate).Trim() + @"""";
                                    @XmlPortfolioSummary += " CustomerAccount=" + @"""" + Convert.ToString(CustomerAccount).Trim() + @"""";
                                    @XmlPortfolioSummary += " CustomerName=" + @"""" + Convert.ToString(CustomerName).Trim() + @"""";
                                    @XmlPortfolioSummary += " AccountCode=" + @"""" + Convert.ToString(AccountCode).Trim() + @"""";
                                    @XmlPortfolioSummary += " Heading=" + @"""" + Convert.ToString(dr["Col1"]) + @"""";
                                    @XmlPortfolioSummary += " Data=" + @"""" + Regex.Replace(Convert.ToString(dr["Col6"]), ",", "") + @"""";
                                    @XmlPortfolioSummary += " />";
                                }
                                if (Convert.ToString(dr["Col1"]) == "Portfolio Summary" && Convert.ToString(dr["Col1"]) != "")
                                {
                                    XMLFlag = true;
                                }

                                Row = Row + 1;
                                FromdateCount = FromdateCount + 1;
                            }
                            @XmlSectorAllocation += "</dtXml>";
                            @XmlPortfolioHolding += "</dtXml>";
                            @XmlPortfolioSummary += "</dtXml>";


                        }

                    }
                }
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_InsertReportsData]").With<ResponseClass>()
                                               .Execute("@Querytype", "@XmlPortfolioSummary", "@XmlSectorAllocation", "@XmlPortfolioHolding", "InsertPortfolioFactSheet", @XmlPortfolioSummary, @XmlSectorAllocation, @XmlPortfolioHolding));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}