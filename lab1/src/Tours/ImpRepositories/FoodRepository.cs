using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tours
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ToursContext db;

        public FoodRepository(ToursContext createDB)
        {
            db = createDB;
        }

        public List<Food> findAll()
        {
            return db.Foods.ToList();
        }

        public Food findByID(int id)
        {
            return db.Foods.Find(id);
        }

        public void add(Food obj)
        {
            obj.Foodid = db.Foods.Count() + 1;
            db.Foods.Add(obj);
            db.SaveChanges();
        }

        public void update(Food obj)
        {
            db.Foods.Update(obj);
            db.SaveChanges();
        }

        public void deleteAll()
        {
            List<Food> allFoods = findAll();
            db.Foods.RemoveRange(allFoods);
            db.SaveChanges();
        }

        public void deleteByID(int id)
        {
            Food food = findByID(id);
            db.Foods.Remove(food);
            db.SaveChanges();
        }

        public List<Food> findFoodByCategory(string cat)
        {
            IQueryable<Food> foods = db.Foods.Where(needed => needed.Category == cat);
            return foods.ToList();
        }

        public List<Food> findFoodByVegMenu(bool vm)
        {
            IQueryable<Food> foods = db.Foods.Where(needed => needed.Vegmenu == vm);
            return foods.ToList();
        }

        public List<Food> findFoodByChildMenu(bool cm)
        {
            IQueryable<Food> foods = db.Foods.Where(needed => needed.Childrenmenu == cm);
            return foods.ToList();
        }
        public List<Food> findFoodByBar(bool bar)
        {
            IQueryable<Food> foods = db.Foods.Where(needed => needed.Bar == bar);
            return foods.ToList();
        }
    }
}
