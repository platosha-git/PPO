using System;
using System.Collections.Generic;
using System.Text;
using Tours.Repositories;

namespace Tours.ComponentsBL
{
    public class GuestController : UserController
    {
        public GuestController(ITourRepository tourRep, IHotelRepository hotelRep, IFoodRepository foodRep,
                                IBusRepository busRep, IPlaneRepository planeRep, ITrainRepository trainRep,
                                IBookingRepository bookingRep) :
            base(tourRep, hotelRep, foodRep, busRep, planeRep, trainRep, bookingRep)
        {
        }
    }
}
