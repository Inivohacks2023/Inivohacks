using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;

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
                ProductID =product.ProductID,
                ManufactureID = product.ManufacturerID,
                Name = product.Name,
                Dosage = product.Dosage,
                PType = product.PType
            };

            return item;
        }

        public static Product TransformAPItoDAL(this ProductDto product)
        {
            if (product == null)
                return null;

            var item = new Product()
            {
                ManufacturerID = product.ManufactureID,
                Name = product.Name,
                Dosage = product.Dosage,
                PType = product.PType
                

            };

            return item;
        }
    }
}
