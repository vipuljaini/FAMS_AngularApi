﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAMS_AngularApi.Models.Security
{
    public class Security
    {
        public Int64 SrNo { get; set; }
        public string SecurityCode { get; set; }
        public string SecurityName { get; set; }
        public string SectorCode { get; set; }
    }
}