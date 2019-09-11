using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;

namespace Store.DataAccess.AppContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, long>
    {
        public DbSet<PrintingEdition> PrintingEditions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AuthorInBook> AuthorInBooks{ get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            BaseSeedData.AddRoles(builder);
        }
    }
}
