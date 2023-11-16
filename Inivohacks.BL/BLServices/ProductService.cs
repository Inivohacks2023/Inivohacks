using Inivohacks.BL.DTOs;
using Inivohacks.BL.Helper;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;

namespace Inivohacks.BL.BLServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<bool> CreateProductAsync(ProductDto product)
        {
            bool status = false;
            if (product == null)
            {
                status = false;
            }
            try
            {
                await productRepository.AddProductAsync(product.TransformAPItoDAL());
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public async IAsyncEnumerable<ProductDto> GetAllProductsAsync()
        {
            IAsyncEnumerable<Product> ProductList = productRepository.GetAllProductAsync();


            await foreach (var prod in ProductList)
            {
                yield return prod.TransformDALtoAPI();
            }
        }

        public async Task<ProductDto> GetProductByIDAsync(int productId)
        {
            if (productId == 0)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            Product product =  await productRepository.GetProductbyProductIdAsync(productId);
            if (product == null)
            {
                return null;
            }

            return product.TransformDALtoAPI();
        }
    }
}
