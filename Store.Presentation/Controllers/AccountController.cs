using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Model.Account.Response;
using Store.BusinessLogic.Model.User.Request;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.Presentation.Controllers.Base;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
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

        [HttpPost("sign-in")]
        public async Task<ActionResult<JwtAuthModel>> SignInAsync(UserSignInModel userRequest)
        {
            JwtAuthModel token = await _accountService.SignInAsync(userRequest);
            return token;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUpAsync(UserSignUpModel newUserRequest)
        {
            var newUser = await _accountService.SignUpAsync(newUserRequest);
            string acceptSignupCode = await _accountService.GetConfirmCodeAsync(newUser);

            string acceptUrl = Url.Action(
                        "ConfirmEmailAsync",
                        "Account",
                        new { userId = newUser.Id, code = acceptSignupCode },
                        protocol: HttpContext.Request.Scheme);

            await _emailSender.SendEmailAsync(newUser.Email, "SignUp", $"<a href=\"{acceptUrl}\">Accept registration</a>");

            return Ok();
        }

        [HttpGet("email/confirm")]
        public async Task<IActionResult> ConfirmEmailAsync(long userId, string code)
        {
            await _accountService.ConfirmEmailAsync(userId, code);
            return Ok();
        }

        [Authorize]
        [HttpPost("log-out")]
        public async Task<IActionResult> LogOutAsync()
        {
            await _accountService.LogOutAsync();
            return Ok();
        }

        [HttpPost("password/reset")]
        public async Task<IActionResult> ResetPasswordAsync()
        {
            var user = await _userManager.GetUserAsync(User); //todo: write reset to Anonymous
            await _accountService.ResetPasswordAsync(user);
            return Ok();
        }

        [HttpPost("password/reset/accept")]
        public async Task<IActionResult> AcceptResetPasswordAsync(long userId, string restoreToken, string newPassword)
        {
            await _accountService.AcceptResetPasswordAsync(userId, restoreToken, newPassword);
            return Ok();
        }

        [Authorize]
        [HttpPost("password/change")]
        public async Task<IActionResult> ChangePasswordAsync(UserChangePasswordModel userChangePasswordRequest)
        {
            var user = await _userManager.GetUserAsync(User);
            await _accountService.ChangePasswordAsync(user, userChangePasswordRequest);
            return Ok();
        }
    }
}