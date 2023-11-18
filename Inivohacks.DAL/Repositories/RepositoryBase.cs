using Inivohacks.DAL.DataContext;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Inivohacks.DAL.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _dbContext;
        public RepositoryBase(DatabaseContext dbContex)
        {
            this._dbContext = dbContex;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
            return entity;

        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            //AssignDate(entity);
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        //private void AssignDate(TEntity entity)
        //{
        //    entity.UpdatedServerDateTimeUTC = DateTime.UtcNow;
        //}

        public IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public async Task<bool> AddBulkAsync(List<TEntity> entities)
        {
            using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.AddRangeAsync(entities);
                    _dbContext.SaveChanges();
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }

    }
}
