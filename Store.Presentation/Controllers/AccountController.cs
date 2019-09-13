using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public AccountController(IAccountService accountService, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _accountService = accountService;
            _userManager = userManager;
            _emailSender = emailSender;
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
            var newUser = await _accountService.SignUpAsync(newUserRequest);
            string acceptSignupCode = await _accountService.GetConfirmCodeAsync(newUser);

            string acceptUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = newUser.Id, code = acceptSignupCode },
                        protocol: HttpContext.Request.Scheme);

            await _emailSender.SendEmailAsync(newUser.Email, "SignUp", $"<a href=\"{acceptUrl}\">Accept registration</a>");

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ConfirmEmail(long userId, string code)
        {
            await _accountService.ConfirmEmailAsync(userId, code);
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
            await _accountService.ResetPasswordAsync(user);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AcceptResetPasswordAsync(long userId, string restoreToken, string newPassword)
        {
            await _accountService.AcceptResetPasswordAsync(userId, restoreToken, newPassword);
            return Ok();
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> ChangePasswordAsync(UserChangePasswordModel userChangePasswordRequest)
        {
            var user = await _userManager.GetUserAsync(User);
            await _accountService.ChangePasswordAsync(user, userChangePasswordRequest);
            return Ok();
        }
    }
}