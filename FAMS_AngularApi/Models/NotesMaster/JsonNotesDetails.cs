using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.NotesMaster
{
    public class JsonNotesDetails
    {
        public string Subject { get; set; }
        public string Note { get; set; }
        public string IsBold { get; set; }
        public string IsItalic { get; set; }
        public string IsUnderLine { get; set; }
        public string Attachment { get; set; }
        public string UserId { get; set; }

    }
}