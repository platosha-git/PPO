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

        public List<Food> FindAll()
        {
            return db.Foods.ToList();
        }

        public Food FindByID(int id)
        {
            return db.Foods.Find(id);
        }

        public void Add(Food obj)
        {
            obj.Foodid = db.Foods.Count() + 1;
            db.Foods.Add(obj);
            db.SaveChanges();
        }

        public void Update(Food obj)
        {
            db.Foods.Update(obj);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            List<Food> allFoods = FindAll();
            db.Foods.RemoveRange(allFoods);
            db.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            Food food = FindByID(id);
            db.Foods.Remove(food);
            db.SaveChanges();
        }

        public List<Food> FindFoodByCategory(string cat)
        {
            IQueryable<Food> foods = db.Foods.Where(needed => needed.Category == cat);
            return foods.ToList();
        }

        public List<Food> FindFoodByVegMenu(bool vm)
        {
            IQueryable<Food> foods = db.Foods.Where(needed => needed.Vegmenu == vm);
            return foods.ToList();
        }

        public List<Food> FindFoodByChildMenu(bool cm)
        {
            IQueryable<Food> foods = db.Foods.Where(needed => needed.Childrenmenu == cm);
            return foods.ToList();
        }
        public List<Food> FindFoodByBar(bool bar)
        {
            IQueryable<Food> foods = db.Foods.Where(needed => needed.Bar == bar);
            return foods.ToList();
        }
    }
}
