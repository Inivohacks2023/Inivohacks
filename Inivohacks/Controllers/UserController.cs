using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.Mapper;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inivohacks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> UserCreation(UserModel viewModel)
        {
            bool status = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            status = await _userService.CreateUserAsync(
                MapperExtentions.ToDto<UserModel, UserDto>(viewModel));

            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<UserModel>> UserDetailsById()
        {
            int userID = 0;
            if (Request.Headers.TryGetValue("useId", out var userId))
            {
                userID = Convert.ToInt32(userId);
            }
            var userDetails = await _userService.GetUserByIDAsync(userID);
            if (userDetails == null)
            {
                return NotFound();
            }

            return Ok(MapperExtentions.ToViewModel<UserDto, UserModel>(userDetails));

        }
    }
}
