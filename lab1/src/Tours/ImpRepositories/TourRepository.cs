using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tours
{
    class TourRepository : ITourRepository
    {
        private readonly ToursContext db;

        public TourRepository(ToursContext createDB)
        {
            db = createDB;
        }

        public List<Tour> findAll()
        {
            return db.Tours.ToList();
        }

        public Tour findByID(int id)
        {
            return db.Tours.Find(id);
        }

        public void add(Tour obj)
        {
            obj.Tourid = db.Tours.Count() + 1;
            db.Tours.Add(obj);
            db.SaveChanges();
        }

        public void update(Tour obj)
        {
            db.Tours.Update(obj);
            db.SaveChanges();
        }

        public void deleteAll()
        {
            List<Tour> allTours = findAll();
            db.Tours.RemoveRange(allTours);
            db.SaveChanges();
        }

        public void deleteByID(int id)
        {
            Tour tour = findByID(id);
            db.Tours.Remove(tour);
            db.SaveChanges();
        }

        public List<Tour> findTourByDate(DateTime b, DateTime e)
        {
            IQueryable<Tour> tours = db.Tours.Where(needed => needed.Datebegin >= b && needed.Dateend <= e);
            return tours.ToList();
        }
    }
}
