using EntityDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLibrary;
using FAMS_AngularApi.Models.State;
using Encryptions;

namespace FAMS_AngularApi.Models.State
{
    public class StateDataAccessLayer
    {
        FAMSEntities context = new FAMSEntities();
        List<State> dataList_State = new List<State>();

        public Dictionary<string, object> BindState()
        {
            try
            {
                var Result = Common.Getdata(context.MultipleResults("[dbo].[FAMS_State]").With<State>().Execute("@QueryType", "BindState"));
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To Add new employee record 
        public IEnumerable<State> AddState(State State, string UserId)
        {
            try
            {


                var Result = context.MultipleResults("[dbo].[FAMS_State]").With<State>().Execute("@QueryType", "@StateCode", "@StateName", "@CountryCode", "@UserId", "SaveState", State.StateCode, State.StateName, Convert.ToString(State.CountryCode), Dbsecurity.Decypt(UserId));
                foreach (var _state in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_State = _state.Cast<State>().ToList();
                }
                return dataList_State;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //To Add new employee record 
        public IEnumerable<State> UpdateState(State State, string UserId, string StateId)
        {
            try
            {


                var Result = context.MultipleResults("[dbo].[FAMS_State]").With<State>().Execute("@QueryType", "@StateCode", "@StateName", "@CountryCode", "@UserId", "@StateId", "UpdateState", State.StateCode, State.StateName, Convert.ToString(State.CountryCode), Dbsecurity.Decypt(UserId), StateId);
                foreach (var _state in Result)
                {
                    //Flag = employe.Cast<ResFlag>().ToList() .Select(x=>x.Responseflag).First().ToString();
                    dataList_State = _state.Cast<State>().ToList();
                }
                return dataList_State;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}