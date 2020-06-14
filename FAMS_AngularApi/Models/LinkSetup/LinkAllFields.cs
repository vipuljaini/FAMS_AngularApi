using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.LinkSetup
{
    public class LinkAllFields
    {
        public Int64 LinkID { get; set; }
        public string LinkName { get; set; }
        public string IconName { get; set; }
        public string url { get; set; }
        public Int64 ParetmenuID { get; set; }
    }
}