using System;
using System.Collections.Generic;
using System.Text;
using Tours.Repositories;

namespace Tours.ComponentsBL
{
    public class ManagerController : UserController
    {
        protected IUsersRepository usersRepository;
        public ManagerController(ITourRepository tourRep, IHotelRepository hotelRep, IFoodRepository foodRep,
                                IBusRepository busRep, IPlaneRepository planeRep, ITrainRepository trainRep,
                                IBookingRepository bookingRep, IUsersRepository usersRep) :
            base(tourRep, hotelRep, foodRep, busRep, planeRep, trainRep, bookingRep)
        {
            usersRepository = usersRep;
        }

        public List<User> GetAllUsers()
        {
            return usersRepository.FindAll();
        }

        /*--------------------------------------------------------------
         *                          Add
         * -----------------------------------------------------------*/
        public void AddTour(Tour ntour)
        {
            tourRepository.Add(ntour);
        }

        public void AddHotel(Hotel nhotel)
        {
            hotelRepository.Add(nhotel);
        }

        public void AddFood(Food nfood)
        {
            foodRepository.Add(nfood);
        }

        public void AddBus(Busticket nbus)
        {
            busRepository.Add(nbus);
        }

        public void AddPlane(Planeticket nplane)
        {
            planeRepository.Add(nplane);
        }

        public void AddTrain(Trainticket ntrain)
        {
            trainRepository.Add(ntrain);
        }

        /*--------------------------------------------------------------
         *                          Update
         * -----------------------------------------------------------*/
        public void UpdateTour(Tour ntour)
        {
            tourRepository.Update(ntour);
        }

        public void UpdateHotel(Hotel nhotel)
        {
            hotelRepository.Update(nhotel);
        }

        public void UpdateFood(Food nfood)
        {
            foodRepository.Update(nfood);
        }

        public void UpdateBus(Busticket nbus)
        {
            busRepository.Update(nbus);
        }

        public void UpdatePlane(Planeticket nplane)
        {
            planeRepository.Update(nplane);
        }

        public void UpdateTrain(Trainticket ntrain)
        {
            trainRepository.Update(ntrain);
        }

        /*--------------------------------------------------------------
         *                          Delete
         * -----------------------------------------------------------*/
        public void DeleteTourByID(int tourID)
        {
            tourRepository.DeleteByID(tourID);
        }

        public void DeleteHotelByID(int hotelID)
        {
            hotelRepository.DeleteByID(hotelID);
        }

        public void DeleteHotelByName(string name)
        {
            Hotel hotel = hotelRepository.FindHotelByName(name);
            hotelRepository.DeleteByID(hotel.Hotelid);
        }

        public void DeleteFoodByID(int foodID)
        {
            foodRepository.DeleteByID(foodID);
        }

        public void DeleteBusByID(int busID)
        {
            busRepository.DeleteByID(busID);
        }

        public void DeletePlaneByID(int planeID)
        {
            planeRepository.DeleteByID(planeID);
        }

        public void DeleteTrainByID(int trainID)
        {
            trainRepository.DeleteByID(trainID);
        }
    }
}
