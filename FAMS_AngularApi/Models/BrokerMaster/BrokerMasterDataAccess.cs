using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using Encryptions;

namespace FAMS_AngularApi.Models.BrokerMaster
{
    public class BrokerMasterDataAccess
    {
        FAMSEntities context = new FAMSEntities();
        public Dictionary<string, object> BindGrid(CommonFields Data)
        {
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BrokerMaster]").With<BindAllFields>().Execute("@QueryType", "@UserId", "BindGrid", Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> SaveData(JsonData Data)
        {
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BrokerMaster]").With<CommonFields>().Execute("@QueryType", "@BrokerName", "@TradeName", "@RegistrationNo", "@GSTNo", "@StockExchangeName", "@Email", "@Telephone", "@ContactEmail", "@Phone", "@Extension", "@MobileNo", "@ContactPerson", "@UserId", "SaveData",
                    Data.BrokerName,Data.TradeName,Data.RegistrationNo,Data.GSTNo,Data.StockExchangeName,Data.Email,Data.Telephone,Data.ContactEmail,Data.Phone,Data.Extension,Data.MobileNo,Data.ContactPerson, Dbsecurity.Decypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}