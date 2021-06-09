using System;
using System.Collections.Generic;
using System.Text;

namespace Tours.Repositories
{
    public interface ITourRepository : CrudRepository<Tour, int>
    {
        List<Tour> FindTourByDate(DateTime b, DateTime e);
    }
}
