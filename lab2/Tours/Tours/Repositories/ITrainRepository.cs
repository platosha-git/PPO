using System;
using System.Collections.Generic;
using System.Text;

namespace Tours.Repositories
{
    public interface ITrainRepository : CrudRepository<Trainticket, int>
    {
        List<Trainticket> FindTrainByLowCost(int cost);
    }
}
