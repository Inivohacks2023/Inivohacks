using Inivohacks.DAL.Models;

namespace Inivohacks.DAL.Repositories
{
    public interface ITrackingCodeRepository : IRepository<TrackingCode>
    {
        public Task<TrackingCode> AddTrackingCodeAsync(TrackingCode trackingCode);
        public Task<TrackingCode> GetTrackingCodeByIdAsync(Guid guid);
        public Task<TrackingCode> UpdateTrackingCodeAsync(TrackingCode trackingCode);
    }
}
