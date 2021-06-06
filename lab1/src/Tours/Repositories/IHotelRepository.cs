using System;
using System.Collections.Generic;
using System.Text;

namespace Tours
{
    public interface IHotelRepository : CrudRepository<Hotel, int>
    {
        List<Hotel> findHotelByName(string name);
        List<Hotel> findHotelByType(string type);
        List<Hotel> findHotelByClass(int cls);
        List<Hotel> findHotelBySwimPool(bool sp);
        List<Hotel> findHotelByLowCost(int cost);
    }
}
