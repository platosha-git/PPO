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

        public List<Tour> FindAll()
        {
            return db.Tours.ToList();
        }

        public Tour FindByID(int id)
        {
            return db.Tours.Find(id);
        }

        public void Add(Tour obj)
        {
            obj.Tourid = db.Tours.Count() + 1;
            db.Tours.Add(obj);
            db.SaveChanges();
        }

        public void Update(Tour obj)
        {
            db.Tours.Update(obj);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            List<Tour> allTours = FindAll();
            db.Tours.RemoveRange(allTours);
            db.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            Tour tour = FindByID(id);
            db.Tours.Remove(tour);
            db.SaveChanges();
        }

        public List<Tour> FindTourByDate(DateTime b, DateTime e)
        {
            IQueryable<Tour> tours = db.Tours.Where(needed => needed.Datebegin >= b && needed.Dateend <= e);
            return tours.ToList();
        }
    }
}
