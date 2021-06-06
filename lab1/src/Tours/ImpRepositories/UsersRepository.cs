using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tours
{
    class UsersRepository : IUsersRepository
    {
        private readonly ToursContext db;

        public UsersRepository(ToursContext createDB)
        {
            db = createDB;
        }

        public List<User> findAll()
        {
            return db.Users.ToList();
        }

        public User findByID(int id)
        {
            return db.Users.Find(id);
        }

        public void add(User obj)
        {
            obj.Userid = db.Users.Count() + 1;
            db.Users.Add(obj);
            db.SaveChanges();
        }

        public void update(User obj)
        {
            db.Users.Update(obj);
            db.SaveChanges();
        }

        public void deleteAll()
        {
            List<User> allUsers = findAll();
            db.Users.RemoveRange(allUsers);
            db.SaveChanges();
        }

        public void deleteByID(int id)
        {
            User user = findByID(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public List<User> findUsersByAccessLevel(int lvl)
        {
            IQueryable<User> users = db.Users.Where(needed => needed.Accesslevel == lvl);
            return users.ToList();
        }
    }
}
