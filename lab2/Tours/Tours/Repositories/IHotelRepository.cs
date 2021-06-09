using System;
using System.Collections.Generic;
using System.Text;

namespace Tours.Repositories
{
    public interface IHotelRepository : CrudRepository<Hotel, int>
    {
        Hotel FindHotelByName(string name);
        List<Hotel> FindHotelByType(string type);
        List<Hotel> FindHotelByClass(int cls);
        List<Hotel> FindHotelBySwimPool(bool sp);
        List<Hotel> FindHotelByLowCost(int cost);
    }
}
