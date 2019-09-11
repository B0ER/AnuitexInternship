using System.ComponentModel.DataAnnotations;

namespace Store.BussinesLogic.Model.User.Request
{
    public class UserSignUpModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordRepeat { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
