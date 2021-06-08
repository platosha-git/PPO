using System;
using System.Collections.Generic;

#nullable disable

namespace Tours
{
    public partial class Busticket
    {
        public Busticket()
        {
            Transfers = new HashSet<Transfer>();
        }

        public int Bustid { get; set; }
        public int? Bus { get; set; }
        public int? Seat { get; set; }
        public int? Cityfrom { get; set; }
        public int? Cityto { get; set; }
        public TimeSpan? Departuretime { get; set; }
        public TimeSpan? Arrivaltime { get; set; }
        public bool? Luggage { get; set; }
        public int? Cost { get; set; }

        public virtual City CityfromNavigation { get; set; }
        public virtual City CitytoNavigation { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
