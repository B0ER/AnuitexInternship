using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services.Interfaces;
using Store.Presentation.Controllers.Base;
using System.Threading.Tasks;
using Store.BusinessLogic.Model.User.Response;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UserModel>> GetAllAsync()
        {
            UserModel users = await _userService.GetAllAsync();
            return users;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserItemModel>> GetByIdAsync([FromRoute] long userId)
        {
            var user = await _userService.FindByIdAsync(userId);
            return user;
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long userId)
        {
            await _userService.DeleteByIdAsync(userId);
            return Ok();
        }

        [HttpPatch("{userId}/")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long userId)
        {
            return Ok();
        }

        [HttpPost("{userId}/create")]
        public async Task<IActionResult> CreateAsync([FromRoute] long userId)
        {
            return Ok();
        }
    }
}