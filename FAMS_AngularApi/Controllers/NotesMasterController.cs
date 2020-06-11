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
