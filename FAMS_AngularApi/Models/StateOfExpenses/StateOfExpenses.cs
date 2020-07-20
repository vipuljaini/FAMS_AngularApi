using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.StateOfExpenses;

namespace FAMS_AngularApi.Models.StateOfExpenses
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindGrid(string FromDate, string ToDate)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
              var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<StatementOfExpenses>().With<StatementOfExpenses1>().With<StatementOfExpenses2>()
                          .Execute("@Querytype",  "@FromDate", "@ToDate", "GetStatementOfExpenses", FromDate, ToDate));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}