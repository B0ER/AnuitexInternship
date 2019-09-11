using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.DataAccess.Entities;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _accouintManager;

        public AccountController(UserManager<ApplicationUser> accouintManager)
        {
            _accouintManager = accouintManager;
        }

        [HttpPost("[action]")]
        public IActionResult SignIn()
        {
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult SignUp()
        {
            return Ok();
        }
    }
}