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
        public async Task<IActionResult> ManufacturerCreation(ManufacturerModel viewModel)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            status = await _manufacturerService.CreateManufactureAsync(
                MapperExtentions.ToDto<ManufacturerModel, ManufacturerDto>(viewModel));

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<ManufacturerModel>> ManufacturerList()
        {
            List<ManufacturerModel> manufacturerModelsList = new List<ManufacturerModel>();

            IAsyncEnumerable<ManufacturerDto> manufacturerList = _manufacturerService.GetAllManufacturerAsync();
            if (manufacturerList == null)
            {
                return NotFound();
            }
            await foreach (var m in manufacturerList)
            {
                manufacturerModelsList.Add(MapperExtentions.ToViewModel<ManufacturerDto, ManufacturerModel>(m));
            }

            return Ok(manufacturerModelsList);

        }
    }
}
