using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.BussinesLogic.Model.User.Request;
using Store.DataAccess.Entities;

namespace Store.BussinesLogic.Services.AccountService
{
    public class AccountService
    {
        //todo: simple crud-operation("createAsync") replace to reepository
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> SignUpAsync(UserSignUpModel newUserResponse)
        {
            var newUser = new ApplicationUser
            {
                Email = newUserResponse.Email,
                UserName = newUserResponse.Email
            };

            var resultReg = await _userManager.CreateAsync(newUser, newUserResponse.Password);

            if (!resultReg.Succeeded)
            {
                throw new InvalidOperationException();
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            return code;
        }

        public async void ConfirmEmail(long userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var resultConfirm = await _userManager.ConfirmEmailAsync(user, code);

            if (!resultConfirm.Succeeded)
            {
                throw new InvalidOperationException();
            }
        }

        public async Task ChangePassword(ApplicationUser user, UserChangePasswordModel passwordChangeRequest)
        {
            var result = await _userManager.ChangePasswordAsync(user, passwordChangeRequest.OldPassword, passwordChangeRequest.NewPasswordRepeate);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException();
            }
        }

        public async Task<string> ResetPassword(ApplicationUser user)
        {
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            return resetToken;
        }

        public async Task AcceptResetPassword(long userId, string restoreToken, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var resultRestore = await _userManager.ResetPasswordAsync(user, restoreToken, newPassword);

            if (!resultRestore.Succeeded)
            {
                throw new InvalidOperationException();
            }
        }


        public async void SignInAsync(UserSignUpModel userResponse)
        {
            var result = await _signInManager.PasswordSignInAsync(userResponse.Email, userResponse.Password, userResponse.RememberMe, false);

            if (result.Succeeded)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(userResponse.Email);
                _signInManager.SignInAsync(user, false);
            }
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
