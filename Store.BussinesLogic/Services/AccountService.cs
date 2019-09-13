using Microsoft.AspNetCore.Identity;
using Store.BussinesLogic.Model.User.Request;
using Store.BussinesLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Store.BussinesLogic.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        private IUserRepository _userRepository;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> SignUpAsync(UserSignUpModel newUserResponse)
        {
            var newUser = new ApplicationUser
            {
                Email = newUserResponse.Email,
                UserName = newUserResponse.Email
            };

            await _userRepository.AddAsync(newUser, newUserResponse.Password);

            return newUser;
        }

        public async Task<string> GetConfirmCodeAsync(ApplicationUser newUser)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            return code;
        }

        public async Task<string> SignInAsync(UserSignInModel userRequest)
        {
            var result = await _signInManager.PasswordSignInAsync(userRequest.Email, userRequest.Password, userRequest.RememberMe, false);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException();
            }

            ApplicationUser user = await _userManager.FindByEmailAsync(userRequest.Email);
            _signInManager.SignInAsync(user, false);

            //todo: add jwt
            return "";
        }

        public async Task ConfirmEmailAsync(long userId, string code)
        {
            var user = await _userRepository.FindByIdAsync(userId);

            var resultConfirm = await _userManager.ConfirmEmailAsync(user, code);

            if (!resultConfirm.Succeeded)
            {
                throw new InvalidOperationException();
            }
        }

        public async Task ChangePasswordAsync(ApplicationUser user, UserChangePasswordModel passwordChangeRequest)
        {
            var result = await _userManager.ChangePasswordAsync(user, passwordChangeRequest.OldPassword, passwordChangeRequest.NewPasswordRepeate);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException();
            }
        }

        public async Task<string> ResetPasswordAsync(ApplicationUser user)
        {
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            return resetToken;
        }

        public async Task AcceptResetPasswordAsync(long userId, string restoreToken, string newPassword)
        {
            var user = await _userRepository.FindByIdAsync(userId);
            var resultRestore = await _userManager.ResetPasswordAsync(user, restoreToken, newPassword);

            if (!resultRestore.Succeeded)
            {
                throw new InvalidOperationException();
            }
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ApplicationUser> GetMeAsync(long userId)
        {
            //todo: add dto
            return await _userRepository.FindByIdAsync(userId);
        }
    }
}
