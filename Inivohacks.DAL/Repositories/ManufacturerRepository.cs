using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;

namespace Inivohacks.DAL.Repositories
{
    public class ManufacturerRepository : RepositoryBase<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AddManufacturerAsync(Manufacturer manufacturer)
        {
            await AddAsync(manufacturer);
            return true;
        }
    }
}
