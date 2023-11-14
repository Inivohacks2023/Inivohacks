using Inivohacks.DAL.Models;

namespace Inivohacks.DAL.Repositories
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
       public IAsyncEnumerable<Manufacturer> GetAllManufacturerAsync();
        public Task<bool> AddManufacturerAsync(Manufacturer manufacturer);

    }
}
