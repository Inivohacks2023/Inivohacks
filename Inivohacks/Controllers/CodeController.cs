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
        public async Task<ActionResult<CodeResponseDto>> SaveCodesAsync([FromBody] AddCodesRequestModel addCodeRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = await _codeService.SaveCustomCodeAsync(MapperExtentions.ToDto<AddCodesRequestModel, CodeDto>(addCodeRequest));
            
            if (res == null)
            {
                return BadRequest();
            }

            return Ok(res);
        }

        [HttpPost]
        [Route("generate")]
        public async Task<IActionResult> GenerateCodesAsync(int noProducts, GenerateCodesRequestModel generateCodesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _codeService.GenerateCodeAsync(noProducts, MapperExtentions.ToDto<GenerateCodesRequestModel, CodeDto>(generateCodesRequest));
            
            if (res == null)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("getcodes")]
        public async Task<IActionResult> GetCodes(int productId, int batchNumber)
        {
            var res = await _codeService.GetCodesByBatch(batchNumber, productId);
            if (res == null)
            {
                return BadRequest();
            }
            return Ok(res);
        }
    }
}