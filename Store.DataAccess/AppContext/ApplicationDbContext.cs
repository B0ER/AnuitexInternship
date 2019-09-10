using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;

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
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AuthorInBook>().HasKey(aib => new { aib.AuthorId, aib.PrintingEditionId });

            builder.Entity<AuthorInBook>()
                .HasOne<Author>(aib => aib.Author)
                .WithMany(s => s.AuthorsBooks)
                .HasForeignKey(aib => aib.AuthorId);


            builder.Entity<AuthorInBook>()
                .HasOne<PrintingEdition>(aib => aib.PrintingEdition)
                .WithMany(pe => pe.AuthorsBooks)
                .HasForeignKey(aib => aib.PrintingEditionId);
        }
    }
}
