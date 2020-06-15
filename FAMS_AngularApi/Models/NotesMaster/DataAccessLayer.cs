using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using EntityDAL;
using FAMS_AngularApi.Models.NotesMaster;
using Encryptions;

namespace FAMS_AngularApi.Models.NotesMaster
{
    public class DataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        public Dictionary<string, object> BindGrid(JsonUserDetails Data)
        {
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<NoteMasterDetails>().Execute("@QueryType", "@UserId", "BindGrid", Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
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
                if (Data.NMId=="") {
                    var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<CommonFields>().Execute("@QueryType", "@Subject", "@Note", "@Attachment", "@UserId", "SaveData", Data.Subject, Data.Note, Data.Attachment, Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                    return results;
                }
                else
                {
                    var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<CommonFields>().Execute("@QueryType", "@Subject", "@Note", "@Attachment", "@NMId", "@UserId", "Update", Data.Subject, Data.Note, Data.Attachment, Data.NMId,Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        //public Dictionary<string, object> SaveCustomer(JsonNotesDetails Data)
        //{
        //    FAMSEntities context = new FAMSEntities();
        //    CustomerResponse ObjCustResponse = new CustomerResponse();
        //    try
        //    {
        //        string Password = string.Empty;
        //        List<CustomerResponse> dataList = new List<CustomerResponse>();
        //        Password = Dbsecurity.Encrypt(Dbsecurity.Decypt(Data.CustomerEmail).ToString().Split('@').ElementAtOrDefault(0));
        //        var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_user]").With<CustomerResponse>().Execute("@QueryType", "@UserId", "BindUser", Dbsecurity.Decypt(Data.UserId).ToString()));
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