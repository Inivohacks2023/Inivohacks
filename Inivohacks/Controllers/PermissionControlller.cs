using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.Mapper;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inivohacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : Controller
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreation(PermissionModel viewModel)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            status = await _permissionService.CreatePermissionAsync(
                MapperExtentions.ToDto<PermissionModel, PermissionDto>(viewModel));

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionModel>> PermissionDetailsbyID(int id)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            return Ok(MapperExtentions.ToViewModel<PermissionDto, PermissionModel>(permission));

        }
        [HttpGet]
        public async Task<ActionResult<PermissionModel>> Get()
        {

            List<PermissionModel> results = new List<PermissionModel>();

            IAsyncEnumerable<PermissionDto> permissionList = _permissionService.GetAllPermissionsAsync();
            if (permissionList == null)
            {
                return NotFound();
            }
            await foreach (var r in permissionList)
            {
                results.Add(MapperExtentions.ToViewModel<PermissionDto, PermissionModel>(r));
            }

            return Ok(results);

        }
    }
}
