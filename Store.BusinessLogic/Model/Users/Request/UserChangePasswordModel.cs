using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Model.Users.Request
{
    public class UserChangePasswordModel
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [Compare("NewPasswordConfirm")]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        public string NewPasswordConfirm { get; set; }
    }
}