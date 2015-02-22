using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DbContext;
using Infrastructure.Repository;
using Repository.Context;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IContext dbcontext = null;
        public IDbSet<T> DbSet;

        public Repository(IContext dbContext)
        {
            this.dbcontext = dbContext;
            this.DbSet = this.dbcontext.Set<T>();
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.DbSet.Add(entity);
            this.dbcontext.Entry(entity).State = EntityState.Modified;

            this.dbcontext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.DbSet.Remove(entity);
            this.dbcontext.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.DbSet.AsQueryable<T>();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.dbcontext.SaveChanges();
        }

        public virtual void InsertRange(IEnumerable<T> entites)
        {
            foreach (var entity in entites)
            {
                this.DbSet.Add(entity);
            }
            this.dbcontext.SaveChanges();
        }

        public virtual T FirstOrDefault(Func<T, bool> predicate)
        {  
            return this.DbSet.FirstOrDefault(predicate);
        }

        public virtual T SingleOrDefault(Func<T, bool> predicate)
        {
            return this.DbSet.SingleOrDefault(predicate);
        }

        public virtual IEnumerable<T> Where(Func<T, bool> predicate)
        {
            return this.DbSet.Where(predicate);
        }

    }
}
