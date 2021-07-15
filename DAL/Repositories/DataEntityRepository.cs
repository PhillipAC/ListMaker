using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;

namespace DAL.Repositories
{
    public class DataEntityRepository<T> where T : DataEntity
    {
        public List<T> _collection = new List<T>();
        public int _nextId = 0;
        public virtual T GetById(int id)
        {
            return _collection.FirstOrDefault(c => c.Id == id);
        }

        public virtual List<T> GetAll()
        {
            return _collection;
        }

        protected T Create(T entity)
        {
            entity.Id = _nextId++;
            entity.LastModifiedDateTime = DateTime.UtcNow;
            _collection.Add(entity);
            return entity;
        }

        protected T Update(T entity)
        {
            entity.LastModifiedDateTime = DateTime.UtcNow;
            return entity;
        }

        public virtual void Destroy(T entity)
        {
            _collection.Remove(entity);
        }
    }
}