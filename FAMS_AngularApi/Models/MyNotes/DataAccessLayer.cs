using EntityDAL;
using FAMS_AngularApi.Models.AllCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using Encryptions;

namespace FAMS_AngularApi.Models.MyNotes
{
    public class DataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        public Dictionary<string, object> BindGrid(CommonFields Data)
        {
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_MyNotes]").With<BindAllFields>().Execute("@QueryType", "@UserId", "BindGrid", Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public Dictionary<string, object> ReadMessage(CommonFields Data)
        //{
        //    try
        //    {
        //        var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_MyNotes]").With<CommonFields>().Execute("@QueryType", "@NMId" , "@UserId", "ReadMessage",Convert.ToString( Data.Result), Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
        //        return results;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}