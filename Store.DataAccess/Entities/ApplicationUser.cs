using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
    }
}
