using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Net.Http;
using BusinessLibrary;

using EntityDAL;
using Encryptions;
using System.Data;
using FAMS_AngularApi.Models;
using System.Reflection;
using Newtonsoft.Json;
using System.Xml;
using FAMS_AngularApi.Models.AutoReportRequest;

namespace FAMS_AngularApi.Models.AutoReportRequest
{
    public class AutoReportRequest
    {
        FAMSEntities dbcontext = new FAMSEntities();
        public string GetXmlByDatable(DataTable dtObjectforXml)
        {
            if (dtObjectforXml == null)
                return "";
            if (dtObjectforXml.Rows.Count == 0)
                return "";

            if (dtObjectforXml.TableName == "")
                dtObjectforXml.TableName = "dtXml";

            XmlDocument objectXmlDocument = new XmlDocument();
            XmlElement objElement = objectXmlDocument.CreateElement(dtObjectforXml.TableName);

            for (int iRecordCounter = 0; iRecordCounter < dtObjectforXml.Rows.Count; iRecordCounter++)
            {
                // Generate XmlObject and Append Nodes by calling a Child function.
                objElement.AppendChild(BuildXmlElement(dtObjectforXml.Rows[iRecordCounter], objectXmlDocument));
            }

            objectXmlDocument.AppendChild(objElement);
            return objectXmlDocument.OuterXml;
        }

        private XmlElement BuildXmlElement(DataRow drObjectforXml, XmlDocument objectXmlDocument)
        {
            XmlElement XmlElement = objectXmlDocument.CreateElement(drObjectforXml.Table.TableName);
            for (int iColumnCounter = 0; iColumnCounter < drObjectforXml.Table.Columns.Count; iColumnCounter++)
            {
                XmlElement.SetAttribute(drObjectforXml.Table.Columns[iColumnCounter].ColumnName, Convert.ToString(drObjectforXml[iColumnCounter].ToString()));
            }

            return XmlElement;
        }

        public Dictionary<string, object> SaveAutoReportRequest(string EData)
        {
            DataTable dts = (DataTable)JsonConvert.DeserializeObject(EData, (typeof(DataTable)));
            string Insert_MandateID_BulkSMS_xml = GetXmlByDatable(dts);
            //DataTable dt = CommonManger.FillDatatableWithParam("Sp_SendEmail", "@QueryType", "@Insert_MandateID_BulkSMS_xml", "@Activity", "Insert_MandateID_BulkSMS", Insert_MandateID_BulkSMS_xml, ActivityID);

            var Result = Common.Getdata(dbcontext.MultipleResults("[dbo].[FAMS_AutoReportRequest]").With<Result>().Execute("@QueryType", "@Insert_MandateID_BulkSMS_xml", "SaveAutoReportRequest", Insert_MandateID_BulkSMS_xml));
            return Result;
        }

        public Dictionary<string, object> BindAutoReportRequest(JsonFields Data)
        {
            var Result = Common.Getdata(dbcontext.MultipleResults("[dbo].[FAMS_AutoReportRequest]").With<BindAutoReportRequestData>().Execute("@QueryType", "@CustomerAccount", "BindAutoReportRequest", Data.CustomerAccount));
            return Result;
        }

        public Dictionary<string, object> BindAllAutoReportRequest()
        {
            var Result = Common.Getdata(dbcontext.MultipleResults("[dbo].[FAMS_AutoReportRequest]").With<BindAllAutoReportRequestData>().Execute("@QueryType", "BindAllAutoReportRequest"));
            return Result;
        }

        public Dictionary<string, object> ViewAllAutoReportRequest(JsonFields Data)
        {
            var Result = Common.Getdata(dbcontext.MultipleResults("[dbo].[FAMS_AutoReportRequest]").With<ViewAllAutoReportRequest>().Execute("@QueryType", "@CustomerAccount", "ViewAllAutoReportRequest", Data.CustomerAccount));
            return Result;
        }
        public static DataTable ToDataTable<T>(List<T> items)
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

