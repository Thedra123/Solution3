using Concat.API.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Concat.API.Infraction.Conctret
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        // MigrationsAssembly belirtilmiş ve connection string eklenmiş
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UserDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;",
                    options => options.MigrationsAssembly("Concat.Api.Server"));  // Burada doğru assembly belirtildi
            }
        }
    }
}
