﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tours
{
    public partial class Hotel
    {
        public Hotel()
        {
            Tours = new HashSet<Tour>();
        }

        public int Hotelid { get; set; }
        public int City { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Class { get; set; }
        public bool? Swimpool { get; set; }
        public int Cost { get; set; }

        public virtual City CityNavigation { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
