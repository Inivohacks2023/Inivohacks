using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;

namespace Inivohacks.DAL.Repositories
{
    public class BatchRepository:RepositoryBase<Batch>, IBatchRepository
    {
        private readonly DatabaseContext _dbContext;
        public BatchRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Batch> AddbatchAsync(Batch batch)
        {
            var  returnObj=await AddAsync(batch);
            return returnObj;
        }
    }
}
