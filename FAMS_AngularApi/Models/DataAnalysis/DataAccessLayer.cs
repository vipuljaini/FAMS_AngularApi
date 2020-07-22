using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.DataAnalysis;

namespace FAMS_AngularApi.Models.DataAnalysis
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindGrid(string FromDate, string ToDate)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_DemoReport]").With<StatementOfExpenses_DataAnalysic>().With<StatementOfExpenses1_DataAnalysic>()
                            .Execute("@Querytype", "@FromDate", "@ToDate", "GetDataAnalysic_StatemenetOfExpenses", FromDate, ToDate));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}