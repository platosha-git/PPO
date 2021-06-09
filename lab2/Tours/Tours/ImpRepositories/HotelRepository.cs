using System;
using System.Collections.Generic;
using System.Linq;
using Tours.Repositories;

namespace Tours.ImpRepositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ToursContext db;

        public HotelRepository(ToursContext createDB)
        {
            db = createDB;
        }

        public List<Hotel> FindAll()
        {
            return db.Hotels.ToList();
        }

        public Hotel FindByID(int id)
        {
            return db.Hotels.Find(id);
        }

        public void Add(Hotel obj)
        {
            obj.Hotelid = db.Hotels.Count() + 1;
            db.Hotels.Add(obj);
            db.SaveChanges();
        }

        public void Update(Hotel obj)
        {
            db.Hotels.Update(obj);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            List<Hotel> allHotels = FindAll();
            db.Hotels.RemoveRange(allHotels);
            db.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            Hotel hotel = FindByID(id);
            db.Hotels.Remove(hotel);
            db.SaveChanges();
        }

        public Hotel FindHotelByName(string name)
        {
            IQueryable<Hotel> hotel = db.Hotels.Where(needed => needed.Name == name);
            return hotel.First();
        }

        public List<Hotel> FindHotelByType(string type)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Type == type);
            return hotels.ToList();
        }

        public List<Hotel> FindHotelByClass(int cls)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Class == cls);
            return hotels.ToList();
        }

        public List<Hotel> FindHotelBySwimPool(bool sp)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Swimpool == sp);
            return hotels.ToList();
        }

        public List<Hotel> FindHotelByLowCost(int cost)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Cost <= cost);
            return hotels.ToList();
        }
    }
}