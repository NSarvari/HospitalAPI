namespace DataAccess.Repositories
{
    using DataAccess.IRepositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<TElement> : IGenericRepository<TElement> where TElement : class
    {
        internal ApplicationDbContext Context { get; set; }

        public GenericRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public IQueryable<TElement> Get()
        {
            return Context.Set<TElement>().AsNoTracking();
        }

        public IQueryable<TElement> GetByCondition(Expression<Func<TElement, bool>> expression)
        {
            return Context.Set<TElement>().Where(expression).AsNoTracking();
        }

        public void Create(TElement element)
        {
            Context.Set<TElement>().Add(element);
        }

        public void Delete(TElement element)
        {
            Context.Set<TElement>().Remove(element);
        }

        public void Update(TElement element)
        {
            Context.Set<TElement>().Update(element);
        }
    }
}
