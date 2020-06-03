using BusinessLibrary;
using Encryptions;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.Security
{
    public class SecurityDataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        List<Country> dataList = new List<Country>();
        List<Custodian> dataList_Custodian = new List<Custodian>();
        List<Sector> dataList_Sector = new List<Sector>();
        List<SecurityDetails> dataList_SecurityDetails = new List<SecurityDetails>();

        public Dictionary<string, object> BindCountry()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_SecurityDetails]").With<Country>().Execute("@QueryType", "BindCountry"));
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
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_SecurityDetails]").With<Custodian>().Execute("@QueryType", "BindCustodian"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> GetAllSector()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_SecurityDetails]").With<Sector>().Execute("@QueryType", "BindSector"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> GetAllSecurityCodeDetails()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_SecurityDetails]").With<Security>().Execute("@QueryType", "BindSecurityCodeDetails"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> GetAllSecurity(string SecurityDetailsId)
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_SecurityDetails]").With<Security>().Execute("@QueryType", "@SecurityDetailId", "BindSecurity", SecurityDetailsId));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> BindAllSecurityDetails()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_SecurityDetails]").With<SecurityDetails>().Execute("@QueryType", "BindSecurityDetails"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> FillSecurityCodeDetails(string SecurityCode)
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_SecurityDetails]").With<SecurityCodeDetails>().Execute("@QueryType", "@SecurityCode", "FillSecurityCodeDetails", SecurityCode));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        //To Add new employee record 
        public IEnumerable<SecurityDetails> AddSecurityDetails(SecurityDetails securityDetails, string UserId)
        {
            try
            {
                string isActive = (securityDetails.Active == "true" ? "1" : "0");
                var Result = context.MultipleResults("[dbo].[FAMS_SecurityDetails]").With<SecurityDetails>().Execute("@QueryType", "@CountryCode", "@CustodianCode", "@ListCode", "@Name", "@SecurityCode", "@SecurityName", "@SectorCode", "@Active", "@UserId", "SaveSecurityDetails", securityDetails.CountryCode, securityDetails.CustodianCode, securityDetails.ListCode, securityDetails.ListName,  securityDetails.SecurityCode, securityDetails.SecurityName, securityDetails.SectorCode,isActive, Dbsecurity.Decypt(UserId));
                foreach (var _securityDetails in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_SecurityDetails = _securityDetails.Cast<SecurityDetails>().ToList();
                }
                return dataList_SecurityDetails;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<SecurityDetails> UpdateSecurityDetails(SecurityDetails securityDetails, string UserId, string SecurityDetailId)
        {
            try
            {

                string isActive = (securityDetails.Active == "true" ? "1" : "0");
                var Result = context.MultipleResults("[dbo].[FAMS_SecurityDetails]").With<SecurityDetails>().Execute("@QueryType", "@CountryCode", "@CustodianCode", "@ListCode", "@Name", "@SecurityCode", "@SecurityName", "@SectorCode", "@Active", "@UserId", "@SecurityDetailId", "UpdateSecurityDetails", securityDetails.CountryCode, securityDetails.CustodianCode, securityDetails.ListCode, securityDetails.ListName, securityDetails.SecurityCode, securityDetails.SecurityName, securityDetails.SectorCode, isActive, Dbsecurity.Decypt(UserId),SecurityDetailId);
                foreach (var _securityDetails in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_SecurityDetails = _securityDetails.Cast<SecurityDetails>().ToList();
                }
                return dataList_SecurityDetails;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}