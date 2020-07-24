using BusinessLibrary;
using Encryptions;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.BankBook
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindGrid(JsonData Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<BindGrid>().With<TotalSumGrid>().With<HeaderData>()
                           .Execute("@Querytype", "@FromDate", "@ToDate", "@CustomerAccount", "BindGrid", Data.FromDate, Data.ToDate,Data.CustomerAccount));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindEmployees(JsonData Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<BindEmployees>()
                           .Execute("@Querytype", "@UserId", "BindEmployees", Dbsecurity.Decrypt(HttpContext.Current.Server.UrlDecode(Data.UserId.Replace("_", "%")))));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}