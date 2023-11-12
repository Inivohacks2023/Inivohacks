using System.Linq.Expressions;

namespace Inivohacks.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
    }
}
