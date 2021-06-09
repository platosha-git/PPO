using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tours;
using Tours.Repositories;
using Tours.ImpRepositories;
using Tours.ComponentsBL;
using System.Collections.Generic;

namespace TestUIRoles
{
    [TestClass]
    public class TestGuestRole
    {
        static ToursContext db = new ToursContext(ConfigManager.GetConnectionString(2));

        static ITourRepository tourRep = new TourRepository(db);
        static IHotelRepository hotelRep = new HotelRepository(db);
        static IFoodRepository foodRep = new FoodRepository(db);
        static IBusRepository busRep = new BusRepository(db);
        static IPlaneRepository planeRep = new PlaneRepository(db);
        static ITrainRepository trainRep = new TrainRepository(db);
        static IBookingRepository bookingRep = new BookingRepository(db);

        private GuestController guest = new GuestController(tourRep, hotelRep, foodRep, busRep, planeRep, trainRep, bookingRep);

        [TestMethod]
        public void GetAllTours()
        {
            List<Tour> tours = guest.GetAllTours();
            Assert.IsTrue(tours.Count != 0);
        }

        [TestMethod]
        public void GetHotelByName()
        {
            Hotel hotel = guest.GetHotelByName("Goodrich Corporation");
            Assert.IsTrue(hotel.Hotelid == 1);
        }

        [TestMethod]
        public void GetHotelsByType()
        {
            List<Hotel> hotels = guest.GetHotelsByType("Mini");
            Assert.IsTrue(hotels.Count > 0);
        }

        [TestMethod]
        public void GetFoodByBar()
        {
            List<Food> foods = guest.GetFoodByBar(true);
            Assert.IsTrue(foods.Count > 0);
        }

        [TestMethod]
        public void GetBusByLowCost()
        {
            List<Busticket> buses = guest.GetBusByLowCost(9000);
            Assert.IsTrue(buses.Count > 0);
        }
    }
}
