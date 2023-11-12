using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;

namespace Inivohacks.DAL.Repositories
{
    public class BatchRepository:RepositoryBase<Batch>, IBatchRepository
    {
        public BatchRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AddBatchAsync(Batch batch)
        {
            await AddAsync(batch);
            return true;
        }
    }
}
