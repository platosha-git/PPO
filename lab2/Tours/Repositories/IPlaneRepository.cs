using System;
using System.Collections.Generic;
using System.Text;

namespace Tours
{
    public interface IPlaneRepository : CrudRepository<Planeticket, int>
    {
        List<Planeticket> FindPlaneByLowCost(int cost);
    }
}
