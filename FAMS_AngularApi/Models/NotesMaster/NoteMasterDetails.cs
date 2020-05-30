using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.NotesMaster
{
    public class NoteMasterDetails
    {
        public string Subject { get; set; }
        public string Note  { get; set; }
        public Nullable<Boolean> IsBold { get; set; }
        public Nullable<Boolean> IsItalic { get; set; }
        public Nullable<Boolean> IsUnderLine { get; set; }
        public string Attachment { get; set; }
        public DateTime CreatedOn { get; set; }


    }
}