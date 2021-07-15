using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IDataEntityRepository<T>
    {
        T GetById(int id);
        
        List<T> GetAll();
        
        void Destroy(T entity);
    }
}