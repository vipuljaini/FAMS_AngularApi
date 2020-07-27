using FAMS_AngularApi.Models.TransactionStatement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FAMS_AngularApi.Controllers
{
    public class TransactionStatementController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpPost]
        [Route("api/TransactionStatement/BindGrid")]
        public Dictionary<string, object> BindGriidApi(JsonFields Data)
        {
            return ObjDAL.BindGrid(Data);
        }


        //[HttpGet]
        //[Route("api/TransactionStatement/BindCustomer/{EmployeeId}")]
        //public Dictionary<string, object> BindCustomer(string EmployeeId)
        //{
        //    return ObjDAL.BindCustomer(EmployeeId);
        //}

        //[HttpPost]
        //[Route("api/TransactionStatement/BindEmployees/{UserId}")]
        //public Dictionary<string, object> BindEmployeesApi(string UserId)
        //{
        //    return ObjDAL.BindEmployees(UserId);
        //}
        [HttpGet]
        [Route("api/TransactionStatement/NextRecordBind/{CustomerAccount}/{FromDate}/{ToDate}/{SeqNo}")]
        public Dictionary<string, object> NextRecordBind(string CustomerAccount, string FromDate, string ToDate, string SeqNo)
        {
            return ObjDAL.NextRecordBind(CustomerAccount, FromDate, ToDate, SeqNo);
        }

        //[HttpGet]
        //[Route("api/StatementOfExpenses/BindGridAllFields/{CustomerAccount}/{FromDate}/{ToDate}/{SeqNo}")]
        //public Dictionary<string, object> BindGridApi(string CustomerAccount, string FromDate, string ToDate, string SeqNo)
        //{
        //    return ObjDAL.BindGrid(CustomerAccount, FromDate, ToDate, SeqNo);
        //}

        [HttpGet]
        [Route("api/TransactionStatement/BindDefaultData/{CustomerAccount}/{GUserId}")]
        public Dictionary<string, object> BindDefaultData(string CustomerAccount, string GUserId)
        {
            return ObjDAL.BindDefaultData(CustomerAccount, GUserId);
        }
    }
}
