using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using EntityDAL;
using Encryptions;
using System.IO;
using System.Web.UI;
using System.Text;
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Configuration;

namespace FAMS_AngularApi.Models.Login
{
    public class Login
    {
        FAMSEntities dbcontext = new FAMSEntities();

        public IEnumerable<CommonFlag> Binddetails(Formdataget Login)
        {
            List<CommonFlag> common = new List<CommonFlag>();
            CommonFlag Flag = new CommonFlag();
            List<Logindetails> dataList = new List<Logindetails>();
            try
            {
                var Result = dbcontext.MultipleResults("[dbo].[FAMS_Login]").With<Logindetails>().Execute("@QueryType", "@Emailid", "UserAccess", Login.UserName);
                foreach (var Logindata in Result)
                {
                    dataList = Logindata.Cast<Logindetails>().ToList();
                    if (dataList.Count > 0)
                    {
                            if (Convert.ToString(Logindata.Cast<Logindetails>().ToList().Select(x => x.EmailId).First().ToString()) == "0")
                            {
                                Flag.Flag = "0";
                                Flag.FlagValue = "User is InActive!!";
                                common.Add(Flag);
                            }
                            else if (Convert.ToString(Logindata.Cast<Logindetails>().ToList().Select(x => x.EmailId).First().ToString()) == "-1")
                            {
                                Flag.Flag = "0";
                                Flag.FlagValue = "Invalid User!!";
                                common.Add(Flag);
                            }
                        else
                        {
                            string strDbPassword = Dbsecurity.Decypt(Convert.ToString(Logindata.Cast<Logindetails>().ToList().Select(x => x.Password).First().ToString()));
                            if (strDbPassword.Trim() != Dbsecurity.Decypt(Login.Password))
                            {
                                Flag.Flag = "0";
                                Flag.FlagValue = "Wrong  Password!!";
                                common.Add(Flag);
                            }
                            else
                            {
                                #region Session creation
                                if (Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserType).First().ToString()) == "1")
                                {
                                    Flag.UserId = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserId).First().ToString()));
                                    Flag.EmailId = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.EmailId).First().ToString()));
                                    Flag.UserName = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserName).First().ToString()));
                                    Flag.WareHouseId = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.WareHouseId).First().ToString()));
                                    Flag.AccountNo = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.AccountNo).First().ToString()));
                                    Flag.IsDefaultPswdChange = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.IsDefaultPswdChange).First().ToString()));
                                    Flag.UserType = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserType).First().ToString()));
                                    Flag.Flag = "1";
                                    Flag.FlagValue = "ReportsDashboard";
                                }
                                // Iace.User.User.SaveUserToSession(dataList);
                                else if (Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserType).First().ToString()) == "2")
                                {
                                    Flag.UserId = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserId).First().ToString()));
                                    Flag.EmailId = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.EmailId).First().ToString()));
                                    Flag.UserName = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserName).First().ToString()));
                                    Flag.WareHouseId = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.WareHouseId).First().ToString()));
                                    Flag.AccountNo = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.AccountNo).First().ToString()));
                                    Flag.IsDefaultPswdChange = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.IsDefaultPswdChange).First().ToString()));
                                    Flag.UserType = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserType).First().ToString()));
                                    Flag.Flag = "1";
                                    Flag.FlagValue = "ReportsDashboard";
                                }
                                else if (Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserType).First().ToString()) == "3")
                                {
                                    Flag.UserId = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserId).First().ToString()));
                                    Flag.EmailId = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.EmailId).First().ToString()));
                                    Flag.UserName = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserName).First().ToString()));
                                    Flag.WareHouseId = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.WareHouseId).First().ToString()));
                                    Flag.AccountNo = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.AccountNo).First().ToString()));
                                    Flag.IsDefaultPswdChange = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.IsDefaultPswdChange).First().ToString()));
                                    Flag.UserType = Dbsecurity.Encrypt(Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.UserType).First().ToString()));
                                    Flag.Flag = "1";
                                    Flag.FlagValue = "Dashboard";

                                }
                                else
                                {
                                    Flag.Flag = "0";
                                    Flag.FlagValue = "Incorrect";
                                }
                                #endregion
                                Flag.Password =Convert.ToString(dataList.Cast<Logindetails>().ToList().Select(x => x.Password).First().ToString());
                                common.Add(Flag);
                            }
                        }
                    }
                    else
                    {
                        Flag.Flag = "0";
                        Flag.FlagValue = "Login Failed!!";
                        common.Add(Flag);
                    }
                }
                return common;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IEnumerable<EmailSent> SendMail(string email)
        {
            List<EmailSent> common = new List<EmailSent>(); 
            EmailSent emailobect = new EmailSent();
            try
            {
                List<Responsevalue> dataList = new List<Responsevalue>(); List<UserDetails> dataList1 = new List<UserDetails>();
                var Result = dbcontext.MultipleResults("[dbo].[Sp_UserLogin]").With<Responsevalue>().With<UserDetails>().Execute("@QueryType", "@EmailId", "ChkEmail", email);
                dataList = Result.FirstOrDefault().Cast<Responsevalue>().ToList();
                dataList1 = Result.LastOrDefault().Cast<UserDetails>().ToList();
                if (dataList.Cast<Responsevalue>().ToList().Select(x => x.value).First().ToString() == "1")
                {
                    if (dataList1.Count > 0)
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
                                sb.Append("Dear " + dataList1.Cast<UserDetails>().ToList().Select(x => x.UserName).First().ToString() + ",<br> <br>");
                                sb.Append("Please click on the below button to set a new Password . <br> <br>");
                                string User = HttpContext.Current.Server.UrlEncode(Dbsecurity.Encrypt(dataList1.Cast<UserDetails>().ToList().Select(x => x.UserId).First().ToString()));
                                sb.Append("<a href=' " + WebAppUrl + "ChangePassword/" + User + "' target='_blank'>");
                                sb.Append("<input style='background-color: #3965a9;color: #fff;padding: 3px 10px 3px 10px;' type='button' value='Change Password' /></a> </div>");

                                SmtpClient smtpClient = new SmtpClient();
                                MailMessage mailmsg = new MailMessage();
                                MailAddress mailaddress = new MailAddress(FromMailId);
                                mailmsg.To.Add(email);
                                mailmsg.From = mailaddress;

                                mailmsg.Subject = "Recover Password";
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

                                emailobect.Flag = "1";
                                emailobect.FlagValue = "Email sent successfully!!";
                                common.Add(emailobect);

                            }
                        }
                    }
                }
                else
                {
                    emailobect.Flag = "0";
                    emailobect.FlagValue = "Invalid EmailID!!";
                    common.Add(emailobect);
                }

            }
            catch (Exception)
            {
                emailobect.Flag = "0";
                emailobect.FlagValue = "Email sent not successfully!!";
                common.Add(emailobect);
            }

            return common;
        }
        public IEnumerable<ChangePasswordRes> UpdatePassworddtail(ChangePasswordJsn changepassword)
        {
            List<ChangePasswordRes> common = new List<ChangePasswordRes>();
            ChangePasswordRes changepasswordobect = new ChangePasswordRes();
            try
            {
                List<Forgotflag> dataList = new List<Forgotflag>();
                var Result = dbcontext.MultipleResults("[dbo].[Sp_UserLogin]").With<Forgotflag>().Execute("@QueryType", "@ChangePassword",
                           "@UserId", "UpdatePassword", changepassword.password, Dbsecurity.Decypt(changepassword.Userid));
                dataList = Result.FirstOrDefault().Cast<Forgotflag>().ToList();
                if (dataList.Count > 0)
                {
                    changepasswordobect.Flag = "1";
                    changepasswordobect.FlagValue = "Password Updated Successfuly !!";
                    common.Add(changepasswordobect);
                }
                else
                {
                    changepasswordobect.Flag = "0";
                    changepasswordobect.FlagValue = "Invalid UserId !!";
                    common.Add(changepasswordobect);
                }
            }
            catch (Exception ex) { throw ex; }
            return common;
        }


        public Dictionary<string, object> ChangePasswordForNewUser(ChangePasswordJson Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[sp_UserLogin]").With<CommonFields>().Execute("@Querytype", "@OldPassword", "@ChangePassword", "@UserId", "ChangePassWordNewUser", Data.OldPassword, Data.NewPassword, Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}