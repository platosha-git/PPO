using System;
using System.Collections.Generic;

#nullable disable

namespace Tours
{
    public partial class User
    {
        public int Userid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Year { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
