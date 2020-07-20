using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityDAL;
using BusinessLibrary;


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
                           .Execute("@Querytype", "@Fromdate", "@Todate", "BindGrid", Data.FromDate, Data.ToDate));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}