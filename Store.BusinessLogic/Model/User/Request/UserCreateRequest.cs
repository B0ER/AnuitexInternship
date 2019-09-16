using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Model.User.Request
{
    public class UserCreateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("PasswordRepeat", ErrorMessage = "Password isn't same")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password isn't same")]
        public string PasswordRepeat { get; set; }
    }
}