using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tours
{
    class TrainRepository
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
            List<Trainticket> allTrainticket = FindAll();
            db.Traintickets.RemoveRange(allTrainticket);
            db.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            Trainticket trainticket = FindByID(id);
            db.Traintickets.Remove(trainticket);
            db.SaveChanges();
        }
    }
}
