using System;
using System.Collections.Generic;
using System.Text;

namespace Tours
{
    public interface IFoodRepository : CrudRepository<Food, int>
    {
        List<Food> findFoodByCategory(string cat);
        List<Food> findFoodByVegMenu(bool vm);
        List<Food> findFoodByChildMenu(bool cm);
        List<Food> findFoodByBar(bool bar);
    }
}
