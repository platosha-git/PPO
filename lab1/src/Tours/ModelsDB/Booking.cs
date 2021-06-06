using System;
using System.Collections.Generic;

#nullable disable

namespace Tours
{
    public partial class Booking
    {
        public int Customer { get; set; }
        public int[] Tourid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual User User { get; set; }
    }
}
