using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tours
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ToursContext db;

        public HotelRepository(ToursContext createDB)
        {
            db = createDB;
        }

        public List<Hotel> findAll()
        {
            return db.Hotels.ToList();
        }

        public Hotel findByID(int id)
        {
            return db.Hotels.Find(id);
        }

        public void add(Hotel obj)
        {
            obj.Hotelid = db.Hotels.Count() + 1;
            db.Hotels.Add(obj);
            db.SaveChanges();
        }

        public void update(Hotel obj)
        {
            db.Hotels.Update(obj);
            db.SaveChanges();
        }

        public void deleteAll()
        {
            List<Hotel> allHotels = findAll();
            db.Hotels.RemoveRange(allHotels);
            db.SaveChanges();
        }

        public void deleteByID(int id)
        {
            Hotel hotel = findByID(id);
            db.Hotels.Remove(hotel);
            db.SaveChanges();
        }

        public List<Hotel> findHotelByName(string name)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Name == name);
            return hotels.ToList();
        }

        public List<Hotel> findHotelByType(string type)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Type == type);
            return hotels.ToList();
        }

        public List<Hotel> findHotelByClass(int cls)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Class == cls);
            return hotels.ToList();
        }

        public List<Hotel> findHotelBySwimPool(bool sp)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Swimpool == sp);
            return hotels.ToList();
        }

        public List<Hotel> findHotelByLowCost(int cost)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Cost <= cost);
            return hotels.ToList();
        }
    }
}