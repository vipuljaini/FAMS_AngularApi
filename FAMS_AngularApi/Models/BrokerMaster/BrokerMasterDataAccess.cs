﻿using EntityDAL;
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
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BrokerMaster]").With<BindAllFields>().With<BindAllFields2>().Execute("@QueryType", "@UserId", "BindGrid", Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
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
                if (Data.BMId == "") {
                    var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BrokerMaster]").With<CommonFields>().Execute("@QueryType", "@BrokerName", "@TradeName", "@RegistrationNo", "@GSTNo", "@StockExchangeName", "@Email", "@Telephone", "@ContactEmail", "@Phone", "@Extension", "@MobileNo", "@ContactPerson", "@UserId", "SaveData",
                        Data.BrokerName, Data.TradeName, Data.RegistrationNo, Data.GSTNo, Data.StockExchangeName, Data.Email, Data.Telephone, Data.ContactEmail, Data.Phone, Data.Extension, Data.MobileNo, Data.ContactPerson, Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                    return results;
                }
                else
                {
                    var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BrokerMaster]").With<CommonFields>().Execute("@QueryType", "@BrokerName", "@TradeName", "@RegistrationNo", "@GSTNo", "@StockExchangeName", "@Email", "@Telephone", "@ContactEmail", "@Phone", "@Extension", "@MobileNo", "@ContactPerson", "@BMId", "@UserId", "UpdateData",
                       Data.BrokerName, Data.TradeName, Data.RegistrationNo, Data.GSTNo, Data.StockExchangeName, Data.Email, Data.Telephone, Data.ContactEmail, Data.Phone, Data.Extension, Data.MobileNo, Data.ContactPerson, Data.BMId ,Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                    return results;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}