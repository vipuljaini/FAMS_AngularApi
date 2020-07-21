using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.Country;
using Encryptions;

namespace FAMS_AngularApi.Models.Country
{
    public class CountryDataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        List<Country> dataList_Country = new List<Country>();
      
        public Dictionary<string, object> BindCountry()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_Country]").With<Country>().Execute("@QueryType", "BindCountry"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<Country> AddCountry(Country country, string UserId)
        {
            try
            {

                
                var Result = context.MultipleResults("[dbo].[FAMS_Country]").With<Country>().Execute("@QueryType", "@CountryCode", "@CountryName", "@UserId", "SaveCountry", country.CountryCode, country.CountryName,Dbsecurity.Decrypt(UserId));
                foreach (var _country in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_Country = _country.Cast<Country>().ToList();
                }
                return dataList_Country;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Add new employee record 
        public IEnumerable<Country> UpdateCountry(Country country, string UserId, string CountryID)
        {
            try
            {

                
                var Result = context.MultipleResults("[dbo].[FAMS_Country]").With<Country>().Execute("@QueryType", "@CountryCode", "@CountryName", "@UserId", "@CountryID", "UpdateCountry", country.CountryCode, country.CountryName, Dbsecurity.Decrypt(UserId), CountryID);
                foreach (var _country in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_Country = _country.Cast<Country>().ToList();
                }
                return dataList_Country;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}