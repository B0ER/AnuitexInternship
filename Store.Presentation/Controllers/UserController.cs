using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess;
using Store.Presentation.Controllers.Base;
using System.Threading.Tasks;
using Store.BusinessLogic.Model.Users.Request;
using Store.BusinessLogic.Model.Users.Response;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Roles.Admin)]
        [HttpGet]
        public async Task<ActionResult<UserModel>> GetAllAsync()
        {
            UserModel users = await _userService.GetAllAsync();
            return users;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Roles.Admin)]
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserItemModel>> GetByIdAsync([FromRoute] long userId)
        {
            var user = await _userService.FindByIdAsync(userId);
            return user;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Roles.Admin)]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long userId)
        {
            await _userService.DeleteByIdAsync(userId);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Roles.Admin)]
        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(UserUpdateRequest userUpdate)
        {
            await _userService.UpdateAsync(userUpdate);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Roles.Admin)]
        [HttpPost("{userId}/create")]
        public async Task<IActionResult> CreateAsync(UserCreateRequest userCreateRequest)
        {
            await _userService.AddAsync(userCreateRequest);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Roles.Admin + ", " + Constants.Roles.User)]
        [HttpGet("profile")]
        public async Task<ActionResult<UserItemModel>> GetProfileAsync()
        {
            var userItem = await _userService.GetProfileAsync(User);
            return userItem;
        }
    }
}