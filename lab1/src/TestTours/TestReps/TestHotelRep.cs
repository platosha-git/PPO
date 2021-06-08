using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using System.Collections.Generic;
using System.Linq;

namespace TestTours
{
    [TestClass]
    public class TestHotelRep
    {
        IHotelRepository HotelRep = new HotelRepository(new ToursContext());

        [TestMethod]
        public void TestFindAll()
        {
            List<Hotel> hotels = HotelRep.FindAll();
            Assert.IsTrue(hotels.Count != 0);
        }

        [TestMethod]
        public void TestFindById()
        {
            Hotel hotelF = HotelRep.FindByID(1);
            Assert.AreEqual(hotelF.Cost, 16895);
        }

        [TestMethod]
        public void TestAUD()
        {
            Hotel hotelA = new Hotel { Hotelid = 11, City = 5, Name = "Spa Sochi Hutor", Type = "Apart", Class = 5, Swimpool = true, Cost = 23910 };
            HotelRep.Add(hotelA);
            Hotel hotelFA = HotelRep.FindAll().Last();
            Assert.AreEqual(hotelA, hotelFA);

            hotelA.Swimpool = false;
            HotelRep.Update(hotelA);
            Hotel hotelFU = HotelRep.FindAll().Last();
            Assert.AreEqual(hotelA, hotelFU);
            
            int LastID = HotelRep.FindAll().Count();
            HotelRep.DeleteByID(LastID);
            int NLastID = HotelRep.FindAll().Count();
            Assert.AreEqual(LastID - 1, NLastID);
        }

        [TestMethod]
        public void TestFindHotelByName()
        {
            Hotel hotelF = HotelRep.FindHotelByName("Goodrich Corporation");
            Assert.IsTrue(hotelF.Hotelid == 1); 
            
        }

        [TestMethod]
        public void TestFindHotelByType()
        {
            List<Hotel> hotels = HotelRep.FindHotelByType("Mini");
            Assert.IsTrue(hotels.Count != 0);

        }

        [TestMethod]
        public void TestFindHotelByClass()
        {
            List<Hotel> hotels = HotelRep.FindHotelByClass(5);
            Assert.IsTrue(hotels.Count != 0);

        }

        [TestMethod]
        public void TestFindHotelBySwimPool()
        {
            List<Hotel> hotels = HotelRep.FindHotelBySwimPool(true);
            Assert.IsTrue(hotels.Count != 0);

        }

        [TestMethod]
        public void TestFindHotelByLowCost()
        {
            List<Hotel> hotels = HotelRep.FindHotelByLowCost(10000);
            Assert.IsTrue(hotels.Count != 0);
        }
    }
}
