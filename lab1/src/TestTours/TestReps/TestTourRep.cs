using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TestTours
{
    [TestClass]
    public class TestTourRep
    {
        ITourRepository TourRep = new TourRepository(new ToursContext(ConfigManager.GetConnectionString(2)));

        [TestMethod]
        public void TestFindAll()
        {
            List<Tour> tours = TourRep.FindAll();
            Assert.IsTrue(tours.Count != 0);
        }

        [TestMethod]
        public void TestFindById()
        {
            Tour tourF = TourRep.FindByID(1);
            Assert.AreEqual(tourF.Cost, 32290);
        }

        [TestMethod]
        public void TestAUD()
        {
            DateTime dateB = new DateTime(2022, 03, 10);
            DateTime dateE = new DateTime(2022, 05, 01);
            Tour tourA = new Tour { Tourid = 11, Food = 4, Hotel = 7, Transfer = 3, Cost = 72013, Datebegin = dateB, Dateend = dateE };
            TourRep.Add(tourA);
            Tour tourFA = TourRep.FindAll().Last();
            Assert.AreEqual(tourA, tourFA);

            tourA.Food = 6;
            TourRep.Update(tourA);
            Tour tourFU = TourRep.FindAll().Last();
            Assert.AreEqual(tourA, tourFU);

            int LastID = TourRep.FindAll().Count();
            TourRep.DeleteByID(LastID);
            int NLastID = TourRep.FindAll().Count();
            Assert.AreEqual(LastID - 1, NLastID);
        }

        [TestMethod]
        public void TestFindTourByDate()
        {
            DateTime dateB = new DateTime(2020, 01, 01);
            DateTime dateE = new DateTime(2022, 12, 31);
            List<Tour> tours = TourRep.FindTourByDate(dateB, dateE);
            Assert.IsTrue(tours.Count != 0);
        }
    }
}
