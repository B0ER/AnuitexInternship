using System.ComponentModel.DataAnnotations;

namespace Store.BusinessLogic.Model.Account.Request
{
    public class JwtUpdateRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}