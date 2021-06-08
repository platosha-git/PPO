using System;
using System.Collections.Generic;
using System.Text;
using Tours.Repositories;

namespace Tours.ComponentsBL
{
    public class TouristController : UserController
    {
        protected IUsersRepository usersRepository;
        public TouristController(ITourRepository tourRep, IHotelRepository hotelRep, IFoodRepository foodRep,
                                IBusRepository busRep, IPlaneRepository planeRep, ITrainRepository trainRep,
                                IBookingRepository bookingRep, IUsersRepository usersRep) :
            base(tourRep, hotelRep, foodRep, busRep, planeRep, trainRep, bookingRep)
        {
            usersRepository = usersRep;
        }

        public List<Tour> GetAllBookings(int userID)
        {
            int[] ToursID = bookingRepository.GetBookToursByID(userID);
            
            List<Tour> tours = new List<Tour>();
            for (int i = 0; i < ToursID.Length; i++)
            {
                int curTourID = ToursID[i];
                Tour curTour = tourRepository.FindByID(curTourID);
                tours.Add(curTour);
            }

            return tours;
        }

        public void BookTour(int TourID, int userID)
        {
            Booking bk = bookingRepository.FindByID(userID);
            int[] ToursID = bk.Toursid;
            int size = ToursID.Length;
            
            int[] NToursID = new int[size + 1];
            for (int i = 0; i < size; i++)
            {
                NToursID[i] = ToursID[i];
            }
            NToursID[size] = TourID;

            bk.Toursid = NToursID;
            bookingRepository.Update(bk);
        }

        public void RemoveTour(int TourID, int userID)
        {
            Booking bk = bookingRepository.FindByID(userID);
            int[] ToursID = bk.Toursid;
            int size = ToursID.Length;

            int[] NToursID = new int[size - 1];
            int i = 0, j = 0;
            while (i < size)
            {
                int curTourID = ToursID[i];
                if (curTourID == TourID)
                {
                    i++;
                }
                NToursID[j] = ToursID[i];
                i++; j++;
            }

            bk.Toursid = NToursID;
            bookingRepository.Update(bk);
        }

        public void UpdateSurname(string surname, int userID)
        {
            User user = usersRepository.FindByID(userID);
            user.Surname = surname;
            usersRepository.Update(user);
        }

        public void UpdateYear(int year, int userID)
        {
            User user = usersRepository.FindByID(userID);
            user.Year = year;
            usersRepository.Update(user);
        }
    }
}
