﻿using Inivohacks.DAL.Models;

namespace Inivohacks.DAL.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<bool> AddProductAsync(Product product);
        public Task<Product> GetProductbyProductIdAsync(int productId);
        public IAsyncEnumerable<Product> GetAllProductAsync();

        public IAsyncEnumerable<Product> GetAllProductByManufacturerIDAsync(int manufacturerID);
    }
}