        public Dictionary<string, object> SendMailAllAutoReportRequest(JsonFields Data)
        {
            List<SendMailAllAutoReportRequest> Gridlist = new List<SendMailAllAutoReportRequest>();            
            var Result = dbcontext.MultipleResults("[dbo].[FAMS_AutoReportRequest]").With<SendMailAllAutoReportRequest>().Execute("@QueryType", "@CustomerAccount", "SendMailAllAutoReportRequest", Data.CustomerAccount);
            Gridlist = Result[0].Cast<SendMailAllAutoReportRequest>().ToList();
            DataTable dt = new DataTable();
            dt = ToDataTable(Gridlist);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //var EmailId = "bibhu@yoekisoft.com";
                var EmailId = dt.Rows[i]["EmailId"].ToString();
                var UserName = dt.Rows[i]["UserName"].ToString();
                        var AccountNo = dt.Rows[i]["AccountNo"].ToString();
                      var DownloadLink = dt.Rows[i]["DownloadLink"].ToString();

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        StringBuilder sb = new StringBuilder();
                        string WebAppUrl = ConfigurationManager.AppSettings["WebAppUrl"].ToString();
                        string SMTPHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                        string FromMailId = ConfigurationManager.AppSettings["UserId"].ToString();
                        string MailPassword = ConfigurationManager.AppSettings["MailPassword"].ToString();
                        string SMTPPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
                        string SMTPEnableSsl = ConfigurationManager.AppSettings["SMTPEnableSsl"].ToString();
                        sb.Append("Dear " + UserName + ",<br> <br>");
                        sb.Append("Please find attached pdf for your reference. <br> <br>");
                        // string User = HttpContext.Current.Server.UrlEncode(Dbsecurity.Encrypt(dataList1.Cast<UserDetails>().ToList().Select(x => x.UserId).First().ToString()));
                        // sb.Append("<a href=' " + WebAppUrl + "ChangePassword/" + User + "' target='_blank'>");
                        //sb.Append("<input style='background-color: #3965a9;color: #fff;padding: 3px 10px 3px 10px;' type='button' value='Change Password' /></a> </div>");

                        sb.Append("Sincerely,<br>");
                        sb.Append("Yoeki Support Team <br> <br>");

                        SmtpClient smtpClient = new SmtpClient();
                        MailMessage mailmsg = new MailMessage();
                        MailAddress mailaddress = new MailAddress(FromMailId);
                        mailmsg.To.Add(EmailId);
                        mailmsg.From = mailaddress;

                        mailmsg.Subject = "All Auto Request : "+DownloadLink;
                        mailmsg.IsBodyHtml = true;
                        mailmsg.Body = sb.ToString();


                        System.Net.Mail.Attachment attachment;
                        //attachment = new System.Net.Mail.Attachment(ConfigurationManager.AppSettings["ExcelFilePath"] + "\\" + ConfigurationManager.AppSettings["ExcelFileName"]);
                       // attachment = new System.Net.Mail.Attachment(ConfigurationManager.AppSettings["ExcelFilePath"] + DownloadLink);
                        attachment = new System.Net.Mail.Attachment(HttpContext.Current.Server.MapPath(DownloadLink).Replace("\\api\\AutoReportRequest",""));

                        //HttpContext.Current.Server.MapPath("Customerwisedata/3/6010001/6010001_30-06-2020.pdf")
                        //attachment = new System.Net.Mail.Attachment(ConfigurationManager.AppSettings["ExcelFilePath"] + "Customerwisedata\\4\\6010001\\6010001_30-06-2020.pdf");
                        attachment.Name = DownloadLink;//ConfigurationManager.AppSettings["ExcelFileName"];
                        mailmsg.Attachments.Add(attachment);


                        smtpClient.Host = SMTPHost;
                        smtpClient.Port = Convert.ToInt32(SMTPPort);
                        smtpClient.EnableSsl = Convert.ToBoolean(SMTPEnableSsl);
                        smtpClient.UseDefaultCredentials = true;
                        smtpClient.Credentials = new System.Net.NetworkCredential(FromMailId, MailPassword);
                        smtpClient.Send(mailmsg);
                        //QuickCheck_AngularEntities dbcontext = new QuickCheck_AngularEntities();
                        //dbcontext.MultipleResults("[dbo].[Sp_SendEmail]").With<Responsevalue>().Execute("@QueryType", "@MandateId", "@EmailCount", "@SmsCount", "SendMail", Convert.ToString(0), "1", "0");

                        //emailobect.Flag = "1";
                        //emailobect.FlagValue = "Email sent successfully!!";
                        //common.Add(emailobect);

                    }
                }

            }

            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Success", "1");
            return d;
            //return Result;
        }
    }
}