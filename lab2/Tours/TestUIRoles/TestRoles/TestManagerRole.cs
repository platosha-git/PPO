using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using Tours.Repositories;
using Tours.ImpRepositories;
using Tours.ComponentsBL;
using System.Collections.Generic;

namespace TestUIRoles
{
    [TestClass]
    public class TestManagertRole
    {
        static ToursContext db = new ToursContext(ConfigManager.GetConnectionString(2));

        static ITourRepository tourRep = new TourRepository(db);
        static IHotelRepository hotelRep = new HotelRepository(db);
        static IFoodRepository foodRep = new FoodRepository(db);
        static IBusRepository busRep = new BusRepository(db);
        static IPlaneRepository planeRep = new PlaneRepository(db);
        static ITrainRepository trainRep = new TrainRepository(db);
        static IBookingRepository bookingRep = new BookingRepository(db);
        static IUsersRepository usersRep = new UsersRepository(db);

        private ManagerController manager = new ManagerController(tourRep, hotelRep, foodRep, busRep, planeRep, trainRep, bookingRep, usersRep);

        [TestMethod]
        public void GetAllUsers()
        {
            List<User> users = manager.GetAllUsers();
            Assert.IsTrue(users.Count != 0);
        }
    }
}
