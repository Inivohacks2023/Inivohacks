using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;

namespace Inivohacks.DAL.Repositories
{
    public class TrackingCodeRepositoryForScan : RepositoryBase<TrackingCode>, ITrackingCodeRepositoryForScan
    {
        private readonly DatabaseContext _dbContext;
        public TrackingCodeRepositoryForScan(DatabaseContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> AddTrackingCodeAsync(TrackingCode trackingCode)
        {
            await AddAsync(trackingCode);
            return true;
        }

    }
}
