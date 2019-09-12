using System.ComponentModel.DataAnnotations;

namespace Store.BussinesLogic.Model.User.Request
{
    public class UserSignInModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
