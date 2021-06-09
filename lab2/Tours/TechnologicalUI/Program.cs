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
            ui.Run();
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

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("0 - Выход\n" +
                    "1 - Роль гостя\n" +
                    "2 - Роль туриста\n" +
                    "3 - Роль менеджера\n");

                string testStr = Console.ReadLine();
                int test = Convert.ToInt32(testStr);

                if (test == 0)
                {
                    break;
                }

                switch(test)
                {
                    case 1:
                        GuestRole tGuest = new GuestRole(guest, outAll);
                        tGuest.Play();
                        break;
                    case 2:
                        TouristRole tTourist = new TouristRole(tourist, outAll);
                        tTourist.Play();
                        break;
                    case 3:
                        ManagerRole tManager = new ManagerRole(manager, outAll);
                        tManager.Play();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
