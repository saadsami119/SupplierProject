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

        T FirstOrDefault(Func<T, bool> predicate);

        T SingleOrDefault(Func<T, bool> predicate);

        IEnumerable<T> Where(Func<T, bool> predicate);

        void InsertRange(IEnumerable<T> entites);
    }
}
