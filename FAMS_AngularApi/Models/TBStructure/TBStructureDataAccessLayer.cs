using BusinessLibrary;
using Encryptions;
using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.TBStructure
{
    public class TBStructureDataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        //List<Country> dataList = new List<Country>();
        //List<Custodian> dataList_Custodian = new List<Custodian>();
        List<Parent> dataList_Sector = new List<Parent>();
        List<TBStructure> dataList_TBStructure = new List<TBStructure>();

        //public Dictionary<string, object> BindCountry()
        //{
        //    try
        //    {
        //        var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_TBStructure]").With<Country>().Execute("@QueryType", "BindCountry"));
        //        return Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Dictionary<string, object> GetAllCustodian()
        //{
        //    try
        //    {
        //        var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_TBStructure]").With<Custodian>().Execute("@QueryType", "BindCustodian"));
        //        return Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public Dictionary<string, object> GetAllParent()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_TBStructure]").With<Parent>().Execute("@QueryType", "BindParent"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindAllTBStructure()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_TBStructure]").With<TBStructure>().Execute("@QueryType", "BindTBStructure"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, object> BindAllTBStructureDetails(string TBStructureId)
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_TBStructure]").With<TBStructureDetails>().Execute("@QueryType", "@TBStructureId", "BindStructureDetails", TBStructureId));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Add new employee record 
        public IEnumerable<TBStructure> AddTBStructure(TBStructure TBStructure, string UserId)
        {
            try
            {
                string isActive = (TBStructure.Active == "true" ? "1" : "0");
                var Result = context.MultipleResults("[dbo].[FAMS_TBStructure]").With<TBStructure>().Execute("@QueryType", "@CountryCode", "@CustodianCode", "@ListCode", "@Name", "@TBHeadCode", "@TBHeadName", "@ParentCode", "@Active", "@UserId", "SaveTBStructure", TBStructure.CountryCode, TBStructure.CustodianCode, TBStructure.ListCode, TBStructure.ListName, TBStructure.TBHeadCode, TBStructure.TBHeadName, TBStructure.ParentCode, isActive, Dbsecurity.Decypt(UserId));
                foreach (var _TBStructure in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_TBStructure = _TBStructure.Cast<TBStructure>().ToList();
                }
                return dataList_TBStructure;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<TBStructure> UpdateTBStructure(TBStructure TBStructure, string UserId, string TBStructureId)
        {
            try
            {

                string isActive = (TBStructure.Active == "true" ? "1" : "0");
                var Result = context.MultipleResults("[dbo].[FAMS_TBStructure]").With<TBStructure>().Execute("@QueryType", "@CountryCode", "@CustodianCode", "@ListCode", "@Name", "@TBHeadCode", "@TBHeadName", "@ParentCode", "@Active", "@UserId", "@TBStructureId", "UpdateTBStructure", TBStructure.CountryCode, TBStructure.CustodianCode, TBStructure.ListCode, TBStructure.ListName, TBStructure.TBHeadCode, TBStructure.TBHeadName, TBStructure.ParentCode, isActive, Dbsecurity.Decypt(UserId), TBStructureId);
                foreach (var _TBStructure in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_TBStructure = _TBStructure.Cast<TBStructure>().ToList();
                }
                return dataList_TBStructure;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}