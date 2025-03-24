using Concat.API.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Concat.API.Infraction.Conctret
{
    public class HospitalWorkDbContext : DbContext
    {
        public HospitalWorkDbContext(DbContextOptions<HospitalWorkDbContext> option) : base(option) { }

        public DbSet<HospitalWork> Works { get; set; }

        // MigrationsAssembly belirtilmiş ve connection string eklenmiş
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalWorkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;",
                    options => options.MigrationsAssembly("Concat.Api.Server"));  // Burada doğru assembly belirtildi
            }
        }
    }
}
