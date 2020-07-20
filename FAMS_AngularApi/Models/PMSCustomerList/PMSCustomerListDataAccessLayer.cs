using BusinessLibrary;
using Encryptions;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FAMS_AngularApi.Models.PMSCustomerList
{
    public class PMSCustomerListDataAccessLayer
    {

        FAMSEntities context = new FAMSEntities();
        List<Custodian> dataList_Custodian = new List<Custodian>();
        List<PortFolio> dataList_PortFolio = new List<PortFolio>();
        List<PMSCustomerList> dataList_PMSCustomerList = new List<PMSCustomerList>();
        //List<SecurityDetails> dataList_SecurityDetails = new List<SecurityDetails>();


        public Dictionary<string, object> BindCustodian()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_PMSCustomerList]").With<Custodian>().Execute("@QueryType", "BindCustodian"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindPortfolio()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_PMSCustomerList]").With<PortFolio>().Execute("@QueryType", "BindPortFolio"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      


        public Dictionary<string, object> BindLinkedPMSEmployee()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_PMSCustomerList]").With<LinkedPMSEmployee>().Execute("@QueryType", "BindLinkedPMSEmployee"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> BindPMSCustomerListDetails()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_PMSCustomerList]").With<PMSCustomerListDetails>().Execute("@QueryType", "BindPMSCustomerListDetails"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> BindPMSCustomerListCodeDetails(string CustomerListId)
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_PMSCustomerList]").With<PMSCustomerListCodeDetails>().Execute("@QueryType", "@CustomerListId", "BindPMSCustomerListCodeDetails", CustomerListId));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        //To Add new employee record 
        public IEnumerable<PMSCustomerList> AddCustomerListDetails(PMSCustomerList pMSCustomerList, string UserId)
        {
            try
            {
                string ISEnable = (pMSCustomerList.Enable == true ? "1" : "0");
                var Result = context.MultipleResults("[dbo].[FAMS_PMSCustomerList]").With<PMSCustomerList>().Execute("@QueryType", "@CustodianCode", "@ListCode", "@Enable", "@CustomerAccount", "@CustomerName", "@PortfolioCode", "@InceptionDate", "@PMSEmployeeCode", "@UserId", "SaveCustomerLists", pMSCustomerList.CustodianCode, pMSCustomerList.ListCode, ISEnable, pMSCustomerList.CustomerAccount, pMSCustomerList.CustomerName, pMSCustomerList.PortfolioCode, pMSCustomerList.InceptionDate,pMSCustomerList.EmployeeCode, Dbsecurity.Decrypt(UserId));
                foreach (var _pMSCustomerList in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_PMSCustomerList = _pMSCustomerList.Cast<PMSCustomerList>().ToList();
                }
                return dataList_PMSCustomerList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<PMSCustomerList> UpdateCustomerListDetails(PMSCustomerList pMSCustomerList, string UserId, string CustomerListId)
        {
            try
            {

                string ISEnable = (pMSCustomerList.Enable == true ? "1" : "0");
                var Result = context.MultipleResults("[dbo].[FAMS_PMSCustomerList]").With<PMSCustomerList>().Execute("@QueryType", "@CustodianCode", "@ListCode", "@Enable", "@CustomerAccount", "@CustomerName", "@PortfolioCode", "@InceptionDate", "@PMSEmployeeCode", "@CustomerListId", "@UserId", "UpdateCustomerLists", pMSCustomerList.CustodianCode, pMSCustomerList.ListCode, ISEnable, pMSCustomerList.CustomerAccount, pMSCustomerList.CustomerName, pMSCustomerList.PortfolioCode, pMSCustomerList.InceptionDate, pMSCustomerList.EmployeeCode, CustomerListId, Dbsecurity.Decrypt(UserId));
                foreach (var _pMSCustomerList in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_PMSCustomerList = _pMSCustomerList.Cast<PMSCustomerList>().ToList();
                }
                return dataList_PMSCustomerList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}