using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.Helper
{
    public static class ProductTransformations
    {
        public static ProductDto TransformDALtoAPI(this Product product)
        {
            if (product == null)
                return null;

            var item = new ProductDto()
            {
                
            };

            return item;
        }

        public static Product TransformAPItoDAL(this ProductDto product)
        {
            if (product == null)
                return null;

            var item = new Product()
            {
                

            };

            return item;
        }
    }
}
