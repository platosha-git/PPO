using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using System.Collections.Generic;
using System.Linq;

namespace TestTours
{
    [TestClass]
    public class TestFoodRep
    {
        IFoodRepository FoodRep = new FoodRepository(new ToursContext(ConfigManager.GetConnectionString(2)));

        [TestMethod]
        public void TestFindAll()
        {
            List<Food> foods = FoodRep.FindAll();
            Assert.IsTrue(foods.Count != 0);
        }

        [TestMethod]
        public void TestFindById()
        {
            Food foodF = FoodRep.FindByID(1);
            Assert.AreEqual(foodF.Cost, 2129);
        }

        [TestMethod]
        public void TestAUD()
        {
            Food foodA = new Food { Foodid = 11, Category = "HB", Vegmenu = true, Childrenmenu = true, Bar = true, Cost = 2530 };
            FoodRep.Add(foodA);
            Food foodFA = FoodRep.FindAll().Last();
            Assert.AreEqual(foodA, foodFA);

            foodA.Vegmenu = false;
            FoodRep.Update(foodA);
            Food foodFU = FoodRep.FindAll().Last();
            Assert.AreEqual(foodA, foodFU);

            int LastID = FoodRep.FindAll().Count();
            FoodRep.DeleteByID(LastID);
            int NLastID = FoodRep.FindAll().Count();
            Assert.AreEqual(LastID - 1, NLastID);
        }

        [TestMethod]
        public void TestFindFoodByCategory()
        {
            List<Food> foods = FoodRep.FindFoodByCategory("BB");
            Assert.IsTrue(foods.Count != 0);
        }

        [TestMethod]
        public void TestFindFoodByVegMenu()
        {
            List<Food> foods = FoodRep.FindFoodByVegMenu(true);
            Assert.IsTrue(foods.Count != 0);
        }

        [TestMethod]
        public void TestFindFoodByChildMenu()
        {
            List<Food> foods = FoodRep.FindFoodByChildMenu(true);
            Assert.IsTrue(foods.Count() != 0);
        }

        [TestMethod]
        public void TestFindFoodByBar()
        {
            List<Food> foods = FoodRep.FindFoodByBar(true);
            Assert.IsTrue(foods.Count != 0);
        }
    }
}
