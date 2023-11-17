using Inivohacks.BL.BLServices;
using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
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
        public async Task<IActionResult> CreateUser(UserModel viewModel)
        {
            bool success = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                success = await _userService.CreateUserAsync(
                    MapperExtentions.ToDto<UserModel, UserDto>(viewModel));
                if (success) {
                    return Ok();
                }
                return BadRequest("Could not create user. Ensure the request contains a valid manufacturerID");
            }
            catch(Exception e){
                return BadRequest(string.Format("CreateUser - Could not create user. Error : {0}",e.Message));
            }
        }


        [HttpGet]
        public async Task<ActionResult<UserModel>> GetUser(int userID)
        {
            UserDto userItem = await _userService.GetUserByIDAsync(userID);
            if (userItem == null)
            {
                return NotFound();
            }

            return Ok(MapperExtentions.ToViewModel<UserDto, UserModel>(userItem));

        }
    }
}
