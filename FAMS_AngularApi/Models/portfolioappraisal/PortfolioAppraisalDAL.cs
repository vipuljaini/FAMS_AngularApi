using BusinessLibrary;
using Encryptions;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.portfolioappraisal
{
    public class PortfolioAppraisalDAL
    {


        FAMSEntities context = new FAMSEntities();
        public Dictionary<string, object> BindGrid(GridFields Data)
        {
            try
            {

                
               // var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);
                
                // var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CapitalStatement]").With<CapitalStatementModel>().Execute("@QueryType", "@Fromdate", "@Todate", "BindMainGrid",fromdate,todate));
                var results = Common.Getdata(context.MultipleResults("[dbo].[SP_PortfolioAppraisal]").With<PortfolioappraisalModel>().With<SumPortfolioappraisalModel>().With<cashportfolio>().With<PortfolioappraisalModel>().With<HDATE>().Execute("@QueryType", "@SeqNo", "@Fromdate", "@CustomerAccount", "GetPortfolioAppraisal", Data.pagecount, Data.Fromdate,Data.CustomerAccountno));
              



                return results;  //
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}