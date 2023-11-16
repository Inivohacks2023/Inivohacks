using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.DAL.Repositories
{
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
        private readonly DatabaseContext _dbContext;
        public ProductRepository(DatabaseContext dbContext) : base(dbContext)
        {
            //this._dbContext = dbContext;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            await AddAsync(product);
            return true;
        }

        public async IAsyncEnumerable<Product> GetAllProductAsync()
        {
            foreach (var plist in _dbContext.Products.ToList())
            {
                yield return plist;
            }
        }

        public async Task<Product> GetProductbyProductIdAsync(int productId)
        {
            return Search(a => a.ProductID == productId).FirstOrDefault();
        }
    }
}
