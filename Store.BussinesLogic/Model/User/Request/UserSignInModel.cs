﻿using System.ComponentModel.DataAnnotations;

namespace Store.BussinesLogic.Model.User.Request
{
    public class UserSignInModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
