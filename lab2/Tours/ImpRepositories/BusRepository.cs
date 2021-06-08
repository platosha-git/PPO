using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tours
{
    public class BusRepository : IBusRepository
    {
        private readonly ToursContext db;

        public BusRepository(ToursContext createDB)
        {
            db = createDB;
        }

        public List<Busticket> FindAll()
        {
            return db.Bustickets.ToList();
        }

        public Busticket FindByID(int id)
        {
            return db.Bustickets.Find(id);
        }

        public void Add(Busticket obj)
        {
            obj.Bustid = db.Bustickets.Count();
            db.Bustickets.Add(obj);
            db.SaveChanges();
        }

        public void Update(Busticket obj)
        {
            db.Bustickets.Update(obj);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            List<Busticket> allBustickets = FindAll();
            db.Bustickets.RemoveRange(allBustickets);
            db.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            Busticket busticket = FindByID(id - 1);
            db.Bustickets.Remove(busticket);
            db.SaveChanges();
        }

        public List<Busticket> FindBusByLowCost(int cost)
        {
            IQueryable<Busticket> busTickets = db.Bustickets.Where(needed => needed.Cost <= cost);
            return busTickets.ToList();
        }
    }
}
