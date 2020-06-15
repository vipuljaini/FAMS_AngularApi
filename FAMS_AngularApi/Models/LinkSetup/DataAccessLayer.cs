using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
//using Encryptions;
using EntityDAL;

namespace FAMS_AngularApi.Models.LinkSetup
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> GetLinks(JsonLink Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[sp_linksetup]").With<LinkAllFields>()
                           .Execute("@Querytype", "@UserType", "BindLinksUserWise",  Data.UserType));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        FAMSEntities context = new FAMSEntities();
        public Dictionary<string, object> BindAllTabs(CommonFields Data)
        {
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[sp_linksetup]").With<BindAllTabs>().Execute("@QueryType", "@UserType" ,"BindAllTabs",Data.UserId));       
                return results;
               // , Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))  "@UserId",
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}