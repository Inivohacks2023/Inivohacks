using Inivohacks.BL.BLServices;
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
        public async Task<IActionResult> SaveCodesAsync()
        {
            _codeService.SaveCustomCodeAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GenerateCodesAsync()
        {
            _codeService.GenerateCodeAsync();
            return Ok();
        }
    }
}
