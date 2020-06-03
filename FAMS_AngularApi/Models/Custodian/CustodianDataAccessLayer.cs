using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FAMS_AngularApi.Models.Custodian;

using BusinessLibrary;
using EntityDAL;
using Encryptions;

namespace FAMS_AngularApi.Models.Custodian
{
    public class CustodianDataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        List<Country> dataList = new List<Country>();
        List<Custodian> dataList_Custodian = new List<Custodian>();

        public Dictionary<string, object> BindCountry()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_Custodian]").With<Country>().Execute("@QueryType", "BindCountry"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> BindPMS()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_Custodian]").With<PMS>().Execute("@QueryType", "BindPMS"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> GetAllCustodian()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_Custodian]").With<Custodian>().Execute("@QueryType", "BindCustodian"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> FillPMSDetails(string PMSCode)
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_Custodian]").With<PMS>().Execute("@QueryType","@PMSCode", "FillPMSDetails",PMSCode));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> GetAllPMSDetails(string CustodianId)
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_Custodian]").With<PMS>().Execute("@QueryType", "@CustodianId", "BindPMSDetails", CustodianId));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<Custodian> AddCustodian(Custodian custodian,string UserId)
        {
            try
            {

                string isActive = (custodian.Active == true ? "1" : "0");
                var Result = context.MultipleResults("[dbo].[FAMS_Custodian]").With<Custodian>().Execute("@QueryType", "@CountryCode", "@CustodianCode", "@CustodianName", "@PMSCode", "@PMSName", "@PMSAccountNumber", "@Active", "@UserId", "SaveCustodian",custodian.CountryCode,custodian.CustodianCode,custodian.CustodianName,custodian.PMSCode,custodian.PMSName,custodian.PMSAccountNumber, isActive, Dbsecurity.Decypt(UserId));
                foreach (var _custodian in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_Custodian = _custodian.Cast<Custodian>().ToList();
                }
                return dataList_Custodian;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Add new employee record 
        public IEnumerable<Custodian> UpdateCustodian(Custodian custodian, string UserId,string CustodianId)
        {
            try
            {

                string isActive = (custodian.Active == true ? "1" : "0");
                var Result = context.MultipleResults("[dbo].[FAMS_Custodian]").With<Custodian>().Execute("@QueryType", "@CountryCode", "@CustodianCode", "@CustodianName", "@PMSCode", "@PMSName", "@PMSAccountNumber", "@Active", "@UserId", "@CustodianId", "UpdateCustodian", custodian.CountryCode, custodian.CustodianCode, custodian.CustodianName, custodian.PMSCode, custodian.PMSName, custodian.PMSAccountNumber, isActive, Dbsecurity.Decypt(UserId),CustodianId);
                foreach (var _custodian in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_Custodian = _custodian.Cast<Custodian>().ToList();
                }
                return dataList_Custodian;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}