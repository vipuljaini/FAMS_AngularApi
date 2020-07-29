using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAMS_AngularApi.Models.NotesMaster;


namespace FAMS_AngularApi.Controllers
{
    public class NotesMasterController : ApiController
    {
        DataAccessLayer ObjDAL = new DataAccessLayer();
        [HttpPost]
        [Route("api/NoteMaster/BindGrid")]
        public Dictionary<string, object> BindGridApi(JsonUserDetails Data)
        {
            return ObjDAL.BindGrid(Data);
        }

        [HttpPost]
        [Route("api/NoteMaster/BindGrid1")]
        public Dictionary<string, object> BindGridApi1(JsonUserDetails Data)
        {
            return ObjDAL.BindGrid1(Data);
        }

        [HttpPost]
        [Route("api/NoteMaster/BindEmail")]
        public Dictionary<string, object> BindEmailApi(JsonUserDetails Data)
        {
            return ObjDAL.BindEmail(Data);
        }

        [HttpPost]
        [Route("api/NoteMaster/BindAllNotification")]
        public Dictionary<string, object> BindNotificationApi(EmailWise Data)
        {
            return ObjDAL.BindNotification(Data);
        }

        [HttpPost]
        [Route("api/NoteMaster/BindAllNotification1")]
        public Dictionary<string, object> BindNotificationApi1(EmailWise Data)
        {
            return ObjDAL.BindNotification1(Data);
        }
        [HttpPost]
        [Route("api/NoteMaster/BindAllNotification2")]
        public Dictionary<string, object> BindNotificationApi2(EmailWise Data)
        {
            return ObjDAL.BindNotification2(Data);
        }

        [HttpPost]
        [Route("api/NoteMaster/BindAlldataNotification")]
        public Dictionary<string, object> BindDataNotificationApi(EmailWise Data)
        {
            return ObjDAL.BindDataNotification(Data);
        }


        [HttpPost]
        [Route("api/NoteMaster/SaveData")]
        public Dictionary<string, object> SaveDataApi(JsonNotesDetails Data)
        {
            return ObjDAL.SaveData(Data);
        }

        //[HttpPost]
        //[Route("api/NotesMaster/InsertNotes")]
        //public Dictionary<string, object> SaveNotesDetails(JsonCustomerDetails Data)
        //{
        //    return ObjDAL.SaveNotes(Data);
        //}
    }
}
