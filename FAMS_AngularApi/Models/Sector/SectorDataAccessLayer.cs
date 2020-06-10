using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.Sector;
using Encryptions;

namespace FAMS_AngularApi.Models.Sector
{
    public class SectorDataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        List<Sector> dataList_Sector = new List<Sector>();

        public Dictionary<string, object> BindSector()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_Sector]").With<Sector>().Execute("@QueryType", "BindSector"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<Sector> AddSector(Sector Sector, string UserId)
        {
            try
            {


                var Result = context.MultipleResults("[dbo].[FAMS_Sector]").With<Sector>().Execute("@QueryType", "@SectorCode", "@SectorName", "@CountryCode", "@UserId", "SaveSector", Sector.SectorCode, Sector.SectorName, Convert.ToString(Sector.CountryCode), Dbsecurity.Decypt(UserId));
                foreach (var _state in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_Sector = _state.Cast<Sector>().ToList();
                }
                return dataList_Sector;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Add new employee record 
        public IEnumerable<Sector> UpdateSector(Sector Sector, string UserId, string SectorId)
        {
            try
            {


                var Result = context.MultipleResults("[dbo].[FAMS_Sector]").With<Sector>().Execute("@QueryType", "@SectorCode", "@SectorName", "@CountryCode", "@UserId", "@SectorId", "UpdateSector", Sector.SectorCode, Sector.SectorName, Convert.ToString(Sector.CountryCode), Dbsecurity.Decypt(UserId), SectorId);
                foreach (var _state in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_Sector = _state.Cast<Sector>().ToList();
                }
                return dataList_Sector;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}