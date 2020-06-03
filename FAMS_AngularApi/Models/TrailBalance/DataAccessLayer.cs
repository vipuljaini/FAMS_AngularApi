using EntityDAL;
using FAMS_AngularApi.Models.TrailBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;

namespace FAMS_AngularApi.Models.TrailBalance
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindGrid(JsonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_TrialBalanceReport]").With<GridAllFields>()
                           .Execute("@Querytype", "@CustomerAccount", "@Fromdate", "@Todate", "@Accounts", "@AccountSubLayer", "BindGride", Data.CustomerAccount, Data.FromDate, Data.ToDate, Data.Account, Data.AccountSubLayer));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}