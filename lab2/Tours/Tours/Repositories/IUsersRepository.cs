using System;
using System.Collections.Generic;
using System.Text;

namespace Tours.Repositories
{
    public interface IUsersRepository : CrudRepository<User, int>
    {
    }
}
