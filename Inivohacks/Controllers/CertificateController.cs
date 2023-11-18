using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using Inivohacks.Mapper;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inivohacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : Controller
    {
        private readonly ICertificateService _certService;
        private readonly IConfiguration _configuration; 


        public CertificateController(ICertificateService certService, IConfiguration configuration)
        {
            _certService = certService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCertificate(CertificateModel viewModel)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token = GenerateJwtToken(viewModel);
            viewModel.Token = token; 
           
            await _certService.CreateCertificateAsync(
                MapperExtentions.ToDto<CertificateModel, CertificateDto>(viewModel));

            return Ok(token);
        }

        private string GenerateJwtToken(CertificateModel cert)
        {
            List<string> permissionIds = new List<string>();
            Claim[] claims = new[]
            {
                new Claim("ProductId", cert.ProductID.ToString()),
                new Claim("ExpiryDate", cert.ExpiryDate.ToString()),
            };


            foreach (int id in cert.PermissionList) {
                claims = claims.Append(new Claim(id.ToString(), "true")).ToArray();
            }
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpirationInMinutes"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet("ByToken/{token}")]
        public async Task<ActionResult<CertificateModel>> CertificateDetailsbyToken(string token)
        {
            var c = await _certService.GetCertificateByTokenAsync(token);
            if (c == null)
            {
                return NotFound();
            }

            return Ok(MapperExtentions.ToViewModel<CertificateDto, CertificateModel>(c));
        }


        [HttpGet("ByProductId/{productId}")]
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
