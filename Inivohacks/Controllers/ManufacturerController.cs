using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.Mapper;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inivohacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : Controller
    {
        private readonly IManufactureService _manufacturerService;

        public ManufacturerController(IManufactureService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }
        [HttpPost]
        public async Task<IActionResult> ManufacturerCreation(ManufacturerRequestModel viewModel)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            status = await _manufacturerService.CreateManufactureAsync(
                MapperExtentions.ToDto<ManufacturerRequestModel, ManufacturerDto>(viewModel));

            return Ok();
        }
    }
}
