using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using Tours.Repositories;
using Tours.ImpRepositories;
using Tours.ComponentsBL;
using System.Collections.Generic;

namespace TestUIRoles
{
    [TestClass]
    public class TestTouristRole
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

        private TouristController tourist = new TouristController(tourRep, hotelRep, foodRep, busRep, planeRep, trainRep, bookingRep, usersRep);

        [TestMethod]
        public void GetAllBookings()
        {
            List<Tour> tours = tourist.GetAllBookings(2);
            Assert.IsTrue(tours.Count != 0);
        }

        [TestMethod]
        public void BRTour()
        {
            List<Tour> tours = tourist.GetAllBookings(2);
            int num = tours.Count;
            tourist.BookTour(7, 2);
            tours = tourist.GetAllBookings(2);
            int anum = tours.Count;
            Assert.AreEqual(num, anum - 1);
        }

        public void UpdateSurname()
        {
            tourist.UpdateSurname("Ivanov", 1);
            User trst = tourist.GetAllUserInfo(1);
            Assert.AreEqual("Ivanov", trst.Surname);
        }
    }
}
