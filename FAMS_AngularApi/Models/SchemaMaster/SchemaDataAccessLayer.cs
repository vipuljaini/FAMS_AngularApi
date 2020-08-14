using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.SchemaMaster;
using Encryptions;
using EntityDAL;
using FAMS_AngularApi.Models.StateOfExpenses;

namespace FAMS_AngularApi.Models.SchemaMaster
{
    public class SchemaDataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        List<SchemaMaster> dataList_SchemaMaster = new List<SchemaMaster>();

        public Dictionary<string, object> BindAllCustomer()
        {
            FAMSEntities context = new FAMSEntities();
            try
            {
                var results = Common.Getdata(context.MultipleResults("[dbo].[FAMS_SchemeMaster]").With<Customer>()
                          .Execute("@Querytype", "BindAllCustomer"));
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Dictionary<string, object> BindSchemaMasterDetails(string SchemaMasterId)
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_SchemeMaster]").With<SchemaMaster>().Execute("@QueryType", "@SchemaMasterId", "BindSchemeMasterDetails", SchemaMasterId));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Dictionary<string, object> BindSchemaMaster()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_SchemeMaster]").With<SchemaMaster>().Execute("@QueryType", "BindSchemeMaster"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<SchemaMaster> AddSchemaMaster(SchemaMaster SchemaMaster, string UserId)
        {
            try
            {
                //var Result = context.MultipleResults("[dbo].[FAMS_PMS]").With<SchemaMaster>().Execute("@QueryType", "@DesignationCode", "@DesignationName", "@UserId", "SavePMS", Designation.DesignationCode, Designation.DesignationName, Dbsecurity.Decrypt(UserId));
                var Result = context.MultipleResults("[dbo].[FAMS_SchemeMaster]").With<SchemaMaster>().Execute("@QueryType", "@PMSCode", "@CustodianCode", "@SchemaNumber", "@UserId", "@Cust_code", "SaveSchemeMaster", SchemaMaster.PMSCode, SchemaMaster.CustodianCode, SchemaMaster.SchemaNumber, Dbsecurity.Decrypt(UserId),SchemaMaster.Cust_code);
                foreach (var _state in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_SchemaMaster = _state.Cast<SchemaMaster>().ToList();
                }
                return dataList_SchemaMaster;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Add new employee record 
        public IEnumerable<SchemaMaster> UpdateSchemaMaster(SchemaMaster SchemaMaster, string UserId, string SchemaMasterId)
        {
            try
            {
                //var Result = context.MultipleResults("[dbo].[FAMS_SchemeMaster]").With<SchemaMaster>().Execute("@QueryType", "@PMSCode", "@PMSName", "@PMSAccountNumber", "@UserId", "@PMSId", "UpdatePMS", SchemaMaster.PMSCode, SchemaMaster.PMSName, SchemaMaster.PMSAccountNumber, Dbsecurity.Decrypt(UserId), PMSId);
                //var Result = context.MultipleResults("[dbo].[FAMS_SchemeMaster]").With<SchemaMaster>().Execute("@QueryType", "@PMSCode", "@CustodianCode", "@SchemaNumber","", "@UserId", "UpdateSchemeMaster", SchemaMaster.PMSCode, SchemaMaster.CustodianCode, SchemaMaster.SchemeNumber, Dbsecurity.Decrypt(UserId), SchemeMasterId);
                var Result = context.MultipleResults("[dbo].[FAMS_SchemeMaster]").With<SchemaMaster>().Execute("@QueryType", "@PMSCode", "@CustodianCode", "@SchemaNumber",  "@UserId", "@SchemaMasterId", "UpdateSchemeMaster", SchemaMaster.PMSCode, SchemaMaster.CustodianCode, SchemaMaster.SchemaNumber, Dbsecurity.Decrypt(UserId), SchemaMasterId);
                foreach (var _state in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_SchemaMaster = _state.Cast<SchemaMaster>().ToList();
                }
                return dataList_SchemaMaster;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}