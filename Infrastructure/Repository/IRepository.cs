using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepository<T>
    {
        void Create(T entity);

        void Delete(T entity);

        IQueryable<T> GetAll();

        void Update(T entity);

        void InsertRange(IEnumerable<T> entites);
    }
}
