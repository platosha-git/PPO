using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TestTours
{
    [TestClass]
    public class TestPlaneRep
    {
        IPlaneRepository PlaneRep = new PlaneRepository(new ToursContext());

        [TestMethod]
        public void TestFindAll()
        {
            List<Planeticket> planes = PlaneRep.FindAll();
            Assert.IsTrue(planes.Count != 0);
        }

        [TestMethod]
        public void TestFindById()
        {
            Planeticket planeF = PlaneRep.FindByID(1);
            Assert.AreEqual(planeF.Plane, 809);
        }

        [TestMethod]
        public void TestAUD()
        {
            DateTime timeB = new DateTime(2021, 01, 01, 13, 15, 00);
            Planeticket planeA = new Planeticket { Planetid = 11, Plane = 74, Seat = 10, Class = 2, Cityfrom = 7, Cityto = 2, 
                Departuretime = timeB.TimeOfDay, Luggage = true, Cost = 4302 };
            PlaneRep.Add(planeA);
            Planeticket planeFA = PlaneRep.FindAll().Last();
            Assert.AreEqual(planeA, planeFA);

            planeA.Luggage = false;
            PlaneRep.Update(planeA);
            Planeticket planeFU = PlaneRep.FindAll().Last();
            Assert.AreEqual(planeA, planeFU);

            int LastID = PlaneRep.FindAll().Count();
            PlaneRep.DeleteByID(LastID);
            int NLastID = PlaneRep.FindAll().Count();
            Assert.AreEqual(LastID - 1, NLastID);
        }

        [TestMethod]
        public void TestFindPlaneByLowCost()
        {
            List<Planeticket> planes = PlaneRep.FindPlaneByLowCost(7000);
            Assert.IsTrue(planes.Count != 0);
        }
    }
}
