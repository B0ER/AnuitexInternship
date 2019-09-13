using Store.BussinesLogic.Model.User.Request;
using Store.DataAccess.Entities;
using System.Threading.Tasks;

namespace Store.BussinesLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ApplicationUser> GetMeAsync(long userId);
        Task<ApplicationUser> SignUpAsync(UserSignUpModel newUserResponse);
        Task<string> GetConfirmCodeAsync(ApplicationUser newUser);
        Task<string> SignInAsync(UserSignInModel userRequest);
        Task ConfirmEmailAsync(long userId, string code);
        Task ChangePasswordAsync(ApplicationUser user, UserChangePasswordModel passwordChangeRequest);
        Task<string> ResetPasswordAsync(ApplicationUser user);
        Task AcceptResetPasswordAsync(long userId, string restoreToken, string newPassword);
        Task LogOutAsync();
    }
}
