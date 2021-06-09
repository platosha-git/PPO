using System;
using System.Collections.Generic;
using System.Linq;
using Tours.Repositories;

namespace Tours.ImpRepositories
{
    public class TrainRepository : ITrainRepository
    {
        private readonly ToursContext db;

        public TrainRepository(ToursContext createDB)
        {
            db = createDB;
        }

        public List<Trainticket> FindAll()
        {
            return db.Traintickets.ToList();
        }

        public Trainticket FindByID(int id)
        {
            return db.Traintickets.Find(id);
        }

        public void Add(Trainticket obj)
        {
            obj.Traintid = db.Traintickets.Count() + 1;
            db.Traintickets.Add(obj);
            db.SaveChanges();
        }

        public void Update(Trainticket obj)
        {
            db.Traintickets.Update(obj);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            List<Trainticket> allTrainTicket = FindAll();
            db.Traintickets.RemoveRange(allTrainTicket);
            db.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            Trainticket trainTicket = FindByID(id);
            db.Traintickets.Remove(trainTicket);
            db.SaveChanges();
        }

        public List<Trainticket> FindTrainByLowCost(int cost)
        {
            IQueryable<Trainticket> trainTickets = db.Traintickets.Where(needed => needed.Cost <= cost && needed.Traintid > 0);
            return trainTickets.ToList();
        }
    }
}
