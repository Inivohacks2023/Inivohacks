using Inivohacks.BL.DTOs;
using Inivohacks.BL.Helper;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                productRepository.AddProductAsync(product.TransformAPItoDAL());
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
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
