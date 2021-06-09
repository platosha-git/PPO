using System;
using Tours;
using Tours.ComponentsBL;
using Tours.Repositories;
using Tours.ImpRepositories;
using System.Collections.Generic;

namespace TechnologicalUI
{
    class Program
    {
        static void Main(string[] args)
        {
            TechnologicalUI ui = new TechnologicalUI();
            ui.Test();
        }
    }

    public class TechnologicalUI
    {        
        private GuestController guest;
        private TouristController tourist;
        private ManagerController manager;
        private ToursContext db;

        Output outAll = new Output();

        public TechnologicalUI()
        {
            db = new ToursContext(ConfigManager.GetConnectionString(2));

            ITourRepository tourRep = new TourRepository(db);
            IHotelRepository hotelRep = new HotelRepository(db);
            IFoodRepository foodRep = new FoodRepository(db);
            IBusRepository busRep = new BusRepository(db);
            IPlaneRepository planeRep = new PlaneRepository(db);
            ITrainRepository trainRep = new TrainRepository(db);
            IUsersRepository usersRep = new UsersRepository(db);
            IBookingRepository bookingRep = new BookingRepository(db);
            
            guest = new GuestController(tourRep, hotelRep, foodRep, busRep, planeRep, trainRep, bookingRep);
            tourist = new TouristController(tourRep, hotelRep, foodRep, busRep, planeRep, trainRep, bookingRep, usersRep);
            manager = new ManagerController(tourRep, hotelRep, foodRep, busRep, planeRep, trainRep, bookingRep, usersRep);
        }

        public void Test()
        {
            while (true)
            {
                Console.WriteLine("0 - Конец тестирования\n" +
                    "1 - Тестирование гостя\n" +
                    "2 - Тестирование туриста\n" +
                    "3 - Тестирование менеджера\n");

                string testStr = Console.ReadLine();
                int test = Convert.ToInt32(testStr);

                if (test == 0)
                {
                    break;
                }

                switch(test)
                {
                    case 1:
                        TestGuest tGuest = new TestGuest(guest, outAll);
                        tGuest.Test();
                        break;
                    case 2:
                        TestTourist tTourist = new TestTourist(tourist, outAll);
                        tTourist.Test();
                        break;
                    case 3:
                        TestManager tManager = new TestManager(manager, outAll);
                        tManager.Test();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
