using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.StateOfExpenses;

namespace FAMS_AngularApi.Controllers
{
    public class StatementOfExpensesController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();


        [HttpGet]
        [Route("api/StatementOfExpenses/BindCustomer/{EmployeeId}")]
        public Dictionary<string, object> BindCustomer(string EmployeeId)
        {
            return ObjDAL.BindCustomer(EmployeeId);
        }

        [HttpPost]
        [Route("api/StatementOfExpenses/BindEmployees/{UserId}")]
        public Dictionary<string, object> BindEmployeesApi(string UserId)
        {
            return ObjDAL.BindEmployees(UserId);
        }
        [HttpGet]
        [Route("api/StatementOfExpenses/NextRecordBind/{CustomerAccount}/{FromDate}/{ToDate}/{SeqNo}")]
        public Dictionary<string, object> NextRecordBind(string CustomerAccount, string FromDate, string ToDate,string SeqNo)
        {
            return ObjDAL.NextRecordBind(CustomerAccount, FromDate, ToDate, SeqNo);
        }

        [HttpGet]
        [Route("api/StatementOfExpenses/BindGridAllFields/{CustomerAccount}/{FromDate}/{ToDate}/{SeqNo}")]
        public Dictionary<string, object> BindGridApi(string CustomerAccount, string FromDate, string ToDate, string SeqNo)
        {
            return ObjDAL.BindGrid(CustomerAccount,FromDate, ToDate, SeqNo);
        }

        [HttpGet]
        [Route("api/StatementOfExpenses/BindDefaultData/{CustomerAccount}/{GUserId}")]
        public Dictionary<string, object> BindDefaultData(string CustomerAccount,string GUserId)
        {
            return ObjDAL.BindDefaultData(CustomerAccount, GUserId);
        }
    }
}