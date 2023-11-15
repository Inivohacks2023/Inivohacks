using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Inivohacks.DAL.Repositories
{
    public class ManufacturerRepository : RepositoryBase<Manufacturer>, IManufacturerRepository
    {
        private readonly DatabaseContext _dbContext;
        public ManufacturerRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> AddManufacturerAsync(Manufacturer manufacturer)
        {
            await AddAsync(manufacturer);
            return true;
        }

        //public IAsyncEnumerable<Manufacturer> GetAllManufacturerAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public async IAsyncEnumerable<Manufacturer> GetAllManufacturerAsync()
        {
            foreach (var mlist in _dbContext.Manufacturers.ToList())
            {
                yield return mlist;
            }
          
        }
    }
}
