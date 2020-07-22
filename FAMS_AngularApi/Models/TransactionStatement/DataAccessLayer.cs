using BusinessLibrary;
using Encryptions;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.TransactionStatement
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindGrid(JsonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_TransactionStatement]").With<BindMainGrid>()
                           .Execute("@Querytype", "@FromDate", "@ToDate", "@CustomerAccount", "BindMainGrid", Data.FromDate, Data.ToDate,Data.CustomerAccount));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}