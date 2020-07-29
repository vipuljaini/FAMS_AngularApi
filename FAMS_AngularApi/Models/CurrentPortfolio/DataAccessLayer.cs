﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using Encryptions;
using EntityDAL;


namespace FAMS_AngularApi.Models.CurrentPortfolio
{
    public class DataAccessLayer
    {
        public Dictionary<string, object> BindGrid(JsonFields Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
               // var CustomerAccountNo = Dbsecurity.Decrypt(Data.CustomerAccountNo);

                //var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CurrentPortfolio]").With<GridFieldData>().With<GridTotalFieldData>().With<GridTotalFieldData>()
                //           .Execute("@Querytype", "@Fromdate", "@Todate", "@CustomerAccount", "BindGrid", Data.FromDate, Data.ToDate, CustomerAccountNo));
                //return results;
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CurrentPortfolio]").With<GridFieldData>().With<Header>().With<GridTotalFieldData>()
                          .Execute("@Querytype", "@ReportDate", "@CustomerAccount", "@PageCount", "BindGrid", Data.ReportDate, Data.CustomerAccountNo , Data.PageCount));
                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindDefaultData(DefaultJson Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_CurrentPortfolio]").With<PageLoadData>()
                            .Execute("@Querytype", "@CustomerAccount", "@UserId", "GetDefault_StatemenetOfExpenses", Data.CustomerAccountNo, Data.UserId));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindNextData(JsonData Data)
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[Sp_BankBook]").With<PageLoadData>()
                            .Execute("@Querytype", "@CustomerAccount", "@UserId", "@PageCount", "NextRecords", Data.CustomerAccount, Data.UserId, Data.PageCount));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}