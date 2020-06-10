using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.MyNotes
{
    public class BindAllFields
    {
        public Nullable<Int64> NMId { get; set; }
        public string Subject { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string AttachmentFile { get; set; }
    }
}