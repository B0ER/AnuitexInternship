using Microsoft.AspNetCore.Identity;
using Store.BussinesLogic.Model.User.Request;
using Store.DataAccess.Entities;

namespace Store.BussinesLogic.Services.AccountService
{
    public class AccountService
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void SignUp(UserSignUpModel newUserResponse)
        {
            var newUser = new ApplicationUser
            {
                Email = newUserResponse.Email,
                UserName = newUserResponse.Email
            };
            _userManager.CreateAsync(newUser, newUserResponse.Password);
        }

        public async void SignIn(UserSignUpModel userResponse)
        {
            ApplicationUser user = null; //todo: write 'find' from bd

            var result = await _signInManager.PasswordSignInAsync(userResponse.Email, userResponse.Password, userResponse.RememberMe, false);
            if (result.Succeeded)
                _signInManager.SignInAsync(user, false);

            //return RedirectToAction("Index", "Home");
        }
    }
}
