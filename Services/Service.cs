using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repository;
using Infrastructure.Service;

namespace Services
{
    public abstract class Service<T> : IService<T> where T : class
    {
        private IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
           
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> SelectQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            _repository.Create(entity);
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdateGraph(T entity)
        {
            throw new NotImplementedException();
        }

        public void InsertGraphRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
