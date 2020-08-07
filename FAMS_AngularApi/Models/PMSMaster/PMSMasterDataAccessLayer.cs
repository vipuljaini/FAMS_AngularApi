using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.PMSMaster;
using Encryptions;
using EntityDAL;

namespace FAMS_AngularApi.Models.PMSMaster
{
    public class PMSMasterDataAccessLayer
    {

        FAMSEntities context = new FAMSEntities();
        List<PMSMaster> dataList_PMSMaster = new List<PMSMaster>();

        public Dictionary<string, object> BindPMSMaster()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_PMS]").With<PMSMaster>().Execute("@QueryType", "BindPMS"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<PMSMaster> AddPMSMaster(PMSMaster PMSMaster, string UserId)
        {
            try
            {
                //var Result = context.MultipleResults("[dbo].[FAMS_PMS]").With<PMSMaster>().Execute("@QueryType", "@DesignationCode", "@DesignationName", "@UserId", "SavePMS", Designation.DesignationCode, Designation.DesignationName, Dbsecurity.Decrypt(UserId));
                var Result = context.MultipleResults("[dbo].[FAMS_PMS]").With<PMSMaster>().Execute("@QueryType", "@PMSCode", "@PMSName", "@PMSAccountNumber", "@UserId", "SavePMS", PMSMaster.PMSCode, PMSMaster.PMSName, PMSMaster.PMSAccountNumber, Dbsecurity.Decrypt(UserId));
                foreach (var _state in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_PMSMaster = _state.Cast<PMSMaster>().ToList();
                }
                return dataList_PMSMaster;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Add new employee record 
        public IEnumerable<PMSMaster> UpdatePMSMaster(PMSMaster PMSMaster, string UserId, string PMSId)
        {
            try
            {


                var Result = context.MultipleResults("[dbo].[FAMS_PMS]").With<PMSMaster>().Execute("@QueryType", "@PMSCode", "@PMSName", "@PMSAccountNumber", "@UserId", "@PMSId", "UpdatePMS", PMSMaster.PMSCode, PMSMaster.PMSName,PMSMaster.PMSAccountNumber, Dbsecurity.Decrypt(UserId), PMSId);
                foreach (var _state in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_PMSMaster = _state.Cast<PMSMaster>().ToList();
                }
                return dataList_PMSMaster;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}