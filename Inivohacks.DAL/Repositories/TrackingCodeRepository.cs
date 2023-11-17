using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Inivohacks.DAL.Repositories
{
    public class TrackingCodeRepository : RepositoryBase<TrackingCode>, ITrackingCodeRepository
    {
        public TrackingCodeRepository(DatabaseContext dbContex) : base(dbContex)
        {
        }

        public async Task<TrackingCode> AddTrackingCodeAsync(TrackingCode trackingCode)
        {
            return await AddAsync(trackingCode);
        }

        public async Task<bool> AddTrackingCodeBulkAsync(List<TrackingCode> trackingCodes)
        {
            return await AddBulkAsync(trackingCodes);
        }

        public async Task<TrackingCode> GetTrackingCodeByIdAsync(Guid guid)
        {
            return await Search(t => t.TrackingCodeID == guid).FirstOrDefaultAsync();
        }

        public async Task<TrackingCode> UpdateTrackingCodeAsync(TrackingCode trackingCode)
        {
            return await UpdateAsync(trackingCode);
        }
    }
}