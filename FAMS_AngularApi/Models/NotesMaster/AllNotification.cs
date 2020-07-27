using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.NotesMaster
{
    public class AllNotification
    {
        public Int64 NMId { get; set; }
        public string Subject { get; set; }
        public string Note { get; set; }
        public string AttachmentFile { get; set; }
        public bool IsRead { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedOnTime { get; set; }
        public Int32 NoteLength { get; set; }
        public Int32 sublength { get; set; }
        

    }
}