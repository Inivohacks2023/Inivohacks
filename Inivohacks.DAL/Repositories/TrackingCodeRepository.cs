using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;

namespace Inivohacks.DAL.Repositories
{
    public class TrackingCodeRepository : RepositoryBase<TrackingCode>, ITrackingCodeRepository
    {
        public TrackingCodeRepository(DatabaseContext dbContex) : base(dbContex)
        {
        }
    }
}
