using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Exceptions;
using Store.BusinessLogic.Helpers;
using Store.BusinessLogic.Model.Account.Response;
using Store.BusinessLogic.Model.User.Request;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly JwtManager _jwtManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;

        public AccountService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserRepository userRepository,
            JwtManager jwtManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _jwtManager = jwtManager;
        }

        public async Task<ApplicationUser> SignUpAsync(UserSignUpModel userResponse)
        {
            var newUser = new ApplicationUser
            {
                Email = userResponse.Email,
                UserName = userResponse.Email
            };

            await _userRepository.AddAsync(newUser, userResponse.Password);

            return newUser;
        }

        public async Task<string> GetConfirmCodeAsync(ApplicationUser newUser)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            return code;
        }

        public async Task<JwtAuthModel> SignInAsync(UserSignInModel userRequest)
        {
            var result = await _signInManager.PasswordSignInAsync(userRequest.Email, userRequest.Password,
                userRequest.RememberMe, false);

            if (!result.Succeeded) throw new PasswordInvalidException();

            var user = await _userManager.FindByEmailAsync(userRequest.Email);
            _signInManager.SignInAsync(user, false);

            IEnumerable<string> userRoles = await _userManager.GetRolesAsync(user);

            var tokensResponse = new JwtAuthModel();
            tokensResponse.AccessToken = _jwtManager.GenerateAccessToken(user, userRoles);
            tokensResponse.RefreshToken = _jwtManager.GenerateRefreshToken(user);

            return tokensResponse;
        }

        public async Task ConfirmEmailAsync(long userId, string code)
        {
            var user = await _userRepository.FindByIdAsync(userId);

            var resultConfirm = await _userManager.ConfirmEmailAsync(user, code);

            if (!resultConfirm.Succeeded) throw new EmailCodeInvalidException();
        }

        public async Task ChangePasswordAsync(ApplicationUser user, UserChangePasswordModel passwordChangeRequest)
        {
            var result = await _userManager.ChangePasswordAsync(user, passwordChangeRequest.OldPassword,
                passwordChangeRequest.NewPasswordRepeate);
            if (!result.Succeeded) throw new PasswordInvalidException();
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

            if (!resultRestore.Succeeded) throw new PasswordInvalidException();
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