using System;
using System.Collections.Generic;

#nullable disable

namespace Tours
{
    public partial class Planeticket
    {
        public Planeticket()
        {
            Transfers = new HashSet<Transfer>();
        }

        public int Planetid { get; set; }
        public int? Plane { get; set; }
        public int? Seat { get; set; }
        public int? Class { get; set; }
        public int? Cityfrom { get; set; }
        public int? Cityto { get; set; }
        public TimeSpan? Departuretime { get; set; }
        public bool? Luggage { get; set; }
        public int? Cost { get; set; }

        public virtual City CityfromNavigation { get; set; }
        public virtual City CitytoNavigation { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
