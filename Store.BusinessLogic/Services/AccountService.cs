using Microsoft.AspNetCore.Identity;
using Store.BusinessLogic.Exceptions;
using Store.BusinessLogic.Helpers;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Store.BusinessLogic.Model.Accounts.Response;
using Store.BusinessLogic.Model.Users.Request;

namespace Store.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly JwtManager _jwtManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserRepository _userRepository;

        public AccountService(SignInManager<ApplicationUser> signInManager,
            IUserRepository userRepository,
            JwtManager jwtManager)
        {
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
            var code = await _signInManager.UserManager.GenerateEmailConfirmationTokenAsync(newUser);
            return code;
        }

        public async Task<JwtAuthModel> SignInAsync(UserSignInModel userRequest)
        {
            var result = await _signInManager.PasswordSignInAsync(userRequest.Email, userRequest.Password,
                userRequest.RememberMe, false);

            if (!result.Succeeded) throw new PasswordInvalidException();

            var user = await _signInManager.UserManager.FindByEmailAsync(userRequest.Email);
            _signInManager.SignInAsync(user, false);

            IEnumerable<string> userRoles = await _signInManager.UserManager.GetRolesAsync(user);

            var tokensResponse = CreateJwtAuthModel(user, userRoles);

            return tokensResponse;
        }

        public async Task ConfirmEmailAsync(long userId, string code)
        {
            var user = await _userRepository.FindByIdAsync(userId);

            var resultConfirm = await _signInManager.UserManager.ConfirmEmailAsync(user, code);

            if (!resultConfirm.Succeeded) throw new EmailCodeInvalidException();
        }

        public async Task ChangePasswordAsync(ApplicationUser user, UserChangePasswordModel passwordChangeRequest)
        {
            var result = await _signInManager.UserManager.ChangePasswordAsync(user, passwordChangeRequest.OldPassword,
                passwordChangeRequest.NewPasswordRepeate);
            if (!result.Succeeded) throw new PasswordInvalidException();
        }

        public async Task<string> ResetPasswordAsync(ApplicationUser user)
        {
            var resetToken = await _signInManager.UserManager.GeneratePasswordResetTokenAsync(user);
            return resetToken;
        }

        public async Task AcceptResetPasswordAsync(long userId, string restoreToken, string newPassword)
        {
            var user = await _userRepository.FindByIdAsync(userId);
            var resultRestore = await _signInManager.UserManager.ResetPasswordAsync(user, restoreToken, newPassword);

            if (!resultRestore.Succeeded) throw new PasswordInvalidException();
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<JwtAuthModel> RefreshTokenAsync(string refreshToken)
        {
            JwtSecurityToken refreshSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(refreshToken);
            var userIdClaim = refreshSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new InvalidOperationException("UserId can't found in claims");
            }

            if (refreshSecurityToken.ValidTo < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Token invalid");
            }

            var user = await _signInManager.UserManager.FindByIdAsync(userIdClaim.Value);
            IEnumerable<string> userRoles = await _signInManager.UserManager.GetRolesAsync(user);
            var jwtAuth = CreateJwtAuthModel(user, userRoles);
            return jwtAuth;
        }

        public async Task<ApplicationUser> GetMeAsync(long userId)
        {
            //todo: add dto
            return await _userRepository.FindByIdAsync(userId);
        }

        private JwtAuthModel CreateJwtAuthModel(ApplicationUser user, IEnumerable<string> userRoles)
        {
            var tokensResponse = new JwtAuthModel
            {
                AccessToken = _jwtManager.GenerateAccessToken(user, userRoles),
                RefreshToken = _jwtManager.GenerateRefreshToken(user)
            };
            return tokensResponse;
        }
    }
}