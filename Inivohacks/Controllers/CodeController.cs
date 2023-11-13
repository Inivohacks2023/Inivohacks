using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.Mapper;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inivohacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : Controller
    {
        private readonly ICodeService _codeService;
        public CodeController(ICodeService codeService)
        {
            _codeService = codeService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveCodesAsync(AddCodeRequestModel addCodeRequest)
        {
            _codeService.SaveCustomCodeAsync(MapperExtentions.ToDto<AddCodeRequestModel,CodeDto>(addCodeRequest));
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GenerateCodesAsync(int NoProducts,int ProductId)
        {
            _codeService.GenerateCodeAsync(NoProducts,ProductId);
            return Ok();
        }
    }
}
