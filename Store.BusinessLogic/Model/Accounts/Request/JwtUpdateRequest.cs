using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Model.Accounts.Request
{
    public class JwtUpdateRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}