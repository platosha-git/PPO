using System;
using System.Collections.Generic;
using System.Text;

namespace Tours
{
    public interface ITourRepository : CrudRepository<Tour, int>
    {
        List<Tour> findTourByDate(DateTime b, DateTime e);
    }
}
