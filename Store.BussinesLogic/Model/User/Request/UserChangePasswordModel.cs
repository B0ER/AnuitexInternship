using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.BussinesLogic.Model.User.Request
{
    public class UserChangePasswordModel
    {
        [Required]
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        public string NewPasswordRepeate { get; set; }
    }
}
