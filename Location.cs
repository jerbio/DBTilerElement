﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBTilerElement
{
    public class Location
    {
        public string LocationId { get; set; }
        public double Long { get; set; }   
        public double Lat { get; set; }
        public string Address { get; set; }
        public string Tag { get; set; }
        public bool isNull { get; set; }
        public bool isAmbiguous { get; set; }
        public bool isVerified { get; set; }
    }
}