using Concat.API.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Concat.API.Infraction.Conctret
{
    public class GotTicketDbContext : DbContext
    {
        public GotTicketDbContext(DbContextOptions<GotTicketDbContext> options) : base(options) { }

        public DbSet<GotTicket> GotTicketDbSet { get; set; }

        // MigrationsAssembly belirtilmiş ve connection string eklenmiş
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GotTicketDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;",
                    options => options.MigrationsAssembly("Concat.Api.Server"));  
            }
        }
    }
}
