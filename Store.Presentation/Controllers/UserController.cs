using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services.Interfaces;
using Store.Presentation.Controllers.Base;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Store.BusinessLogic.Model.User.Response;
using Store.DataAccess;

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
        [HttpPatch("{userId}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long userId)
        {
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Roles.Admin)]
        [HttpPost("{userId}/create")]
        public async Task<IActionResult> CreateAsync([FromRoute] long userId)
        {
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