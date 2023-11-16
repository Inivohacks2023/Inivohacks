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

        public CodeController(ICodeService userService)
        {
            _codeService = userService;
        }

        [HttpPost]
        [Route("addcodes")]
        public async Task<ActionResult<CodeResponseDto>> SaveCodesAsync([FromBody] AddCodeRequestModel addCodeRequest)
        {
            var res = await _codeService.SaveCustomCodeAsync(MapperExtentions.ToDto<AddCodeRequestModel, CodeDto>(addCodeRequest));
            return Ok(res);
        }

        [HttpGet]
        [Route("generate")]
        public async Task<IActionResult> GenerateCodesAsync(int noProducts, AddCodeRequestModel addCodeRequest)
        {
            var res = await _codeService.GenerateCodeAsync(noProducts, MapperExtentions.ToDto<AddCodeRequestModel, CodeDto>(addCodeRequest));
            return Ok(res);
        }

        [HttpGet]
        [Route("getcodes")]
        public async Task<IActionResult> GetCodes(int productId, int batchNumber)
        {
            var res = await _codeService.GetCodesByBatch(batchNumber, productId);
            return Ok(res);
        }
    }
}