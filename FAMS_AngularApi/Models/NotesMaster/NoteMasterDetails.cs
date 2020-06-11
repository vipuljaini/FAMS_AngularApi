using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.NotesMaster
{
    public class NoteMasterDetails
    {
        public Nullable<Int64> srNo { get; set; }
        public Nullable<Int64> NMId { get; set; }
        //public Nullable<Boolean> IsBold { get; set; }
        //public Nullable<Boolean> IsItalic { get; set; }
        //public Nullable<Boolean> IsUnderLine { get; set; }
        public string subject { get; set; }
        public string dateofsubmission { get; set; }


    }
}