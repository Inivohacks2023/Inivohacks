using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.Mapper;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inivohacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> ProductCreation(ProductModel viewModel)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            status = await _productService.CreateProductAsync(
                MapperExtentions.ToDto<ProductModel, ProductDto>(viewModel));

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<ProductModel>> ProductDetailsbyID()
        {
            int productID = 0;
            if (Request.Headers.TryGetValue("productId", out var productId))
            {
                productID = Convert.ToInt32(productId);
            }
            var productItem = await _productService.GetProductByIDAsync(productID);
            if (productItem == null)
            {
                return NotFound();
            }

            return Ok(MapperExtentions.ToViewModel<ProductDto, ProductModel>(productItem));

        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<ProductModel>> ProductList()
        {

            List<ProductModel> productListmodel = new List<ProductModel>();

            IAsyncEnumerable<ProductDto> productList = _productService.GetAllProductsAsync();
            if (productList == null)
            {
                return NotFound();
            }
            await foreach (var prod in productList)
            {
                productListmodel.Add(MapperExtentions.ToViewModel<ProductDto, ProductModel>(prod));
            }

            return Ok(productListmodel);

        }


        [HttpGet("ByProductId/{manufactureID}")]
        public async Task<ActionResult<ProductModel>> getAllProductbyManufactureID(int manufactureID)
        {

            List<ProductModel> results = new List<ProductModel>();

            IAsyncEnumerable<ProductDto> certs =  _productService.GetAllProductByManufactureID(manufactureID);

            if (certs == null)
            {
                return NotFound();
            }
            await foreach (var r in certs)
            {
                results.Add(MapperExtentions.ToViewModel<ProductDto, ProductModel>(r));
            }

            return Ok(results);
        }
    }
}
