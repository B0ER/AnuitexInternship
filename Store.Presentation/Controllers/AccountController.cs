using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.BussinesLogic.Model.User.Request;
using Store.BussinesLogic.Services.Interfaces;
using Store.DataAccess.Entities;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private UserManager<ApplicationUser> _userManager;

        public AccountController(IAccountService accountService, UserManager<ApplicationUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignInAsync(UserSignInModel userRequest)
        {
            //todo: add model with two token
            string token = await _accountService.SignInAsync(userRequest);
            return Ok(token);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignUpAsync(UserSignUpModel newUserRequest)
        {
            string acceptSignupCode = await _accountService.SignUpAsync(newUserRequest);
            //todo: add generate url and send message to email
            /*
            string acceptUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, acceptSignupCode = acceptSignupCode },
                        protocol: HttpContext.Request.Scheme);
            */

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LogOutAsync()
        {
            await _accountService.LogOutAsync();
            return Ok();
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPasswordAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            _accountService.ResetPasswordAsync(user);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AcceptResetPasswordAsync(long userId, string restoreToken, string newPassword)
        {
            _accountService.AcceptResetPasswordAsync(userId, restoreToken, newPassword);
            return Ok();
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> ChangePasswordAsync(UserChangePasswordModel userChangePasswordRequest)
        {
            var user = await _userManager.GetUserAsync(User);
            _accountService.ChangePasswordAsync(user, userChangePasswordRequest);
            return Ok();
        }
    }
}