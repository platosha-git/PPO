using System;
using System.Collections.Generic;
using System.Text;

namespace Tours
{
    public interface ITourRepository : CrudRepository<Tour, int>
    {
        List<Tour> FindTourByDate(DateTime b, DateTime e);
    }
}
