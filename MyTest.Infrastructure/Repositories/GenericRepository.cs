using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyTest.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public virtual T Add(T entity)
        {
            throw new NotImplementedException();
        }
        public virtual IEnumerable<T> All()
        {
            return context.Set<T>()
                .AsQueryable()
                .ToList();
        }
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate).ToList();
        }
        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }
        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
        public virtual T Update(T entity)
        {
            throw new NotImplementedException();
        }      

    }   
}
