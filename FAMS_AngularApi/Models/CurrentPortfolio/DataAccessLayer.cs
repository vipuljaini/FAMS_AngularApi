using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityDAL;
using BusinessLibrary;
using Encryptions;


namespace FAMS_AngularApi.Models.CurrentPortfolio
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindGrid(JsonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CurrentPortfolio]").With<GridFieldData>().With<GridTotalFieldData>().With<GridTotalFieldData>()
                           .Execute("@Querytype", "@Fromdate", "@Todate", "@CustomerAccount", "BindGrid", Data.FromDate, Data.ToDate,Dbsecurity.Decrypt(Data.CustomerAccountNo)));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}