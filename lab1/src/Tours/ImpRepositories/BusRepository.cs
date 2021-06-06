using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tours
{
    class BusRepository
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
            obj.Bustid = db.Bustickets.Count() + 1;
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
            Busticket busticket = FindByID(id);
            db.Bustickets.Remove(busticket);
            db.SaveChanges();
        }
    }
}
