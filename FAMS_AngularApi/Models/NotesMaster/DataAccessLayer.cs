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
        public Dictionary<string, object> BindGrid(JsonUserDetails Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_NotesMaster]").With<NoteMasterDetails>().Execute("@QueryType", "@UserId", "BindNotesGrid", Dbsecurity.Decypt(Data.UserId).ToString()));
                return results;
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