using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tours.Repositories;

namespace Tours.ImpRepositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ToursContext db;

        public BookingRepository(ToursContext createDB)
        {
            db = createDB;
        }

        public List<Booking> FindAll()
        {
            return db.Bookings.ToList();
        }

        public Booking FindByID(int id)
        {
            return db.Bookings.Find(id);
        }

        public void Add(Booking obj)
        {
        }

        public void Update(Booking obj)
        {
            db.Bookings.Update(obj);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            List<Booking> allBookings = FindAll();
            db.Bookings.RemoveRange(allBookings);
            db.SaveChanges();
        }

        public void DeleteByID(int id)
        {
        }

        public int[] GetBookToursByID(int id)
        {
            return FindByID(id).Toursid;
        }
    }
}
