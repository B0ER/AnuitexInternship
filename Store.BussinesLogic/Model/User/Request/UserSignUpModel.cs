﻿using System.ComponentModel.DataAnnotations;

namespace Store.BussinesLogic.Model.User.Request
{
    public class UserSignUpModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password isn't same")]
        public string PasswordRepeat { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
