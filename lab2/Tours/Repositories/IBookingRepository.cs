using System;
using System.Collections.Generic;
using System.Text;

namespace Tours.Repositories
{
    public interface IBookingRepository : CrudRepository<Booking, int>
    {
        int[] GetBookToursByID(int id);
    }
}
