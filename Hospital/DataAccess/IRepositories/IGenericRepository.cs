namespace DataAccess.IRepositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<TElement>
    {
        IQueryable<TElement> Get();
        IQueryable<TElement> GetByCondition(Expression<Func<TElement, bool>> expression);
        void Delete(TElement element);
        void Create(TElement element);
        void Update(TElement element);
    }
}
