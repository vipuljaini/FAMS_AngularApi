using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.Designation;
using Encryptions;

namespace FAMS_AngularApi.Models.Designation
{
    public class DesignationDataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        List<Designation> dataList_Designation = new List<Designation>();

        public Dictionary<string, object> BindDesignation()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_Designation]").With<Designation>().Execute("@QueryType", "BindDesignation"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<Designation> AddDesignation(Designation Designation, string UserId)
        {
            try
            {


                var Result = context.MultipleResults("[dbo].[FAMS_Designation]").With<Designation>().Execute("@QueryType", "@DesignationCode", "@DesignationName","@UserId", "SaveDesignation", Designation.DesignationCode, Designation.DesignationName, Dbsecurity.Decypt(UserId));
                foreach (var _state in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_Designation = _state.Cast<Designation>().ToList();
                }
                return dataList_Designation;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Add new employee record 
        public IEnumerable<Designation> UpdateDesignation(Designation Designation, string UserId, string DesignationId)
        {
            try
            {


                var Result = context.MultipleResults("[dbo].[FAMS_Designation]").With<Designation>().Execute("@QueryType", "@DesignationCode", "@DesignationName", "@UserId", "@DesignationId", "UpdateDesignation", Designation.DesignationCode, Designation.DesignationName, Dbsecurity.Decypt(UserId), DesignationId);
                foreach (var _state in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_Designation = _state.Cast<Designation>().ToList();
                }
                return dataList_Designation;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}