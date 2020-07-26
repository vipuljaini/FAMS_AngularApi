using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using EntityDAL;
using FAMS_AngularApi.Models.NotesMaster;
using Encryptions;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
namespace FAMS_AngularApi.Models.NotesMaster
{
    public class DataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        public Dictionary<string, object> BindGrid(JsonUserDetails Data)
        {
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<NoteMasterDetails>().Execute("@QueryType", "@UserId", "BindGrid", Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindGrid1(JsonUserDetails Data)
        {
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<NoteMasterDetails>().Execute("@QueryType", "@UserId", "@Searchvalue", "BindGridSearch", Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%"))),Data.Searchvalue.Trim()));
                return results; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindEmail(JsonUserDetails Data)
        {
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<NoteMasterDetails>().Execute("@QueryType", "@UserId", "BindEmaildata", Data.UserId));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindNotification2(EmailWise Data)
        {
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<Totalcount>().With<Totalcount>().With<Totalcount>().Execute("@QueryType", "@EmailId", "BindNotificatedataCount", Data.EmailId));

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Dictionary<string, object> BindNotification(EmailWise Data)
        {
            if (Data.NotiType == "1")
            {
                try
                {
                    var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<AllNotification>().Execute("@QueryType", "@EmailId", "BindNotificatedata", Data.EmailId));

                    return results;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (Data.NotiType == "2")
            {
                try
                {
                    var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<AllNotification>().Execute("@QueryType", "@EmailId", "BindNotificatedata1", Data.EmailId));

                    return results;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<AllNotification>().Execute("@QueryType", "@EmailId", "BindNotificatedata2", Data.EmailId));

                    return results;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public Dictionary<string, object> BindNotification1(EmailWise Data)
        {
            if (Data.NotiType == "1")
            {
                try
                {
                    var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<AllNotification>().Execute("@QueryType", "@EmailId","@Searchvalue", "BindSearchNotificatedata", Data.EmailId,Data.Searchvalue.Trim()));

                    return results;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<AllNotification>().Execute("@QueryType", "@EmailId", "@Searchvalue", "BindSearchNotificatedata1", Data.EmailId,Data.Searchvalue.Trim()));

                    return results;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Dictionary<string, object> BindDataNotification(EmailWise Data)
        {
          
                try
                {
                    var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<Notedata>().Execute("@QueryType", "@EmailId", "@NMId", "UpdateNotificatedata", Data.EmailId,Data.NotiType));

                    return results;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
           
        }
        public Dictionary<string, object> SaveData(JsonNotesDetails Data) {
            try
            {
                Random rand = new Random();
                int ranno = rand.Next(1000,9999);
                string fileName = string.Empty;
                string filePath = string.Empty;
                string extension = string.Empty;
                string targetPath = string.Empty;
                string Emailtype = string.Empty;
                int notelength = 0;
                int sublength = 0;
                if (Data.Attachment != null)
                {
                    fileName = Data.Subject+"_"+Dbsecurity.Decrypt(Data.UserId) + "_" + DateTime.Now.ToString("ddMMyyyy") + "_" + ranno + ".jpg";
                    filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Notificationattachments/"), fileName);
                    byte[] bytes = System.Convert.FromBase64String(Data.Attachment);
                    using (System.Drawing.Image image = new Bitmap(new MemoryStream(bytes)))
                    {
                        image.Save(filePath, ImageFormat.Png);

                    }
                }
                string dtEmail = "<dtXml>";
                if (Data.Email == "1")
                {
                    List<AllEmail> dataList = new List<AllEmail>();
                 
                    var Result1 = context.MultipleResults("[dbo].[Sp_NotesMaster]").With<AllEmail>().Execute("@QueryType", "AllEmail");
                    foreach (var emaildata in Result1)
                    {
                        dataList = emaildata.Cast<AllEmail>().ToList();
                        if (dataList.Count > 0)
                        {
                            for (int i = 0; i < dataList.Count; i++)
                            {
                                dtEmail += "<dtXml ";
                                dtEmail += " Emailid=" + @"""" + Convert.ToString(dataList[i].EmailId) + @"""";
                                dtEmail += " EmailType=" + @"""" + 1 + @"""";
                                dtEmail += " />";
                                SendMail(Convert.ToString(dataList[i].EmailId), Convert.ToString(dataList[i].EmailId),Data.Subject,Data.Note, filePath);
                            }
                        }
                        
                    }
                    dtEmail += "</dtXml>";

                }
                else
                {

                  //  string dtEmail = "<dtXml>";
                    string[] Email = Data.Email.Split(',');
                    for (int i = 0; i < Email.Length; i++)
                    {
                        dtEmail += "<dtXml ";
                        dtEmail += " Emailid=" + @"""" + Email[i] + @"""";
                        dtEmail += " EmailType=" + @"""" + 2 + @"""";
                        dtEmail += " />";
                        SendMail(Convert.ToString(Email[i]), Convert.ToString(Email[i]), Data.Subject, Data.Note, filePath);
                    }
                    dtEmail += "</dtXml>";
                }
                if (Data.Note.Length <= 35)
                {
                    notelength = 0;
                }
                else
                {
                    notelength = 1;
                }
                if (Data.Subject.Length <= 35)
                {
                    sublength = 0;
                }
                else
                {
                    sublength = 1;
                }
                FAMSEntities context1 = new FAMSEntities();
                var results = Common.Getdata(context1.MultipleResults("[dbo].[Sp_NotesMaster]").With<CommonFields>().Execute("@QueryType", "@Subject", "@Note", "@Attachment", "@UserId", "@dtEmail", "@notelength", "@sublength", "SaveData", Data.Subject, Data.Note, fileName, Dbsecurity.Decrypt(Data.UserId),dtEmail,Convert.ToString(notelength), Convert.ToString(sublength)));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendMail(string Emailid,string username,string subject,string note, string filepath)
        {
            StringBuilder sb = new StringBuilder();
            string WebAppUrl = ConfigurationManager.AppSettings["WebAppUrl"].ToString();
            string SMTPHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            string FromMailId = ConfigurationManager.AppSettings["UserId"].ToString();
            string MailPassword = ConfigurationManager.AppSettings["MailPassword"].ToString();
            string SMTPPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            string SMTPEnableSsl = ConfigurationManager.AppSettings["SMTPEnableSsl"].ToString();
            sb.Append("Dear " + (username).ToString() + ",<br> <br>");
            sb.Append(note.ToString() + " <br> <br>");
            SmtpClient smtpClient = new SmtpClient();
            MailMessage mailmsg = new MailMessage();
            MailAddress mailaddress = new MailAddress(FromMailId);
            mailmsg.To.Add((Emailid).ToString());
            mailmsg.From = mailaddress;
            if (filepath != "")
            {
                mailmsg.Attachments.Add(new System.Net.Mail.Attachment(filepath));
            }
            mailmsg.Subject = subject.ToString();
            mailmsg.IsBodyHtml = true;
            mailmsg.Body = sb.ToString();

            smtpClient.Host = SMTPHost;
            smtpClient.Port = Convert.ToInt32(SMTPPort);
            smtpClient.EnableSsl = Convert.ToBoolean(SMTPEnableSsl);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(FromMailId, MailPassword);
            try
            {
                smtpClient.Send(mailmsg);
            }
            catch(Exception){ }
        }

        //public Dictionary<string, object> SaveCustomer(JsonNotesDetails Data)
        //{
        //    FAMSEntities context = new FAMSEntities();
        //    CustomerResponse ObjCustResponse = new CustomerResponse();
        //    try
        //    {
        //        string Password = string.Empty;
        //        List<CustomerResponse> dataList = new List<CustomerResponse>();
        //        Password = Dbsecurity.Encrypt(Dbsecurity.Decrypt(Data.CustomerEmail).ToString().Split('@').ElementAtOrDefault(0));
        //        var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_user]").With<CustomerResponse>().Execute("@QueryType", "@UserId", "BindUser", Dbsecurity.Decrypt(Data.UserId).ToString()));
        //        dataList = results.Cast<CustomerResponse>().ToList();

        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
  
}