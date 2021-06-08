using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using System.Collections.Generic;
using System.Linq;

namespace TestTours
{
    [TestClass]
    public class TestBusRep
    {
        IBusRepository BusRep = new BusRepository(new ToursContext());
        
        [TestMethod]
        public void TestFindAll()
        {   
            List<Busticket> buses = BusRep.FindAll();
            Assert.IsTrue(buses.Count != 0);
        }

        [TestMethod]
        public void TestFindById()
        {
            Busticket busF = BusRep.FindByID(1);
            Assert.AreEqual(busF.Cost, 23012);
        }

        [TestMethod]
        public void TestAdd()
        {
            Busticket busA = new Busticket { Bustid = 11, Seat = 23, Cityfrom = 3, Cityto = 8, Luggage = true, Cost = 9201 };
            BusRep.Add(busA);
            Busticket busF = BusRep.FindAll().Last();
            Assert.AreEqual(busA, busF);
        }

        /*[TestMethod]
        public void TestUpdate()
        {
            Busticket busU = new Busticket { Seat = 23, Cityfrom = 3, Cityto = 8, Luggage = false, Cost = 9201 };
            BusRep.Update(busU);

            Busticket busF = BusRep.FindAll().Last();
            Assert.AreEqual(busU, busF);
        }
        

        [TestMethod]
        public void TestDeleteById()
        {
            int LastID = BusRep.FindAll().Count();
            BusRep.DeleteByID(12);

            Assert.AreEqual(LastID, 12);
        }
        */

        [TestMethod]
        public void TestFindBusByLowCost()
        {
            List<Busticket> buses = BusRep.FindBusByLowCost(7000);
            Assert.IsNotNull(buses);
        }
    }
}
