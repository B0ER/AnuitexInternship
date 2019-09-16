using Microsoft.AspNetCore.Mvc;
using Store.BussinesLogic.Model.User.Response;
using Store.BussinesLogic.Services.Interfaces;
using Store.Presentation.Controllers.Base;
using System.Threading.Tasks;

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
        public async Task<ActionResult<UserModel>> GetAll()
        {
            UserModel users = await _userService.GetAllAsync();
            return users;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserItemModel>> GetById([FromRoute] long userId)
        {
            var user = await _userService.FindByIdAsync(userId);
            return user;
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete([FromRoute] long userId)
        {
            await _userService.DeleteByIdAsync(userId);
            return Ok();
        }

        [HttpPatch("{userId}/[action]")]
        public async Task<IActionResult> Update([FromRoute] long userId)
        {
            return Ok();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Create([FromRoute] long userId)
        {
            return Ok();
        }
    }
}