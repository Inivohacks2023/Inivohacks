﻿using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.BLServices
{
    public interface IProductService
    {
        public Task<bool> CreateProductAsync(ProductDto product);
        public Task<ProductDto> GetProductByIDAsync(int productIdString);
        public IAsyncEnumerable<ProductDto> GetAllProductsAsync();

        public IAsyncEnumerable<ProductDto> GetAllProductByManufactureID(int manufactureId);
    }
}
