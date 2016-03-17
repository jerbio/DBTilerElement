﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilerElements;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TilerFront;
namespace DBTilerElement
{
    [Table("Locations")]
    public class DB_LocationElements:Location_Elements
    {
        /// <summary>
        /// user id for which this location is associated with
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Address Line 1
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// Address Line 1
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// City or town of address
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// State or province of the address
        /// </summary>
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        override public string Id
        {
            get
            {
                return LocationID.ToString();
            }
            protected set
            {
                LocationID =Guid.Parse( value);
            }
        }

        public double Longitude {
            get
            {
                return yValue;
            }
            set
            {
                yValue = value;
            }
        }

        public double Latitude
        {
            get
            {
                return xValue;
            }
            set
            {
                xValue = value;
            }
        }

        public bool defaultLocation
        {
            get
            {
                return DefaultLocation;
            }
            set
            {
                DefaultLocation = value;
            }
        }

        public bool isNullLocation
        {
            get
            {
                return NullLocation;
            }
            set
            {
                NullLocation = value;
            }
        }

        public bool isVerified
        {
            get
            {
                return Verified;
            }
            set
            {
                Verified = value;
            }
        }

        public string Name
        {
            get
            {
                return TaggedDescription;
            }
            set
            {
                TaggedDescription = value;
            }
        }

        public string Address
        {
            get
            {
                return TaggedAddress;
            }
            set
            {
                TaggedAddress = value;
            }
        }
    }
}
