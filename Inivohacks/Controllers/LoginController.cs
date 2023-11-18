using Inivohacks.DAL.DataContext;
using Inivohacks.DAL.Models;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inivohacks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _dbContext;

        public LoginController(IConfiguration configuration, DatabaseContext context)
        {
            _configuration = configuration;
            _dbContext = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel userLogin)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == userLogin.Username && u.Password == userLogin.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("Username", user.Username),
                new Claim("isManufacturer", user.isManufacturer.ToString()),
                new Claim("isSupplier", user.isSupplier.ToString()),
            };

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
    }
}
