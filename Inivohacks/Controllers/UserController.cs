using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.Mapper;
using Inivohacks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inivohacks.Controllers
{
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

            status = await _userService.CreateUserAsyncAsync(
                MapperExtentions.ToDto<UserModel, UserDto>(viewModel));

            return Ok();
        }
    }
}
