using System;
using System.Collections.Generic;
using System.Linq;
using Tours.Repositories;

namespace Tours.ImpRepositories
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly ToursContext db;

        public PlaneRepository(ToursContext createDB)
        {
            db = createDB;
        }

        public List<Planeticket> FindAll()
        {
            return db.Planetickets.ToList();
        }

        public Planeticket FindByID(int id)
        {
            return db.Planetickets.Find(id);
        }

        public void Add(Planeticket obj)
        {
            obj.Planetid = db.Planetickets.Count() + 1;
            db.Planetickets.Add(obj);
            db.SaveChanges();
        }

        public void Update(Planeticket obj)
        {
            db.Planetickets.Update(obj);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            List<Planeticket> allPlanetickets = FindAll();
            db.Planetickets.RemoveRange(allPlanetickets);
            db.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            Planeticket planeticket = FindByID(id);
            db.Planetickets.Remove(planeticket);
            db.SaveChanges();
        }

        public List<Planeticket> FindPlaneByLowCost(int cost)
        {
            IQueryable<Planeticket> planeTickets = db.Planetickets.Where(needed => needed.Cost <= cost && needed.Planetid > 0);
            return planeTickets.ToList();
        }
    }
}
