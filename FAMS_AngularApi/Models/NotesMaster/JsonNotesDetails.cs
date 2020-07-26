using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.NotesMaster
{
    public class JsonNotesDetails
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Note { get; set; }
        public string Attachment { get; set; }
        public string UserId { get; set; }
        //public string Attachment { get; set; }
        //public string UserId { get; set; }
        //public string NMId { get; set; }
    }
}