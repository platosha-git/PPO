using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using System.Collections.Generic;
using System.Linq;

namespace TestTours
{
    [TestClass]
    public class TestUsersRep
    {
        IUsersRepository UsersRep = new UsersRepository(new ToursContext());

        [TestMethod]
        public void TestFindAll()
        {
            List<User> users = UsersRep.FindAll();
            Assert.IsTrue(users.Count != 0);
        }

        [TestMethod]
        public void TestFindById()
        {
            User userF = UsersRep.FindByID(1);
            Assert.AreEqual(userF.Name, "Ivan");
        }

        [TestMethod]
        public void TestAUD()
        {
            User userA = new User { Userid = 11, Accesslevel = 0, Name = "Ksenia", Surname = "Petrova", Year = 1997 };
            UsersRep.Add(userA);
            User userFA = UsersRep.FindAll().Last();
            Assert.AreEqual(userA, userFA);

            userA.Year = 1996;
            UsersRep.Update(userA);
            User userFU = UsersRep.FindAll().Last();
            Assert.AreEqual(userA, userFU);

            int LastID = UsersRep.FindAll().Count();
            UsersRep.DeleteByID(LastID);
            int NLastID = UsersRep.FindAll().Count();
            Assert.AreEqual(LastID - 1, NLastID);
        }

        [TestMethod]
        public void TestFindByAccess()
        {
            List<User> users = UsersRep.FindUsersByAccessLevel(0);
            Assert.IsTrue(users.Count != 0);
        }
    }
}
