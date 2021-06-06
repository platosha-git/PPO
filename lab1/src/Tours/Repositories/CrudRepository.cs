using System;
using System.Collections.Generic;
using System.Text;

namespace Tours
{
    public interface CrudRepository<T, ID>
    {
        List<T> findAll();
        T findByID(ID id);
        void add(T obj);
        void update(T obj);
        void deleteAll();
        void deleteByID(ID id);
    }
}
