using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.City;
using Encryptions;

namespace FAMS_AngularApi.Models.City
{
    public class CityDataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        List<City> dataList_City = new List<City>();

        public Dictionary<string, object> BindState(string CountryCode)
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_City]").With<City>().Execute("@QueryType", "@CountryCode", "BindState", CountryCode));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindCity()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_City]").With<City>().Execute("@QueryType", "BindCity"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<City> AddCity(City City, string UserId)
        {
            try
            {


                var Result = context.MultipleResults("[dbo].[FAMS_City]").With<City>().Execute("@QueryType", "@CityCode", "@CityName", "@CountryCode", "@StateCode", "@UserId", "SaveCity", City.CityCode, City.CityName, Convert.ToString(City.CountryCode), Convert.ToString(City.StateCode), Dbsecurity.Decypt(UserId));
                foreach (var _city in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_City = _city.Cast<City>().ToList();
                }
                return dataList_City;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Add new employee record 
        public IEnumerable<City> UpdateCity(City City, string UserId, string CityId)
        {
            try
            {


                var Result = context.MultipleResults("[dbo].[FAMS_City]").With<City>().Execute("@QueryType", "@CityCode", "@CityName", "@CountryCode", "@StateCode", "@UserId", "@CityId", "UpdateCity", City.CityCode, City.CityName, Convert.ToString(City.CountryCode), Convert.ToString(City.StateCode), Dbsecurity.Decypt(UserId),CityId);
                foreach (var _city in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_City = _city.Cast<City>().ToList();
                }
                return dataList_City;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}