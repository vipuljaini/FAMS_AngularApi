﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.AllCustomer;


namespace FAMS_AngularApi.Controllers
{
    public class AllCustomerController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpGet]
        [Route("api/AllCustomer/BindGrid/{UserId}")]
        public Dictionary<string, object> BindGridApi(string UserId)
        {
            return ObjDAL.BindGrid(UserId);
        }


        [HttpPost]
        [Route("api/AllCustomer/InsertCustomerDetails/{UserId}")]
        public IEnumerable<CustomerResponse> SaveCustomerDetails(JsonCustomerDetails Data, string UserId)
        {
            return ObjDAL.SaveCustomer(Data,UserId);
        }

        [HttpPost]
        [Route("api/AllCustomer/UpdateCustomerDetails/{UserId}/{CustomerId}")]
        public IEnumerable<CustomerResponse> UpdateCustomerDetails(JsonCustomerDetails Data, string UserId, string CustomerId)
        {
            return ObjDAL.UpdateCustomer(Data, UserId, CustomerId);
        }
        [HttpGet]
        [Route("api/AllCustomer/BindGraphGrid")]
        public Dictionary<string, object> BindGGridApi()
        {
            return ObjDAL.BindGGrid();
        }
    }
}
