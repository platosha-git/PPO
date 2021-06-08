using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TestTours
{
    [TestClass]
    public class TestTrainRep
    {
        ITrainRepository TrainRep = new TrainRepository(new ToursContext());

        [TestMethod]
        public void TestFindAll()
        {
            List<Trainticket> trains = TrainRep.FindAll();
            Assert.IsTrue(trains.Count != 0);
        }

        [TestMethod]
        public void TestFindById()
        {
            Trainticket trainF = TrainRep.FindByID(1);
            Assert.AreEqual(trainF.Train, 809);
        }

        [TestMethod]
        public void TestAUD()
        {
            DateTime timeB = new DateTime(2021, 01, 01, 13, 15, 00);
            DateTime timeE = new DateTime(2021, 01, 01, 15, 25, 00);
            Trainticket trainA = new Trainticket { Traintid = 11, Train = 74, Coach = 3, Seat = 10, Cityfrom = 7, Cityto = 2, 
                Departuretime = timeB.TimeOfDay, Arrivaltime = timeE.TimeOfDay, Linens = true, Cost = 4302 };
            TrainRep.Add(trainA);
            Trainticket trainFA = TrainRep.FindAll().Last();
            Assert.AreEqual(trainA, trainFA);

            trainA.Linens = false;
            TrainRep.Update(trainA);
            Trainticket trainFU = TrainRep.FindAll().Last();
            Assert.AreEqual(trainA, trainFU);

            int LastID = TrainRep.FindAll().Count();
            TrainRep.DeleteByID(LastID);
            int NLastID = TrainRep.FindAll().Count();
            Assert.AreEqual(LastID - 1, NLastID);
        }

        [TestMethod]
        public void TestFindTrainByLowCost()
        {
            List<Trainticket> trains = TrainRep.FindTrainByLowCost(2000);
            Assert.IsTrue(trains.Count != 0);
        }
    }
}
