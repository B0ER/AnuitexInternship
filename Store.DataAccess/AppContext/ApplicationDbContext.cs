using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using System.Collections.Generic;

namespace Store.DataAccess.AppContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, long>
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DbSet<PrintingEdition> PrintingEditions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AuthorInBook> AuthorInBooks { get; set; }


        internal ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, RoleManager<Role> roleManager, UserManager<ApplicationUser> userManager) : base(options)
        {
            _roleManager = roleManager;
            _userManager = userManager;

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Role>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ApplicationUser>()
                .Property(au => au.Id)
                .ValueGeneratedOnAdd();

            BaseSeedData.AddRoles(_roleManager);
            BaseSeedData.AddAdmins(_userManager);
        }
    }
}
