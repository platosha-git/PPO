using System;
using System.Collections.Generic;
using System.Text;

namespace Tours.Repositories
{
    public interface IBusRepository : CrudRepository<Busticket, int>
    {
        List<Busticket> FindBusByLowCost(int cost);
    }

}
