using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public class Role : IdentityRole<long>
    {
    }
}
