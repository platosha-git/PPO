using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TestTours
{
    [TestClass]
    public class TestBusRep
    {
        IBusRepository BusRep = new BusRepository(new ToursContext(ConfigManager.GetConnectionString(2)));
        
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
            Assert.AreEqual(busF.Bus, 234);
        }

        [TestMethod]
        public void TestAUD()
        {
            DateTime timeB = new DateTime(2021, 01, 01, 13, 15, 00);
            DateTime timeE = new DateTime(2021, 01, 01, 15, 37, 00);
            Busticket busA = new Busticket { Bustid = 11, Bus = 74, Seat = 10, Cityfrom = 7, Cityto = 2, 
                Departuretime = timeB.TimeOfDay, Arrivaltime = timeE.TimeOfDay, Luggage = true, Cost = 4302 };
            BusRep.Add(busA);
            Busticket tourFA = BusRep.FindAll().Last();
            Assert.AreEqual(busA, tourFA);
            
            busA.Luggage = false;
            BusRep.Update(busA);
            Busticket tourFU = BusRep.FindAll().Last();
            Assert.AreEqual(busA, tourFU);
            
            int LastID = BusRep.FindAll().Count();
            BusRep.DeleteByID(LastID);
            int NLastID = BusRep.FindAll().Count();
            Assert.AreEqual(LastID - 1, NLastID);
        }

        [TestMethod]
        public void TestFindBusByLowCost()
        {
            List<Busticket> buses = BusRep.FindBusByLowCost(7000);
            Assert.IsTrue(buses.Count != 0);
        }
    }
}
