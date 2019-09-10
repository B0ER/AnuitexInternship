using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Store.DataAccess.AppContext
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(@"Data Source=DESKTOP-RRC378M\SQLEXPRESS;Initial Catalog=Store;Integrated Security=True");
            return new ApplicationDbContext(builder.Options);
        }
    }
}
