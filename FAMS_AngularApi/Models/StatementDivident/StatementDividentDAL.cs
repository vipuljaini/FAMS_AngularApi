using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using Encryptions;
using EntityDAL;

namespace FAMS_AngularApi.Models.StatementDivident
{
    public class StatementDividentDAL
    {

        FAMSEntities context = new FAMSEntities();
        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            try
            {
                // var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementModel>().Execute("@QueryType", "@Fromdate", "@Todate", "BindMainGrid",fromdate,todate));
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_StatementDividend]").With<StatementDividentModel>().With<DividendModel>().With<SDSum>().With<SumDividend>().Execute("@QueryType", "@PageCount", "@Fromdate", "@Todate", "BindMainGrid", Data.PageCount, Data.fromdate, Data.todate));
                return results;  //
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}