using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using EntityDAL;
using FAMS_AngularApi.Models.AllCustomer;
using FAMS_AngularApi.Models.GraphBind;
using Encryptions;
using System.IO;
using System.Web.UI;
using System.Text;
using System.Configuration;
using System.Net.Mail;

namespace FAMS_AngularApi.Models.AllCustomer
{
    public class DataAccessLayer
    {

        public Dictionary<string, object> BindGGrid()
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_user]").With<Employee>().With<Customer>().With<ReportLink>().Execute("@QueryType", "BindGraphUser"));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindGrid(string UserId)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_user]").With<CustomerDetails>().Execute("@QueryType","@UserId", "BindUser",Dbsecurity.Decrypt(UserId).ToString()));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<CustomerResponse> SaveCustomer(JsonCustomerDetails Data, string UserId)
        {
            FAMSEntities context = new FAMSEntities();
            CustomerResponse ObjCustResponse = new CustomerResponse();
            try
            {
                string Password = string.Empty;
                List<CustomerResponse> dataList = new List<CustomerResponse>();
                Password = Dbsecurity.Encrypt(Data.CustomerEmailID.Split('@').ElementAtOrDefault(0));
                var results = context.MultipleResults("[dbo].[Sp_user]").With<CustomerResponse>().Execute("@QueryType", "@UserId", "@UserName", "@AccountNo", "@EmailId", "@Password", "SaveData", Dbsecurity.Decrypt(UserId).ToString(),Data.CustomerUsername.ToString(),Data.CustomerAccount.ToString(), Data.CustomerEmailID.ToString(), Password.ToString());
                //results.tab
                dataList = results.FirstOrDefault().Cast<CustomerResponse>().ToList();
                if (dataList.Cast<CustomerResponse>().ToList().Select(x => x.value).First().ToString() == "1")
                {
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
                            sb.Append("Dear " + (Data.CustomerUsername).ToString() + ",<br> <br>");
                            sb.Append("Please find your new Password is --   " + Dbsecurity.Decrypt(Password).ToString() + " <br> <br>");

                            SmtpClient smtpClient = new SmtpClient();
                            MailMessage mailmsg = new MailMessage();
                            MailAddress mailaddress = new MailAddress(FromMailId);
                            mailmsg.To.Add((Data.CustomerEmailID).ToString());
                            mailmsg.From = mailaddress;

                            mailmsg.Subject = "User New Password";
                            mailmsg.IsBodyHtml = true;
                            mailmsg.Body = sb.ToString();

                            smtpClient.Host = SMTPHost;
                            smtpClient.Port = Convert.ToInt32(SMTPPort);
                            smtpClient.EnableSsl = Convert.ToBoolean(SMTPEnableSsl);
                            smtpClient.UseDefaultCredentials = true;
                            smtpClient.Credentials = new System.Net.NetworkCredential(FromMailId, MailPassword);
                            smtpClient.Send(mailmsg);
                            //QuickCheck_AngularEntities dbcontext = new QuickCheck_AngularEntities();
                            //dbcontext.MultipleResults("[dbo].[Sp_SendEmail]").With<Responsevalue>().Execute("@QueryType", "@MandateId", "@EmailCount", "@SmsCount", "SendMail", Convert.ToString(0), "1", "0");
                        }
                    }
                }
                return dataList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<CustomerResponse> UpdateCustomer(JsonCustomerDetails Data, string UserId,string CustomerId)
        {
            FAMSEntities context = new FAMSEntities();
            CustomerResponse ObjCustResponse = new CustomerResponse();
            try
            {
                string Password = string.Empty;
                List<CustomerResponse> dataList = new List<CustomerResponse>();
                Password = Dbsecurity.Encrypt(Data.CustomerEmailID.Split('@').ElementAtOrDefault(0));
                var results = context.MultipleResults("[dbo].[Sp_user]").With<CustomerResponse>().Execute("@QueryType", "@UserId", "@UserName", "@AccountNo", "@EmailId", "@Password", "@UserIdNew", "UpdateData", Dbsecurity.Decrypt(UserId).ToString(), Data.CustomerUsername.ToString(), Data.CustomerAccount.ToString(), Data.CustomerEmailID.ToString(), Password.ToString(), CustomerId);
                //results.tab
                dataList = results.FirstOrDefault().Cast<CustomerResponse>().ToList();
                if (dataList.Cast<CustomerResponse>().ToList().Select(x => x.value).First().ToString() == "1")
                {
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
                            sb.Append("Dear " + (Data.CustomerUsername).ToString() + ",<br> <br>");
                            sb.Append("Please find your new Password is --   " + Dbsecurity.Decrypt(Password).ToString() + " <br> <br>");

                            SmtpClient smtpClient = new SmtpClient();
                            MailMessage mailmsg = new MailMessage();
                            MailAddress mailaddress = new MailAddress(FromMailId);
                            mailmsg.To.Add((Data.CustomerEmailID).ToString());
                            mailmsg.From = mailaddress;

                            mailmsg.Subject = "User New Password";
                            mailmsg.IsBodyHtml = true;
                            mailmsg.Body = sb.ToString();

                            smtpClient.Host = SMTPHost;
                            smtpClient.Port = Convert.ToInt32(SMTPPort);
                            smtpClient.EnableSsl = Convert.ToBoolean(SMTPEnableSsl);
                            smtpClient.UseDefaultCredentials = true;
                            smtpClient.Credentials = new System.Net.NetworkCredential(FromMailId, MailPassword);
                            smtpClient.Send(mailmsg);
                            //QuickCheck_AngularEntities dbcontext = new QuickCheck_AngularEntities();
                            //dbcontext.MultipleResults("[dbo].[Sp_SendEmail]").With<Responsevalue>().Execute("@QueryType", "@MandateId", "@EmailCount", "@SmsCount", "SendMail", Convert.ToString(0), "1", "0");
                        }
                    }
                }
                return dataList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}