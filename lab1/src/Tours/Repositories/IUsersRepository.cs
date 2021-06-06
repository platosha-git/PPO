using System;
using System.Collections.Generic;
using System.Text;

namespace Tours
{
    public interface IUsersRepository : CrudRepository<User, int>
    {
        List<User> FindUsersByAccessLevel(int lvl);
    }
}
