using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tours
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ToursContext db;

        public UsersRepository(ToursContext createDB)
        {
            db = createDB;
        }

        public List<User> FindAll()
        {
            return db.Users.ToList();
        }

        public User FindByID(int id)
        {
            return db.Users.Find(id);
        }

        public void Add(User obj)
        {
            obj.Userid = db.Users.Count() + 1;
            db.Users.Add(obj);
            db.SaveChanges();
        }

        public void Update(User obj)
        {
            db.Users.Update(obj);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            List<User> allUsers = FindAll();
            db.Users.RemoveRange(allUsers);
            db.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            User user = FindByID(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
