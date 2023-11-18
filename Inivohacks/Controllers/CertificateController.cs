using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.Mapper;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inivohacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : Controller
    {
        private readonly ICertificateService _certService;


        public CertificateController(ICertificateService certService)
        {
            _certService = certService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCertificate(CertificateModel viewModel)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            status = await _certService.CreateCertificateAsync(
                MapperExtentions.ToDto<CertificateModel, CertificateDto>(viewModel));

            return Ok();
        }

        [HttpGet("{token}")]
        public async Task<ActionResult<CertificateModel>> CertificateDetailsbyToken(string token)
        {
            var c = await _certService.GetCertificateByTokenAsync(token);
            if (c == null)
            {
                return NotFound();
            }

            return Ok(MapperExtentions.ToViewModel<CertificateDto, CertificateModel>(c));
        }


        [HttpGet("{productId}")]
        public async Task<ActionResult<CertificateModel>> GetAllCertificatesForProduct(int productId)
        {

            List<CertificateModel> results = new List<CertificateModel>();

            IAsyncEnumerable<CertificateDto> certs = _certService.GetCertificatesByProductIdAsync(productId);
            
            if (certs == null)
            {
                return NotFound();
            }
            await foreach (var r in certs)
            {
                results.Add(MapperExtentions.ToViewModel<CertificateDto, CertificateModel>(r));
            }

            return Ok(results);
        }

        //TODO: isValid Cert
    }
}
