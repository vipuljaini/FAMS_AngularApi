﻿using System;
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
        [Route("api/StatementOfExpenses/BindGridAllFields/{FromDate}/{ToDate}")]
        public Dictionary<string, object> BindGridApi(string FromDate, string ToDate)
        {
            return ObjDAL.BindGrid(FromDate, ToDate);
        }
    }
}