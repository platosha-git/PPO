﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tours
{
    public partial class Tour
    {
        public int Tourid { get; set; }
        public int Food { get; set; }
        public int Hotel { get; set; }
        public int Transfer { get; set; }
        public int Cost { get; set; }
        public DateTime Datebegin { get; set; }
        public DateTime Dateend { get; set; }

        public virtual Food FoodNavigation { get; set; }
        public virtual Hotel HotelNavigation { get; set; }
        public virtual Transfer TransferNavigation { get; set; }
    }
}
